using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Opc.Hda.Controls;
using Opc.Hda.Controls.Tree;
using OPC.HDA.Lib;
using Opc.Hda.Models;
using Service.Compressing;

namespace Opc.Hda
{
    public partial class ReadDataFromHda : Form
    {
        private volatile bool stopGetData = false;
        private static readonly string[] allowedExtensions= new[] { ".dt" };
        private static readonly string[] allowedXmlExtensions= new[] { ".xml" };
        private bool stopDtDataToSql;

        public ReadDataFromHda()
        {
            InitializeComponent();
        }

        

        private DateTime GetDateEndTS()
        {
            DateTime result = DateTime.Now;
            InvokeTS(()=>result= DateTime.ParseExact(txtDateEnd.Text,"dd.MM.yyyy",null));
            return result;
        }

        private DateTime GetDateStartTS()
        {
            DateTime result = DateTime.Now;
            InvokeTS(()=>result= DateTime.ParseExact(txtDateStart.Text,"dd.MM.yyyy",null));
            return result;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(delegate
            {
                ReadHistoryAsync();
            });
        }

        private T GetInvokeTS<T>(Func<T> operation)
        {
            T result = default;
            InvokeTS(()=>result= operation());
            return result;
        }

        private void InvokeTS(Action operation)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(operation);
            }
            else
            {
                operation();
            }
        }

        private void ReadHistoryAsync()
        {
            try
            {
                int maxRowsInTable = 200000;
                InvokeTS(()=>maxRowsInTable = int.Parse(this.txtMaxRowsInTable.Text));

                stopGetData = false;
                var dateStart = GetDateStartTS();
                var dateEnd = GetDateEndTS();

                var currentDateStart = dateStart;
                int index = 0;
                int count = Convert.ToInt32((dateEnd - dateStart).TotalDays);

                int reconnectServerPeriod = GetInvokeTS(() => Convert.ToInt32(txtReconnectPeriod.Text));

                //var dtTemplate = CreateDtTemplate();


                //var tag = GetInvokeTS(()=>txtTag.Text); //"Bucket Brigade.Real8";
                var maxPoints = GetInvokeTS(()=>Convert.ToInt32(txtMaxPoints.Text));

                var tags = GetInvokeTS(()=>this.richTextBox1.Lines);

                for (var i = 0; i < tags.Length; i++)
                {
                    var tag = tags[i];
                    if (string.IsNullOrWhiteSpace(tag)) continue;
                    tag = tag.Trim();

                    InvokeTS(()=>this.txtTagFromTags.Text = $"{i + 1} из {tags.Length}");

                    WriteTagToDataTableTS(tag, currentDateStart, dateEnd, maxPoints, maxRowsInTable, reconnectServerPeriod, count);

                    if (this.stopGetData)
                    {
                        InvokeTS(()=>MessageBox.Show("Остановлено пользователем."));

                        System.Console.WriteLine("Остановлено пользователем");
                        break;
                    }
                }
            }
            catch (Exception exception)
            {
                System.Console.WriteLine(exception);
            }

            System.Console.WriteLine("Завершена запись тэга...");
        }

        private void WriteTagToDataTableTS(string tag, DateTime dateStart, DateTime dateEnd,
            int maxPoints, int maxRowsInTable, int reconnectServerPeriod, int count)
        {

            var server = GetInvokeTS(()=>this.txtServer.Text);
            var serverName = GetInvokeTS(()=>txtServerSuffix.Text); //"Matrikon.OPC.Simulation.1";

            HdaClient client1 = null;
            static HdaClient GetHdaClient(ref HdaClient clientLocal, int indexLocal, int rebuildPeriod, string serverLocal, string serverNameLocal)
            {
                if (( indexLocal % rebuildPeriod) == 0)//каждые N периодов пересоздаем сервер
                {
                    clientLocal?.Dispose();
                    clientLocal = null;
                }

                if (clientLocal == null)
                {
                    clientLocal = new HdaClient(serverLocal, serverNameLocal);
                    System.Console.WriteLine($"{clientLocal.HdaServer.Host}\t {clientLocal.HdaServer.ServerName} \t Server connected: {clientLocal.HdaServer.Connected}");
                }

                return clientLocal;
            }

            bool noDetails = GetInvokeTS(() => this.cbNoConsoleDetails.Checked);

            InvokeTS(()=>txtTag.Text=tag); //"Bucket Brigade.Real8";
            var dtTag = CreateDtTemplate();
            dtTag.TableName = tag;

            System.Console.WriteLine($"Начало импорта: {tag}");

            var index = 0;
            var currentDateStart = dateStart;
            while (currentDateStart < dateEnd)
            {
                index++;
                var client = GetHdaClient(ref client1, index, reconnectServerPeriod, server, serverName);

                var currentDateEnd = currentDateStart.AddDays(1);

                var readRes = client.ReadRaw(tag, currentDateStart, currentDateEnd, maxPoints, true);

                bool existsData = false;
                //if (readRes?.Count > 0)
                {
                    DateTime? dtcur = null;

                    foreach (var keyValuePair in readRes)
                    {
                        //System.Console.WriteLine($"Key: {keyValuePair.Key}, Value: {keyValuePair.Value}");
                        var date = keyValuePair.Key;
                        if (date < currentDateStart)
                        {
                            dtcur = null;
                            //это историчное, но до даты начала, не пишем - иначе будет много дубликатов
                            continue;
                        }
                        
                        if (date > currentDateEnd)
                        {
                            dtcur = null;
                            //это историчное, но до даты начала, не пишем - иначе будет много дубликатов
                            continue;
                        }

                        if (dtcur != null)
                        {
                            if ((date - dtcur.Value).TotalMinutes < 1)
                            {
                                //пропускаем - пишем раз в минуту
                                continue;
                            }

                            dtcur = date;
                        }
                        else
                        {
                            dtcur = date;
                        }

                        var value = keyValuePair.Value;
                        if (!string.IsNullOrEmpty(value))
                        {
                            existsData = true;

                            dtTag.Rows.Add(date, value);
                        }
                    }

                    if (dtTag.Rows.Count >= maxRowsInTable)
                    {
                        var bytes = Compress.getDTSerializerCompressedDatatable(dtTag);
                        File.WriteAllBytes($"{tag}_{index:0000}.dt", bytes);
                        dtTag.Rows.Clear();
                    }

                    if (!noDetails)
                    {
                        System.Console.WriteLine($"\t\tЗагружено: {index} из {count} ({readRes.FirstOrDefault().Key:s} - {readRes.LastOrDefault().Key:s})");
                    }

                    InvokeTS(()=>
                    {
                        this.progressBar1.Maximum = count;
                        this.progressBar1.Minimum = 0;
                        this.progressBar1.Value = Math.Min(index, count);

                        this.txtDayFromDays.Text = $"\tСохранен {currentDateStart:dd.MM.yyyy} ({index} из {count})";
                    });
                }

                if (!existsData && !noDetails)
                {
                    System.Console.WriteLine($"\tПропущено: {index} из {count} - нет данных ({readRes.FirstOrDefault().Key:s} - {readRes.LastOrDefault().Key:s})");
                }

                currentDateStart = currentDateStart.AddDays(1);

                if (this.stopGetData)
                {
                    System.Console.WriteLine("\tОстановлено пользователем");
                    break;
                }
            }

            if (dtTag.Rows.Count >= 0)
            {
                index++;
                var bytes = Compress.getDTSerializerCompressedDatatable(dtTag);
                File.WriteAllBytes($"{tag}_{index:0000}.dt", bytes);
            }
            System.Console.WriteLine($"Завершен импорт: {tag}");

        }

        private static DataTable CreateDtTemplate()
        {
            DataTable dtTemplate = new DataTable();
            dtTemplate.Columns.Add("Date", typeof(DateTime));
            dtTemplate.Columns.Add("Value", typeof(string));
            return dtTemplate;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.stopGetData = true;
        }

        private void dataGridView1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.IsAllFilesAllowed(allowedExtensions))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void dataGridView1_DragDrop(object sender, DragEventArgs e)
        {
            var fName = e.GetFirstFileFromDragEventArgs();
            this.ShowDataTable(fName);

        }

        private void ShowDataTable(string fName)
        {
            var body = File.ReadAllBytes(fName);
            var dt = Compress.getUncompressedDataTable(body);
            this.dataGridView1.DataSource = dt;
        }

        private void dataGridView1_DragOver(object sender, DragEventArgs e)
        {
            if (e.IsAllFilesAllowed(allowedExtensions))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void textBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.IsAllFilesAllowed(allowedXmlExtensions))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void textBox1_DragDrop(object sender, DragEventArgs e)
        {
            var fName = e.GetFirstFileFromDragEventArgs();
            this.txtTagsFileName.Text = fName;
            var opcTagDefinition = OPCTagDefinition.LoadFromFile(fName);
            var tree = new OPCTagDefinitionTree(opcTagDefinition);
            this.tree.AllocateITreeDataSource(tree, false);
        }

        private void btnFindTagInTree_Click(object sender, EventArgs e)
        {
            TreeNodeAdv FindAdvNode(TreeNodeAdv parentNode, string textNode)
            {
                var nodes = parentNode == null ? this.tree.AllNodes: parentNode.Nodes;
                foreach (var node in nodes)
                {
                    var tag = node.Tag as OPCTagDefinition;
                    if (tag == null) continue;

                    var localName = tag.Name;
                    if (localName == textNode)
                    {
                        return node;
                    }
                }

                return null;
            }

            var tagPats = this.txtSearchTag.Text.Split(new []{'.'},StringSplitOptions.RemoveEmptyEntries);
            tree.CollapseAll();

            TreeNodeAdv currentNode = null;
            try
            {
                foreach (var tagPat in tagPats)
                {
                    var node = FindAdvNode(currentNode, tagPat);
                    if (node == null)
                    {
                        //if (currentNode.Tag is OPCTagDefinition)
                        //this.txtCurrentTag.Text = (currentNode?.Tag as OPCTagDefinition?).ItemName;
                        return;
                    }

                    currentNode = node;
                }

                if (currentNode != null)
                {
                    //обновим найденный тэг - может часть только нашли
                    var tag = currentNode.Tag as OPCTagDefinition;
                    this.txtCurrentTag.Text = tag?.ItemName;

                    //var parent = currentNode;
                    //while (parent.Parent != null)
                    //{
                    //    parent = parent.Parent;
                    //    parent.Expand();
                    //}

                    tree.EnsureVisible(currentNode);
                    tree.SelectedNode = currentNode;
                }
            }
            finally
            {
                
            }
            //this.tree.FindNodeByTag()
        }

        

        private void tree_SelectionChanged(object sender, EventArgs e)
        {
            var tag = this.tree.CurrentNode.Tag as OPCTagDefinition;
            var name = tag.ItemName;
            this.txtCurrentTag.Text = name;
        }

        private void richTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.stopDtDataToSql = false;

            //выбираем папку с экспортированными .dt
            var allDtFiles = Directory.GetFiles(".", "*.dt");
            if (allDtFiles.Length == 0)
            {
                MessageBox.Show("Нет ни одного .dt-файла в папке с программой. Загрузка отменена.");
                return;
            }
            
            if (MessageBox.Show($"Вы точно хотите загрузить в АРМ Геолога информацию из {allDtFiles.Length} .dt-файлов. (!!!Операция вносит изменения в архив - Вы сделали резервную копию базы данных)?",
                    "Загрузка в архив телеметрии АРМ Геолога", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            MessageBox.Show("Информационно. Все успешно загруженные в Архив АРМ Геолог.dt-файлы будут помещены в подпапку: .\\Загруженные");

            ThreadPool.QueueUserWorkItem(delegate {
                ImportDataFromDtToOPCArchive(allDtFiles);
            });
        }

        private void ImportDataFromDtToOPCArchive(string[] allDtFiles)
        {
            //txtCurrentIndex_FromAll_dtFiles
            var connectionString = GetInvokeTS(()=>this.txtSQLConnectionString.Text);
            using var connSql = new SqlConnection(connectionString);
            connSql.Open();


            static int DeleteFromArchive(SqlConnection conn, SqlTransaction trans, string idOpcPoint, DateTime dateStart, DateTime dateEnd)
            {
                using var cmdDeleteFromArchive = conn.CreateCommand();
                if (trans != null) cmdDeleteFromArchive.Transaction = trans;

                cmdDeleteFromArchive.CommandText = $"delete from OPCArchive where idOPCPoint='{idOpcPoint}' and Timestamp>='{dateStart:s}' and Timestamp <= '{dateEnd:s}'";
                var deletedpoints = cmdDeleteFromArchive.ExecuteNonQuery();
                return deletedpoints;
            }

            static string GetIdOpcPoint(SqlConnection conn, string tag)
            {
                using var cmdReadIdOPcPOint = conn.CreateCommand();
                cmdReadIdOPcPOint.CommandText = $"select idOPCPoint from OPCPoint where Tag='{tag}'";
                var idPoint = cmdReadIdOPcPOint.ExecuteScalar();
                if (idPoint == DBNull.Value || idPoint == null)
                {
                    return null;
                }

                var id = ((Guid)idPoint).ToString("B");
                return id;
            }


            int count = allDtFiles.Length;
            StringBuilder log = new StringBuilder();
            try
            {
                for (var i = 0; i < allDtFiles.Length; i++)
                {
                    var dtFile = allDtFiles[i];

                    //(!)
                    var startImportText = "Start import:" + dtFile;
                    log.AppendLine(startImportText);
                    Console.WriteLine(startImportText);

                    var dt = Compress.getUncompressedDataTable(File.ReadAllBytes(dtFile));

                    var tagName = dt.TableName;
                    if (string.IsNullOrEmpty(tagName))
                    {
                        throw new NotSupportedException(
                            $".dt-файл {dtFile} не содержит в названии таблицы имени тэга - удалите данный файл из спсика загружаемых и повторите операцию с оставшимися .dt-файлами.");
                    }

                    var idOpcPoint = GetIdOpcPoint(connSql, tagName);
                    if (idOpcPoint == null)
                    {
                        throw new NotSupportedException(
                            $".dt-файл {dtFile} содержит Тэг ({tagName}), который отсуствует в архиве телеметрии АРМ Геолога. Добавьте тэг в справочник АРМ Геолога и повторите операцию. А пока исключите данный файл из списка к загрузке и повторите операцию с оставшимися .dt-файлами.");
                    }

                    var currentText = $"Загрузка .dt: {i + 1} из {count}";
                    InvokeTS(() => this.txtCurrentIndex_FromAll_dtFiles.Text = currentText);

                    //(!)
                    log.AppendLine(currentText);
                    Console.WriteLine(currentText);

                    if (this.stopDtDataToSql)
                    {
                        InvokeTS(() =>
                            MessageBox.Show(
                                "Загрузка отменена пользователем. Не забудьте переиндексировать таблицу OPCArchive в АРМ Геолога после частичной загрузки данных телеметрии..."));
                        break;
                    }

                    if (dt.Rows.Count == 0)
                    {
                        continue;
                    }

                    //Date=>Timestamp
                    dt.Columns["Date"].ColumnName = "Timestamp";
                    var timestampIndex = dt.Columns.IndexOf("Timestamp");

                    //Value=>Val
                    dt.Columns["Value"].ColumnName = "Val";

                    //Tag=>idOPCPoint
                    dt.Columns.Add("idOPCPoint", typeof(Guid));
                    var idOpcPointIndex = dt.Columns.IndexOf("idOPCPoint");

                    DateTime minDateTime = DateTime.MaxValue;
                    DateTime maxDateTime = DateTime.MinValue;
                    var idOpcPointGuid = new Guid(idOpcPoint);
                    //var idOpcPointGuid = idOpcPoint;
                    foreach (DataRow dtRow in dt.Rows)
                    {
                        dtRow[idOpcPointIndex] = idOpcPointGuid;
                        var date = dtRow[timestampIndex] as DateTime?;
                        if (date == null)
                        {
                            throw new ArgumentNullException("Есть строки без даты. Загрузка прекращена...");
                        }

                        if (minDateTime > date)
                        {
                            minDateTime = date.Value;
                        }

                        if (maxDateTime < date)
                        {
                            maxDateTime = date.Value;
                        }
                    }

                    if (minDateTime == DateTime.MaxValue) throw new ArgumentNullException("Не найдена минимальная дата. Загрузка прекращена...");
                    if (maxDateTime == DateTime.MinValue) throw new ArgumentNullException("Не найдена максимальная дата. Загрузка прекращена...");

                    using (var transaction = connSql.BeginTransaction())
                    {
                        dt.TableName = "OPCArchive";
                        try
                        {

                            //удаляем
                            int deleted = DeleteFromArchive(connSql, transaction, idOpcPoint, minDateTime, maxDateTime);
                            //(!)
                            var deletedTxt = $"Удалено: {deleted} шт. за период {minDateTime:s}-{maxDateTime:s}";
                            log.AppendLine(deletedTxt);
                            Console.WriteLine(deletedTxt);
                            //загружаем
                            using var sbc = new SqlBulkCopy(connSql, SqlBulkCopyOptions.Default, transaction);
                            var columnsS = dt.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToArray();
                            //var columnsSd = columnsS;
                            for (var c = 0; c < columnsS.Length; c++)
                            {
                                var col = columnsS[c];
                                //var colD = columnsSd[i];
                                sbc.ColumnMappings.Add(col, col);
                            }

                            sbc.DestinationTableName = dt.TableName;
                            sbc.WriteToServer(dt);
                            var insertedText = $"Вставлено: {dt.Rows.Count} шт. за период {minDateTime:s}-{maxDateTime:s}";

                            log.AppendLine(insertedText);
                            Console.WriteLine(insertedText);

                            transaction.Commit();
                        }
                        catch (Exception e)
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }

                    var endImportText = "End import:" + dtFile;
                    log.AppendLine(endImportText);
                    Console.WriteLine(endImportText);

                    //переносим файл в загруженные
                    var newPathForImported = Path.Combine(Path.GetDirectoryName(dtFile), "Загруженные", Path.GetFileName(dtFile));
                    var folder = Path.GetDirectoryName(newPathForImported);
                    if (!Directory.Exists(folder))
                    {
                        Directory.CreateDirectory(folder);
                    }

                    File.Move(dtFile, newPathForImported);
                }
            }
            catch (Exception ex)
            {
                InvokeTS(()=>MessageBox.Show("Есть ошибки импорта. Смотрите детали в лог-файле..."));
            }
            finally
            {
                var logPath = $"LogUploadDtFilesToOPCArchive_{DateTime.Now.ToString("s").Replace(":", "_")}.log";
                File.WriteAllText(logPath, log.ToString());
                InvokeTS(() => MessageBox.Show($"Детали по импорту сохранены в лог-файле {logPath}"));
            }
            //if (columnMunit != null)
            //{
            //    columnsS = new string[] {"ObjectId", "ArticleId", "TagName", "ValueTime", "Value", "MUnit"};
            //    columnsSd = new string[] {"ObjectId", "ArticleId", "TagName", "ValueTime", "Value", "MUnit"};
            //}
            //else
            //{
            //columnsS = new string[]dt.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToArray();
            //columnsSd = columnsS;

            InvokeTS(()=>MessageBox.Show("Загрузка завершена. Не забудьте переиндексировать таблицу OPCArchive в АРМ Геолога после загрузки данных телеметрии..."));
        }

        private void btnTestOPC_Click(object sender, EventArgs e)
        {
             try
            {
                var dtStart = GetDateStartTS();//= DateTime.Now;
                var dtEnd = GetDateEndTS();//= DateTime.Now;
                
                int maxPoints = 100;
                InvokeTS(()=>maxPoints=Convert.ToInt32(txtMaxPoints.Text));
                string server = GetInvokeTS(()=>this.txtServer.Text);
                var serverName = GetInvokeTS(()=>txtServerSuffix.Text);//"Matrikon.OPC.Simulation.1";

                using var client = new HdaClient(server, serverName);

                System.Console.WriteLine($"{client.HdaServer.Host}");
                System.Console.WriteLine($"{client.HdaServer.ServerName}");
                System.Console.WriteLine($"сервер подключен: {client.HdaServer.Connected}");

                if (client.HdaServer.Connected)
                {
                    this.btnTestOPC.BackColor = Color.LawnGreen;
                    this.btnTestOPC.Text = "OK";
                }
                else
                {
                    this.btnTestOPC.Text = "Oшибка";
                    this.btnTestOPC.BackColor = Color.IndianRed;
                }

                System.Console.WriteLine("Доступные сервера: ");
                try
                {
                    foreach (var availableServer in HdaUtils.GetAvailableServers(server))
                    {
                        System.Console.WriteLine(availableServer.ServerName);
                    }
                }
                catch (Exception exception)
                {
                    System.Console.WriteLine("Ошибка получения списка серверов:"+exception);
                }

                System.Console.WriteLine();

                var tag = GetInvokeTS(() => richTextBox1.Lines.FirstOrDefault() ?? "АСУТП.SHU_3T.AI.GPS3T_AI_PG_V_KOLL.XVXX");//"Bucket Brigade.Real8";
                System.Console.WriteLine($"Чтение тэга {tag} из {client.HdaServer.Url}:");
           
                var readRes = client.ReadRaw(tag, dtStart , dtEnd, maxPoints);

                foreach (var keyValuePair in readRes)
                {
                    System.Console.WriteLine($"Дата: {keyValuePair.Key}, Значение: {keyValuePair.Value}");
                }
            }
            catch (Exception exception)
            {
                System.Console.WriteLine(exception);
                this.btnTestOPC.Text = "Oшибка";
                this.btnTestOPC.BackColor = Color.IndianRed;
            }

            System.Console.WriteLine("Завершено чтение...");
        }

        private void btnTestSqlServer_Click(object sender, EventArgs e)
        {
            try
            {
                using var conn = new SqlConnection(this.txtSQLConnectionString.Text);
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "select 1";
                cmd.ExecuteScalar();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Успешное подключение к Архиву телеметрии АРМ Геолога.");
                Console.ResetColor();
                this.btnTestSqlServer.BackColor = Color.LawnGreen;
            }
            catch (Exception exception)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Ошибка подключения к архиву телеметрии АРМ Геолога:\r\n"+exception);
                Console.ResetColor();
                this.btnTestSqlServer.BackColor = Color.IndianRed;
            }
        }

        private void btnStopDtToSql_Click(object sender, EventArgs e)
        {
            this.stopDtDataToSql = true;
        }
    }
}

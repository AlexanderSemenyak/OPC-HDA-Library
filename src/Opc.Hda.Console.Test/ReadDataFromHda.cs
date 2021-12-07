using System;
using System.Data;
using System.IO;
using System.Linq;
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

        public ReadDataFromHda()
        {
            InitializeComponent();
        }

        private void btnReadTag_Click(object sender, EventArgs e)
        {
            try
            {
                var dtStart = GetDateStartTS();//= DateTime.Now;
                var dtEnd = GetDateEndTS();//= DateTime.Now;
                
                int maxPoints = 100000;
                InvokeTS(()=>maxPoints=Convert.ToInt32(txtMaxPoints.Text));

                string server = GetInvokeTS(()=>this.txtServer.Text);

                var serverName = GetInvokeTS(()=>txtServerSuffix.Text);//"Matrikon.OPC.Simulation.1";

                var client = new HdaClient(server, serverName);
                System.Console.WriteLine($"{client.HdaServer.Host}");
                System.Console.WriteLine($"{client.HdaServer.ServerName}");
                System.Console.WriteLine($"Server connected: {client.HdaServer.Connected}");

                System.Console.WriteLine();
                //var node = client.Browse();
                //System.Console.WriteLine("Browse: ");
                //System.Console.WriteLine(node + Environment.NewLine);
                System.Console.WriteLine("Available servers: ");
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

                var tag = GetInvokeTS(()=>txtTag.Text);//"Bucket Brigade.Real8";
                System.Console.WriteLine($"Rading tag {tag} from {client.HdaServer.Url}:");
           
                var readRes = client.ReadRaw(tag, dtStart , dtEnd, maxPoints);

                foreach (var keyValuePair in readRes)
                {
                    System.Console.WriteLine($"Key: {keyValuePair.Key}, Value: {keyValuePair.Value}");
                }
            }
            catch (Exception exception)
            {
                System.Console.WriteLine(exception);
            }

            System.Console.WriteLine("Завершено чтение...");
            //System.Console.Read();
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
                        existsData = true;
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
                            dtTag.Rows.Add(date, value);
                        }
                    }

                    if (dtTag.Rows.Count >= maxRowsInTable)
                    {
                        var bytes = Compress.getDTSerializerCompressedDatatable(dtTag);
                        File.WriteAllBytes($"{tag}_{index:0000}.dt", bytes);
                        dtTag.Rows.Clear();
                    }

                    System.Console.WriteLine($"\t\tЗагружено: {index} из {count} ({readRes.FirstOrDefault().Key:s} - {readRes.LastOrDefault().Key:s})");
                    InvokeTS(()=>
                    {
                        this.progressBar1.Maximum = count;
                        this.progressBar1.Minimum = 0;
                        this.progressBar1.Value = Math.Min(index, count);

                        this.txtDayFromDays.Text = $"\tСохранен {currentDateStart:dd.MM.yyyy} ({index} из {count})";
                    });
                }

                if (!existsData)
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
    }
}

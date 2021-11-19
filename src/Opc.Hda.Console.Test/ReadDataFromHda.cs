using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OPC.HDA.Lib;
using Service.Compressing;

namespace Opc.Hda.Console.Test
{
    public partial class ReadDataFromHda : Form
    {
        private volatile bool stopGetData = false;
        public ReadDataFromHda()
        {
            InitializeComponent();
        }

        private void btnReadTag_Click(object sender, EventArgs e)
        {
            try
            {
                var dtStart = GetDateStart();//= DateTime.Now;
                var dtEnd = GetDateEnd();//= DateTime.Now;
                var maxPoints = Convert.ToInt32(txtMaxPoints.Text);
                var server = this.txtServer.Text;
                var serverName = txtServerSuffix.Text;//"Matrikon.OPC.Simulation.1";
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
                var tag = txtTag.Text;//"Bucket Brigade.Real8";
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

        private DateTime GetDateEnd()
        {
            return DateTime.ParseExact(txtDateEnd.Text,"dd.MM.yyyy",null);
        }

        private DateTime GetDateStart()
        {
            return DateTime.ParseExact(txtDateStart.Text,"dd.MM.yyyy",null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
            stopGetData = false;
            var dateStart = GetDateStart();
            var dateEnd = GetDateEnd();
            var currentDateStart = dateStart;
            int index = 0;
            int count = Convert.ToInt32((dateEnd - dateStart).TotalDays);

            DataTable dtTemplate = new DataTable();
            dtTemplate.Columns.Add("Date", typeof(DateTime));
            dtTemplate.Columns.Add("Value", typeof(string));

            var server = this.txtServer.Text;
            var serverName = txtServerSuffix.Text;//"Matrikon.OPC.Simulation.1";
            var client = new HdaClient(server, serverName);
            System.Console.WriteLine($"{client.HdaServer.Host}");
            System.Console.WriteLine($"{client.HdaServer.ServerName}");
            System.Console.WriteLine($"Server connected: {client.HdaServer.Connected}");

            var tag = txtTag.Text;//"Bucket Brigade.Real8";
            var maxPoints = Convert.ToInt32(txtMaxPoints.Text);


            while (currentDateStart < dateEnd)
            {
                index++;

                var currentDateEnd = currentDateStart.AddDays(1);
           
                var readRes = client.ReadRaw(tag, currentDateStart , currentDateEnd, maxPoints);

                if (readRes?.Count > 0)
                {
                    var dtTag = dtTemplate.Clone();
                    dtTag.TableName = tag;

                    foreach (var keyValuePair in readRes)
                    {
                        //System.Console.WriteLine($"Key: {keyValuePair.Key}, Value: {keyValuePair.Value}");
                        var date = keyValuePair.Key;
                        var value = keyValuePair.Value;
                        dtTag.Rows.Add(date, value);
                    }

                    var bytes = Compress.getDTSerializerCompressedDatatable(dtTag);
                    File.WriteAllBytes($"{tag}_{index:0000}.dt", bytes);

                    System.Console.WriteLine($"Сохранено: {index} из {count} ({readRes.FirstOrDefault().Key:s} - {readRes.LastOrDefault().Key:s})");
                }
                else
                {
                    System.Console.WriteLine($"Пропущено: {index} из {count} - нет данных ({readRes.FirstOrDefault().Key:s} - {readRes.LastOrDefault().Key:s})");

                }

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

        private void button2_Click(object sender, EventArgs e)
        {
            this.stopGetData = true;
        }
    }
}

using System;
using System.Windows.Forms;
using OPC.HDA.Lib;

namespace Opc.Hda.Console.Test
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ReadDataFromHda());
            //var server = "localhost";
            //var client = new HdaClient(server, "Matrikon.OPC.Simulation.1");
            //System.Console.WriteLine($"{client.HdaServer.Host}");
            //System.Console.WriteLine($"{client.HdaServer.ServerName}");
            //System.Console.WriteLine($"Server connected: {client.HdaServer.Connected}");

            //System.Console.WriteLine();
            ////var node = client.Browse();
            ////System.Console.WriteLine("Browse: ");
            ////System.Console.WriteLine(node + Environment.NewLine);
            //System.Console.WriteLine("Available servers: ");
            //foreach (var availableServer in HdaUtils.GetAvailableServers(server))
            //{
            //    System.Console.WriteLine(availableServer.ServerName);
            //}

            //System.Console.WriteLine();
            //var tag = "Bucket Brigade.Real8";
            //System.Console.WriteLine($"Rading tag {tag} from {client.HdaServer.Url}:");
            //var dt = DateTime.Now;
            //var readRes = client.ReadRaw(tag, dt - TimeSpan.FromDays(2), dt);



            //foreach (var keyValuePair in readRes)
            //{
            //    System.Console.WriteLine($"Key: {keyValuePair.Key}, Value: {keyValuePair.Value}");
            //}

            //System.Console.WriteLine("Завершено чтение, нажмите любую клавишу...");
            //System.Console.Read();
        }
    }
}

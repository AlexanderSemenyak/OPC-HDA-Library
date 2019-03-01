using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OPC.HDA.Lib;

namespace OPC.HDA.Win.UI.Test
{
    public class Test
    {
        public static void Main()
        {
            var client = new HdaClient("localhost", "Advosol.HDA.Net4.Test.6");
            client.AddItemIdentifier("Data.Ramp");
            var res = client.ReadRaw("Data.Ramp", DateTime.MinValue, DateTime.MaxValue);
            var brw = client.Browse("Data");
            Console.WriteLine("dupa");
        }
    }
}
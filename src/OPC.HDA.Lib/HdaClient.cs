using System;
using System.Collections.Generic;

namespace OPC.HDA.Lib
{

    public class HdaClient
    {
        public readonly HdaServer HdaServer;
        
        public HdaClient(string host, string serverName)
        {
            HdaServer = new HdaServer(host, serverName);
            HdaServer.Connect();
        }

        public IList<KeyValuePair<DateTime, string>> ReadRaw(string tag, DateTime startTime, DateTime endTime, int? maxValues = null, bool includeBounds = false)
        {
            return HdaServer.ReadRaw(tag, startTime, endTime, maxValues, includeBounds);
        }

        public HdaBrowseNode Browse(string address = null)
        {
            return HdaServer.Browse(address);
        }
    }
}

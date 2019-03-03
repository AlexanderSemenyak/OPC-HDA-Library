using System;
using System.Collections.Generic;
using Opc;

namespace OPC.HDA.Lib
{
    public static class HdaUtils
    {
        public static IList<HdaServer> GetAvailableServers(string host)
        {
            var opcServers = new OpcCom.ServerEnumerator().GetAvailableServers(Specification.COM_HDA_10, String.IsNullOrWhiteSpace(host) ? "localhost" : host, null);
            var servers = new List<HdaServer>();
            foreach (var opcServer in opcServers)
            {
                servers.Add(new HdaServer(host, opcServer.Name));
            }

            return servers;
        }
    }
}

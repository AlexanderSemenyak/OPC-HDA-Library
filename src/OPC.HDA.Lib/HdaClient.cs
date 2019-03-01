using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using Opc;
using Opc.Ae;
using Opc.Hda;

namespace OPC.HDA.Lib
{
    public class HdaClient
    {
        private Opc.Hda.Server _hdaServer = null;
        private ItemIdentifier[] Identifiers { get; set; }
        private IBrowser _browser;
        
        public HdaClient(string host, string serverName)
        {
            try
            {
                _hdaServer = new Opc.Hda.Server(new OpcCom.Factory(), new URL($"opchda://{host}/{serverName}"));
                _hdaServer.Connect();

                _browser = _hdaServer.CreateBrowser(null, out _);
            }
            catch (ConnectFailedException ex)
            {
                Console.WriteLine(ex.ToString());
                throw ex;
            }
        }

        public void AddItemIdentifier(string identifier)
        {
            if (_hdaServer != null)
            {
                var identifiers = new[] { new ItemIdentifier(identifier) };
                _hdaServer.CreateItems(identifiers);
                _hdaServer.ValidateItems(identifiers);
                Identifiers = new ItemIdentifier[_hdaServer.Items.Count];
                _hdaServer.Items.CopyTo(Identifiers, 0);
            }
        }

        public IList<KeyValuePair<DateTime, string>> ReadRaw(string identifier, DateTime startTime, DateTime endTime, int? maxValues = null, bool includeBounds = false)
        {
            var response = new List<KeyValuePair<DateTime, string>>();
            var readResult = _hdaServer.ReadRaw(new Time(startTime), new Time(endTime), maxValues ?? int.MaxValue, includeBounds, Identifiers);
            
            foreach (var itemValueCollection in readResult)
            {
                foreach (Opc.Hda.ItemValue itemValue in itemValueCollection)
                {
                    response.Add(new KeyValuePair<DateTime, string>(itemValue.Timestamp, itemValue.Value == null ? "" : itemValue.ToString() ));
                }
            }
            
            return response;
        }

        public HdaBrowseNode Browse(string address)
        {
            var browseElements = _browser.Browse(new ItemIdentifier(String.IsNullOrWhiteSpace(address) ? null : address));
            var root = new HdaBrowseNode { Address = String.IsNullOrEmpty(address) ? "" : address, Name = String.IsNullOrEmpty(address) ? "Root" : address, Root = true, HasChildren = browseElements.Length > 0 };
            this.GetNodes(root, browseElements);
            return root;
        }

        public void GetNodes(HdaBrowseNode node, Opc.Hda.BrowseElement[] browseElements)
        {
            foreach (var browseElement in browseElements)
            {
                node.Nodes.Add(new HdaBrowseNode { Address = browseElement.ItemName, Item = browseElement.IsItem, Name = browseElement.Name, HasChildren = browseElement.HasChildren, OpcBrowseElement = browseElement });
            }

            foreach (var hdaBrowseNode in node.Nodes.Where(x => x.HasChildren).ToList())
            {
                var elements = _browser.Browse(new ItemIdentifier(hdaBrowseNode.Address));
                GetNodes(hdaBrowseNode, elements);
            }
        }
    }
}

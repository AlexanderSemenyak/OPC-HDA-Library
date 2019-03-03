using System;
using System.Collections.Generic;
using System.Linq;
using Opc;
using Opc.Hda;
using ItemIdentifier = Opc.ItemIdentifier;
using Server = Opc.Hda.Server;
using ServerState = Opc.Hda.ServerState;

namespace OPC.HDA.Lib
{
    public class HdaServer
    {
        private Server _opcHdaServer = null;
        private IBrowser _browser;

        public string Host { get; private set; }
        public string ServerName { get; private set; }
        public string Url => $"opchda://{Host}/{ServerName}";

        public bool Connected
        {
            get
            {
                if (_opcHdaServer == null) return false;

                var status = _opcHdaServer.GetStatus();
                return status.ServerState == ServerState.Up;
            }
        }

        internal HdaServer(string host, string serverName)
        {
            Host = host;
            ServerName = serverName;
            _opcHdaServer = new Server(new OpcCom.Factory(), new URL(Url));
        }

        internal void Connect()
        {
            try
            {
                _opcHdaServer.Connect();
                _browser = _opcHdaServer.CreateBrowser(null, out _);
            }
            catch (Exception ex)
            {
                //TODO: Exception handling
                throw ex;
            }
        }

        private ItemIdentifier[] HandleItemIdentifiers(string identifier)
        {
            if (_opcHdaServer == null) return new[] { new ItemIdentifier() };

            var identifiers = new[] { new ItemIdentifier(identifier) };
            _opcHdaServer.CreateItems(identifiers);
            _opcHdaServer.ValidateItems(identifiers);
            identifiers = new ItemIdentifier[_opcHdaServer.Items.Count];
            _opcHdaServer.Items.CopyTo(identifiers, 0);
            return identifiers;
        }

        internal IList<KeyValuePair<DateTime, string>> ReadRaw(string identifier, DateTime startTime, DateTime endTime, int? maxValues = null, bool includeBounds = false)
        {
            var response = new List<KeyValuePair<DateTime, string>>();

            var readResult = _opcHdaServer.ReadRaw(new Time(startTime), new Time(endTime), maxValues ?? int.MaxValue, includeBounds, HandleItemIdentifiers(identifier));

            foreach (var itemValueCollection in readResult)
            {
                foreach (ItemValue itemValue in itemValueCollection)
                {
                    response.Add(new KeyValuePair<DateTime, string>(itemValue.Timestamp, itemValue.Value == null ? "" : itemValue.Value.ToString()));
                }
            }

            return response;
        }

        internal HdaBrowseNode Browse(string address)
        {
            var browseElements = _browser.Browse(new ItemIdentifier(string.IsNullOrWhiteSpace(address) ? null : address));
            var root = new HdaBrowseNode { Tag = string.IsNullOrEmpty(address) ? "" : address, Name = string.IsNullOrEmpty(address) ? "Root" : address, Root = true, HasChildren = browseElements.Length > 0 };
            this.GetNodes(root, browseElements);
            return root;
        }

        private void GetNodes(HdaBrowseNode node, BrowseElement[] browseElements)
        {
            foreach (var browseElement in browseElements)
            {
                node.Nodes.Add(new HdaBrowseNode { Tag = browseElement.ItemName, Item = browseElement.IsItem, Name = browseElement.Name, HasChildren = browseElement.HasChildren, OpcBrowseElement = browseElement });
            }

            foreach (var hdaBrowseNode in node.Nodes.Where(x => x.HasChildren).ToList())
            {
                var elements = _browser.Browse(new ItemIdentifier(hdaBrowseNode.Tag));
                GetNodes(hdaBrowseNode, elements);
            }
        }
    }
}

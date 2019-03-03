using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Opc.Hda;

namespace OPC.HDA.Lib
{
    public class HdaBrowseNode
    {
        public string Name { get; set; }
        public string Tag { get; set; }
        public bool Root { get; set; } = false;
        public bool Item { get; set; } = false;
        public List<HdaBrowseNode>  Nodes { get; set; } = new List<HdaBrowseNode>();
        public bool HasChildren { get; internal set; }
        internal BrowseElement OpcBrowseElement { get; set; }
        
        private string GetNodes(HdaBrowseNode node, int level)
        {
            Func<string, int, string> repeat = (str, count) =>
            {
                var res = "";
                for (var i = 0; i < count; i++) res += str;
                return res;
            };
            var sb = new StringBuilder();
            sb.AppendLine(repeat("   ", level) + $"Name: {node.Name}, Address: {node.Tag}, IsItem: {node.Item}");

            foreach (var hdaBrowseNode in node.Nodes)
            {
                sb.Append(GetNodes(hdaBrowseNode, level + 1));
            }
            return sb.ToString();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(GetNodes(this, 0));
            return sb.ToString();
        }
    }
}

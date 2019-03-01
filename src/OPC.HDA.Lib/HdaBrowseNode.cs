using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Opc.Hda;

namespace OPC.HDA.Lib
{
    public class HdaBrowseNode
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public bool Root { get; set; } = false;
        public bool Item { get; set; } = false;
        public List<HdaBrowseNode>  Nodes { get; set; } = new List<HdaBrowseNode>();
        public bool HasChildren { get; internal set; }
        internal BrowseElement OpcBrowseElement { get; set; }
    }
}

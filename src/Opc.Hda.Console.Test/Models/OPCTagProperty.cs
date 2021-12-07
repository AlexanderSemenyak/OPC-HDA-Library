using System;
using System.Xml.Serialization;

namespace Opc.Hda.Models
{
        [Serializable]
        public partial class OPCTagProperty
        {
            [XmlAttribute]
            public int IDCode { get; set; }

            [XmlAttribute]
            public string IDName { get; set; }

            [XmlAttribute]
            public string E { get; set; }

            [XmlAttribute]
            public string V { get; set; }

            [XmlAttribute]
            public string Path { get; set; }

            [XmlAttribute]
            public string ItemName { get; set; }

            [XmlAttribute]
            public string D { get; set; }

            [XmlAttribute]
            public string T { get; set; }
        }
}

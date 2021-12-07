using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Opc.Hda.Models
{
    [Serializable]
        [XmlInclude(typeof(OPCTagProperty))]
        public class OPCTagDefinition
        {

            [XmlAttribute]
            public string Name { get; set; }

            [XmlAttribute]
            public string Path { get; set; }

            [XmlAttribute]
            public string D { get; set; }

            public List<OPCTagDefinition> C { get; set; } = new List<OPCTagDefinition>();
            public List<OPCTagProperty> Props { get; set; } = new List<OPCTagProperty>();

            /// <summary>
            /// Читаем из коллекции свойств значение тэга
            /// </summary>
            public string PropValue => this.Props.FirstOrDefault(x => string.Equals(x.IDName, "value", StringComparison.InvariantCultureIgnoreCase))?.V;

            [XmlAttribute]
            public string ItemName { get; set; }

            public string PropDescription => this.Props.FirstOrDefault(x => string.Equals(x.IDName, "description", StringComparison.InvariantCultureIgnoreCase))?.V;

            public string SaveToString()
            {
                var sb = new StringBuilder();
                using (var sw1 = new StringWriter(sb))
                {
                    XmlSerializer xs = new XmlSerializer(typeof(OPCTagDefinition));
                    xs.Serialize(sw1, this);
                }

                return sb.ToString();
            }

            public void SaveToFile(string fName)
            {
                using (var sw1 = new StreamWriter(fName, false))
                {
                    XmlSerializer xs = new XmlSerializer(typeof(OPCTagDefinition));
                    xs.Serialize(sw1, this);
                }
            }

            public static OPCTagDefinition LoadFromFile(string fName)
            {
                using (var sw1 = new StreamReader(fName))
                {
                    XmlSerializer xs = new XmlSerializer(typeof(OPCTagDefinition));
                    return (OPCTagDefinition)xs.Deserialize(sw1);
                }
            }

            public Dictionary<string, OPCTagDefinition> ToDictionary()
            {
                var result = new Dictionary<string, OPCTagDefinition>();

                void AddToCache(OPCTagDefinition arg1, OPCTagDefinition parent)
                {
                    if (parent != null && (arg1.C == null || arg1.C.Count == 0))
                    {
                        result[parent.ItemName] = parent;
                    }

                    if (arg1 != null && !string.IsNullOrWhiteSpace(arg1.ItemName))
                    {
                        result[arg1.ItemName] = arg1;
                    }
                }

                Fond.TreeDataSource.HelperRecur.Instance.RecurDoOperation(this, arg => arg.C, AddToCache, null);
                return result;
            }
        }
}

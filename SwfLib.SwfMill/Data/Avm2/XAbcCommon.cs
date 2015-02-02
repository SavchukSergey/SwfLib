using System.Collections.Generic;
using System.Xml.Linq;
using SwfLib.Avm2;

namespace SwfLib.SwfMill.Data.Avm2 {
    public static class XAbcCommon {
        
        public static string ToXml(this AbcMultiname multiname) {
            if (multiname is AbcMultinameVoid) return "";
            if (multiname is AbcMultinameAny) return "*";
            return multiname.ToString();
        }

        public static XElement ToXml(this IEnumerable<AbcTrait> traits) {
            var res = new XElement("traits");
            foreach (var trait in traits) {
                res.Add(trait.ToXml());
            }
            return res;
        }

        public static string ToXml(this AbcConstant value) {
            return value.ToString(); //todo:
        }

        public static XElement ToXml(this IEnumerable<AbcMetadata> metas) {
            var res = new XElement("metas");
            foreach (var meta in metas) {
                res.Add(meta.ToXml());
            }
            return res;
        }

        public static XElement ToXml(this AbcMetadata meta) {
            var res = new XElement("meta", new XAttribute("name", meta.Name));
            if (meta.Items.Count > 0) {
                var xItems = new XElement("items");
                foreach (var item in meta.Items) {
                    xItems.Add(new XElement("item", new XAttribute("key", item.Key), new XAttribute("value", item.Value)));
                }
                res.Add(xItems);
            }
            return res;
        }

    }
}

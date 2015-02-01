using System.Xml.Linq;
using SwfLib.Avm2;
using SwfLib.Avm2.Data;

namespace SwfLib.SwfMill.Data.Avm2 {
    public static class XAbcFile {

        public const string TAG_NAME = "abcFile";

        public static XElement ToXml(AbcFileInfo abcInfo) {
            var abc = AbcFile.From(abcInfo);
            var res = new XElement(TAG_NAME,
                new XAttribute("minorVersion", abc.MinorVersion),
                new XAttribute("majorVersion", abc.MajorVersion)
            );

            if (abc.Metadata.Count > 0) {
                var xMeta = new XElement("meta");
                foreach (var meta in abc.Metadata) {
                    xMeta.Add(ToXml(meta));
                }
                res.Add(xMeta);
            }
            if (abc.Classes.Count > 0) {
                var xClasses = new XElement("classes");
                foreach (var cls in abc.Classes) {
                    xClasses.Add(cls.ToXml());
                }
                res.Add(xClasses);
            }

            if (abc.Scripts.Count > 0) {
                var xScripts = new XElement("scripts");
                foreach (var script in abc.Scripts) {
                    xScripts.Add(ToXml(script));
                }
                res.Add(xScripts);
            }

            if (abc.Methods.Count > 0) {
                var xMethods = new XElement("methods");
                foreach (var method in abc.Methods) {
                    xMethods.Add(method.ToXml());
                }
                res.Add(xMethods);
            }

            return res;
        }

        private static XElement ToXml(AbcMetadata meta) {
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

        private static XElement ToXml(AbcScript script) {
            var res = new XElement("script");
            if (script.Traits.Count > 0) {
                res.Add(script.Traits.ToXml());
            }
            //todo: script initializer
            return res;
        }

    }
}

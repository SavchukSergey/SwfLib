using System.Xml.Linq;
using SwfLib.Avm2;

namespace SwfLib.SwfMill.Data.Avm2 {
    public static class XAbcClass {

        public static XElement ToXml(this AbcClass cls) {
            var res = new XElement("class");
            res.Add(cls.Instance.ToXml());

            if (cls.Traits.Count > 0) {
                res.Add(cls.Traits.ToXml());
            }
            return res;
        }

        private static XElement ToXml(this AbcInstance instance) {
            var xInstance = new XElement("instance");
            xInstance.Add(new XAttribute("name", instance.Name.ToXml()));
            if (instance.SuperName != null && instance.SuperName != AbcMultiname.Void) {
                xInstance.Add(new XAttribute("extends", instance.SuperName.ToXml()));
            }
            if (instance.Traits.Count > 0) {
                xInstance.Add(instance.Traits.ToXml());
            }

            if (instance.Interfaces.Count > 0) {
                var xInterfaces = new XElement("implements");
                foreach (var inter in instance.Interfaces) {
                    xInterfaces.Add(new XElement("interface", inter));
                }
                xInstance.Add(xInterfaces);
            }

            return xInstance;
        }
    }
}

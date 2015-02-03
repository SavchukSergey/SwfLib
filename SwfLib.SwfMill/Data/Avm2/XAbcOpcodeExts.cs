using System.Xml.Linq;
using SwfLib.Avm2;

namespace SwfLib.SwfMill.Data.Avm2 {

    public static class XAbcOpcodeExts {

        public static XElement AddRegister(this XElement node, uint register) {
            node.Add(new XAttribute("reg", register));
            return node;
        }

        public static XElement AddArgsCount(this XElement node, uint args) {
            node.Add(new XAttribute("args", args));
            return node;
        }

        public static XElement AddName(this XElement node, AbcMultiname multiname) {
            node.Add(new XAttribute("name", multiname.ToXml()));
            return node;
        }
    }
}

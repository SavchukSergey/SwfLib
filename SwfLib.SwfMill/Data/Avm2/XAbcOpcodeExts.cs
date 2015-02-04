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
        
        public static XElement AddMethod(this XElement node, AbcMethod method) {
            node.Add(new XAttribute("method", method.Name));
            return node;
        }

        public static XElement AddSlotIndex(this XElement node, uint slotIndex) {
            node.Add(new XAttribute("slotIndex", slotIndex));
            return node;
        } 

    }
}

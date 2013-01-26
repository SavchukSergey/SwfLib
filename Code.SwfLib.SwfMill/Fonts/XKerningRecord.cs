using System.Xml.Linq;
using Code.SwfLib.Fonts;

namespace Code.SwfLib.SwfMill.Fonts {
    public static class XKerningRecord {

        public static XElement ToXml(KerningRecord record) {
            return new XElement("WideKerning",
                new XAttribute("a", record.LeftCode),
                new XAttribute("b", record.RightCode),
                new XAttribute("adjustment", record.Adjustment));
        }
    }
}

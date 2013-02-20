using System.Xml.Linq;
using Code.SwfLib.Fonts;
using Code.SwfLib.SwfMill.Utils;

namespace Code.SwfLib.SwfMill.Fonts {
    public static class XKerningRecord {

        public static KerningRecord FromXml(XElement xRecord) {
            return new KerningRecord {
                LeftCode = xRecord.RequiredUShortAttribute("a"),
                RightCode = xRecord.RequiredUShortAttribute("b"),
                Adjustment = xRecord.RequiredShortAttribute("adjustment"),
            };
        }

        public static XElement ToXml(KerningRecord record) {
            return new XElement("WideKerning",
                new XAttribute("a", record.LeftCode),
                new XAttribute("b", record.RightCode),
                new XAttribute("adjustment", record.Adjustment));
        }
    }
}

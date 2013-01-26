using System.Xml.Linq;
using Code.SwfLib.Fonts;

namespace Code.SwfLib.SwfMill.Fonts {
    public static class XKerningRecord {

        public static KerningRecord FromXml(XElement xRecord) {
            var xLeft = xRecord.Attribute("a");
            var xRight = xRecord.Attribute("b");
            var xAdjustment = xRecord.Attribute("adjustment");
            return new KerningRecord {
                LeftCode = ushort.Parse(xLeft.Value),
                RightCode = ushort.Parse(xRight.Value),
                Adjustment = short.Parse(xAdjustment.Value)
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

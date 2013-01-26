using System.Xml.Linq;
using Code.SwfLib.Fonts;
using Code.SwfLib.SwfMill.Data;

namespace Code.SwfLib.SwfMill.Fonts {
    public static class XZoneData {

        public static XElement ToXml(ZoneData data) {
            return new XElement("ZoneData",
                new XAttribute("position", CommonFormatter.Format(data.Position)),
                new XAttribute("size", CommonFormatter.Format(data.Size))
            );
        }
    }
}

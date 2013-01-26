using System.Xml.Linq;
using Code.SwfLib.Fonts;
using Code.SwfLib.Tags.FontTags;

namespace Code.SwfLib.SwfMill.Fonts {
    public static class XZoneRecord {

        public static XElement ToXml(ZoneRecord zoneRecord) {
            var res = new XElement("ZoneArray",
                new XAttribute("zoneX", zoneRecord.ZoneX ? "1" : "0"),
                new XAttribute("zoneY", zoneRecord.ZoneY ? "1" : "0")
            );
            
            var xZones = new XElement("zones");
            foreach (var data in zoneRecord.Data) {
                xZones.Add(XZoneData.ToXml(data));
            }
            res.Add(xZones);

            if (zoneRecord.Reserved > 0) {
                res.Add(new XAttribute("reserved", zoneRecord.Reserved));
            }
            return res;
        }
    }
}

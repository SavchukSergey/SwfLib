using System.Xml.Linq;
using Code.SwfLib.Fonts;
using Code.SwfLib.SwfMill.Data;
using SwfLib.SwfMill.Data;
using SwfLib.SwfMill.Utils;

namespace Code.SwfLib.SwfMill.Fonts {
    public static class XZoneRecord {

        public static ZoneRecord FromXml(XElement xZoneRecord) {
            var zoneArray = new ZoneRecord();
            var xZoneX = xZoneRecord.Attribute("zoneX");
            var xZoneY = xZoneRecord.Attribute("zoneY");
            var xReserved = xZoneRecord.Attribute("reserved");
            zoneArray.ZoneX = CommonFormatter.ParseBool(xZoneX.Value);
            zoneArray.ZoneY = CommonFormatter.ParseBool(xZoneY.Value);
            if (xReserved != null) {
                zoneArray.Reserved = byte.Parse(xReserved.Value);
            }

            foreach (var xZoneData in xZoneRecord.RequiredElement("zones").Elements()) {
                zoneArray.Data.Add(XZoneData.FromXml(xZoneData));
            }
            return zoneArray;
        }

        public static XElement ToXml(ZoneRecord zoneRecord) {
            var res = new XElement("ZoneArray",
                new XAttribute("zoneX", CommonFormatter.Format(zoneRecord.ZoneX)),
                new XAttribute("zoneY", CommonFormatter.Format(zoneRecord.ZoneY))
            );
            if (zoneRecord.Reserved != 0) {
                res.Add(new XAttribute("reserved", zoneRecord.Reserved));
            }

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

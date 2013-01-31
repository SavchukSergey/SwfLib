using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Code.SwfLib.Fonts;
using Code.SwfLib.SwfMill.Fonts;
using Code.SwfLib.Tags.FontTags;

namespace Code.SwfLib.SwfMill.TagFormatting.FontTags {
    public class DefineFontAlignZonesTagFormatter : DefineFontBaseFormatter<DefineFontAlignZonesTag> {

        private const string CSM_HINT_ATTRIB = "csmTableHint";

        private const string ZONE_ARRAYS_ELEM = "zoneArrays";
        private const string ZONE_ARRAY_ELEM = "ZoneArray";
        private const string ZONE_X_ATTRIB = "zoneX";
        private const string ZONE_Y_ATTRIB = "zoneY";

        private const string ZONES_ELEM = "zones";
        private const string ZONE_DATA_ELEM = "ZoneData";

        protected override bool AcceptTagAttribute(DefineFontAlignZonesTag tag, XAttribute attrib) {
            switch (attrib.Name.LocalName) {
                case CSM_HINT_ATTRIB:
                    tag.CsmTableHint = (CSMTableHint)(byte.Parse(attrib.Value));
                    break;
                case "reserved":
                    tag.Reserved = byte.Parse(attrib.Value);
                    break;
                default:
                    return false;
            }
            return true;
        }

        protected override bool AcceptTagElement(DefineFontAlignZonesTag tag, XElement element) {
            switch (element.Name.LocalName) {
                case ZONE_ARRAYS_ELEM:
                    foreach (var record in ParseZoneArrays(element)) {
                        tag.ZoneTable.Add(record);
                    }
                    break;
                default:
                    return false;
            }
            return true;
        }

        protected override void FormatTagElement(DefineFontAlignZonesTag tag, XElement xTag) {
            xTag.Add(new XAttribute(CSM_HINT_ATTRIB, (byte)tag.CsmTableHint));
            if (tag.Reserved > 0) {
                xTag.Add(new XAttribute("reserved", tag.Reserved));
            }
            var xZoneArrays = new XElement("zoneArrays");
            foreach (var record in tag.ZoneTable) {
                xZoneArrays.Add(XZoneRecord.ToXml(record));
            }
            xTag.Add(xZoneArrays);
        }


        private ZoneRecord[] ParseZoneArrays(XElement xZoneArrays) {
            var res = new List<ZoneRecord>();
            foreach (var element in xZoneArrays.Elements()) {
                switch (element.Name.LocalName) {
                    case ZONE_ARRAY_ELEM:
                        res.Add(ParseZoneArray(element));
                        break;
                    default:
                        throw new FormatException("Invalid element " + element.Name.LocalName);
                }
            }
            return res.ToArray();
        }


        private ZoneRecord ParseZoneArray(XElement xZoneArray) {
            var zoneArray = new ZoneRecord();
            foreach (var attrib in xZoneArray.Attributes()) {
                switch (attrib.Name.LocalName) {
                    case ZONE_X_ATTRIB:
                        zoneArray.ZoneX = ParseBoolFromDigit(attrib);
                        break;
                    case ZONE_Y_ATTRIB:
                        zoneArray.ZoneY = ParseBoolFromDigit(attrib);
                        break;
                    default:
                        throw new FormatException("Invalid attribute " + attrib.Name.LocalName);
                }
            }
            foreach (var element in xZoneArray.Elements()) {
                switch (element.Name.LocalName) {
                    case ZONES_ELEM:
                        zoneArray.Data = ParseZoneDataArray(element);
                        break;
                    default:
                        throw new FormatException("Invalid element " + element.Name.LocalName);
                }
            }
            return zoneArray;
        }


        private ZoneData[] ParseZoneDataArray(XElement xZoneDataArray) {
            var res = new List<ZoneData>();
            foreach (var element in xZoneDataArray.Elements()) {
                switch (element.Name.LocalName) {
                    case ZONE_DATA_ELEM:
                        res.Add(XZoneData.FromXml(element));
                        break;
                    default:
                        throw new FormatException("Invalid element " + element.Name.LocalName);
                }
            }
            return res.ToArray(); ;
        }



        public override string TagName {
            get { return "DefineFontAlignZones"; }
        }

    }
}
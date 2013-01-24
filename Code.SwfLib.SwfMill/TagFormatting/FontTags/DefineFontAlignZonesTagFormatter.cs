using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
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
        private const string POSITION_ATTRIB = "position";
        private const string SIZE_ATTRIB = "size";

        protected override void AcceptTagAttribute(DefineFontAlignZonesTag tag, XAttribute attrib) {
            switch (attrib.Name.LocalName) {
                case CSM_HINT_ATTRIB:
                    tag.CsmTableHint = (byte)(byte.Parse(attrib.Value) << 6);
                    break;
                default:
                    throw new FormatException("Invalid attribute " + attrib.Name.LocalName);
            }
        }

        protected override void AcceptTagElement(DefineFontAlignZonesTag tag, XElement element) {
            switch (element.Name.LocalName) {
                case ZONE_ARRAYS_ELEM:
                    tag.Zones = ParseZoneArrays(element);
                    break;
                default:
                    throw new FormatException("Invalid element " + element.Name.LocalName);
            }
        }

        protected override XElement FormatTagElement(DefineFontAlignZonesTag tag, XElement xTag) {
            xTag.Add(new XAttribute(CSM_HINT_ATTRIB, tag.CsmTableHint >> 6));
            xTag.Add(FormatZoneArrays(tag.Zones));
            //TODO: reserved flags
            return xTag;
        }


        protected virtual XElement FormatZoneArrays(SwfZoneArray[] array) {
            return new XElement(ZONE_ARRAYS_ELEM, array.Select(FormatZoneArray));
        }

        protected virtual SwfZoneArray[] ParseZoneArrays(XElement xZoneArrays) {
            var res = new List<SwfZoneArray>();
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


        protected virtual XElement FormatZoneArray(SwfZoneArray array) {
            return new XElement(ZONE_ARRAY_ELEM,
                new XAttribute(ZONE_X_ATTRIB, FormatBoolToDigit(array.ZoneX)),
                new XAttribute(ZONE_Y_ATTRIB, FormatBoolToDigit(array.ZoneY)),
                FormatZoneDataArray(array.Data)
                );
        }

        protected virtual SwfZoneArray ParseZoneArray(XElement xZoneArray) {
            var zoneArray = new SwfZoneArray();
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


        protected virtual XElement FormatZoneDataArray(SwfZoneData[] zoneDataArray) {
            return new XElement(ZONES_ELEM, zoneDataArray.Select(FormatZoneData));
        }

        protected virtual SwfZoneData[] ParseZoneDataArray(XElement xZoneDataArray) {
            var res = new List<SwfZoneData>();
            foreach (var element in xZoneDataArray.Elements()) {
                switch (element.Name.LocalName) {
                    case ZONE_DATA_ELEM:
                        res.Add(ParseZoneData(element));
                        break;
                    default:
                        throw new FormatException("Invalid element " + element.Name.LocalName);
                }
            }
            return res.ToArray(); ;
        }


        protected virtual XElement FormatZoneData(SwfZoneData data) {
            return new XElement(ZONE_DATA_ELEM,
                new XAttribute(POSITION_ATTRIB, FormatFloat(data.Position)),
                new XAttribute(SIZE_ATTRIB, FormatFloat(data.Size))
                );
        }

        protected virtual SwfZoneData ParseZoneData(XElement xZoneData) {
            var res = new SwfZoneData();
            foreach (var attrib in xZoneData.Attributes()) {
                switch (attrib.Name.LocalName) {
                    case POSITION_ATTRIB:
                        //TODO: parse float to base class
                        res.Position = double.Parse(attrib.Value);
                        break;
                    case SIZE_ATTRIB:
                        //TODO: parse float to base class
                        res.Size = double.Parse(attrib.Value);
                        break;
                    default:
                        throw new FormatException("Invalid attribute " + attrib.Name.LocalName);
                }
            }
            return res;
        }

        public override string TagName {
            get { return "DefineFontAlignZones"; }
        }

    }
}
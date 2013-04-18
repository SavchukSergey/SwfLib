using System.Xml.Linq;
using SwfLib.Fonts;
using SwfLib.SwfMill.Fonts;
using SwfLib.Tags.FontTags;

namespace SwfLib.SwfMill.TagFormatting.FontTags {
    public class DefineFontAlignZonesTagFormatter : DefineFontBaseFormatter<DefineFontAlignZonesTag> {

        private const string CSM_HINT_ATTRIB = "csmTableHint";

        private const string ZONE_ARRAYS_ELEM = "zoneArrays";

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
                    foreach (var xZoneArray in element.Elements()) {
                        tag.ZoneTable.Add(XZoneRecord.FromXml(xZoneArray));
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

        /// <summary>
        /// Gets xml element name.
        /// </summary>
        public override string TagName {
            get { return "DefineFontAlignZones"; }
        }

    }
}
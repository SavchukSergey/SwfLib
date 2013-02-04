using System;
using System.Globalization;
using System.Xml.Linq;
using Code.SwfLib.SwfMill.Data;
using Code.SwfLib.Tags.TextTags;

namespace Code.SwfLib.SwfMill.TagFormatting.TextTags {
    public class CSMTextSettingsTagFormatter : TagFormatterBase<CSMTextSettingsTag> {

        private const string USE_FLASH_TYPE_ATTRIB = "useFlashType";
        private const string GRID_FIT = "gridFit";
        private const string THICKNESS = "thickness";
        private const string SHARPNESS = "sharpness";

        protected override bool AcceptTagAttribute(CSMTextSettingsTag tag, XAttribute attrib) {
            switch (attrib.Name.LocalName) {
                case USE_FLASH_TYPE_ATTRIB:
                    tag.UseFlashType = byte.Parse(attrib.Value);
                    break;
                case GRID_FIT:
                    tag.GridFit = byte.Parse(attrib.Value);
                    break;
                case "reservedFlags":
                    tag.ReservedFlags = byte.Parse(attrib.Value);
                    break;
                case THICKNESS:
                    tag.Thickness = float.Parse(attrib.Value, CultureInfo.InvariantCulture);
                    break;
                case SHARPNESS:
                    tag.Sharpness = float.Parse(attrib.Value, CultureInfo.InvariantCulture);
                    break;
                case "reserved":
                    tag.Reserved = byte.Parse(attrib.Value);
                    break;
                default:
                    return false;
            }
            return true;
        }

        protected override void FormatTagElement(CSMTextSettingsTag tag, XElement xTag) {
            xTag.Add(new XAttribute(XName.Get("useFlashType"), tag.UseFlashType));
            xTag.Add(new XAttribute(XName.Get("gridFit"), tag.GridFit));

            if (tag.ReservedFlags != 0) {
                xTag.Add(new XAttribute("reservedFlags", tag.ReservedFlags));
            }
            xTag.Add(new XAttribute(XName.Get("thickness"), CommonFormatter.Format(tag.Thickness)));
            xTag.Add(new XAttribute(XName.Get("sharpness"), CommonFormatter.Format(tag.Sharpness)));
            if (tag.Reserved != 0) {
                xTag.Add(new XAttribute("reserved", tag.ReservedFlags));
            }
        }

        public override string TagName {
            get { return "CSMTextSettings"; }
        }

        protected override ushort? GetObjectID(CSMTextSettingsTag tag) {
            return tag.TextID;
        }

        protected override void SetObjectID(CSMTextSettingsTag tag, ushort value) {
            tag.TextID = value;
        }
    }
}
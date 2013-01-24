using System;
using System.Globalization;
using System.Xml.Linq;
using Code.SwfLib.Tags.TextTags;

namespace Code.SwfLib.SwfMill.TagFormatting.TextTags {
    public class CSMTextSettingsTagFormatter : TagFormatterBase<CSMTextSettingsTag> {

        private const string USE_FLASH_TYPE_ATTRIB = "useFlashType";
        private const string GRID_FIT = "gridFit";
        private const string THICKNESS = "thickness";
        private const string SHARPNESS = "sharpness";

        protected override void AcceptTagAttribute(CSMTextSettingsTag tag, XAttribute attrib) {
            switch (attrib.Name.LocalName) {
                case USE_FLASH_TYPE_ATTRIB:
                    tag.UseFlashType = byte.Parse(attrib.Value);
                    break;
                case GRID_FIT:
                    tag.GridFit = byte.Parse(attrib.Value);
                    break;
                case THICKNESS:
                    tag.Thickness = float.Parse(attrib.Value, CultureInfo.InvariantCulture);
                    break;
                case SHARPNESS:
                    tag.Sharpness = float.Parse(attrib.Value, CultureInfo.InvariantCulture);
                    break;
                default:
                    throw new FormatException("Invalid attribute " + attrib.Name.LocalName);
            }
        }

        protected override void AcceptTagElement(CSMTextSettingsTag tag, XElement element) {
            switch (element.Name.LocalName) {
                default:
                    throw new FormatException("Invalid element " + element.Name.LocalName);
            }
        }

        protected override XElement FormatTagElement(CSMTextSettingsTag tag, XElement xTag) {
            xTag.Add(new XAttribute(XName.Get("useFlashType"), tag.UseFlashType));
            xTag.Add(new XAttribute(XName.Get("gridFit"), tag.GridFit));

            //TODO: reserved flagss
            //new XAttribute(XName.Get("reservedFlags"), tag.ReservedFlags),
            xTag.Add(new XAttribute(XName.Get("thickness"), tag.Thickness.ToString(CultureInfo.InvariantCulture)));
            xTag.Add(new XAttribute(XName.Get("sharpness"), tag.Sharpness.ToString(CultureInfo.InvariantCulture)));
            //TODO: hide reserved attr
            //new XAttribute(XName.Get("reserved"), tag.Reserved)
            return xTag;
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
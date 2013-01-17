using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Code.SwfLib.Tags.TextTags;

namespace Code.SwfLib.SwfMill.TagFormatting.DynamicTextTags
{
    public class CSMTextSettingsTagFormatter : TagFormatterBase<CSMTextSettingsTag> {

        private const string USE_FLASH_TYPE_ATTRIB = "useFlashType";
        private const string GRID_FIT = "gridFit";
        private const string THICKNESS = "thickness";
        private const string SHARPNESS = "sharpness";

        public override void AcceptAttribute(CSMTextSettingsTag tag, XAttribute attrib) {
            switch (attrib.Name.LocalName) {
                case OBJECT_ID_ATTRIB:
                    tag.TextID = SwfMillPrimitives.ParseObjectID(attrib);
                    break;
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

        public override void AcceptElement(CSMTextSettingsTag tag, XElement element) {
            switch (element.Name.LocalName) {
                default:
                    throw new FormatException("Invalid element " + element.Name.LocalName);
            }
        }

        public override XElement FormatTag(CSMTextSettingsTag tag) {
            return new XElement(XName.Get(SwfTagNameMapping.CSM_TEXT_SETTINGS_TAG),
                                new XAttribute(XName.Get("objectID"), tag.TextID),
                                new XAttribute(XName.Get("useFlashType"), tag.UseFlashType),
                                new XAttribute(XName.Get("gridFit"), tag.GridFit),
                                //TODO: reserved flagss
                                //new XAttribute(XName.Get("reservedFlags"), tag.ReservedFlags),
                                new XAttribute(XName.Get("thickness"), tag.Thickness.ToString(CultureInfo.InvariantCulture)),
                                new XAttribute(XName.Get("sharpness"), tag.Sharpness.ToString(CultureInfo.InvariantCulture))
                                //TODO: hide reserved attr
                                //new XAttribute(XName.Get("reserved"), tag.Reserved)
                                );
        }
    }
}
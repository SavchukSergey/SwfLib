using System;
using System.Xml.Linq;
using Code.SwfLib.Data;
using Code.SwfLib.Tags.ControlTags;

namespace Code.SwfLib.SwfMill.TagFormatting.ControlTags {
    public class SetBackgroundColorTagFormatter : TagFormatterBase<SetBackgroundColorTag> {

        private const string COLOR_ELEM = "color";

        public override void AcceptAttribute(SetBackgroundColorTag tag, XAttribute attrib) {
            switch (attrib.Name.LocalName) {
                default:
                    throw new FormatException("Invalid attribute " + attrib.Name.LocalName);
            }
        }

        public override void AcceptElement(SetBackgroundColorTag tag, XElement element) {
            switch (element.Name.LocalName) {
                case COLOR_ELEM:
                    tag.Color = ParseRGBFromFirstChild(element);
                    break;
                default:
                    throw new FormatException("Invalid element " + element.Name.LocalName);
            }
        }

        public override XElement FormatTag(SetBackgroundColorTag tag) {
            return new XElement(XName.Get(SwfTagNameMapping.SET_BACKGROUND_COLOR_TAG),
                                new XElement(XName.Get("color"), _formatters.ColorRGB.Format(ref tag.Color)));
        }
    }
}
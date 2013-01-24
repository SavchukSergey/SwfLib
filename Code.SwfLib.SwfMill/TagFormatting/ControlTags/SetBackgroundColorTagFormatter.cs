using System;
using System.Xml.Linq;
using Code.SwfLib.SwfMill.Data;
using Code.SwfLib.Tags.ControlTags;

namespace Code.SwfLib.SwfMill.TagFormatting.ControlTags {
    public class SetBackgroundColorTagFormatter : TagFormatterBase<SetBackgroundColorTag> {

        private const string COLOR_ELEM = "color";

        protected override void AcceptTagAttribute(SetBackgroundColorTag tag, XAttribute attrib) {
            switch (attrib.Name.LocalName) {
                default:
                    throw new FormatException("Invalid attribute " + attrib.Name.LocalName);
            }
        }

        protected override void AcceptTagElement(SetBackgroundColorTag tag, XElement element) {
            switch (element.Name.LocalName) {
                case COLOR_ELEM:
                    tag.Color = XColorRGB.FromXml(element.Element("Color"));
                    break;
                default:
                    throw new FormatException("Invalid element " + element.Name.LocalName);
            }
        }

        protected override XElement FormatTagElement(SetBackgroundColorTag tag, XElement xTag) {
            return new XElement(XName.Get(SwfTagNameMapping.SET_BACKGROUND_COLOR_TAG),
                                new XElement("color", XColorRGB.ToXml(tag.Color)));
        }
    }
}
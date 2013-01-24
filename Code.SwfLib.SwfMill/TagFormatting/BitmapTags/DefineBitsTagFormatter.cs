using System;
using System.Xml.Linq;
using Code.SwfLib.SwfMill.Data;
using Code.SwfLib.Tags.BitmapTags;

namespace Code.SwfLib.SwfMill.TagFormatting.BitmapTags {
    public class DefineBitsTagFormatter : TagFormatterBase<DefineBitsTag> {
        
        protected override XElement FormatTagElement(DefineBitsTag tag, XElement xTag) {
            xTag.Add(new XElement("data", XBinary.ToXml(tag.JPEGData)));
            return xTag;
        }

        protected override void AcceptTagAttribute(DefineBitsTag tag, XAttribute attrib) {
            switch (attrib.Name.LocalName) {
                default:
                    throw new FormatException("Invalid attribute " + attrib.Name.LocalName);
            }
        }

        protected override void AcceptTagElement(DefineBitsTag tag, XElement element) {
            switch (element.Name.LocalName) {
                case "data":
                    tag.JPEGData = XBinary.FromXml(element.Element("data"));
                    break;
                default:
                    throw new FormatException("Invalid element " + element.Name.LocalName);
            }
        }

        public override string TagName {
            get { return "DefineBits"; }
        }
    }
}

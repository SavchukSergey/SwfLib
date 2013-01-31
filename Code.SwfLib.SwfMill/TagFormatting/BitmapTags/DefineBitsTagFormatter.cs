using System;
using System.Xml.Linq;
using Code.SwfLib.SwfMill.Data;
using Code.SwfLib.Tags.BitmapTags;

namespace Code.SwfLib.SwfMill.TagFormatting.BitmapTags {
    public class DefineBitsTagFormatter : TagFormatterBase<DefineBitsTag> {
        
        protected override void FormatTagElement(DefineBitsTag tag, XElement xTag) {
            xTag.Add(new XElement("data", XBinary.ToXml(tag.JPEGData)));
        }

        protected override void AcceptTagElement(DefineBitsTag tag, XElement element) {
            switch (element.Name.LocalName) {
                case "data":
                    tag.JPEGData = XBinary.FromXml(element.Element("data"));
                    break;
                default:
                    return false;
            }
        }

        public override string TagName {
            get { return "DefineBits"; }
        }
    }
}

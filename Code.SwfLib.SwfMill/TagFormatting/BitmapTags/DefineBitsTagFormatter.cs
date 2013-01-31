using System;
using System.Xml.Linq;
using Code.SwfLib.SwfMill.Data;
using Code.SwfLib.Tags.BitmapTags;

namespace Code.SwfLib.SwfMill.TagFormatting.BitmapTags {
    public class DefineBitsTagFormatter : TagFormatterBase<DefineBitsTag> {

        protected override void FormatTagElement(DefineBitsTag tag, XElement xTag) {
        }

        protected override bool AcceptTagElement(DefineBitsTag tag, XElement element) {
            switch (element.Name.LocalName) {
                case "data":
                    tag.JPEGData = XBinary.FromXml(element.Element("data"));
                    break;
                default:
                    return false;
            }
            return true;
        }

        protected override byte[] GetData(DefineBitsTag tag) {
            return tag.JPEGData;
        }

        public override string TagName {
            get { return "DefineBits"; }
        }
    }
}

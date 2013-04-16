using System.Xml.Linq;
using Code.SwfLib.SwfMill.Data;
using Code.SwfLib.Tags.BitmapTags;

namespace Code.SwfLib.SwfMill.TagFormatting.BitmapTags {
    public class DefineBitsJPEG3TagFormatter : DefineBitmapBaseTagFormatter<DefineBitsJPEG3Tag> {

        protected override void FormatTagElement(DefineBitsJPEG3Tag tag, XElement xTag) {
            xTag.Add(new XElement("alpha", XBinary.ToXml(tag.BitmapAlphaData)));
        }

        protected override bool AcceptTagElement(DefineBitsJPEG3Tag tag, XElement element) {
            switch (element.Name.LocalName) {
                case "alpha":
                    tag.BitmapAlphaData = XBinary.FromXml(element.Element("data"));
                    break;
                default:
                    return false;
            }
            return true;
        }

        protected override byte[] GetData(DefineBitsJPEG3Tag tag) {
            return tag.ImageData;
        }

        protected override void SetData(DefineBitsJPEG3Tag tag, byte[] data) {
            tag.ImageData = data;
        }

        public override string TagName {
            get { return "DefineBitsJPEG3"; }
        }

    }
}

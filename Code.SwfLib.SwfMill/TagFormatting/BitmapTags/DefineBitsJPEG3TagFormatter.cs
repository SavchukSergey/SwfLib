using System;
using System.Xml.Linq;
using Code.SwfLib.SwfMill.Data;
using Code.SwfLib.Tags.BitmapTags;

namespace Code.SwfLib.SwfMill.TagFormatting.BitmapTags {
    public class DefineBitsJPEG3TagFormatter : DefineBitmapBaseTagFormatter<DefineBitsJPEG3Tag> {

        protected override void FormatTagElement(DefineBitsJPEG3Tag tag, XElement xTag) {
            xTag.Add(new XElement("data", XBinary.ToXml(tag.ImageData)));
            xTag.Add(new XElement("alpha", XBinary.ToXml(tag.BitmapAlphaData)));
        }

        protected override bool AcceptTagElement(DefineBitsJPEG3Tag tag, XElement element) {
            switch (element.Name.LocalName) {
                case "data":
                    tag.ImageData = XBinary.FromXml(element.Element("data"));
                    break;
                case "alpha":
                    tag.BitmapAlphaData = XBinary.FromXml(element.Element("data"));
                    break;
                default:
                    return false;
            }
            return true;
        }

        public override string TagName {
            get { return "DefineBitsJPEG3"; }
        }

    }
}

using System.Xml.Linq;
using SwfLib.SwfMill.Data;
using SwfLib.Tags.BitmapTags;

namespace SwfLib.SwfMill.TagFormatting.BitmapTags {
    public class DefineBitsJPEG4TagFormatter : DefineBitmapBaseTagFormatter<DefineBitsJPEG4Tag> {

        protected override void FormatTagElement(DefineBitsJPEG4Tag tag, XElement xTag) {
            xTag.Add(new XAttribute("deblock", tag.DeblockParam));
            xTag.Add(new XElement("alpha", XBinary.ToXml(tag.BitmapAlphaData)));
        }

        protected override bool AcceptTagAttribute(DefineBitsJPEG4Tag tag, XAttribute attrib) {
            switch (attrib.Name.LocalName) {
                case "deblock":
                    tag.DeblockParam = ushort.Parse(attrib.Value);
                    break;
                default:
                    return false;
            }
            return true;
        }

        protected override bool AcceptTagElement(DefineBitsJPEG4Tag tag, XElement element) {
            switch (element.Name.LocalName) {
                case "alpha":
                    tag.BitmapAlphaData = XBinary.FromXml(element.Element("data"));
                    break;
                default:
                    return false;
            }
            return true;
        }

        protected override byte[] GetData(DefineBitsJPEG4Tag tag) {
            return tag.ImageData;
        }

        protected override void SetData(DefineBitsJPEG4Tag tag, byte[] data) {
            tag.ImageData = data;
        }

        /// <summary>
        /// Gets xml element name.
        /// </summary>
        public override string TagName {
            get { return "DefineBitsJPEG4"; }
        }

    }
}

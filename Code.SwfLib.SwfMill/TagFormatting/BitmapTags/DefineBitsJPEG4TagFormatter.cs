using System;
using System.Xml.Linq;
using Code.SwfLib.SwfMill.Data;
using Code.SwfLib.Tags.BitmapTags;

namespace Code.SwfLib.SwfMill.TagFormatting.BitmapTags {
    public class DefineBitsJPEG4TagFormatter : DefineBitmapBaseTagFormatter<DefineBitsJPEG4Tag> {

        protected override XElement FormatTagElement(DefineBitsJPEG4Tag tag, XElement xTag) {
            xTag.Add(new XAttribute("deblock", tag.DeblockParam));
            xTag.Add(new XElement("data", XBinary.ToXml(tag.ImageData)));
            xTag.Add(new XElement("alpha", XBinary.ToXml(tag.BitmapAlphaData)));
            return xTag;
        }

        protected override void AcceptTagAttribute(DefineBitsJPEG4Tag tag, XAttribute attrib) {
            switch (attrib.Name.LocalName) {
                case "deblock":
                    tag.DeblockParam = ushort.Parse(attrib.Value);
                    break;
                default:
                    throw new FormatException("Invalid attribute " + attrib.Name.LocalName);
            }
        }

        protected override void AcceptTagElement(DefineBitsJPEG4Tag tag, XElement element) {
            switch (element.Name.LocalName) {
                case "data":
                    tag.ImageData = XBinary.FromXml(element.Element("data"));
                    break;
                case "alpha":
                    tag.BitmapAlphaData = XBinary.FromXml(element.Element("data"));
                    break;
                default:
                    throw new FormatException("Invalid element " + element.Name.LocalName);
            }
        }

        public override string TagName {
            get { return "DefineBitsJPEG4"; }
        }

    }
}

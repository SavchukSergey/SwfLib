using System;
using System.Xml.Linq;
using Code.SwfLib.SwfMill.Data;
using Code.SwfLib.Tags.BitmapTags;

namespace Code.SwfLib.SwfMill.TagFormatting.BitmapTags {
    public class DefineBitsJPEG2TagFormatter : DefineBitmapBaseTagFormatter<DefineBitsJPEG2Tag> {

        protected override XElement FormatTagElement(DefineBitsJPEG2Tag tag, XElement xTag) {
            xTag.Add(new XElement("data", XBinary.ToXml(tag.ImageData)));
            return xTag;
        }

        protected override void AcceptTagAttribute(DefineBitsJPEG2Tag tag, XAttribute attrib) {
            switch (attrib.Name.LocalName) {
                default:
                    throw new FormatException("Invalid attribute " + attrib.Name.LocalName);
            }
        }

        protected override void AcceptTagElement(DefineBitsJPEG2Tag tag, XElement element) {
            switch (element.Name.LocalName) {
                case "data":
                    tag.ImageData = XBinary.FromXml(element.Element("data"));
                    break;
                default:
                    throw new FormatException("Invalid element " + element.Name.LocalName);
            }
        }

        public override string TagName {
            get { return "DefineBitsJPEG2"; }
        }

        protected override ushort? GetObjectID(DefineBitsJPEG2Tag tag) {
            return tag.CharacterID;
        }

        protected override void SetObjectID(DefineBitsJPEG2Tag tag, ushort value) {
            tag.CharacterID = value;
        }
    }
}
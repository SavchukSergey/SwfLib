using System;
using System.Linq;
using System.Xml.Linq;
using Code.SwfLib.Tags.BitmapTags;

namespace Code.SwfLib.SwfMill.TagFormatting.BitmapTags {
    public class DefineBitsJPEG2TagFormatter : TagFormatterBase<DefineBitsJPEG2Tag> {

        protected override void AcceptTagAttribute(DefineBitsJPEG2Tag tag, XAttribute attrib) {
            switch (attrib.Name.LocalName) {
                default:
                    throw new FormatException("Invalid attribute " + attrib.Name.LocalName);
            }
        }

        protected override void AcceptTagElement(DefineBitsJPEG2Tag tag, XElement element) {
            switch (element.Name.LocalName) {
                case DATA_TAG:
                    //TODO: navigate to tag correctly
                    tag.ImageData = Convert.FromBase64String(element.Elements().First().Value.Trim());
                    break;
                default:
                    throw new FormatException("Invalid element " + element.Name.LocalName);
            }
        }

        protected override XElement FormatTagElement(DefineBitsJPEG2Tag tag, XElement xTag) {
            xTag.Add(new XElement(XName.Get("data"), SwfMillPrimitives.FormatBinaryData(tag.ImageData)));
            //TODO: store image data
            return xTag;
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
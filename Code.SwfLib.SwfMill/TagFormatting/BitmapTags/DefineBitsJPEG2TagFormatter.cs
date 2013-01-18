using System;
using System.Linq;
using System.Xml.Linq;
using Code.SwfLib.Tags.BitmapTags;

namespace Code.SwfLib.SwfMill.TagFormatting.BitmapTags {
    public class DefineBitsJPEG2TagFormatter : TagFormatterBase<DefineBitsJPEG2Tag> {

        public override void AcceptAttribute(DefineBitsJPEG2Tag tag, XAttribute attrib) {
            switch (attrib.Name.LocalName) {
                case OBJECT_ID_ATTRIB:
                    tag.CharacterID = ushort.Parse(attrib.Value);
                    break;
                default:
                    throw new FormatException("Invalid attribute " + attrib.Name.LocalName);
            }
        }

        public override void AcceptElement(DefineBitsJPEG2Tag tag, XElement element) {
            switch (element.Name.LocalName) {
                case DATA_TAG:
                    //TODO: navigate to tag correctly
                    tag.ImageData = Convert.FromBase64String(element.Elements().First().Value.Trim());
                    break;
                default:
                    throw new FormatException("Invalid element " + element.Name.LocalName);
            }
        }

        public override XElement FormatTag(DefineBitsJPEG2Tag tag) {
            return new XElement(XName.Get(SwfTagNameMapping.DEFINE_BITS_JPEG2_TAG),
                                new XAttribute(XName.Get(OBJECT_ID_ATTRIB), tag.CharacterID),
                                new XElement(XName.Get("data"), SwfMillPrimitives.FormatBinaryData(tag.ImageData))
                //TODO: store image data
                );
        }
    }
}
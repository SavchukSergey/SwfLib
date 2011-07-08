using System;
using System.Xml.Linq;
using Code.SwfLib.Tags.FontTags;

namespace Code.SwfLib.SwfMill.TagFormatting.FontTags {
    public class DefineFont3TagFormatter : TagFormatterBase<DefineFont3Tag> {

        private const string NAME_ATTRIB = "name";

        public override void AcceptAttribute(DefineFont3Tag tag, XAttribute attrib) {
            switch (attrib.Name.LocalName) {
                case OBJECT_ID_ATTRIB:
                    tag.ObjectID = ushort.Parse(attrib.Value);
                    break;
                case NAME_ATTRIB:
                    tag.FontName = attrib.Value;
                    break;
                default:
                    throw new FormatException("Invalid attribute " + attrib.Name.LocalName);
            }
        }

        public override void AcceptElement(DefineFont3Tag tag, XElement element) {
            switch (element.Name.LocalName) {
                case DATA_TAG:
                    //TODO: set data
                    FromBase64(element);
                    break;
                default:
                    throw new FormatException("Invalid element " + element.Name.LocalName);
            }
        }

        public override XElement FormatTag(DefineFont3Tag tag) {
            return new XElement(XName.Get(SwfTagNameMapping.DEFINE_FONT_3_TAG),
                                new XAttribute(OBJECT_ID_ATTRIB, tag.ObjectID),
                                new XAttribute(NAME_ATTRIB, tag.FontName)
                //TODO: other fields
                                );
        }
    }
}
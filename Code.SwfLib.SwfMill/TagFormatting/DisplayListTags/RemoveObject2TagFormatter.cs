using System;
using System.Xml.Linq;
using Code.SwfLib.Tags.DisplayListTags;

namespace Code.SwfLib.SwfMill.TagFormatting.DisplayListTags {
    public class RemoveObject2TagFormatter : TagFormatterBase<RemoveObject2Tag> {

        private const string DEPTH_ATTRIB = "depth";

        public override void AcceptAttribute(RemoveObject2Tag tag, XAttribute attrib) {
            switch (attrib.Name.LocalName) {
                case DEPTH_ATTRIB:
                    //TODO: read depth
                    break;
                default:
                    throw new FormatException("Invalid attribute " + attrib.Name.LocalName);
            }
        }

        public override void AcceptElement(RemoveObject2Tag tag, XElement element) {
            switch (element.Name.LocalName) {
                default:
                    throw new FormatException("Invalid element " + element.Name.LocalName);
            }
        }

        public override XElement FormatTag(RemoveObject2Tag tag) {
            return new XElement(XName.Get(SwfTagNameMapping.REMOVE_OBJECT2_TAG));
        }
    }
}
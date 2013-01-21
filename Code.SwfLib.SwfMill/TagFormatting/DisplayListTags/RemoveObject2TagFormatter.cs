using System;
using System.Xml.Linq;
using Code.SwfLib.Tags.DisplayListTags;

namespace Code.SwfLib.SwfMill.TagFormatting.DisplayListTags {
    public class RemoveObject2TagFormatter : TagFormatterBase<RemoveObject2Tag> {

        private const string DEPTH_ATTRIB = "depth";

        protected override void AcceptTagAttribute(RemoveObject2Tag tag, XAttribute attrib) {
            switch (attrib.Name.LocalName) {
                case DEPTH_ATTRIB:
                    tag.Depth = ushort.Parse(attrib.Value);
                    break;
                default:
                    throw new FormatException("Invalid attribute " + attrib.Name.LocalName);
            }
        }

        protected override void AcceptTagElement(RemoveObject2Tag tag, XElement element) {
            switch (element.Name.LocalName) {
                default:
                    throw new FormatException("Invalid element " + element.Name.LocalName);
            }
        }

        protected override XElement FormatTagElement(RemoveObject2Tag tag) {
            return new XElement(SwfTagNameMapping.REMOVE_OBJECT2_TAG,
                new XAttribute(DEPTH_ATTRIB, tag.Depth));
        }
    }
}
using System;
using System.Xml.Linq;
using Code.SwfLib.Tags.ControlTags;

namespace Code.SwfLib.SwfMill.TagFormatting.ControlTags {
    public class FrameLabelTagFormater : TagFormatterBase<FrameLabelTag> {

        private const string LABEL_ATTRIB = "label";
        private const string FLAGS_ELEM = "flags";

        public override void AcceptAttribute(FrameLabelTag tag, XAttribute attrib) {
            switch (attrib.Name.LocalName) {
                case LABEL_ATTRIB:
                    tag.Name = attrib.Value;
                    break;
                default:
                    throw new FormatException("Invalid attribute " + attrib.Name.LocalName);
            }
        }

        public override void AcceptElement(FrameLabelTag tag, XElement element) {
            switch (element.Name.LocalName) {
                case FLAGS_ELEM:
                    //TODO: read flags
                    break;
                default:
                    throw new FormatException("Invalid element " + element.Name.LocalName);
            }
        }

        public override XElement FormatTag(FrameLabelTag tag) {
            return new XElement(XName.Get(SwfTagNameMapping.FRAME_LABEL_TAG),
                new XAttribute(XName.Get(LABEL_ATTRIB), tag.Name)
                //TODO: Flags
                );
        }
    }
}
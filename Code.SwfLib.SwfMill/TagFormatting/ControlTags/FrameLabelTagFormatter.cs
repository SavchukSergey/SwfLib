using System;
using System.Xml.Linq;
using Code.SwfLib.Tags.ControlTags;

namespace Code.SwfLib.SwfMill.TagFormatting.ControlTags {
    public class FrameLabelTagFormatter : TagFormatterBase<FrameLabelTag> {

        private const string LABEL_ATTRIB = "label";
        private const string FLAGS_ELEM = "flags";

        protected override void AcceptTagAttribute(FrameLabelTag tag, XAttribute attrib) {
            switch (attrib.Name.LocalName) {
                case LABEL_ATTRIB:
                    tag.Name = attrib.Value;
                    break;
                default:
                    throw new FormatException("Invalid attribute " + attrib.Name.LocalName);
            }
        }

        protected override void AcceptTagElement(FrameLabelTag tag, XElement element) {
            switch (element.Name.LocalName) {
                case FLAGS_ELEM:
                    //TODO: read flags
                    break;
                default:
                    throw new FormatException("Invalid element " + element.Name.LocalName);
            }
        }

        protected override XElement FormatTagElement(FrameLabelTag tag, XElement xTag) {
            xTag.Add(new XAttribute(XName.Get(LABEL_ATTRIB), tag.Name));

            //TODO: Flags
            return xTag;
        }

        public override string TagName {
            get { return "FrameLabel"; }
        }
    }
}
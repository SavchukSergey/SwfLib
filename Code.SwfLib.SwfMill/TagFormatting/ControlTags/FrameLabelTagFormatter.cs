using System;
using System.Xml.Linq;
using Code.SwfLib.Tags.ControlTags;

namespace Code.SwfLib.SwfMill.TagFormatting.ControlTags {
    public class FrameLabelTagFormatter : TagFormatterBase<FrameLabelTag> {

        private const string LABEL_ATTRIB = "label";
        private const string FLAGS_ELEM = "flags";

        protected override bool AcceptTagAttribute(FrameLabelTag tag, XAttribute attrib) {
            switch (attrib.Name.LocalName) {
                case LABEL_ATTRIB:
                    tag.Name = attrib.Value;
                    break;
                default:
                    return false;
            }
            return true;
        }

        protected override bool AcceptTagElement(FrameLabelTag tag, XElement element) {
            switch (element.Name.LocalName) {
                case FLAGS_ELEM:
                    var xValue = element.Attribute("value");
                    if (xValue != null) {
                        tag.AnchorFlag = byte.Parse(xValue.Value);
                    }
                    break;
                default:
                    return false;
            }
            return true;
        }

        protected override void FormatTagElement(FrameLabelTag tag, XElement xTag) {
            xTag.Add(new XAttribute(LABEL_ATTRIB, tag.Name));
            var xFlags = new XElement(FLAGS_ELEM);
            if (tag.AnchorFlag.HasValue) {
                xFlags.Add(new XAttribute("value", tag.AnchorFlag.Value));
            }
            xTag.Add(xFlags);
        }

        public override string TagName {
            get { return "FrameLabel"; }
        }
    }
}
using System;
using System.Xml.Linq;
using Code.SwfLib.Tags.DisplayListTags;

namespace Code.SwfLib.SwfMill.TagFormatting.DisplayListTags {
    public class ShowFrameTagFormatter : TagFormatterBase<ShowFrameTag> {

        protected override void AcceptTagAttribute(ShowFrameTag tag, XAttribute attrib) {
            switch (attrib.Name.LocalName) {
                default:
                    throw new FormatException("Invalid attribute " + attrib.Name.LocalName);
            }
        }

        protected override void AcceptTagElement(ShowFrameTag tag, XElement element) {
            switch (element.Name.LocalName) {
                default:
                    throw new FormatException("Invalid element " + element.Name.LocalName);
            }
        }

        protected override void FormatTagElement(ShowFrameTag tag, XElement xTag) {
        }

        public override string TagName {
            get { return "ShowFrame"; }
        }
    }
}
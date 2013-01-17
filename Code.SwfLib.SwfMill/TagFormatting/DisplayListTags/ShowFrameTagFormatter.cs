using System;
using System.Xml.Linq;
using Code.SwfLib.Tags;
using Code.SwfLib.Tags.DisplayListTags;

namespace Code.SwfLib.SwfMill.TagFormatting.DisplayListTags {
    public class ShowFrameTagFormatter : TagFormatterBase<ShowFrameTag> {

        public override void AcceptAttribute(ShowFrameTag tag, XAttribute attrib) {
            switch (attrib.Name.LocalName) {
                default:
                    throw new FormatException("Invalid attribute " + attrib.Name.LocalName);
            }
        }

        public override void AcceptElement(ShowFrameTag tag, XElement element) {
            switch (element.Name.LocalName) {
                default:
                    throw new FormatException("Invalid element " + element.Name.LocalName);
            }
        }

        public override XElement FormatTag(ShowFrameTag tag) {
            return new XElement(XName.Get(SwfTagNameMapping.SHOW_FRAME_TAG));

        }
    }
}
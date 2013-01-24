using System;
using System.Xml.Linq;
using Code.SwfLib.Tags.FontTags;

namespace Code.SwfLib.SwfMill.TagFormatting.FontTags {
    public class DefineFontInfoTagFormatter : DefineFontBaseFormatter<DefineFontInfoTag> {

        protected override void AcceptTagAttribute(DefineFontInfoTag tag, XAttribute attrib) {
            switch (attrib.Name.LocalName) {
                default:
                    throw new FormatException("Invalid attribute " + attrib.Name.LocalName);
            }
        }

        protected override void AcceptTagElement(DefineFontInfoTag tag, XElement element) {
            switch (element.Name.LocalName) {
                default:
                    throw new FormatException("Invalid element " + element.Name.LocalName);
            }
        }

        protected override XElement FormatTagElement(DefineFontInfoTag tag, XElement xTag) {
            return xTag;
        }

        protected override string TagName {
            get { return "DefineFontInfo"; }
        }

    }
}

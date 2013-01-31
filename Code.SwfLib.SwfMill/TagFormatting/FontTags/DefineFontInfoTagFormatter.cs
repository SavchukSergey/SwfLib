using System;
using System.Xml.Linq;
using Code.SwfLib.Tags.FontTags;

namespace Code.SwfLib.SwfMill.TagFormatting.FontTags {
    public class DefineFontInfoTagFormatter : DefineFontBaseFormatter<DefineFontInfoTag> {

        protected override void AcceptTagElement(DefineFontInfoTag tag, XElement element) {
            switch (element.Name.LocalName) {
                default:
                    throw new FormatException("Invalid element " + element.Name.LocalName);
            }
        }

        protected override void FormatTagElement(DefineFontInfoTag tag, XElement xTag) {
        }

        public override string TagName {
            get { return "DefineFontInfo"; }
        }

    }
}

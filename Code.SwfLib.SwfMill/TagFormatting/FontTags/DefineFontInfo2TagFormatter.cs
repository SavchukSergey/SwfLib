using System;
using System.Xml.Linq;
using Code.SwfLib.Tags.FontTags;

namespace Code.SwfLib.SwfMill.TagFormatting.FontTags {
    public class DefineFontInfo2TagFormatter : DefineFontBaseFormatter<DefineFontInfo2Tag> {
        protected override void FormatTagElement(DefineFontInfo2Tag tag, XElement xTag) {
        }

        protected override void AcceptTagElement(DefineFontInfo2Tag tag, XElement element) {
        }

        public override string TagName {
            get { return "DefineFontInfo2"; }
        }
    }
}

using System;
using System.Xml.Linq;
using Code.SwfLib.Tags.TextTags;

namespace Code.SwfLib.SwfMill.TagFormatting.TextTags {
    public class DefineText2TagFormatter : TagFormatterBase<DefineText2Tag> {
        protected override void FormatTagElement(DefineText2Tag tag, XElement xTag) {
        }

        protected override void AcceptTagElement(DefineText2Tag tag, XElement element) {
        }

        public override string TagName {
            get { return "DefineText2"; }
        }
    }
}

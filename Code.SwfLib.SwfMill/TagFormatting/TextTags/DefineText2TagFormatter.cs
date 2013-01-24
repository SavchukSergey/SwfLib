using System;
using System.Xml.Linq;
using Code.SwfLib.Tags.TextTags;

namespace Code.SwfLib.SwfMill.TagFormatting.TextTags {
    public class DefineText2TagFormatter : TagFormatterBase<DefineText2Tag> {
        protected override XElement FormatTagElement(DefineText2Tag tag, XElement xTag) {
            return xTag;
        }

        protected override void AcceptTagAttribute(DefineText2Tag tag, XAttribute attrib) {
            throw new NotImplementedException();
        }

        protected override void AcceptTagElement(DefineText2Tag tag, XElement element) {
            throw new NotImplementedException();
        }

        public override string TagName {
            get { return "DefineText2"; }
        }
    }
}

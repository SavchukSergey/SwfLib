using System;
using System.Xml.Linq;
using Code.SwfLib.Tags.FontTags;

namespace Code.SwfLib.SwfMill.TagFormatting.FontTags {
    public class DefineFontInfo2TagFormatter : DefineFontBaseFormatter<DefineFontInfo2Tag> {
        protected override XElement FormatTagElement(DefineFontInfo2Tag tag, XElement xTag) {
            return xTag;
        }

        protected override void AcceptTagAttribute(DefineFontInfo2Tag tag, XAttribute attrib) {
            throw new NotImplementedException();
        }

        protected override void AcceptTagElement(DefineFontInfo2Tag tag, XElement element) {
            throw new NotImplementedException();
        }

        public override string TagName {
            get { return "DefineFontInfo2"; }
        }
    }
}

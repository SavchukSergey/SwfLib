using System.Xml.Linq;
using Code.SwfLib.Tags.FontTags;

namespace SwfLib.SwfMill.TagFormatting.FontTags {
    //TODO: format & parse
    public class DefineFontInfo2TagFormatter : DefineFontBaseFormatter<DefineFontInfo2Tag> {
        protected override void FormatTagElement(DefineFontInfo2Tag tag, XElement xTag) {
        }

        public override string TagName {
            get { return "DefineFontInfo2"; }
        }
    }
}

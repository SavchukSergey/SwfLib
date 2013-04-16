using System.Xml.Linq;
using Code.SwfLib.Tags.FontTags;

namespace Code.SwfLib.SwfMill.TagFormatting.FontTags {
    //TODO: format & parse
    public class DefineFont4TagFormatter : DefineFontBaseFormatter<DefineFont4Tag> {
        protected override void FormatTagElement(DefineFont4Tag tag, XElement xTag) {
        }

        public override string TagName {
            get { return "DefineFont4"; }
        }
    }
}

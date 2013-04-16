using System.Xml.Linq;
using Code.SwfLib.Tags.FontTags;

namespace SwfLib.SwfMill.TagFormatting.FontTags {
    //TODO: format & parse
    public class DefineFont2TagFormatter : DefineFontBaseFormatter<DefineFont2Tag> {
        protected override void FormatTagElement(DefineFont2Tag tag, XElement xTag) {
        }

        public override string TagName {
            get { return "DefineFont2"; }
        }

    }
}

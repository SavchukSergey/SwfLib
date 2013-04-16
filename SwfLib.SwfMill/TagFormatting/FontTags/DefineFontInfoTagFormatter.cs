using System.Xml.Linq;
using SwfLib.Tags.FontTags;

namespace SwfLib.SwfMill.TagFormatting.FontTags {
    //TODO: format & parse
    public class DefineFontInfoTagFormatter : DefineFontBaseFormatter<DefineFontInfoTag> {

        protected override void FormatTagElement(DefineFontInfoTag tag, XElement xTag) {
        }

        public override string TagName {
            get { return "DefineFontInfo"; }
        }

    }
}

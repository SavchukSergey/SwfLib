using System.Xml.Linq;
using Code.SwfLib.Tags.FontTags;

namespace Code.SwfLib.SwfMill.TagFormatting.FontTags {
    //TODO: format & parse
    public class DefineFontInfoTagFormatter : DefineFontBaseFormatter<DefineFontInfoTag> {

        protected override void FormatTagElement(DefineFontInfoTag tag, XElement xTag) {
        }

        public override string TagName {
            get { return "DefineFontInfo"; }
        }

    }
}

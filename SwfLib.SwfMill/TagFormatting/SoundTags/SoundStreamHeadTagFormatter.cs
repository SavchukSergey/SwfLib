using System.Xml.Linq;
using SwfLib.Tags.SoundTags;

namespace SwfLib.SwfMill.TagFormatting.SoundTags {
    public class SoundStreamHeadTagFormatter : TagFormatterBase<SoundStreamHeadTag> {
        protected override void FormatTagElement(SoundStreamHeadTag tag, XElement xTag) {
        }

        public override string TagName {
            get { return "SoundStreamHeadTag"; }
        }
    }
}

using System.Xml.Linq;
using Code.SwfLib.Tags.SoundTags;

namespace Code.SwfLib.SwfMill.TagFormatting.SoundTags {
    public class SoundStreamHeadTagFormatter : TagFormatterBase<SoundStreamHeadTag> {
        protected override void FormatTagElement(SoundStreamHeadTag tag, XElement xTag) {
        }

        protected override void AcceptTagElement(SoundStreamHeadTag tag, XElement element) {
        }

        public override string TagName {
            get { return "SoundStreamHeadTag"; }
        }
    }
}

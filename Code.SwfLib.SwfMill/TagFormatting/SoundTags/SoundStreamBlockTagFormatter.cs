using System.Xml.Linq;
using Code.SwfLib.Tags.SoundTags;

namespace Code.SwfLib.SwfMill.TagFormatting.SoundTags {
    public class SoundStreamBlockTagFormatter : TagFormatterBase<SoundStreamBlockTag> {
        protected override void FormatTagElement(SoundStreamBlockTag tag, XElement xTag) {
        }

        protected override void AcceptTagElement(SoundStreamBlockTag tag, XElement element) {
        }

        public override string TagName {
            get { return "SoundStreamBlock"; }
        }
    }
}

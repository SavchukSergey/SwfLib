using System.Xml.Linq;
using SwfLib.Tags.SoundTags;

namespace SwfLib.SwfMill.TagFormatting.SoundTags {
    public class SoundStreamBlockTagFormatter : TagFormatterBase<SoundStreamBlockTag> {
        protected override void FormatTagElement(SoundStreamBlockTag tag, XElement xTag) {
        }

        public override string TagName {
            get { return "SoundStreamBlock"; }
        }
    }
}

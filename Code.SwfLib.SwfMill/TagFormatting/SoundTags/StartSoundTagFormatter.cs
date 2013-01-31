using System.Xml.Linq;
using Code.SwfLib.Tags.SoundTags;

namespace Code.SwfLib.SwfMill.TagFormatting.SoundTags {
    public class StartSoundTagFormatter : TagFormatterBase<StartSoundTag> {

        protected override void FormatTagElement(StartSoundTag tag, XElement xTag) {
        }

        protected override void AcceptTagElement(StartSoundTag tag, XElement element) {
        }

        public override string TagName {
            get { return "StartSound"; }
        }

    }
}

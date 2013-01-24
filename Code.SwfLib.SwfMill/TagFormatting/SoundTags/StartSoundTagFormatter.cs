using System.Xml.Linq;
using Code.SwfLib.Tags.SoundTags;

namespace Code.SwfLib.SwfMill.TagFormatting.SoundTags {
    public class StartSoundTagFormatter : TagFormatterBase<StartSoundTag> {

        protected override XElement FormatTagElement(StartSoundTag tag, XElement xTag) {
            return xTag;
        }

        protected override void AcceptTagAttribute(StartSoundTag tag, XAttribute attrib) {
            throw new System.NotImplementedException();
        }

        protected override void AcceptTagElement(StartSoundTag tag, XElement element) {
            throw new System.NotImplementedException();
        }

        protected override string TagName {
            get { return "StartSound"; }
        }

    }
}

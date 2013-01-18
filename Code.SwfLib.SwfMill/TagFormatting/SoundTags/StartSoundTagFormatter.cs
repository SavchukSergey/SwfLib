using System.Xml.Linq;
using Code.SwfLib.Tags.SoundTags;

namespace Code.SwfLib.SwfMill.TagFormatting.SoundTags {
    public class StartSoundTagFormatter : TagFormatterBase<StartSoundTag> {
        public override XElement FormatTag(StartSoundTag tag) {
            throw new System.NotImplementedException();
        }

        public override void AcceptAttribute(StartSoundTag tag, XAttribute attrib) {
            throw new System.NotImplementedException();
        }

        public override void AcceptElement(StartSoundTag tag, XElement element) {
            throw new System.NotImplementedException();
        }
    }
}

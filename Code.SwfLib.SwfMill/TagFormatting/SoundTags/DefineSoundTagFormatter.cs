using System.Xml.Linq;
using Code.SwfLib.Tags.SoundTags;

namespace Code.SwfLib.SwfMill.TagFormatting.SoundTags {
    public class DefineSoundTagFormatter : TagFormatterBase<DefineSoundTag> {
        protected override XElement FormatTagElement(DefineSoundTag tag, XElement xTag) {
            throw new System.NotImplementedException();
        }

        protected override void AcceptTagAttribute(DefineSoundTag tag, XAttribute attrib) {
            throw new System.NotImplementedException();
        }

        protected override void AcceptTagElement(DefineSoundTag tag, XElement element) {
            throw new System.NotImplementedException();
        }
    }
}

using System.Xml.Linq;
using Code.SwfLib.Tags.SoundTags;

namespace Code.SwfLib.SwfMill.TagFormatting.SoundTags {
    public class DefineSoundTagFormatter : TagFormatterBase<DefineSoundTag> {
        public override XElement FormatTag(DefineSoundTag tag) {
            throw new System.NotImplementedException();
        }

        public override void AcceptAttribute(DefineSoundTag tag, XAttribute attrib) {
            throw new System.NotImplementedException();
        }

        public override void AcceptElement(DefineSoundTag tag, XElement element) {
            throw new System.NotImplementedException();
        }
    }
}

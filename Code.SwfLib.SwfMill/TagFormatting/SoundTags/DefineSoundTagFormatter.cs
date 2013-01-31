using System.Xml.Linq;
using Code.SwfLib.Tags.SoundTags;

namespace Code.SwfLib.SwfMill.TagFormatting.SoundTags {
    public class DefineSoundTagFormatter : TagFormatterBase<DefineSoundTag> {
        protected override void FormatTagElement(DefineSoundTag tag, XElement xTag) {
        }

        public override string TagName {
            get { return "DefineSound"; }
        }
    }
}

using System.Xml.Linq;
using Code.SwfLib.Tags.ButtonTags;

namespace Code.SwfLib.SwfMill.TagFormatting.ButtonTags {
    public class DefineButtonSoundTagFormatter : DefineButtonBaseTagFormatter<DefineButtonSoundTag> {
        
        protected override void FormatTagElement(DefineButtonSoundTag tag, XElement xTag) {
        }

        protected override void AcceptTagAttribute(DefineButtonSoundTag tag, XAttribute attrib) {
        }

        protected override void AcceptTagElement(DefineButtonSoundTag tag, XElement element) {
        }

        public override string TagName {
            get { return "DefineButtonSound"; }
        }
    }
}

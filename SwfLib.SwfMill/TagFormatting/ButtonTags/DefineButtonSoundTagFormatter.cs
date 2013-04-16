using System.Xml.Linq;
using Code.SwfLib.Tags.ButtonTags;

namespace Code.SwfLib.SwfMill.TagFormatting.ButtonTags {
    public class DefineButtonSoundTagFormatter : DefineButtonBaseTagFormatter<DefineButtonSoundTag> {
        
        protected override void FormatTagElement(DefineButtonSoundTag tag, XElement xTag) {
        }

        public override string TagName {
            get { return "DefineButtonSound"; }
        }
    }
}

using System.Xml.Linq;
using SwfLib.Tags.ButtonTags;

namespace SwfLib.SwfMill.TagFormatting.ButtonTags {
    public class DefineButtonSoundTagFormatter : DefineButtonBaseTagFormatter<DefineButtonSoundTag> {
        
        protected override void FormatTagElement(DefineButtonSoundTag tag, XElement xTag) {
        }

        public override string TagName {
            get { return "DefineButtonSound"; }
        }
    }
}

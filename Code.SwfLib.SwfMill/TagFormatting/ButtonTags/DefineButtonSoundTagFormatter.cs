using System.Xml.Linq;
using Code.SwfLib.Tags.ButtonTags;

namespace Code.SwfLib.SwfMill.TagFormatting.ButtonTags {
    public class DefineButtonSoundTagFormatter : TagFormatterBase<DefineButtonSoundTag> {
        protected override XElement FormatTagElement(DefineButtonSoundTag tag, XElement xTag) {
            return xTag;
        }

        protected override void AcceptTagAttribute(DefineButtonSoundTag tag, XAttribute attrib) {
            throw new System.NotImplementedException();
        }

        protected override void AcceptTagElement(DefineButtonSoundTag tag, XElement element) {
            throw new System.NotImplementedException();
        }

        protected override string TagName {
            get { return "DefineButtonSound"; }
        }
    }
}

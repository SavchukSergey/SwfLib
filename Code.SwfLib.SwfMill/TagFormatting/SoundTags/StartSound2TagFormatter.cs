using System.Xml.Linq;
using Code.SwfLib.Tags.SoundTags;

namespace Code.SwfLib.SwfMill.TagFormatting.SoundTags {
    public class StartSound2TagFormatter : TagFormatterBase<StartSound2Tag> {
        
        protected override void FormatTagElement(StartSound2Tag tag, XElement xTag) {
        }

        protected override void AcceptTagAttribute(StartSound2Tag tag, XAttribute attrib) {
        }

        protected override void AcceptTagElement(StartSound2Tag tag, XElement element) {
        }

        public override string TagName {
            get { return "StartSound2"; }
        }
    }
}

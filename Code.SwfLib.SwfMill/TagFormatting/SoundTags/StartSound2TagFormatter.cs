using System.Xml.Linq;
using Code.SwfLib.Tags.SoundTags;

namespace Code.SwfLib.SwfMill.TagFormatting.SoundTags {
    public class StartSound2TagFormatter : TagFormatterBase<StartSound2Tag> {
        
        protected override XElement FormatTagElement(StartSound2Tag tag, XElement xTag) {
            return xTag;
        }

        protected override void AcceptTagAttribute(StartSound2Tag tag, XAttribute attrib) {
            throw new System.NotImplementedException();
        }

        protected override void AcceptTagElement(StartSound2Tag tag, XElement element) {
            throw new System.NotImplementedException();
        }

        public override string TagName {
            get { return "StartSound2"; }
        }
    }
}

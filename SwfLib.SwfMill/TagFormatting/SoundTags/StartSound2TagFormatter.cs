using System.Xml.Linq;
using SwfLib.Tags.SoundTags;

namespace SwfLib.SwfMill.TagFormatting.SoundTags {
    public class StartSound2TagFormatter : TagFormatterBase<StartSound2Tag> {
        
        protected override void FormatTagElement(StartSound2Tag tag, XElement xTag) {
        }

        public override string TagName {
            get { return "StartSound2"; }
        }
    }
}

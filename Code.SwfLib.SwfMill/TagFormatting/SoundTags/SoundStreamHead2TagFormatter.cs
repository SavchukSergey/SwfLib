using System.Xml.Linq;
using Code.SwfLib.Tags.SoundTags;

namespace Code.SwfLib.SwfMill.TagFormatting.SoundTags {
    public class SoundStreamHead2TagFormatter : TagFormatterBase<SoundStreamHead2Tag> {
        
        protected override void FormatTagElement(SoundStreamHead2Tag tag, XElement xTag) {
        }

        public override string TagName {
            get { return "SoundStreamHead2"; }
        }
    }
}

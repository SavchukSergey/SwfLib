using System.Xml.Linq;
using SwfLib.Tags.SoundTags;

namespace SwfLib.SwfMill.TagFormatting.SoundTags {
    public class SoundStreamHead2TagFormatter : TagFormatterBase<SoundStreamHead2Tag> {
        
        protected override void FormatTagElement(SoundStreamHead2Tag tag, XElement xTag) {
        }

        public override string TagName {
            get { return "SoundStreamHead2"; }
        }
    }
}

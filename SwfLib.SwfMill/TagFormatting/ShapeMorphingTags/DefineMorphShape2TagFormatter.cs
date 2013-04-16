using System.Xml.Linq;
using SwfLib.Tags.ShapeMorphingTags;

namespace SwfLib.SwfMill.TagFormatting.ShapeMorphingTags {
    public class DefineMorphShape2TagFormatter : TagFormatterBase<DefineMorphShape2Tag> {
        protected override void FormatTagElement(DefineMorphShape2Tag tag, XElement xTag) {
        }

        public override string TagName {
            get { return "DefineMorphShape2"; }
        }
    }
}

using System.Xml.Linq;
using Code.SwfLib.Tags.ShapeMorphingTags;

namespace Code.SwfLib.SwfMill.TagFormatting.ShapeMorphingTags {
    public class DefineMorphShape2TagFormatter : TagFormatterBase<DefineMorphShape2Tag> {
        protected override void FormatTagElement(DefineMorphShape2Tag tag, XElement xTag) {
        }

        protected override void AcceptTagElement(DefineMorphShape2Tag tag, XElement element) {
        }

        public override string TagName {
            get { return "DefineMorphShape2"; }
        }
    }
}

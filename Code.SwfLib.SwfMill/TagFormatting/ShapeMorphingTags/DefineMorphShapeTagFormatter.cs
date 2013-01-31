using System.Xml.Linq;
using Code.SwfLib.Tags.ShapeMorphingTags;

namespace Code.SwfLib.SwfMill.TagFormatting.ShapeMorphingTags {
    public class DefineMorphShapeTagFormatter : TagFormatterBase<DefineMorphShapeTag> {
        protected override void FormatTagElement(DefineMorphShapeTag tag, XElement xTag) {
        }

        protected override void AcceptTagAttribute(DefineMorphShapeTag tag, XAttribute attrib) {
        }

        protected override void AcceptTagElement(DefineMorphShapeTag tag, XElement element) {
        }

        public override string TagName {
            get { return "DefineMorphShape"; }
        }
    }

}

using System.Xml.Linq;
using Code.SwfLib.Tags.ShapeMorphingTags;

namespace Code.SwfLib.SwfMill.TagFormatting.ShapeMorphingTags {
    public class DefineMorphShapeTagFormatter : TagFormatterBase<DefineMorphShapeTag> {
        protected override XElement FormatTagElement(DefineMorphShapeTag tag, XElement xTag) {
            return xTag;
        }

        protected override void AcceptTagAttribute(DefineMorphShapeTag tag, XAttribute attrib) {
            throw new System.NotImplementedException();
        }

        protected override void AcceptTagElement(DefineMorphShapeTag tag, XElement element) {
            throw new System.NotImplementedException();
        }

        public override string TagName {
            get { return "DefineMorphShape"; }
        }
    }

}

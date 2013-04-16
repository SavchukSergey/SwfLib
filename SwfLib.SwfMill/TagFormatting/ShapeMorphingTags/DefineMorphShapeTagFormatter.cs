using System.Xml.Linq;
using SwfLib.Tags.ShapeMorphingTags;

namespace SwfLib.SwfMill.TagFormatting.ShapeMorphingTags {
    public class DefineMorphShapeTagFormatter : TagFormatterBase<DefineMorphShapeTag> {
        protected override void FormatTagElement(DefineMorphShapeTag tag, XElement xTag) {
        }

        public override string TagName {
            get { return "DefineMorphShape"; }
        }
    }

}

using System.Xml.Linq;
using Code.SwfLib.Tags.ShapeTags;

namespace Code.SwfLib.SwfMill.TagFormatting.ShapeTags {
    public class DefineShape4TagFormatter : DefineShapeBaseFormatter<DefineShape4Tag> {

        protected override void FormatShapeElement(DefineShape4Tag tag, XElement elem) {
        }

        protected override void AcceptShapeTagElement(DefineShape4Tag tag, XElement element)
        {
        }

        protected override string TagName {
            get { return SwfTagNameMapping.DEFINE_SHAPE_4_TAG; }
        }
    }
}

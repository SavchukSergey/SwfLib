using System.Xml.Linq;
using Code.SwfLib.Tags.ShapeTags;

namespace Code.SwfLib.SwfMill.TagFormatting.ShapeTags {
    public class DefineShape4TagFormatter : DefineShapeBaseFormatter<DefineShape4Tag> {

        private const string EDGE_BOUNDS_ELEM = "strokeBounds";

        protected override void FormatShapeElement(DefineShape4Tag tag, XElement elem) {
        }

        protected override void FormatAdditionalBounds(DefineShape4Tag tag, XElement elem) {
            elem.Add(new XElement(EDGE_BOUNDS_ELEM, _formatters.Rectangle.Format(ref tag.EdgeBounds)));
        }

        protected override void AcceptShapeTagElement(DefineShape4Tag tag, XElement element) {
            switch (element.Name.LocalName) {
                case EDGE_BOUNDS_ELEM:
                    _formatters.Rectangle.Parse(element.Element("Rectangle"), out tag.EdgeBounds);
                    break;
                default:
                    AcceptShapeTagElement(tag, element);
                    break;
            }
        }

        protected override string TagName {
            get { return SwfTagNameMapping.DEFINE_SHAPE_4_TAG; }
        }
    }
}

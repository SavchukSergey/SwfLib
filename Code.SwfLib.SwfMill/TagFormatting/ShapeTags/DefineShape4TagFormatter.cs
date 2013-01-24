using System.Xml.Linq;
using Code.SwfLib.SwfMill.Data;
using Code.SwfLib.SwfMill.Shapes;
using Code.SwfLib.Tags.ShapeTags;

namespace Code.SwfLib.SwfMill.TagFormatting.ShapeTags {
    public class DefineShape4TagFormatter : DefineShapeBaseFormatter<DefineShape4Tag> {

        private const string EDGE_BOUNDS_ELEM = "strokeBounds";

        protected override void FormatFillStyles(DefineShape4Tag tag, XElement xFillStyles) {
            foreach (var style in tag.FillStyles) {
                xFillStyles.Add(FormatFillStyle(style));
            }
        }

        protected override void FormatLineStyles(DefineShape4Tag tag, XElement xLineStyles) {
            foreach (var style in tag.LineStyles) {
                xLineStyles.Add(XLineStyleEx.ToXml(style));
            }
        }

        protected override void FormatAdditionalBounds(DefineShape4Tag tag, XElement elem) {
            elem.Add(new XElement(EDGE_BOUNDS_ELEM, XRect.ToXml(tag.EdgeBounds)));
        }

        protected override void AcceptShapeTagElement(DefineShape4Tag tag, XElement element) {
            switch (element.Name.LocalName) {
                case EDGE_BOUNDS_ELEM:
                    tag.EdgeBounds = XRect.FromXml(element.Element("Rectangle"));
                    break;
                default:
                    AcceptShapeTagElement(tag, element);
                    break;
            }
        }

        public override string TagName {
            get { return "DefineShape5"; }
        }
    }
}

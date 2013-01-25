using System.Xml.Linq;
using Code.SwfLib.SwfMill.Data;
using Code.SwfLib.SwfMill.Shapes;
using Code.SwfLib.Tags.ShapeTags;

namespace Code.SwfLib.SwfMill.TagFormatting.ShapeTags {
    public class DefineShape4TagFormatter : DefineShapeBaseFormatter<DefineShape4Tag> {

        private const string EDGE_BOUNDS_ELEM = "strokeBounds";

        protected override void WriteStyles(DefineShape4Tag tag, XElement xStyles) {
            xStyles.Add(XStyleList.ToXml(tag.FillStyles, tag.LineStyles));
        }

        protected override void ReadShapes(DefineShape4Tag tag, XElement xEdges) {
            foreach (var xShape in xEdges.Elements()) {
                tag.ShapeRecords.Add(XShapeRecord.ExFromXml(xShape));
            }
        }

        protected override void WriteShapes(DefineShape4Tag tag, XElement xEdges) {
            foreach (var shapeRecord in tag.ShapeRecords) {
                xEdges.Add(XShapeRecord.ToXml(shapeRecord));
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

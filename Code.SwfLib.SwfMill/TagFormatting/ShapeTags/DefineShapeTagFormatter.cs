using System;
using System.Xml.Linq;
using Code.SwfLib.SwfMill.Shapes;
using Code.SwfLib.Tags.ShapeTags;

namespace Code.SwfLib.SwfMill.TagFormatting.ShapeTags {
    public class DefineShapeTagFormatter : DefineShapeBaseFormatter<DefineShapeTag> {

        protected override void WriteStyles(DefineShapeTag tag, XElement xStyles) {
            xStyles.Add(XStyleList.ToXml(tag.FillStyles, tag.LineStyles));
        }

        protected override void ReadShapes(DefineShapeTag tag, XElement xEdges) {
            foreach (var xShape in xEdges.Elements()) {
                tag.ShapeRecords.Add(XShapeRecord.RGBFromXml(xShape));
            }
        }

        protected override void WriteShapes(DefineShapeTag tag, XElement xEdges) {
            foreach (var shapeRecord in tag.ShapeRecords) {
                xEdges.Add(XShapeRecord.ToXml(shapeRecord));
            }
        }

        protected override void AcceptShapeTagElement(DefineShapeTag tag, XElement element) {
            switch (element.Name.LocalName) {
                case STYLES_ELEM:
                    ReadStyles(tag, element);
                    break;
                default:
                    throw new FormatException("Invalid xRecords " + element.Name.LocalName);
            }
        }

        private static void ReadStyles(DefineShapeTag tag, XElement styleElements) {
            var array = styleElements.Element(XName.Get("StyleList"));
            var fillStyles = array.Element("fillStyles");
            //TODO: line styles

            foreach (var styleElem in fillStyles.Elements()) {
                FillStyleRGB fillStyle;
                _formatters.FillStyleRGB.Parse(styleElem, out fillStyle);
                tag.FillStyles.Add(fillStyle);
            }
        }

        //TODO: Simulate swfmill ShapeSetup struct bug

        public override string TagName {
            get { return "DefineShape"; }
        }


    }
}
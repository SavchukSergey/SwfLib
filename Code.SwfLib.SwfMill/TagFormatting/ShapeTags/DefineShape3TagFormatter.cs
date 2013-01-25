using System;
using System.Xml.Linq;
using Code.SwfLib.SwfMill.Shapes;
using Code.SwfLib.Tags.ShapeTags;

namespace Code.SwfLib.SwfMill.TagFormatting.ShapeTags {
    public class DefineShape3TagFormatter : DefineShapeBaseFormatter<DefineShape3Tag> {

        private const string STYLES_ELEM = "styles";
        private const string SHAPES_ELEM = "shapes";

        protected override void FormatFillStyles(DefineShape3Tag tag, XElement xFillStyles) {
            foreach (var style in tag.FillStyles) {
                xFillStyles.Add(FormatFillStyle(style));
            }
        }

        protected override void FormatLineStyles(DefineShape3Tag tag, XElement xLineStyles) {
            foreach (var style in tag.LineStyles) {
                xLineStyles.Add(XLineStyleRGBA.ToXml(style));
            }
        }

        protected override void ReadShapes(DefineShape3Tag tag, XElement xEdges) {
            foreach (var xShape in xEdges.Elements()) {
                tag.ShapeRecords.Add(XShapeRecord.RGBAFromXml(xShape));
            }
        }


        protected override void WriteShapes(DefineShape3Tag tag, XElement xEdges) {
            foreach (var shapeRecord in tag.ShapeRecords) {
                xEdges.Add(XShapeRecord.ToXml(shapeRecord));
            }
        }

        protected override void AcceptShapeTagElement(DefineShape3Tag tag, XElement element) {
            switch (element.Name.LocalName) {
                case STYLES_ELEM:
                    ReadStyles(tag, element);
                    break;
                case SHAPES_ELEM:
                    ReadShapes(tag, element);
                    break;
                default:
                    throw new FormatException("Invalid element " + element.Name.LocalName);
            }
        }

        private static void ReadStyles(DefineShape3Tag tag, XElement styleElements) {
            //TODO: Implement styles reading;
        }

        public override string TagName {
            get { return "DefineShape3"; }
        }

    }
}
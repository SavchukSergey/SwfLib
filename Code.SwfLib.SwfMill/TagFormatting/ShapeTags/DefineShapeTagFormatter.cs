using System;
using System.Linq;
using System.Xml.Linq;
using Code.SwfLib.Tags.ShapeTags;

namespace Code.SwfLib.SwfMill.TagFormatting.ShapeTags {
    public class DefineShapeTagFormatter : TagFormatterBase<DefineShapeTag> {

        private const string BOUNDS_ELEM = "bounds";
        private const string STYLES_ELEM = "styles";
        private const string SHAPES_ELEM = "shapes";

        public override void AcceptAttribute(DefineShapeTag tag, XAttribute attrib) {
            switch (attrib.Name.LocalName) {
                case OBJECT_ID_ATTRIB:
                    tag.ShapeID = ushort.Parse(attrib.Value);
                    break;
                default:
                    throw new FormatException("Invalid attribute " + attrib.Name.LocalName);
            }
        }

        public override void AcceptElement(DefineShapeTag tag, XElement element) {
            switch (element.Name.LocalName) {
                case BOUNDS_ELEM:
                    tag.ShapeBounds = SwfMillPrimitives.ParseRectangle(element.Element(XName.Get("Rectangle")));
                    break;
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

        private static void ReadStyles(DefineShapeTag tag, XElement styleElements) {
            var array = styleElements.Element(XName.Get("StyleList"));
            var fillStyles = array.Element("fillStyles");

            foreach (var styleElem in fillStyles.Elements()) {
                switch (styleElem.Name.LocalName) {
                    case "ClippedBitmap":
                        tag.Shapes.FillStyles.Add(SwfMillPrimitives.ParseClippedBitmapFillStyle(styleElem));
                        break;
                    case "ClippedBitmap2":
                        tag.Shapes.FillStyles.Add(SwfMillPrimitives.ParseNonSmoothedClippedBitmapFillStyle(styleElem));
                        break;
                    case "LinearGradient":
                        tag.Shapes.FillStyles.Add(SwfMillPrimitives.ParseLinearGradientFillStyle(styleElem));
                        break;
                    case "Solid":
                        tag.Shapes.FillStyles.Add(SwfMillPrimitives.ParseSolidRGBFillStyle(styleElem));
                        break;
                    default:
                        throw new FormatException("Unknown fill style " + styleElem.Name.LocalName);
                }
            }
        }

        private static void ReadShapes(DefineShapeTag tag, XElement shapes) {
            var array = shapes.Element(XName.Get("Shape"));
            var fillStyles = array.Element("edges");

            foreach (var shapeElement in fillStyles.Elements()) {
                switch (shapeElement.Name.LocalName) {
                    case "ShapeSetup":
                        if (shapeElement.Attributes().Count() > 0)
                        {
                            tag.Shapes.ShapeRecords.Add(SwfMillPrimitives.ReadStyleChangeShapeRecord(shapeElement));
                        } else
                        {
                            tag.Shapes.ShapeRecords.Add(SwfMillPrimitives.ReadEndShapeRecord(shapeElement));
                        }
                        break;
                    case "LineTo":
                        tag.Shapes.ShapeRecords.Add(SwfMillPrimitives.ReadStraightEdgeShapeRecord(shapeElement));
                        break;
                    case "CurveTo":
                        tag.Shapes.ShapeRecords.Add(SwfMillPrimitives.ReadCurvedEdgeShapeRecord(shapeElement));
                        break;
                    default:
                        throw new FormatException("Unknown shape type " + shapeElement.Name.LocalName);
                }
            }
        }

        public override XElement FormatTag(DefineShapeTag tag) {
            return new XElement(XName.Get(SwfTagNameMapping.DEFINE_SHAPE_TAG));
        }
    }
}
using System;
using System.Linq;
using System.Xml.Linq;
using Code.SwfLib.Data.FillStyles;
using Code.SwfLib.Tags.ShapeTags;

namespace Code.SwfLib.SwfMill.TagFormatting.ShapeTags {
    public class DefineShapeTagFormatter : DefineShapeBaseFormatter<DefineShapeTag> {

        private const string STYLES_ELEM = "styles";
        private const string SHAPES_ELEM = "shapes";

        protected override void FormatShapeElement(DefineShapeTag tag, XElement element) {
            var shapesElem = new XElement(XName.Get(SHAPES_ELEM));
            var shapeElem = new XElement(XName.Get("Shape"));
            var edgesElem = FormatEdges(tag.Shapes.ShapeRecords);
            shapeElem.Add(edgesElem);
            shapesElem.Add(shapeElem);
            element.Add(shapesElem);
        }

        protected override void AcceptShapeTagElement(DefineShapeTag tag, XElement element) {
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

        protected override string TagName {
            get { return SwfTagNameMapping.DEFINE_SHAPE_TAG; }
        }

        private static void ReadStyles(DefineShapeTag tag, XElement styleElements) {
            var array = styleElements.Element(XName.Get("StyleList"));
            var fillStyles = array.Element("fillStyles");
            //TODO: line styles

            foreach (var styleElem in fillStyles.Elements()) {
                FillStyle fillStyle;
                _formatters.FillStyle1.Parse(styleElem, out fillStyle);
                tag.FillStyles.Add(fillStyle);
            }
        }

        private static void ReadShapes(DefineShapeTag tag, XElement shapes) {
            var array = shapes.Element(XName.Get("Shape"));
            var edges = array.Element("edges");
            if (edges != null) {
                foreach (var shapeElement in edges.Elements()) {
                    switch (shapeElement.Name.LocalName) {
                        case "ShapeSetup":
                            if (shapeElement.Attributes().Count() > 0) {
                                tag.Shapes.ShapeRecords.Add(SwfMillPrimitives.ReadStyleChangeShapeRecord(shapeElement));
                            } else {
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
        }




        //TODO: Simulate swfmill ShapeSetup struct bug



    }
}
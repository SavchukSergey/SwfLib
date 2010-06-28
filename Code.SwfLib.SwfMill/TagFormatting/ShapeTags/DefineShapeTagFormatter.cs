using System;
using System.Linq;
using System.Xml.Linq;
using Code.SwfLib.Data.Shapes;
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
                    _formatters.Rectangle.Parse(element.Element(XName.Get("Rectangle")), out tag.ShapeBounds);
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
            //TODO: line styles

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
        
        public override XElement FormatTag(DefineShapeTag tag) {
            var res = new XElement(XName.Get(SwfTagNameMapping.DEFINE_SHAPE_TAG),
                new XAttribute(XName.Get(OBJECT_ID_ATTRIB), tag.ShapeID),
                new XElement(XName.Get(BOUNDS_ELEM), _formatters.Rectangle.Format(ref tag.ShapeBounds))
                );
            var shapesElem = new XElement(XName.Get(SHAPES_ELEM));
            var shapeElem = new XElement(XName.Get("Shape"));
            var edgesElem = new XElement(XName.Get("edges"));
            foreach (var shape in tag.Shapes.ShapeRecords) {
                var styleChange = shape as StyleChangeShapeRecord;
                if (styleChange != null) edgesElem.Add(FormatShapeSetup(styleChange));
                var endRecord = shape as EndShapeRecord;
                if (endRecord != null) edgesElem.Add(FormatEndRecord(endRecord));
                var lineRecord = shape as StraightEdgeShapeRecord;
                if (lineRecord != null) edgesElem.Add(FormatStraightEdgeShapeRecord(lineRecord));
                var curvedRecord = shape as CurvedEdgeShapeRecord;
                if (curvedRecord != null) edgesElem.Add(FormatCurvedEdgeShapeRecord(curvedRecord));
                //TODO: default behavior? throw new exception
            }
            shapeElem.Add(edgesElem);
            shapesElem.Add(shapeElem);
            res.Add(shapesElem);
            return res;
        }
        //TODO: Simulate swfmill ShapeSetup struct bug

        private static XElement FormatShapeSetup(StyleChangeShapeRecord styleChange)
        {
            var setup = new XElement(XName.Get("ShapeSetup"));
            if (styleChange.FillStyle0.HasValue) {
                setup.Add(new XAttribute(XName.Get("fillStyle0"), styleChange.FillStyle0.Value));
            }
            if (styleChange.FillStyle1.HasValue) {
                setup.Add(new XAttribute(XName.Get("fillStyle1"), styleChange.FillStyle1.Value));
            }
            //TODO: line style
            setup.Add(new XAttribute(XName.Get("x"), styleChange.MoveDeltaX));
            setup.Add(new XAttribute(XName.Get("y"), styleChange.MoveDeltaY));

            //TODO: Glyphs  
            return setup;
        }

        private static XElement FormatStraightEdgeShapeRecord(StraightEdgeShapeRecord record)
        {
            return new XElement(XName.Get("LineTo"),
                new XAttribute(XName.Get("x"), record.DeltaX),
                new XAttribute(XName.Get("y"), record.DeltaY)
            );
        }

        private static XElement FormatCurvedEdgeShapeRecord(CurvedEdgeShapeRecord record) {
            //TODO: what is x1, y1, x2, y2
            return new XElement(XName.Get("CurveTo"),
                new XAttribute(XName.Get("x1"), record.ControlDeltaX),
                new XAttribute(XName.Get("y1"), record.ControlDeltaY),
                new XAttribute(XName.Get("x2"), record.AnchorDeltaX),
                new XAttribute(XName.Get("y2"), record.AnchorDeltaY)
            );
        }

        private static XElement FormatEndRecord(EndShapeRecord endRecord) {
            var setup = new XElement(XName.Get("ShapeSetup"));
            return setup;
        }

    }
}
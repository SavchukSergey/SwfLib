using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Code.SwfLib.Data.FillStyles;
using Code.SwfLib.Data.Shapes;
using Code.SwfLib.Tags.ShapeTags;

namespace Code.SwfLib.SwfMill.TagFormatting.ShapeTags {
    public class DefineShapeTagFormatter : DefineShapeBaseFormatter<DefineShapeTag> {

        private const string STYLES_ELEM = "styles";
        private const string SHAPES_ELEM = "shapes";

        protected override void FormatShapeElement(DefineShapeTag tag, XElement element) {
            var stylesElem = new XElement(XName.Get("styles"));
            var styleListElem = new XElement(XName.Get("StyleList"));
            styleListElem.Add(FormatFillStyles(tag.Shapes.FillStyles));
            stylesElem.Add(styleListElem);
            element.Add(stylesElem);

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
                tag.Shapes.FillStyles.Add(fillStyle);
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

        private static XElement FormatFillStyles(IEnumerable<FillStyle> styles) {
            var fillStylesElem = new XElement(XName.Get("fillStyles"));
            foreach (var style in styles) {
                var fillStyle = style;
                fillStylesElem.Add(_formatters.FillStyle1.Format(ref fillStyle));
            }
            return fillStylesElem;
        }

        private static XElement FormatEdges(IEnumerable<ShapeRecord> edges) {
            var edgesElem = new XElement(XName.Get("edges"));

            foreach (var shape in edges) {
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
            return edgesElem;
        }
        //TODO: Simulate swfmill ShapeSetup struct bug

        private static XElement FormatShapeSetup(StyleChangeShapeRecord styleChange) {
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

        private static XElement FormatStraightEdgeShapeRecord(StraightEdgeShapeRecord record) {
            return new XElement("LineTo",
                new XAttribute("x", record.DeltaX),
                new XAttribute("y", record.DeltaY)
            );
        }

        private static XElement FormatCurvedEdgeShapeRecord(CurvedEdgeShapeRecord record) {
            return new XElement("CurveTo",
                new XAttribute("x1", record.ControlDeltaX),
                new XAttribute("y1", record.ControlDeltaY),
                new XAttribute("x2", record.AnchorDeltaX),
                new XAttribute("y2", record.AnchorDeltaY)
            );
        }

        private static XElement FormatEndRecord(EndShapeRecord endRecord) {
            var setup = new XElement(XName.Get("ShapeSetup"));
            return setup;
        }

    }
}
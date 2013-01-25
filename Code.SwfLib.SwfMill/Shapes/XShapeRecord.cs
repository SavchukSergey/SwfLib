using System;
using System.Linq;
using System.Xml.Linq;
using Code.SwfLib.Shapes.Records;

namespace Code.SwfLib.SwfMill.Shapes {
    public static class XShapeRecord {

        public static ShapeRecord FromXml(XElement xShape) {
            switch (xShape.Name.LocalName) {
                case "ShapeSetup":
                    if (xShape.Attributes().Any()) {
                        return SwfMillPrimitives.ReadStyleChangeShapeRecord(xShape);
                    }
                    return SwfMillPrimitives.ReadEndShapeRecord(xShape);
                case "LineTo":
                    return SwfMillPrimitives.ReadStraightEdgeShapeRecord(xShape);
                case "CurveTo":
                    return SwfMillPrimitives.ReadCurvedEdgeShapeRecord(xShape);
                default:
                    throw new FormatException("Unknown shape type " + xShape.Name.LocalName);
            }
        }

        public static XElement ToXml(ShapeRecord shapeRecord) {
            var styleChange = shapeRecord as StyleChangeShapeRecord;
            if (styleChange != null) return FormatShapeSetup(styleChange);
            var endRecord = shapeRecord as EndShapeRecord;
            if (endRecord != null) return FormatEndRecord(endRecord);
            var lineRecord = shapeRecord as StraightEdgeShapeRecord;
            if (lineRecord != null) return FormatStraightEdgeShapeRecord(lineRecord);
            var curvedRecord = shapeRecord as CurvedEdgeShapeRecord;
            if (curvedRecord != null) return FormatCurvedEdgeShapeRecord(curvedRecord);
            throw new NotSupportedException();
        }

        private static XElement FormatShapeSetup(StyleChangeShapeRecord styleChange) {
            var setup = new XElement("ShapeSetup");
            if (styleChange.FillStyle0.HasValue) {
                setup.Add(new XAttribute(XName.Get("fillStyle0"), styleChange.FillStyle0.Value));
            }
            if (styleChange.FillStyle1.HasValue) {
                setup.Add(new XAttribute(XName.Get("fillStyle1"), styleChange.FillStyle1.Value));
            }
            //TODO: line style
            setup.Add(new XAttribute(XName.Get("x"), styleChange.MoveDeltaX));
            setup.Add(new XAttribute(XName.Get("y"), styleChange.MoveDeltaY));

            if (styleChange.StateNewStyles) {

            }
            //TODO: Glyphs  
            return setup;
        }

        private static XElement FormatEndRecord(EndShapeRecord endRecord) {
            var setup = new XElement("ShapeSetup");
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
    }
}

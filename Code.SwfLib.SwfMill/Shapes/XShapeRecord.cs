using System;
using System.Linq;
using System.Xml.Linq;
using Code.SwfLib.Shapes.Records;

namespace Code.SwfLib.SwfMill.Shapes {
    public static class XShapeRecord {

        private class Writer : IShapeRecordVisitor<object, XElement> {

            public XElement Visit(EndShapeRecord record, object arg) {
                return new XElement("ShapeSetup");
            }

            public XElement Visit(StyleChangeShapeRecordRGB record, object arg) {
                var res = FormatShapeSetup(record);
                if (record.StateNewStyles) {
                    var xStyles = new XElement("styles");
                    xStyles.Add(XStyleList.ToXml(record.FillStyles, record.LineStyles));
                    res.Add(xStyles);
                }
                return res;
            }

            public XElement Visit(StyleChangeShapeRecordRGBA record, object arg) {
                var res = FormatShapeSetup(record);
                if (record.StateNewStyles) {
                    var xStyles = new XElement("styles");
                    xStyles.Add(XStyleList.ToXml(record.FillStyles, record.LineStyles));
                    res.Add(xStyles);
                }
                return res;
            }

            public XElement Visit(StyleChangeShapeRecordEx record, object arg) {
                var res = FormatShapeSetup(record);
                if (record.StateNewStyles) {
                    var xStyles = new XElement("styles");
                    xStyles.Add(XStyleList.ToXml(record.FillStyles, record.LineStyles));
                    res.Add(xStyles);
                }
                return res;
            }

            public XElement Visit(StraightEdgeShapeRecord record, object arg) {
                return new XElement("LineTo",
                      new XAttribute("x", record.DeltaX),
                      new XAttribute("y", record.DeltaY)
                );
            }

            public XElement Visit(CurvedEdgeShapeRecord record, object arg) {
                return new XElement("CurveTo",
                    new XAttribute("x1", record.ControlDeltaX),
                    new XAttribute("y1", record.ControlDeltaY),
                    new XAttribute("x2", record.AnchorDeltaX),
                    new XAttribute("y2", record.AnchorDeltaY)
                );
            }

            private static XElement FormatShapeSetup(StyleChangeShapeRecord styleChange) {
                var setup = new XElement("ShapeSetup");
                if (styleChange.StateMoveTo) {
                    setup.Add(new XAttribute("x", styleChange.MoveDeltaX));
                    setup.Add(new XAttribute("y", styleChange.MoveDeltaY));
                }
                if (styleChange.FillStyle0.HasValue) {
                    setup.Add(new XAttribute("fillStyle0", styleChange.FillStyle0.Value));
                }
                if (styleChange.FillStyle1.HasValue) {
                    setup.Add(new XAttribute("fillStyle1", styleChange.FillStyle1.Value));
                }
                if (styleChange.LineStyle.HasValue) {
                    setup.Add(new XAttribute("lineStyle", styleChange.LineStyle.Value));
                }

                return setup;
            }
        }

        private class Reader : IShapeRecordVisitor<XElement, IShapeRecord> {
            public IShapeRecord Visit(EndShapeRecord record, XElement xShapeRecord) {
                return record;
            }

            public IShapeRecord Visit(StyleChangeShapeRecordRGB record, XElement xShapeRecord) {
                ReadStyleChange(record, xShapeRecord);
                var xStyles = xShapeRecord.Element("styles");
                if (xStyles != null) {
                    record.StateNewStyles = true;
                    XStyleList.FromXml(xStyles.Element("StyleList"), record.FillStyles, record.LineStyles);
                }
                return record;
            }

            public IShapeRecord Visit(StyleChangeShapeRecordRGBA record, XElement xShapeRecord) {
                ReadStyleChange(record, xShapeRecord);
                var xStyles = xShapeRecord.Element("styles");
                if (xStyles != null) {
                    record.StateNewStyles = true;
                    XStyleList.FromXml(xStyles.Element("StyleList"), record.FillStyles, record.LineStyles);
                }
                return record;
            }

            public IShapeRecord Visit(StyleChangeShapeRecordEx record, XElement xShapeRecord) {
                ReadStyleChange(record, xShapeRecord);
                var xStyles = xShapeRecord.Element("styles");
                if (xStyles != null) {
                    record.StateNewStyles = true;
                    XStyleList.FromXml(xStyles.Element("StyleList"), record.FillStyles, record.LineStyles);
                } return record;
            }

            public IShapeRecord Visit(StraightEdgeShapeRecord record, XElement xShape) {
                var xDeltaX = xShape.Attribute("x");
                var xDeltaY = xShape.Attribute("y");
                record.DeltaX = int.Parse(xDeltaX.Value);
                record.DeltaY = int.Parse(xDeltaY.Value);
                return record;
            }

            public IShapeRecord Visit(CurvedEdgeShapeRecord record, XElement xShape) {
                foreach (var attribute in xShape.Attributes()) {
                    switch (attribute.Name.LocalName) {
                        case "x1":
                            record.ControlDeltaX = int.Parse(attribute.Value);
                            break;
                        case "y1":
                            record.ControlDeltaY = int.Parse(attribute.Value);
                            break;
                        case "x2":
                            record.AnchorDeltaX = int.Parse(attribute.Value);
                            break;
                        case "y2":
                            record.AnchorDeltaY = int.Parse(attribute.Value);
                            break;
                        default:
                            OnUnknownAttributeFound(attribute);
                            break;

                    }
                }
                return record;
            }

            private static void ReadStyleChange(StyleChangeShapeRecord record, XElement xShape) {
                foreach (var attribute in xShape.Attributes()) {
                    switch (attribute.Name.LocalName) {
                        case "fillStyle0":
                            record.FillStyle0 = uint.Parse(attribute.Value);
                            break;
                        case "fillStyle1":
                            record.FillStyle1 = uint.Parse(attribute.Value);
                            break;
                        case "lineStyle":
                            record.LineStyle = uint.Parse(attribute.Value);
                            break;
                        case "x":
                            record.StateMoveTo = true;
                            record.MoveDeltaX = int.Parse(attribute.Value);
                            break;
                        case "y":
                            record.StateMoveTo = true;
                            record.MoveDeltaY = int.Parse(attribute.Value);
                            break;
                        default:
                            OnUnknownAttributeFound(attribute);
                            break;
                    }
                }
            }

            private static void OnUnknownAttributeFound(XAttribute elem) {
                throw new FormatException("Unknown attribute " + elem.Name.LocalName);
            }
        }

        private static readonly Writer _writer = new Writer();
        private static readonly Reader _reader = new Reader();
        private static readonly ShapeRecordFactory _factory = new ShapeRecordFactory();

        public static IShapeRecordRGB RGBFromXml(XElement xShape) {
            var type = GetShapeRecordType(xShape);
            var record = _factory.CreateRGB(type);
            record.AcceptVisitor(_reader, xShape);
            return record;
        }

        public static IShapeRecordRGBA RGBAFromXml(XElement xShape) {
            var type = GetShapeRecordType(xShape);
            var record = _factory.CreateRGBA(type);
            record.AcceptVisitor(_reader, xShape);
            return record;
        }

        public static IShapeRecordEx ExFromXml(XElement xShape) {
            var type = GetShapeRecordType(xShape);
            var record = _factory.CreateEx(type);
            record.AcceptVisitor(_reader, xShape);
            return record;
        }

        private static ShapeRecordType GetShapeRecordType(XElement xShape) {
            switch (xShape.Name.LocalName) {
                case "ShapeSetup":
                    if (xShape.Attributes().Any() || xShape.Elements().Any()) {
                        return ShapeRecordType.StyleChangeRecord;
                    }
                    return ShapeRecordType.EndRecord;
                case "LineTo":
                    return ShapeRecordType.StraightEdge;
                case "CurveTo":
                    return ShapeRecordType.CurvedEdgeRecord;
                default:
                    throw new FormatException("Unknown shape type " + xShape.Name.LocalName);
            }
        }

        public static XElement ToXml(IShapeRecord shapeRecord) {
            return shapeRecord.AcceptVisitor(_writer, null);
        }

    }
}

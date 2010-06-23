using System;
using System.Linq;
using System.Xml.Linq;
using Code.SwfLib.Data;
using Code.SwfLib.Data.FillStyles;
using Code.SwfLib.Data.Shapes;
using Code.SwfLib.Data.Text;

namespace Code.SwfLib.SwfMill {
    public static class SwfMillPrimitives {

        public static SwfMorphShapeWithStyle ParseSwfMorphShapeWithStyle(XElement element) {
            //TODO: Implement;
            return new SwfMorphShapeWithStyle();
        }


        public static ushort ParseObjectID(XAttribute attrib) {
            return ushort.Parse(attrib.Value);
        }

        public static SwfMatrix ParseMatrix(XElement element) {
            var matrix = new SwfMatrix();
            matrix.ScaleX = 1.0;
            matrix.ScaleY = 1.0;
            foreach (var attrib in element.Attributes()) {
                switch (attrib.Name.LocalName) {
                    case "scaleX":
                        matrix.ScaleX = double.Parse(attrib.Value);
                        break;
                    case "scaleY":
                        matrix.ScaleY = double.Parse(attrib.Value);
                        break;
                    case "transX":
                        matrix.TranslateX = int.Parse(attrib.Value);
                        break;
                    case "transY":
                        matrix.TranslateY = int.Parse(attrib.Value);
                        break;
                    default:
                        OnUnknownAttributeFound(attrib);
                        break;
                }
            }
            foreach (var elem in element.Elements()) {
                switch (elem.Name.LocalName) {
                    default:
                        OnUnknownElementFound(elem);
                        break;
                }
            }
            return matrix;
        }

        public static ClippedBitmapFillStyle ParseClippedBitmapFillStyle(XElement styleElement) {
            var style = new ClippedBitmapFillStyle();
            foreach (var attribute in styleElement.Attributes()) {
                switch (attribute.Name.LocalName) {
                    case "objectID":
                        style.ObjectID = ParseObjectID(attribute);
                        break;
                    default:
                        OnUnknownAttributeFound(attribute);
                        break;
                }
            }
            foreach (var elem in styleElement.Elements()) {
                switch (elem.Name.LocalName) {
                    case "matrix":
                        style.BitmapMatrix = ParseMatrix(elem.Element(XName.Get("Transform")));
                        break;
                    default:
                        OnUnknownElementFound(elem);
                        break;
                }
            }
            return style;
        }

        public static NonSmoothedClippedBitmapFillStyle ParseNonSmoothedClippedBitmapFillStyle(XElement styleElement) {
            var style = new NonSmoothedClippedBitmapFillStyle();
            foreach (var attribute in styleElement.Attributes()) {
                switch (attribute.Name.LocalName) {
                    case "objectID":
                        style.ObjectID = ParseObjectID(attribute);
                        break;
                    default:
                        OnUnknownAttributeFound(attribute);
                        break;
                }
            }
            foreach (var elem in styleElement.Elements()) {
                switch (elem.Name.LocalName) {
                    case "matrix":
                        style.BitmapMatrix = ParseMatrix(elem.Element(XName.Get("Transform")));
                        break;
                    default:
                        OnUnknownElementFound(elem);
                        break;
                }
            }
            return style;
        }

        public static LinearGradientFillStyle ParseLinearGradientFillStyle(XElement styleElement) {
            var style = new LinearGradientFillStyle();
            foreach (var attribute in styleElement.Attributes()) {
                switch (attribute.Name.LocalName) {
                    default:
                        OnUnknownAttributeFound(attribute);
                        break;
                }
            }
            foreach (var elem in styleElement.Elements()) {
                switch (elem.Name.LocalName) {
                    case "matrix":
                        style.GradientMatrix = ParseMatrix(elem.Element(XName.Get("Transform")));
                        break;
                    case "gradientColors":
                        //TODO: Implement
                        break;
                    default:
                        OnUnknownElementFound(elem);
                        break;
                }
            }
            return style;
        }

        public static SolidRGBFillStyle ParseSolidRGBFillStyle(XElement styleElement) {
            var style = new SolidRGBFillStyle();
            foreach (var attribute in styleElement.Attributes()) {
                switch (attribute.Name.LocalName) {
                    default:
                        OnUnknownAttributeFound(attribute);
                        break;
                }
            }
            foreach (var elem in styleElement.Elements()) {
                switch (elem.Name.LocalName) {
                    case "color":
                        style.Color = ParseRGBColor(elem.Element(XName.Get("Color")));
                        break;
                    default:
                        OnUnknownElementFound(elem);
                        break;
                }
            }
            return style;
        }

        public static SwfRGB ParseRGBColor(XElement element) {
            var rgb = new SwfRGB();
            foreach (var attribute in element.Attributes()) {
                switch (attribute.Name.LocalName) {
                    case "red":
                        rgb.Red = byte.Parse(attribute.Value);
                        break;
                    case "green":
                        rgb.Green = byte.Parse(attribute.Value);
                        break;
                    case "blue":
                        rgb.Blue = byte.Parse(attribute.Value);
                        break;
                    default:
                        OnUnknownAttributeFound(attribute);
                        break;
                }
            }
            foreach (var elem in element.Elements()) {
                switch (elem.Name.LocalName) {
                    default:
                        OnUnknownElementFound(elem);
                        break;
                }
            }
            return rgb;
        }

        public static XElement FormatRGBColor(SwfRGB rgb) {
            return new XElement(XName.Get("Color"),
                                new XAttribute(XName.Get("red"), rgb.Red),
                                new XAttribute(XName.Get("green"), rgb.Green),
                                new XAttribute(XName.Get("blue"), rgb.Blue));
        }

        public static SwfRect ParseRectangle(XElement element) {
            var rect = new SwfRect();
            foreach (var attribute in element.Attributes()) {
                switch (attribute.Name.LocalName) {
                    case "left":
                        rect.XMin = int.Parse(attribute.Value);
                        break;
                    case "top":
                        rect.YMin = int.Parse(attribute.Value);
                        break;
                    case "right":
                        rect.XMax = int.Parse(attribute.Value);
                        break;
                    case "bottom":
                        rect.YMax = int.Parse(attribute.Value);
                        break;
                    default:
                        OnUnknownAttributeFound(attribute);
                        break;
                }
            }
            foreach (var elem in element.Elements()) {
                switch (elem.Name.LocalName) {
                    default:
                        OnUnknownElementFound(elem);
                        break;
                }
            }
            return rect;
        }

        private static void OnUnknownElementFound(XElement elem) {
            throw new FormatException("Unknown element " + elem.Name.LocalName);
        }

        private static void OnUnknownAttributeFound(XAttribute elem) {
            throw new FormatException("Unknown attribute " + elem.Name.LocalName);
        }


        public static StyleChangeShapeRecord ReadStyleChangeShapeRecord(XElement element) {
            var result = new StyleChangeShapeRecord();
            foreach (var attribute in element.Attributes()) {
                switch (attribute.Name.LocalName) {
                    case "fillStyle0":
                        result.FillStyle0 = uint.Parse(attribute.Value);
                        break;
                    case "fillStyle1":
                        result.FillStyle1 = uint.Parse(attribute.Value);
                        break;
                    case "x":
                        result.MoveDeltaX = int.Parse(attribute.Value);
                        break;
                    case "y":
                        result.MoveDeltaY = int.Parse(attribute.Value);
                        break;
                    default:
                        OnUnknownAttributeFound(attribute);
                        break;

                }
            }
            foreach (var elem in element.Elements()) {
                switch (elem.Name.LocalName) {
                    default:
                        OnUnknownElementFound(elem);
                        break;
                }
            }
            return result;
        }

        public static EndShapeRecord ReadEndShapeRecord(XElement element) {
            var result = new EndShapeRecord();
            foreach (var attribute in element.Attributes()) {
                switch (attribute.Name.LocalName) {
                    default:
                        OnUnknownAttributeFound(attribute);
                        break;

                }
            }
            foreach (var elem in element.Elements()) {
                switch (elem.Name.LocalName) {
                    default:
                        OnUnknownElementFound(elem);
                        break;
                }
            }
            return result;
        }

        public static StraightEdgeShapeRecord ReadStraightEdgeShapeRecord(XElement element) {
            var result = new StraightEdgeShapeRecord();
            foreach (var attribute in element.Attributes()) {
                switch (attribute.Name.LocalName) {
                    case "x":
                        result.DeltaX = int.Parse(attribute.Value);
                        break;
                    case "y":
                        result.DeltaY = int.Parse(attribute.Value);
                        break;
                    default:
                        OnUnknownAttributeFound(attribute);
                        break;

                }
            }
            foreach (var elem in element.Elements()) {
                switch (elem.Name.LocalName) {
                    default:
                        OnUnknownElementFound(elem);
                        break;
                }
            }
            return result;
        }

        public static CurvedEdgeShapeRecord ReadCurvedEdgeShapeRecord(XElement element) {
            var result = new CurvedEdgeShapeRecord();
            foreach (var attribute in element.Attributes()) {
                switch (attribute.Name.LocalName) {
                    //TODO:  what is x1 and x2?
                    case "x1":
                        result.ControlDeltaX = int.Parse(attribute.Value);
                        break;
                    case "y1":
                        result.ControlDeltaY = int.Parse(attribute.Value);
                        break;
                    case "x2":
                        result.AnchorDeltaX = int.Parse(attribute.Value);
                        break;
                    case "y2":
                        result.AnchorDeltaY = int.Parse(attribute.Value);
                        break;
                    default:
                        OnUnknownAttributeFound(attribute);
                        break;

                }
            }
            foreach (var elem in element.Elements()) {
                switch (elem.Name.LocalName) {
                    default:
                        OnUnknownElementFound(elem);
                        break;
                }
            }
            return result;
        }

        public static XElement FormatTextRecord(TextRecord entry) {
            var res = new XElement(XName.Get("TextRecord6"));
            if (entry.HasFont) {
                res.Add(new XAttribute(XName.Get("objectID"), entry.FontID.Value));
            }
            if (entry.HasXOffset) {
                res.Add(new XAttribute(XName.Get("x"), entry.XOffset.Value));
            }
            if (entry.HasYOffset) {
                res.Add(new XAttribute(XName.Get("y"), entry.YOffset.Value));
            }
            if (entry.HasFont) {
                if (!entry.TextHeight.HasValue) throw new InvalidOperationException("Text Height must be specified");
                res.Add(new XAttribute(XName.Get("fontHeight"), entry.TextHeight.Value));
            }
            if (entry.HasColor) {
                res.Add(new XElement(XName.Get("color"), FormatRGBColor(entry.TextColor.Value)));
            }
            res.Add(new XElement(XName.Get("glyphs"), entry.Glyphs.Select(item => FormatGlyphEntry(item))));
            return res;
        }

        public static TextRecord ParseTextRecord(XElement element) {
            var result = new TextRecord();
            foreach (var attribute in element.Attributes()) {
                switch (attribute.Name.LocalName) {
                    case "objectID":
                        result.FontID = ushort.Parse(attribute.Value);
                        break;
                    case "x":
                        result.XOffset = short.Parse(attribute.Value);
                        break;
                    case "y":
                        result.YOffset = short.Parse(attribute.Value);
                        break;
                    case "fontHeight":
                        result.TextHeight = ushort.Parse(attribute.Value);
                        break;
                    default:
                        OnUnknownAttributeFound(attribute);
                        break;

                }
            }
            foreach (var elem in element.Elements()) {
                switch (elem.Name.LocalName) {
                    case "color":
                        result.TextColor = ParseRGBColor(elem.Element("Color"));
                        break;
                    case "glyphs":
                        foreach (var glyphElem in elem.Elements()) {
                            result.Glyphs.Add(ParseGlyphEntry(glyphElem));
                        }
                        break;
                    default:
                        OnUnknownElementFound(elem);
                        break;
                }
            }
            return result;
        }

        public static XElement FormatGlyphEntry(GlyphEntry entry) {
            return new XElement(XName.Get("TextEntry"),
                                new XAttribute(XName.Get("glyph"), entry.GlyphIndex),
                                new XAttribute(XName.Get("advance"), entry.GlyphAdvance));
        }

        public static GlyphEntry ParseGlyphEntry(XElement element) {
            var result = new GlyphEntry();
            foreach (var attribute in element.Attributes()) {
                switch (attribute.Name.LocalName) {
                    case "glyph":
                        result.GlyphIndex = uint.Parse(attribute.Value);
                        break;
                    case "advance":
                        result.GlyphAdvance = int.Parse(attribute.Value);
                        break;
                    default:
                        OnUnknownAttributeFound(attribute);
                        break;

                }
            }
            foreach (var elem in element.Elements()) {
                switch (elem.Name.LocalName) {
                    default:
                        OnUnknownElementFound(elem);
                        break;
                }
            }
            return result;
        }

        public static bool ParseBoolean(XAttribute attribute) {
            switch (attribute.Value) {
                case "0":
                    return false;
                case "1":
                    return true;
                default:
                    throw new FormatException("Unknown value");
            }
        }

        public static string GetStringValue(bool val) {
            return val ? "1" : "0";
        }
    }
}

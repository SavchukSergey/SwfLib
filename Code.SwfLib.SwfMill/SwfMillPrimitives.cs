using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Code.SwfLib.Data;
using Code.SwfLib.Tags.ShapeTags;

namespace Code.SwfLib.SwfMill {
    public static class SwfMillPrimitives {

        public static SwfMorphShapeWithStyle ParseSwfMorphShapeWithStyle(XElement element) {
            //TODO: Implement;
            return new SwfMorphShapeWithStyle();
        }

        public static SwfShapeWithStyle ParseSwfShapeWithStyle(XElement element) {
            //TODO: Implement;
            return new SwfShapeWithStyle();
        }

        public static ushort ParseObjectID(XAttribute attrib) {
            return ushort.Parse(attrib.Value);
        }

        public static SwfMatrix ParseMatrix(XElement element) {
            var matrix = new SwfMatrix();
            foreach (var attrib in element.Attributes()) {
                switch (attrib.Name.LocalName) {
                    case "scaleX":
                        matrix.ScaleX = double.Parse(attrib.Value);
                        break;
                    case "scaleY":
                        matrix.ScaleY = double.Parse(attrib.Value);
                        break;
                    case "transX":
                        matrix.TranslateX = double.Parse(attrib.Value);
                        break;
                    case "transY":
                        matrix.TranslateY = double.Parse(attrib.Value);
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

        public static SwfRGB ParseRGBColor(XElement element)
        {
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

        public static SwfRect ParseRectangle(XElement element)
        {
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


    }
}

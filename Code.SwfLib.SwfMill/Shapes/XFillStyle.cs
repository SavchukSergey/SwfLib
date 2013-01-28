using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Code.SwfLib.Data;
using Code.SwfLib.Gradients;
using Code.SwfLib.Shapes.FillStyles;
using Code.SwfLib.SwfMill.Data;
using Code.SwfLib.SwfMill.Gradients;
using Code.SwfLib.Tags.ShapeTags;

namespace Code.SwfLib.SwfMill.Shapes {
    public class XFillStyle {

        public static XElement ToXml(FillStyleRGB fillStyle) {
            var res = new XElement(GetNodeName(fillStyle.FillStyleType));
            switch (fillStyle.FillStyleType) {
                case FillStyleType.SolidColor:
                    res.Add(new XElement("color", XColorRGB.ToXml(fillStyle.Color)));
                    break;
                case FillStyleType.LinearGradient:
                    AddSpreadMode(res, fillStyle.Gradient.SpreadMode);
                    AddInterpolationMode(res, fillStyle.Gradient.InterpolationMode);
                    AddMatrix(res, fillStyle.GradientMatrix);
                    AddGradientColors(res, fillStyle.Gradient.GradientRecords);
                    break;
                case FillStyleType.RepeatingBitmap:
                    AddBitmapId(res, fillStyle.BitmapID);
                    AddMatrix(res, fillStyle.BitmapMatrix);
                    break;
                case FillStyleType.ClippedBitmap:
                    AddBitmapId(res, fillStyle.BitmapID);
                    AddMatrix(res, fillStyle.BitmapMatrix);
                    break;
                case FillStyleType.NonSmoothedRepeatingBitmap:
                    AddBitmapId(res, fillStyle.BitmapID);
                    AddMatrix(res, fillStyle.BitmapMatrix);
                    break;
                case FillStyleType.NonSmoothedClippedBitmap:
                    AddBitmapId(res, fillStyle.BitmapID);
                    AddMatrix(res, fillStyle.BitmapMatrix);
                    break;
            }
            return res;
        }

        public static XElement ToXml(FillStyleRGBA fillStyle) {
            var res = new XElement(GetNodeName(fillStyle.FillStyleType));
            switch (fillStyle.FillStyleType) {
                case FillStyleType.SolidColor:
                    res.Add(new XElement("color", XColorRGBA.ToXml(fillStyle.Color)));
                    break;
                case FillStyleType.LinearGradient:
                    AddSpreadMode(res, fillStyle.Gradient.SpreadMode);
                    AddInterpolationMode(res, fillStyle.Gradient.InterpolationMode);
                    AddMatrix(res, fillStyle.GradientMatrix);
                    AddGradientColors(res, fillStyle.Gradient.GradientRecords);
                    break;
                case FillStyleType.RepeatingBitmap:
                    AddBitmapId(res, fillStyle.BitmapID);
                    AddMatrix(res, fillStyle.BitmapMatrix);
                    break;
                case FillStyleType.ClippedBitmap:
                    AddBitmapId(res, fillStyle.BitmapID);
                    AddMatrix(res, fillStyle.BitmapMatrix);
                    break;
                case FillStyleType.NonSmoothedRepeatingBitmap:
                    AddBitmapId(res, fillStyle.BitmapID);
                    AddMatrix(res, fillStyle.BitmapMatrix);
                    break;
                case FillStyleType.NonSmoothedClippedBitmap:
                    AddBitmapId(res, fillStyle.BitmapID);
                    AddMatrix(res, fillStyle.BitmapMatrix);
                    break;
            }
            return res;
        }

        public static FillStyleRGB FromXmlRGB(XElement xFillStyle) {
            switch (xFillStyle.Name.LocalName) {
                case "Solid":
                    return ParseSolidRGB(xFillStyle);
                case "LinearGradient":
                    return ParseLinearRGB(xFillStyle);
                case "RepeatingBitmap":
                    return ParseRepeatingBitmapRGB(xFillStyle);
                case "ClippedBitmap":
                    return ParseClippedBitmapRGB(xFillStyle);
                case "NonSmoothedRepeatingBitmap":
                    return ParseNonSmoothedRepeatingBitmapRGB(xFillStyle);
                case "ClippedBitmap2":
                    return ParseNonSmoothedClippedBitmapRGB(xFillStyle);

                //TODO: other fill styles
                default:
                    throw new NotSupportedException();
            }
        }

        public static FillStyleRGBA FromXmlRGBA(XElement xFillStyle) {
            switch (xFillStyle.Name.LocalName) {
                case "Solid":
                    return ParseSolidRGBA(xFillStyle);
                case "LinearGradient":
                    return ParseLinearRGBA(xFillStyle);
                case "RepeatingBitmap":
                    return ParseRepeatingBitmapRGBA(xFillStyle);
                case "ClippedBitmap":
                    return ParseClippedBitmapRGBA(xFillStyle);
                case "NonSmoothedRepeatingBitmap":
                    return ParseNonSmoothedRepeatingBitmapRGBA(xFillStyle);
                case "ClippedBitmap2":
                    return ParseNonSmoothedClippedBitmapRGBA(xFillStyle);
                //TODO: other fill styles
                default:
                    throw new NotSupportedException();
            }
        }

        #region Solid

        private static FillStyleRGB ParseSolidRGB(XElement xFillStyle) {
            var xColor = xFillStyle.Element("color").Element("Color");
            return new FillStyleRGB {
                FillStyleType = FillStyleType.SolidColor,
                Color = XColorRGB.FromXml(xColor)
            };
        }

        private static FillStyleRGBA ParseSolidRGBA(XElement xFillStyle) {
            var xColor = xFillStyle.Element("color").Element("Color");
            return new FillStyleRGBA {
                FillStyleType = FillStyleType.SolidColor,
                Color = XColorRGBA.FromXml(xColor)
            };
        }

        #endregion

        #region Linear Gradient

        private static FillStyleRGB ParseLinearRGB(XElement xFillStyle) {
            var res = new FillStyleRGB {
                FillStyleType = FillStyleType.LinearGradient,
                Gradient = {
                    SpreadMode = GetSpreadMode(xFillStyle),
                    InterpolationMode = GetInterpolationMode(xFillStyle),
                },
                GradientMatrix = GetMatrix(xFillStyle)
            };
            var xGradientColors = xFillStyle.Element("gradientColors");
            foreach (var xRecord in xGradientColors.Elements("GradientItem")) {
                res.Gradient.GradientRecords.Add(XGradientRecordRGB.FromXml(xRecord));
            }
            return res;
        }

        private static FillStyleRGBA ParseLinearRGBA(XElement xFillStyle) {
            var res = new FillStyleRGBA {
                FillStyleType = FillStyleType.LinearGradient,
                Gradient = {
                    SpreadMode = GetSpreadMode(xFillStyle),
                    InterpolationMode = GetInterpolationMode(xFillStyle),
                },
                GradientMatrix = GetMatrix(xFillStyle)
            };
            var xGradientColors = xFillStyle.Element("gradientColors");
            foreach (var xRecord in xGradientColors.Elements("GradientItem")) {
                res.Gradient.GradientRecords.Add(XGradientRecordRGBA.FromXml(xRecord));
            }
            return res;
        }

        #endregion

        private static void AddGradientColors(XElement xml, IEnumerable<GradientRecordRGB> records) {
            var xColors = new XElement("gradientColors");
            foreach (var record in records) {
                var xRecord = XGradientRecordRGB.ToXml(record);
                xColors.Add(xRecord);
            }
            xml.Add(xColors);
        }

        private static void AddGradientColors(XElement xml, IEnumerable<GradientRecordRGBA> records) {
            var xColors = new XElement("gradientColors");
            foreach (var record in records) {
                var xRecord = XGradientRecordRGBA.ToXml(record);
                xColors.Add(xRecord);
            }
            xml.Add(xColors);
        }

        private static void AddMatrix(XElement xml, SwfMatrix matrix) {
            xml.Add(new XElement("matrix", XMatrix.ToXml(matrix)));
        }

        private static SwfMatrix GetMatrix(XElement xFillStyle) {
            var xMatrix = xFillStyle.Element("matrix");
            return XMatrix.FromXml(xMatrix.Element("Transform"));
        }

        private static void AddSpreadMode(XElement xml, SpreadMode mode) {
            xml.Add(new XAttribute("spreadMode", mode.ToString()));
        }

        private static SpreadMode GetSpreadMode(XElement xFillStyle) {
            var xMode = xFillStyle.Attribute("spreadMode");
            var res = SpreadMode.Pad;
            if (xMode == null) return res;
            return (SpreadMode)Enum.Parse(typeof(SpreadMode), xMode.Value);
        }

        private static void AddInterpolationMode(XElement xml, InterpolationMode mode) {
            xml.Add(new XAttribute("interpolationMode", mode.ToString()));
        }

        private static InterpolationMode GetInterpolationMode(XElement xFillStyle) {
            var xMode = xFillStyle.Attribute("interpolationMode");
            var res = InterpolationMode.Normal;
            if (xMode == null) return res;
            return (InterpolationMode)Enum.Parse(typeof(InterpolationMode), xMode.Value);
        }

        private static void AddBitmapId(XElement xml, ushort bitmapId) {
            xml.Add(new XAttribute("objectID", bitmapId.ToString()));
        }

        private static ushort GetBitmapId(XElement xml) {
            return ushort.Parse(xml.Attribute("objectID").Value);
        }

        public static FillStyleRGB ParseRepeatingBitmapRGB(XElement xFillStyle) {
            return new FillStyleRGB {
                FillStyleType = FillStyleType.RepeatingBitmap,
                BitmapID = GetBitmapId(xFillStyle),
                BitmapMatrix = GetMatrix(xFillStyle)
            };
        }

        public static FillStyleRGBA ParseRepeatingBitmapRGBA(XElement xFillStyle) {
            return new FillStyleRGBA {
                FillStyleType = FillStyleType.RepeatingBitmap,
                BitmapID = GetBitmapId(xFillStyle),
                BitmapMatrix = GetMatrix(xFillStyle)
            };
        }

        public static FillStyleRGB ParseNonSmoothedRepeatingBitmapRGB(XElement xFillStyle) {
            return new FillStyleRGB {
                FillStyleType = FillStyleType.NonSmoothedRepeatingBitmap,
                BitmapID = GetBitmapId(xFillStyle),
                BitmapMatrix = GetMatrix(xFillStyle)
            };
        }

        public static FillStyleRGBA ParseNonSmoothedRepeatingBitmapRGBA(XElement xFillStyle) {
            return new FillStyleRGBA {
                FillStyleType = FillStyleType.NonSmoothedRepeatingBitmap,
                BitmapID = GetBitmapId(xFillStyle),
                BitmapMatrix = GetMatrix(xFillStyle)
            };
        }


        public static FillStyleRGB ParseClippedBitmapRGB(XElement xFillStyle) {
            return new FillStyleRGB {
                FillStyleType = FillStyleType.ClippedBitmap,
                BitmapID = GetBitmapId(xFillStyle),
                BitmapMatrix = GetMatrix(xFillStyle)
            };
        }

        public static FillStyleRGBA ParseClippedBitmapRGBA(XElement xFillStyle) {
            return new FillStyleRGBA {
                FillStyleType = FillStyleType.ClippedBitmap,
                BitmapID = GetBitmapId(xFillStyle),
                BitmapMatrix = GetMatrix(xFillStyle)
            };
        }

        public static FillStyleRGB ParseNonSmoothedClippedBitmapRGB(XElement xFillStyle) {
            return new FillStyleRGB {
                FillStyleType = FillStyleType.NonSmoothedClippedBitmap,
                BitmapID = GetBitmapId(xFillStyle),
                BitmapMatrix = GetMatrix(xFillStyle)
            };
        }

        public static FillStyleRGBA ParseNonSmoothedClippedBitmapRGBA(XElement xFillStyle) {
            return new FillStyleRGBA {
                FillStyleType = FillStyleType.NonSmoothedClippedBitmap,
                BitmapID = GetBitmapId(xFillStyle),
                BitmapMatrix = GetMatrix(xFillStyle)
            };
        }


        private static string GetNodeName(FillStyleType type) {
            switch (type) {
                case FillStyleType.LinearGradient:
                    return "LinearGradient";
                case FillStyleType.SolidColor:
                    return "Solid";
                case FillStyleType.RepeatingBitmap:
                    return "RepeatingBitmap";
                case FillStyleType.ClippedBitmap:
                    return "ClippedBitmap";
                case FillStyleType.NonSmoothedRepeatingBitmap:
                    return "NonSmoothedRepeatingBitmap";
                case FillStyleType.NonSmoothedClippedBitmap:
                    return "ClippedBitmap2";
                default:
                    throw new NotSupportedException();
            }
        }

    }
}

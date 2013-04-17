using System;
using System.Xml.Linq;
using SwfLib.Data;
using SwfLib.Shapes.FillStyles;
using SwfLib.SwfMill.Data;

namespace SwfLib.SwfMill.Shapes {
    /// <summary>
    /// Represents BitmapFillStyle xml formatter.
    /// </summary>
    public static class XBitmapFillStyle {

        public const string CLIPPED_BITMAP = "ClippedBitmap";
        public const string REPEATING_BITMAP = "RepeatingBitmap"; //TiledBitmap ?
        public const string NON_SMOOTHED_CLIPPED_BITMAP = "ClippedBitmap2";
        public const string NON_SMOOTHED_REPEATING_BITMAP = "RepeatingBitmap2";

        public static XElement ToXml(BitmapFillStyleRGB fillStyle) {
            var res = new XElement(GetNodeName(fillStyle.Type));
            res.Add(new XAttribute("objectID", fillStyle.BitmapID.ToString()));
            res.Add(new XElement("matrix", XMatrix.ToXml(fillStyle.BitmapMatrix)));
            return res;
        }

        public static XElement ToXml(BitmapFillStyleRGBA fillStyle) {
            var res = new XElement(GetNodeName(fillStyle.Type));
            res.Add(new XAttribute("objectID", fillStyle.BitmapID.ToString()));
            res.Add(new XElement("matrix", XMatrix.ToXml(fillStyle.BitmapMatrix)));
            return res;
        }


        public static FillStyleRGB ParseRepeatingBitmapRGB(XElement xFillStyle) {
            return new BitmapFillStyleRGB {
                Mode = BitmapMode.Repeat,
                Smoothing = true,
                BitmapID = GetBitmapId(xFillStyle),
                BitmapMatrix = GetMatrix(xFillStyle)
            };
        }

        public static FillStyleRGBA ParseRepeatingBitmapRGBA(XElement xFillStyle) {
            return new BitmapFillStyleRGBA {
                Mode = BitmapMode.Repeat,
                Smoothing = true,
                BitmapID = GetBitmapId(xFillStyle),
                BitmapMatrix = GetMatrix(xFillStyle)
            };
        }

        public static FillStyleRGB ParseNonSmoothedRepeatingBitmapRGB(XElement xFillStyle) {
            return new BitmapFillStyleRGB {
                Mode = BitmapMode.Repeat,
                Smoothing = false,
                BitmapID = GetBitmapId(xFillStyle),
                BitmapMatrix = GetMatrix(xFillStyle)
            };
        }

        public static FillStyleRGBA ParseNonSmoothedRepeatingBitmapRGBA(XElement xFillStyle) {
            return new BitmapFillStyleRGBA {
                Mode = BitmapMode.Repeat,
                Smoothing = false,
                BitmapID = GetBitmapId(xFillStyle),
                BitmapMatrix = GetMatrix(xFillStyle)
            };
        }


        public static FillStyleRGB ParseClippedBitmapRGB(XElement xFillStyle) {
            return new BitmapFillStyleRGB {
                Mode = BitmapMode.Clip,
                Smoothing = true,
                BitmapID = GetBitmapId(xFillStyle),
                BitmapMatrix = GetMatrix(xFillStyle)
            };
        }

        public static FillStyleRGBA ParseClippedBitmapRGBA(XElement xFillStyle) {
            return new BitmapFillStyleRGBA {
                Mode = BitmapMode.Clip,
                Smoothing = true,
                BitmapID = GetBitmapId(xFillStyle),
                BitmapMatrix = GetMatrix(xFillStyle)
            };
        }

        public static FillStyleRGB ParseNonSmoothedClippedBitmapRGB(XElement xFillStyle) {
            return new BitmapFillStyleRGB {
                Mode = BitmapMode.Clip,
                Smoothing = false,
                BitmapID = GetBitmapId(xFillStyle),
                BitmapMatrix = GetMatrix(xFillStyle)
            };
        }

        public static FillStyleRGBA ParseNonSmoothedClippedBitmapRGBA(XElement xFillStyle) {
            return new BitmapFillStyleRGBA {
                Mode = BitmapMode.Clip,
                Smoothing = false,
                BitmapID = GetBitmapId(xFillStyle),
                BitmapMatrix = GetMatrix(xFillStyle)
            };
        }

        private static ushort GetBitmapId(XElement xml) {
            return ushort.Parse(xml.Attribute("objectID").Value);
        }

        private static SwfMatrix GetMatrix(XElement xFillStyle) {
            var xMatrix = xFillStyle.Element("matrix");
            return XMatrix.FromXml(xMatrix.Element(XMatrix.TAG_NAME));
        }

        private static string GetNodeName(FillStyleType type) {
            switch (type) {
                case FillStyleType.RepeatingBitmap:
                    return REPEATING_BITMAP;
                case FillStyleType.ClippedBitmap:
                    return CLIPPED_BITMAP;
                case FillStyleType.NonSmoothedRepeatingBitmap:
                    return NON_SMOOTHED_REPEATING_BITMAP;
                case FillStyleType.NonSmoothedClippedBitmap:
                    return NON_SMOOTHED_CLIPPED_BITMAP;
                default:
                    throw new NotSupportedException();
            }
        }
    }
}

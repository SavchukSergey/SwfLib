using System.Xml.Linq;
using SwfLib.Data;
using SwfLib.SwfMill.Utils;

namespace SwfLib.SwfMill.Data {
    public static class XMatrix {

        public const string TAG_NAME = "Transform";

        public static SwfMatrix FromXml(XElement xMatrix) {
            var xMoveX = xMatrix.RequiredIntAttribute("transX");
            var xMoveY = xMatrix.RequiredIntAttribute("transY");

            var xScaleX = xMatrix.Attribute("scaleX");
            var xScaleY = xMatrix.Attribute("scaleY");

            var xSkewX = xMatrix.Attribute("skewX");
            var xSkewY = xMatrix.Attribute("skewY");

            var matrix = new SwfMatrix {
                TranslateX = xMoveX,
                TranslateY = xMoveY,
                ScaleX = xScaleX != null ? CommonFormatter.ParseDouble(xScaleX.Value) : 1,
                ScaleY = xScaleY != null ? CommonFormatter.ParseDouble(xScaleY.Value) : 1,
                RotateSkew0 = xSkewX != null ? CommonFormatter.ParseDouble(xSkewX.Value) : 0,
                RotateSkew1 = xSkewY != null ? CommonFormatter.ParseDouble(xSkewY.Value) : 0,
            };

            return matrix;
        }

        public static XElement ToXml(SwfMatrix matrix) {
            var res = new XElement(TAG_NAME,
                 new XAttribute("transX", matrix.TranslateX),
                 new XAttribute("transY", matrix.TranslateY));
            if (matrix.HasScale) {
                res.Add(new XAttribute("scaleX", matrix.ScaleX));
                res.Add(new XAttribute("scaleY", matrix.ScaleY));
            }
            if (matrix.HasRotate) {
                res.Add(new XAttribute("skewX", matrix.RotateSkew0));
                res.Add(new XAttribute("skewY", matrix.RotateSkew1));
            }
            return res;
        }
    }
}

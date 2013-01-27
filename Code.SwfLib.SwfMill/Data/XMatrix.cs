using System.Xml.Linq;
using Code.SwfLib.Data;

namespace Code.SwfLib.SwfMill.Data {
    public static class XMatrix {

        public static SwfMatrix FromXml(XElement xMatrix) {
            var xMoveX = xMatrix.Attribute("transX");
            var xMoveY = xMatrix.Attribute("transY");

            var scaleX = xMatrix.Attribute("scaleX");
            var scaleY = xMatrix.Attribute("scaleY");

            var skewX = xMatrix.Attribute("skewX");
            var skewY = xMatrix.Attribute("skewY");

            var matrix = new SwfMatrix {
                TranslateX = int.Parse(xMoveX.Value),
                TranslateY = int.Parse(xMoveY.Value),
                ScaleX = 1,
                ScaleY = 1
            };

            if (scaleX != null || scaleY != null) {
                matrix.ScaleX = CommonFormatter.ParseDouble(scaleX.Value);
                matrix.ScaleY = CommonFormatter.ParseDouble(scaleY.Value);
                matrix.HasScale = true;
            }

            if (skewX != null || skewY != null) {
                matrix.RotateSkew0 = CommonFormatter.ParseDouble(skewX.Value);
                matrix.RotateSkew1 = CommonFormatter.ParseDouble(skewY.Value);
                matrix.HasRotate = true;
            }

            return matrix;
        }

        public static XElement ToXml(SwfMatrix matrix) {
            var res = new XElement("Transform",
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

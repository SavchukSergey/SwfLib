using System.Xml.Linq;
using Code.SwfLib.Data;

namespace Code.SwfLib.SwfMill.Data {
    public static class XMatrix {

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

using System.Xml.Linq;
using SwfLib.Data;

namespace SwfLib.SwfMill.Data {
    public static class XColorTransformRGB {

        public const string TAG_NAME = "ColorTransform";

        public static ColorTransformRGB FromXml(XElement xTransform) {
            var xFactorRed = xTransform.Attribute("factorRed");
            var xFactorGreen = xTransform.Attribute("factorGreen");
            var xFactorBlue = xTransform.Attribute("factorBlue");

            var xAddRed = xTransform.Attribute("redadd");
            var xAddGreen = xTransform.Attribute("greenadd");
            var xAddBlue = xTransform.Attribute("blueadd");

            return new ColorTransformRGB {
                RedMultTerm = xFactorRed != null ? short.Parse(xFactorRed.Value) : (short)0,
                GreenMultTerm = xFactorGreen != null ? short.Parse(xFactorGreen.Value) : (short)0,
                BlueMultTerm = xFactorBlue != null ? short.Parse(xFactorBlue.Value) : (short)0,
                HasMultTerms = xFactorRed != null || xFactorGreen != null || xFactorBlue != null,

                RedAddTerm = xAddRed != null ? short.Parse(xAddRed.Value) : (short)0,
                GreenAddTerm = xAddGreen != null ? short.Parse(xAddGreen.Value) : (short)0,
                BlueAddTerm = xAddBlue != null ? short.Parse(xAddBlue.Value) : (short)0,
                HasAddTerms = xAddRed != null || xAddGreen != null || xAddBlue != null,
            };
        }

        public static XElement ToXml(ColorTransformRGB transform) {
            var res = new XElement(TAG_NAME);
            if (transform.HasMultTerms) {
                res.Add(new XAttribute("factorRed", transform.RedMultTerm));
                res.Add(new XAttribute("factorGreen", transform.GreenMultTerm));
                res.Add(new XAttribute("factorBlue", transform.BlueMultTerm));
            }
            if (transform.HasAddTerms) {
                res.Add(new XAttribute("redadd", transform.RedAddTerm));
                res.Add(new XAttribute("greenadd", transform.GreenAddTerm));
                res.Add(new XAttribute("blueadd", transform.BlueAddTerm));
            }
            return res;
        }
    }
}

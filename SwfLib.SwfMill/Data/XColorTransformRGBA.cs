using System.Xml.Linq;
using Code.SwfLib.Data;
using SwfLib.Data;

namespace Code.SwfLib.SwfMill.Data {
    public static class XColorTransformRGBA {

        public static ColorTransformRGBA FromXml(XElement xTransform) {
            var xFactorRed = xTransform.Attribute("factorRed");
            var xFactorGreen = xTransform.Attribute("factorGreen");
            var xFactorBlue = xTransform.Attribute("factorBlue");
            var xFactorAlpha = xTransform.Attribute("factorAlpha");

            var xAddRed = xTransform.Attribute("redadd");
            var xAddGreen = xTransform.Attribute("greenadd");
            var xAddBlue = xTransform.Attribute("blueadd");
            var xAddAlpha = xTransform.Attribute("alphaadd");

            return new ColorTransformRGBA {
                RedMultTerm = xFactorRed != null ? short.Parse(xFactorRed.Value) : (short)0,
                GreenMultTerm = xFactorGreen != null ? short.Parse(xFactorGreen.Value) : (short)0,
                BlueMultTerm = xFactorBlue != null ? short.Parse(xFactorBlue.Value) : (short)0,
                AlphaMultTerm = xFactorAlpha != null ? short.Parse(xFactorAlpha.Value) : (short)0,
                HasMultTerms = xFactorRed != null || xFactorGreen != null || xFactorBlue != null || xFactorAlpha != null,

                RedAddTerm = xAddRed != null ? short.Parse(xAddRed.Value) : (short)0,
                GreenAddTerm = xAddGreen != null ? short.Parse(xAddGreen.Value) : (short)0,
                BlueAddTerm = xAddBlue != null ? short.Parse(xAddBlue.Value) : (short)0,
                AlphaAddTerm = xAddAlpha != null ? short.Parse(xAddAlpha.Value) : (short)0,
                HasAddTerms = xAddRed != null || xAddGreen != null || xAddBlue != null || xAddAlpha != null,
            };
        }

        public static XElement ToXml(ColorTransformRGBA transform) {
            var res = new XElement("ColorTransform2");
            if (transform.HasMultTerms) {
                res.Add(new XAttribute("factorRed", transform.RedMultTerm));
                res.Add(new XAttribute("factorGreen", transform.GreenMultTerm));
                res.Add(new XAttribute("factorBlue", transform.BlueMultTerm));
                res.Add(new XAttribute("factorAlpha", transform.AlphaMultTerm));
            }
            if (transform.HasAddTerms) {
                res.Add(new XAttribute("redadd", transform.RedAddTerm));
                res.Add(new XAttribute("greenadd", transform.GreenAddTerm));
                res.Add(new XAttribute("blueadd", transform.BlueAddTerm));
                res.Add(new XAttribute("alphaadd", transform.AlphaAddTerm));
            }
            return res;
        }
    }
}

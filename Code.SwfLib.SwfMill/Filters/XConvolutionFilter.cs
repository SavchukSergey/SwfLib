using System;
using System.Linq;
using System.Xml.Linq;
using Code.SwfLib.Filters;
using Code.SwfLib.SwfMill.Data;
using Code.SwfLib.SwfMill.Utils;

namespace Code.SwfLib.SwfMill.Filters {
    public class XConvolutionFilter {

        public const string TAG_NAME = "ConvolutionFilter";

        public static XElement ToXml(ConvolutionFilter filter) {
            var res = new XElement(TAG_NAME,
                new XAttribute("divisor", CommonFormatter.Format(filter.Divisor)),
                new XAttribute("bias", CommonFormatter.Format(filter.Bias))
            );

            var xMatrix = new XElement("matrix");
            for (var y = 0; y < filter.MatrixY; y++) {
                var xRow = new XElement("r");
                for (var x = 0; x < filter.MatrixX; x++) {
                    var xCol = new XElement("c") { Value = CommonFormatter.Format(filter.Matrix[y, x]) };
                    xRow.Add(xCol);
                }
                xMatrix.Add(xRow);
            }
            res.Add(xMatrix);

            res.Add(new XElement("color", XColorRGBA.ToXml(filter.DefaultColor)));
            if (filter.Reserved != 0) {
                res.Add(new XAttribute("reserved", filter.Reserved));
            }
            res.Add(new XAttribute("clamp", CommonFormatter.Format(filter.Clamp)));
            res.Add(new XAttribute("preserveAlpha", CommonFormatter.Format(filter.PreserveAlpha)));
            return res;
        }

        public static ConvolutionFilter FromXml(XElement xFilter) {
            const string node = "Convolution";
            var xMatrix = xFilter.Element("matrix");
            var xReserved = xFilter.Attribute("reserved");
            var xClamp = xFilter.Attribute("clamp");
            var xPreserveAlpha = xFilter.Attribute("preserveAlpha");

            var filter = new ConvolutionFilter {
                Divisor = xFilter.RequiredDoubleAttribute("divisor", node),
                Bias = xFilter.RequiredDoubleAttribute("bias", node)
            };

            var xRows = xMatrix.Elements().ToList();
            var height = xRows.Count;
            var width = xMatrix.Elements().First().Elements().Count();

            filter.Matrix = new double[height, width];
            for (var y = 0; y < filter.MatrixY; y++) {
                var xRow = xRows[y];
                var xCols = xRow.Elements().ToList();
                for (var x = 0; x < filter.MatrixX; x++) {
                    var xCol = xCols[x];
                    filter.Matrix[y, x] = CommonFormatter.ParseDouble(xCol.Value);
                }
            }

            filter.DefaultColor = XColorRGBA.FromXml(xFilter.Element("color").Element("Color"));
            if (xReserved != null) {
                filter.Reserved = byte.Parse(xReserved.Value);
            }
            filter.Clamp = CommonFormatter.ParseBool(xClamp.Value);
            filter.PreserveAlpha = CommonFormatter.ParseBool(xPreserveAlpha.Value);
            return filter;
        }

    }
}

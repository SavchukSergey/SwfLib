using System.Linq;
using System.Xml.Linq;
using SwfLib.Filters;
using SwfLib.SwfMill.Data;
using SwfLib.SwfMill.Utils;

namespace SwfLib.SwfMill.Filters {
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
            var xMatrix = xFilter.RequiredElement("matrix");
            var xReserved = xFilter.Attribute("reserved");

            var filter = new ConvolutionFilter {
                Divisor = xFilter.RequiredDoubleAttribute("divisor"),
                Bias = xFilter.RequiredDoubleAttribute("bias")
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

            filter.DefaultColor = XColorRGBA.FromXml(xFilter.RequiredElement("color").Element("Color"));
            if (xReserved != null) {
                filter.Reserved = byte.Parse(xReserved.Value);
            }
            filter.Clamp = xFilter.RequiredBoolAttribute("clamp");
            filter.PreserveAlpha = xFilter.RequiredBoolAttribute("preserveAlpha");
            return filter;
        }

    }
}

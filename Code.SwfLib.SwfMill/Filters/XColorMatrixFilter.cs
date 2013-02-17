using System.Xml.Linq;
using Code.SwfLib.Filters;
using Code.SwfLib.SwfMill.Data;
using Code.SwfLib.SwfMill.Utils;

namespace Code.SwfLib.SwfMill.Filters {
    public static class XColorMatrixFilter {

        public const string TAG_NAME = "ColorMatrix";

        public static XElement ToXml(ColorMatrixFilter filter) {
            return new XElement(TAG_NAME,
                new XAttribute("r0", CommonFormatter.Format(filter.R0)),
                new XAttribute("r1", CommonFormatter.Format(filter.R1)),
                new XAttribute("r2", CommonFormatter.Format(filter.R2)),
                new XAttribute("r3", CommonFormatter.Format(filter.R3)),
                new XAttribute("r4", CommonFormatter.Format(filter.R4)),

                new XAttribute("g0", CommonFormatter.Format(filter.G0)),
                new XAttribute("g1", CommonFormatter.Format(filter.G1)),
                new XAttribute("g2", CommonFormatter.Format(filter.G2)),
                new XAttribute("g3", CommonFormatter.Format(filter.G3)),
                new XAttribute("g4", CommonFormatter.Format(filter.G4)),

                new XAttribute("b0", CommonFormatter.Format(filter.B0)),
                new XAttribute("b1", CommonFormatter.Format(filter.B1)),
                new XAttribute("b2", CommonFormatter.Format(filter.B2)),
                new XAttribute("b3", CommonFormatter.Format(filter.B3)),
                new XAttribute("b4", CommonFormatter.Format(filter.B4)),

                new XAttribute("a0", CommonFormatter.Format(filter.A0)),
                new XAttribute("a1", CommonFormatter.Format(filter.A1)),
                new XAttribute("a2", CommonFormatter.Format(filter.A2)),
                new XAttribute("a3", CommonFormatter.Format(filter.A3)),
                new XAttribute("a4", CommonFormatter.Format(filter.A4))
            );
        }

        public static ColorMatrixFilter FromXml(XElement xFilter) {
            const string NODE = "ColorMatrix";
            var xR0 = xFilter.RequiredAttribute("r0", NODE);
            var xR1 = xFilter.RequiredAttribute("r1", NODE);
            var xR2 = xFilter.RequiredAttribute("r2", NODE);
            var xR3 = xFilter.RequiredAttribute("r3", NODE);
            var xR4 = xFilter.RequiredAttribute("r4", NODE);

            var xG0 = xFilter.RequiredAttribute("g0", NODE);
            var xG1 = xFilter.RequiredAttribute("g1", NODE);
            var xG2 = xFilter.RequiredAttribute("g2", NODE);
            var xG3 = xFilter.RequiredAttribute("g3", NODE);
            var xG4 = xFilter.RequiredAttribute("g4", NODE);

            var xB0 = xFilter.RequiredAttribute("b0", NODE);
            var xB1 = xFilter.RequiredAttribute("b1", NODE);
            var xB2 = xFilter.RequiredAttribute("b2", NODE);
            var xB3 = xFilter.RequiredAttribute("b3", NODE);
            var xB4 = xFilter.RequiredAttribute("b4", NODE);

            var xA0 = xFilter.RequiredAttribute("a0", NODE);
            var xA1 = xFilter.RequiredAttribute("a1", NODE);
            var xA2 = xFilter.RequiredAttribute("a2", NODE);
            var xA3 = xFilter.RequiredAttribute("a3", NODE);
            var xA4 = xFilter.RequiredAttribute("a4", NODE);

            return new ColorMatrixFilter {
                R0 = CommonFormatter.ParseDouble(xR0),
                R1 = CommonFormatter.ParseDouble(xR1),
                R2 = CommonFormatter.ParseDouble(xR2),
                R3 = CommonFormatter.ParseDouble(xR3),
                R4 = CommonFormatter.ParseDouble(xR4),

                G0 = CommonFormatter.ParseDouble(xG0),
                G1 = CommonFormatter.ParseDouble(xG1),
                G2 = CommonFormatter.ParseDouble(xG2),
                G3 = CommonFormatter.ParseDouble(xG3),
                G4 = CommonFormatter.ParseDouble(xG4),

                B0 = CommonFormatter.ParseDouble(xB0),
                B1 = CommonFormatter.ParseDouble(xB1),
                B2 = CommonFormatter.ParseDouble(xB2),
                B3 = CommonFormatter.ParseDouble(xB3),
                B4 = CommonFormatter.ParseDouble(xB4),

                A0 = CommonFormatter.ParseDouble(xA0),
                A1 = CommonFormatter.ParseDouble(xA1),
                A2 = CommonFormatter.ParseDouble(xA2),
                A3 = CommonFormatter.ParseDouble(xA3),
                A4 = CommonFormatter.ParseDouble(xA4)
            };
        }

    }
}

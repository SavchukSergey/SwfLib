using System.Xml.Linq;
using Code.SwfLib.Filters;
using Code.SwfLib.SwfMill.Data;

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
            var xR0 = xFilter.Attribute("r0");
            var xR1 = xFilter.Attribute("r1");
            var xR2 = xFilter.Attribute("r2");
            var xR3 = xFilter.Attribute("r3");
            var xR4 = xFilter.Attribute("r4");

            var xG0 = xFilter.Attribute("g0");
            var xG1 = xFilter.Attribute("g1");
            var xG2 = xFilter.Attribute("g2");
            var xG3 = xFilter.Attribute("g3");
            var xG4 = xFilter.Attribute("g4");

            var xB0 = xFilter.Attribute("b0");
            var xB1 = xFilter.Attribute("b1");
            var xB2 = xFilter.Attribute("b2");
            var xB3 = xFilter.Attribute("b3");
            var xB4 = xFilter.Attribute("b4");

            var xA0 = xFilter.Attribute("a0");
            var xA1 = xFilter.Attribute("a1");
            var xA2 = xFilter.Attribute("a2");
            var xA3 = xFilter.Attribute("a3");
            var xA4 = xFilter.Attribute("a4");

            return new ColorMatrixFilter {
                R0 = CommonFormatter.ParseDouble(xR0.Value),
                R1 = CommonFormatter.ParseDouble(xR1.Value),
                R2 = CommonFormatter.ParseDouble(xR2.Value),
                R3 = CommonFormatter.ParseDouble(xR3.Value),
                R4 = CommonFormatter.ParseDouble(xR4.Value),

                G0 = CommonFormatter.ParseDouble(xG0.Value),
                G1 = CommonFormatter.ParseDouble(xG1.Value),
                G2 = CommonFormatter.ParseDouble(xG2.Value),
                G3 = CommonFormatter.ParseDouble(xG3.Value),
                G4 = CommonFormatter.ParseDouble(xG4.Value),

                B0 = CommonFormatter.ParseDouble(xB0.Value),
                B1 = CommonFormatter.ParseDouble(xB1.Value),
                B2 = CommonFormatter.ParseDouble(xB2.Value),
                B3 = CommonFormatter.ParseDouble(xB3.Value),
                B4 = CommonFormatter.ParseDouble(xB4.Value),

                A0 = CommonFormatter.ParseDouble(xA0.Value),
                A1 = CommonFormatter.ParseDouble(xA1.Value),
                A2 = CommonFormatter.ParseDouble(xA2.Value),
                A3 = CommonFormatter.ParseDouble(xA3.Value),
                A4 = CommonFormatter.ParseDouble(xA4.Value)
            };
        }

    }
}

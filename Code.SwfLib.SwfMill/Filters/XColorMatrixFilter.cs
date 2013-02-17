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

            return new ColorMatrixFilter {
                R0 = xFilter.RequiredDoubleAttribute("r0", NODE),
                R1 = xFilter.RequiredDoubleAttribute("r1", NODE),
                R2 = xFilter.RequiredDoubleAttribute("r2", NODE),
                R3 = xFilter.RequiredDoubleAttribute("r3", NODE),
                R4 = xFilter.RequiredDoubleAttribute("r4", NODE),

                G0 = xFilter.RequiredDoubleAttribute("g0", NODE),
                G1 = xFilter.RequiredDoubleAttribute("g1", NODE),
                G2 = xFilter.RequiredDoubleAttribute("g2", NODE),
                G3 = xFilter.RequiredDoubleAttribute("g3", NODE),
                G4 = xFilter.RequiredDoubleAttribute("g4", NODE),

                B0 = xFilter.RequiredDoubleAttribute("b0", NODE),
                B1 = xFilter.RequiredDoubleAttribute("b1", NODE),
                B2 = xFilter.RequiredDoubleAttribute("b2", NODE),
                B3 = xFilter.RequiredDoubleAttribute("b3", NODE),
                B4 = xFilter.RequiredDoubleAttribute("b4", NODE),

                A0 = xFilter.RequiredDoubleAttribute("a0", NODE),
                A1 = xFilter.RequiredDoubleAttribute("a1", NODE),
                A2 = xFilter.RequiredDoubleAttribute("a2", NODE),
                A3 = xFilter.RequiredDoubleAttribute("a3", NODE),
                A4 = xFilter.RequiredDoubleAttribute("a4", NODE)
            };
        }

    }
}

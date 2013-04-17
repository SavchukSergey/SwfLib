using System.Xml.Linq;
using SwfLib.Filters;
using SwfLib.SwfMill.Data;
using SwfLib.SwfMill.Utils;

namespace SwfLib.SwfMill.Filters {
    /// <summary>
    /// Represents ColorMatrixFilter  formatter.
    /// </summary>
    public static class XColorMatrixFilter {

        public const string TAG_NAME = "ColorMatrix";

        /// <summary>
        /// Formats color matrix to xml representation.
        /// </summary>
        /// <param name="filter">Filter to format.</param>
        /// <returns>Filter xml representation.</returns>
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

        /// <summary>
        /// Parse ColorMatrixFilter from xml element.
        /// </summary>
        /// <param name="xFilter">Xml element representing color matrix filter.</param>
        /// <returns>Parsed ColorMatrixFilter.</returns>
        public static ColorMatrixFilter FromXml(XElement xFilter) {
            return new ColorMatrixFilter {
                R0 = xFilter.RequiredDoubleAttribute("r0"),
                R1 = xFilter.RequiredDoubleAttribute("r1"),
                R2 = xFilter.RequiredDoubleAttribute("r2"),
                R3 = xFilter.RequiredDoubleAttribute("r3"),
                R4 = xFilter.RequiredDoubleAttribute("r4"),

                G0 = xFilter.RequiredDoubleAttribute("g0"),
                G1 = xFilter.RequiredDoubleAttribute("g1"),
                G2 = xFilter.RequiredDoubleAttribute("g2"),
                G3 = xFilter.RequiredDoubleAttribute("g3"),
                G4 = xFilter.RequiredDoubleAttribute("g4"),

                B0 = xFilter.RequiredDoubleAttribute("b0"),
                B1 = xFilter.RequiredDoubleAttribute("b1"),
                B2 = xFilter.RequiredDoubleAttribute("b2"),
                B3 = xFilter.RequiredDoubleAttribute("b3"),
                B4 = xFilter.RequiredDoubleAttribute("b4"),

                A0 = xFilter.RequiredDoubleAttribute("a0"),
                A1 = xFilter.RequiredDoubleAttribute("a1"),
                A2 = xFilter.RequiredDoubleAttribute("a2"),
                A3 = xFilter.RequiredDoubleAttribute("a3"),
                A4 = xFilter.RequiredDoubleAttribute("a4")
            };
        }

    }
}

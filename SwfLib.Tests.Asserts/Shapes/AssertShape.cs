using System;
using Code.SwfLib.Shapes.Records;
using NUnit.Framework;
using SwfLib.Shapes.LineStyles;
using SwfLib.Shapes.Records;

namespace SwfLib.Tests.Asserts.Shapes {
    public static class AssertShape {

        public static void AreEqual(IShapeRecord expected, IShapeRecord actual, string message) {
            if (expected is StyleChangeShapeRecord && actual is StyleChangeShapeRecord) {
                AreEqual((StyleChangeShapeRecord)expected, (StyleChangeShapeRecord)actual, message);
            } else if (expected is StraightEdgeShapeRecord && actual is StraightEdgeShapeRecord) {
                AreEqual((StraightEdgeShapeRecord)expected, (StraightEdgeShapeRecord)actual, message);
            } else if (expected is EndShapeRecord && actual is EndShapeRecord) {
                AreEqual((EndShapeRecord)expected, (EndShapeRecord)actual, message);
            } else {
                throw new NotSupportedException(string.Format("{0}: Can't compare {1} and {2}", message,
                                                              expected.GetType(), actual.GetType()));
            }
        }

        public static void AreEqual(StyleChangeShapeRecord expected, StyleChangeShapeRecord actual, string message) {
            Assert.AreEqual(expected.FillStyle0, actual.FillStyle0, "{0}: FillStyle0", message);
            Assert.AreEqual(expected.FillStyle1, actual.FillStyle1, "{0}: FillStyle1", message);
            Assert.AreEqual(expected.LineStyle, actual.LineStyle, "{0}: LineStyle", message);
            Assert.AreEqual(expected.StateMoveTo, actual.StateMoveTo, "{0}: StateMoveTo", message);
            Assert.AreEqual(expected.MoveDeltaX, actual.MoveDeltaX, "{0}: MoveDeltaX", message);
            Assert.AreEqual(expected.MoveDeltaY, actual.MoveDeltaY, "{0}: MoveDeltaY", message);
            Assert.AreEqual(expected.StateNewStyles, actual.StateNewStyles, "{0}: StateNewStyles", message);

            if (expected is StyleChangeShapeRecordRGB && actual is StyleChangeShapeRecordRGB) {
                AreEqual((StyleChangeShapeRecordRGB)expected, (StyleChangeShapeRecordRGB)actual, message);
            } else if (expected is StyleChangeShapeRecordRGBA && actual is StyleChangeShapeRecordRGBA) {
                AreEqual((StyleChangeShapeRecordRGBA)expected, (StyleChangeShapeRecordRGBA)actual, message);
            } else {
                throw new NotSupportedException(string.Format("{0}: Can't compare {1} and {2}", message,
                                                            expected.GetType(), actual.GetType()));
            }
        }

        private static void AreEqual(StyleChangeShapeRecordRGB expected, StyleChangeShapeRecordRGB actual, string message) {
            Assert.AreEqual(expected.FillStyles.Count, actual.FillStyles.Count);
        }

        private static void AreEqual(StyleChangeShapeRecordRGBA expected, StyleChangeShapeRecordRGBA actual, string message) {
            Assert.AreEqual(expected.FillStyles.Count, actual.FillStyles.Count);
        }

        public static void AreEqual(StraightEdgeShapeRecord expected, StraightEdgeShapeRecord actual, string message) {
            Assert.AreEqual(expected.DeltaX, actual.DeltaX, "{0}: DeltaX", message);
            Assert.AreEqual(expected.DeltaY, actual.DeltaY, "{0}: DeltaY", message);
        }

        public static void AreEqual(EndShapeRecord expected, EndShapeRecord actual, string message) {
        }

        public static void AreEqual(LineStyleRGB expected, LineStyleRGB actual, string message) {
            Assert.AreEqual(expected.Width, actual.Width, "Width");
            AssertColors.AreEqual(expected.Color, actual.Color, "Color");
        }

        public static void AreEqual(LineStyleRGBA expected, LineStyleRGBA actual, string message) {
            Assert.AreEqual(expected.Width, actual.Width, "Width");
            AssertColors.AreEqual(expected.Color, actual.Color, "Color");
        }
    }
}

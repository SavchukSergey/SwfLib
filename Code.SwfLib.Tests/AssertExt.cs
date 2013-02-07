using System;
using Code.SwfLib.Data;
using Code.SwfLib.Shapes.FillStyles;
using Code.SwfLib.Shapes.Records;
using Code.SwfLib.Tags.ShapeTags;
using Code.SwfLib.Tests.Asserts;
using NUnit.Framework;

namespace Code.SwfLib.Tests {
    public static class AssertExt {

        public static void AreEqual(byte[] expected, byte[] actual, string message) {
            Assert.AreEqual(expected != null, actual != null, message);
            if (expected == null || actual == null) return;
            var cnt = Math.Max(expected.Length, actual.Length);
            for (var i = 0; i < cnt; i++) {
                if (i >= expected.Length) {
                    Assert.Fail("{0}: Array differs at {1}. Expected: EOF, Actual: {2}", message, i, actual[i]);
                }
                if (i >= actual.Length) {
                    Assert.Fail("{0}: Array differs at {1}. Expected: {2}, Actual: EOF", message, i, expected[i]);
                }
                Assert.AreEqual(expected[i], actual[i], "{0}: Array differs at {1}. Expected: {2}, Actual: {3}", message, i, expected[i], actual[i]);
            }
        }

        public static void AreEqual(DefineShapeTag expected, DefineShapeTag actual) {
            Assert.AreEqual(expected.ShapeID, actual.ShapeID);
            AreEqual(expected.ShapeBounds, actual.ShapeBounds, "ShapeBounds");
            Assert.AreEqual(expected.FillStyles.Count, actual.FillStyles.Count, "FillStyles.Count");
            for (var i = 0; i < expected.FillStyles.Count; i++) {
                var exp = expected.FillStyles[i];
                var act = actual.FillStyles[i];
                AssertFillStyles.AreEqual(exp, act, "FillStyles[" + i + "]");
            }
            Assert.AreEqual(expected.LineStyles.Count, actual.LineStyles.Count, "LineStyles.Count");
            for (var i = 0; i < expected.LineStyles.Count; i++) {
                var exp = expected.LineStyles[i];
                var act = actual.LineStyles[i];
                AreEqual(exp, act, "LineStyles[" + i + "]");
            }
            Assert.AreEqual(expected.ShapeRecords.Count, actual.ShapeRecords.Count, "ShapeRecords.Count");
            for (var i = 0; i < expected.ShapeRecords.Count; i++) {
                var exp = expected.ShapeRecords[i];
                var act = actual.ShapeRecords[i];
                AreEqual(exp, act, "ShapeRecords[" + i + "]");
            }
        }

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

        public static void AreEqual(SwfMatrix expected, SwfMatrix actual, string message) {
            Assert.AreEqual(expected.HasScale, actual.HasScale, message + ": HasScale");
            Assert.AreEqual(expected.HasRotate, actual.HasRotate, message + ": HasRotate");

            Assert.AreEqual(expected.ScaleX, actual.ScaleX, message + ": ScaleX");
            Assert.AreEqual(expected.ScaleY, actual.ScaleY, message + ": ScaleY");
            Assert.AreEqual(expected.RotateSkew0, actual.RotateSkew0, message + ": RotateSkew0");
            Assert.AreEqual(expected.RotateSkew1, actual.RotateSkew1, message + ": RotateSkew1");
            Assert.AreEqual(expected.TranslateX, actual.TranslateX, message + ": TranslateX");
            Assert.AreEqual(expected.TranslateY, actual.TranslateY, message + ": TranslateY");
        }

        public static void AreEqual(SwfRect actual, SwfRect expected, string message) {
            Assert.AreEqual(expected.XMin, actual.XMin, message + ": XMin");
            Assert.AreEqual(expected.XMax, actual.XMax, message + ": XMax");
            Assert.AreEqual(expected.YMin, actual.YMin, message + ": YMin");
            Assert.AreEqual(expected.YMax, actual.YMax, message + ": YMax");
        }
    }
}

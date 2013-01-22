using System;
using Code.SwfLib.Data;
using Code.SwfLib.Data.FillStyles;
using Code.SwfLib.Data.Gradients;
using Code.SwfLib.Data.LineStyles;
using Code.SwfLib.Data.Shapes;
using Code.SwfLib.Tags.ShapeTags;
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
                AreEqual(exp, act, "FillStyles[" + i + "]");
            }
            Assert.AreEqual(expected.Shapes.LineStyles.Count, actual.Shapes.LineStyles.Count, "LineStyles.Count");
            for (var i = 0; i < expected.Shapes.LineStyles.Count; i++) {
                var exp = expected.Shapes.LineStyles[i];
                var act = actual.Shapes.LineStyles[i];
                AreEqual(exp, act, "LineStyles[" + i + "]");
            }
            Assert.AreEqual(expected.Shapes.ShapeRecords.Count, actual.Shapes.ShapeRecords.Count, "ShapeRecords.Count");
            for (var i = 0; i < expected.Shapes.ShapeRecords.Count; i++) {
                var exp = expected.Shapes.ShapeRecords[i];
                var act = actual.Shapes.ShapeRecords[i];
                AreEqual(exp, act, "ShapeRecords[" + i + "]");
            }
        }

        public static void AreEqual(ShapeRecord expected, ShapeRecord actual, string message) {
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
            Assert.AreEqual(expected.MoveDeltaX, actual.MoveDeltaX, "{0}: MoveDeltaX", message);
            Assert.AreEqual(expected.MoveDeltaY, actual.MoveDeltaY, "{0}: MoveDeltaY", message);
        }

        public static void AreEqual(StraightEdgeShapeRecord expected, StraightEdgeShapeRecord actual, string message) {
            Assert.AreEqual(expected.DeltaX, actual.DeltaX, "{0}: DeltaX", message);
            Assert.AreEqual(expected.DeltaY, actual.DeltaY, "{0}: DeltaY", message);
        }

        public static void AreEqual(EndShapeRecord expected, EndShapeRecord actual, string message) {
        }

        public static void AreEqual(LineStyleRGB expected, LineStyleRGB rgb, string s) {
            throw new NotImplementedException();
        }

        public static void AreEqual(FillStyle expected, FillStyle actual, string message) {
            Assert.AreEqual(expected.BitmapID, actual.BitmapID, "BitmapID");
            AreEqual(expected.BitmapMatrix, actual.BitmapMatrix, "BitmapMatrix");
            AreEqual(expected.ColorRGB, actual.ColorRGB, "ColorRGB");
            AreEqual(expected.ColorRGBA, actual.ColorRGBA, "ColorRGBA");
            Assert.AreEqual(expected.FillStyleType, actual.FillStyleType, "FillStyleType");
            AreEqual(expected.FocalGradient, actual.FocalGradient, "FocalGradient");
            AreEqual(expected.Gradient, actual.Gradient, "Gradient");
            AreEqual(expected.GradientMatrix, actual.GradientMatrix, "GradientMatrix");
        }

        public static void AreEqual(GradientRGB expected, GradientRGB actual, string message) {
            Assert.AreEqual(expected.SpreadMode, actual.SpreadMode, message + ": SpreadMode");
            Assert.AreEqual(expected.InterpolationMode, actual.InterpolationMode, message + ": InterpolationMode");
            Assert.AreEqual(expected.GradientRecords.Count, actual.GradientRecords.Count, message + ": GradientRecords.Count");
            for (var i = 0; i < expected.GradientRecords.Count; i++) {
                var exp = expected.GradientRecords[i];
                var act = actual.GradientRecords[i];
                AreEqual(exp, act, message + ": GradientRecords[" + i + "]");
            }
        }

        public static void AreEqual(GradientRecordRGB expected, GradientRecordRGB actual, string message) {
            Assert.AreEqual(expected.Ratio, actual.Ratio, message + ": Ratio");
            AreEqual(expected.Color, actual.Color, message + ": Color");
        }

        public static void AreEqual(FocalGradient expected, FocalGradient actual, string message) {
            //TODO: Implement
        }

        public static void AreEqual(SwfRGBA expected, SwfRGBA actual, string message) {
            Assert.AreEqual(expected.Red, actual.Red, message + ": Red");
            Assert.AreEqual(expected.Green, actual.Green, message + ": Green");
            Assert.AreEqual(expected.Blue, actual.Blue, message + ": Blue");
            Assert.AreEqual(expected.Alpha, actual.Alpha, message + ": Alpha");
        }

        public static void AreEqual(SwfRGB expected, SwfRGB actual, string message) {
            Assert.AreEqual(expected.Red, actual.Red, message + ": Red");
            Assert.AreEqual(expected.Green, actual.Green, message + ": Green");
            Assert.AreEqual(expected.Blue, actual.Blue, message + ": Blue");
        }

        public static void AreEqual(SwfMatrix expected, SwfMatrix actual, string message) {
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

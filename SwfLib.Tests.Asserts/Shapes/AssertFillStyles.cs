using System;
using Code.SwfLib.Shapes.FillStyles;
using NUnit.Framework;
using SwfLib.Shapes.FillStyles;
using SwfLib.Tests.Asserts;

namespace Code.SwfLib.Tests.Asserts.Shapes {
    public static class AssertFillStyles {

        public static void AreEqual(FillStyleRGB expected, FillStyleRGB actual, string message) {
            Assert.AreEqual(expected.Type, actual.Type);

            if (expected is SolidFillStyleRGB && actual is SolidFillStyleRGB) {
                AreEqual((SolidFillStyleRGB)expected, (SolidFillStyleRGB)actual, message);
            } else if (expected is LinearGradientFillStyleRGB && actual is LinearGradientFillStyleRGB) {
                AreEqual((LinearGradientFillStyleRGB)expected, (LinearGradientFillStyleRGB)actual, message);
            } else if (expected is BitmapFillStyleRGB && actual is BitmapFillStyleRGB) {
                AreEqual((BitmapFillStyleRGB)expected, (BitmapFillStyleRGB)actual, message);
            } else {
                throw new NotSupportedException();
            }
        }

        public static void AreEqual(FillStyleRGBA expected, FillStyleRGBA actual, string message) {
            Assert.AreEqual(expected.Type, actual.Type);

            if (expected is SolidFillStyleRGBA && actual is SolidFillStyleRGBA) {
                AreEqual((SolidFillStyleRGBA)expected, (SolidFillStyleRGBA)actual, message);
            } else if (expected is LinearGradientFillStyleRGBA && actual is LinearGradientFillStyleRGBA) {
                AreEqual((LinearGradientFillStyleRGBA)expected, (LinearGradientFillStyleRGBA)actual, message);
            } else if (expected is BitmapFillStyleRGBA && actual is BitmapFillStyleRGBA) {
                AreEqual((BitmapFillStyleRGBA)expected, (BitmapFillStyleRGBA)actual, message);
            } else {
                throw new NotSupportedException();
            }
        }

        public static void AreEqual(SolidFillStyleRGB expected, SolidFillStyleRGB actual, string message) {
            AssertColors.AreEqual(expected.Color, actual.Color, "Color");
        }

        public static void AreEqual(SolidFillStyleRGBA expected, SolidFillStyleRGBA actual, string message) {
            AssertColors.AreEqual(expected.Color, actual.Color, "Color");
        }

        public static void AreEqual(LinearGradientFillStyleRGB expected, LinearGradientFillStyleRGB actual, string message) {
            AssertData.AreEqual(expected.GradientMatrix, actual.GradientMatrix, message);
            AssertGradients.AreEqual(expected.Gradient, actual.Gradient, message + ".Gradient");
        }

        public static void AreEqual(LinearGradientFillStyleRGBA expected, LinearGradientFillStyleRGBA actual, string message) {
            AssertData.AreEqual(expected.GradientMatrix, actual.GradientMatrix, message);
            AssertGradients.AreEqual(expected.Gradient, actual.Gradient, message + ".Gradient");
        }

        public static void AreEqual(BitmapFillStyleRGB expected, BitmapFillStyleRGB actual, string message) {
            Assert.AreEqual(expected.Mode, actual.Mode, message + ".Mode");
            Assert.AreEqual(expected.Smoothing, actual.Smoothing, message + ".Smoothing");
            Assert.AreEqual(expected.BitmapID, actual.BitmapID, "BitmapID");
            AssertData.AreEqual(expected.BitmapMatrix, actual.BitmapMatrix, "BitmapMatrix");
        }

        public static void AreEqual(BitmapFillStyleRGBA expected, BitmapFillStyleRGBA actual, string message) {
            Assert.AreEqual(expected.Mode, actual.Mode, message + ".Mode");
            Assert.AreEqual(expected.Smoothing, actual.Smoothing, message + ".Smoothing");
            Assert.AreEqual(expected.BitmapID, actual.BitmapID, "BitmapID");
            AssertData.AreEqual(expected.BitmapMatrix, actual.BitmapMatrix, "BitmapMatrix");
        }

    }
}

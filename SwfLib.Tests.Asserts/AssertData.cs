using NUnit.Framework;
using SwfLib.Data;

namespace SwfLib.Tests.Asserts {
    public static class AssertData {

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

        public static void AreEqual(ColorTransformRGB expected, ColorTransformRGB actual, string message) {
            Assert.AreEqual(expected.HasAddTerms, actual.HasAddTerms, message + ".HasAddTerms");
            Assert.AreEqual(expected.HasMultTerms, actual.HasMultTerms, message + ".HasMultTerms");

            Assert.AreEqual(expected.RedAddTerm, actual.RedAddTerm, message + ".RedAddTerm");
            Assert.AreEqual(expected.GreenAddTerm, actual.GreenAddTerm, message + ".GreenAddTerm");
            Assert.AreEqual(expected.BlueAddTerm, actual.BlueAddTerm, message + ".BlueAddTerm");

            Assert.AreEqual(expected.RedMultTerm, actual.RedMultTerm, message + ".RedMultTerm");
            Assert.AreEqual(expected.GreenMultTerm, actual.GreenMultTerm, message + ".GreenMultTerm");
            Assert.AreEqual(expected.BlueMultTerm, actual.BlueMultTerm, message + ".BlueMultTerm");
        }

        public static void AreEqual(ColorTransformRGBA expected, ColorTransformRGBA actual, string message) {
            Assert.AreEqual(expected.HasAddTerms, actual.HasAddTerms, message + ".HasAddTerms");
            Assert.AreEqual(expected.HasMultTerms, actual.HasMultTerms, message + ".HasMultTerms");

            Assert.AreEqual(expected.RedAddTerm, actual.RedAddTerm, message + ".RedAddTerm");
            Assert.AreEqual(expected.GreenAddTerm, actual.GreenAddTerm, message + ".GreenAddTerm");
            Assert.AreEqual(expected.BlueAddTerm, actual.BlueAddTerm, message + ".BlueAddTerm");
            Assert.AreEqual(expected.AlphaAddTerm, actual.AlphaAddTerm, message + ".AlphaAddTerm");

            Assert.AreEqual(expected.RedMultTerm, actual.RedMultTerm, message + ".RedMultTerm");
            Assert.AreEqual(expected.GreenMultTerm, actual.GreenMultTerm, message + ".GreenMultTerm");
            Assert.AreEqual(expected.BlueMultTerm, actual.BlueMultTerm, message + ".BlueMultTerm");
            Assert.AreEqual(expected.AlphaMultTerm, actual.AlphaMultTerm, message + ".AlphaMultTerm");
        }
    }
}

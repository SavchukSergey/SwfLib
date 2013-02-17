using Code.SwfLib.Data;
using NUnit.Framework;

namespace Code.SwfLib.Tests.Asserts {
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

    }
}

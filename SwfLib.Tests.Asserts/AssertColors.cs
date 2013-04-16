using Code.SwfLib.Data;
using NUnit.Framework;
using SwfLib.Data;

namespace SwfLib.Tests.Asserts {
    public static class AssertColors {
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
    }
}

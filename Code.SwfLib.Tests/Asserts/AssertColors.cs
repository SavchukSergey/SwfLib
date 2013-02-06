using Code.SwfLib.Data;
using NUnit.Framework;

namespace Code.SwfLib.Tests.Asserts {
    public static class AssertColors {
        public static void AreEqual(SwfRGBA expected, SwfRGBA actual, string message) {
            Assert.AreEqual(expected.Red, actual.Red, message + ": Red");
            Assert.AreEqual(expected.Green, actual.Green, message + ": Green");
            Assert.AreEqual(expected.Blue, actual.Blue, message + ": Blue");
            Assert.AreEqual(expected.Alpha, actual.Alpha, message + ": Alpha");
        }
    }
}

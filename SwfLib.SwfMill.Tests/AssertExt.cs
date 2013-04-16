using NUnit.Framework;

namespace SwfLib.SwfMill.Tests {
    public static class AssertExt {

        public static void AreEqual(byte[] expected, byte[] actual, string message) {
            Assert.AreEqual(expected != null, actual != null, message);
            if (expected == null || actual == null) return;
            Assert.AreEqual(expected.Length, actual.Length, message);
            for (var i = 0; i < expected.Length; i++) {
                Assert.AreEqual(expected[i], actual[i], "Array differs at " + i + "." + message);
            }
        }
    }
}
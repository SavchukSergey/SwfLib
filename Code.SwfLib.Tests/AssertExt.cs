using System;
using NUnit.Framework;

namespace Code.SwfLib.Tests {
    public static class AssertExt {

        //TODO: remove
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

     
    }
}

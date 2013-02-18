using Code.SwfLib.Actions;
using NUnit.Framework;

namespace Code.SwfLib.Tests.Asserts {
    public static class AssertAction {

        public static void AreEqual(ActionPush expected, ActionPush actual, string message) {
            Assert.AreEqual(expected.Items.Count, actual.Items.Count, message + ".Items.Count");
            for (var i = 0; i < expected.Items.Count; i++) {
                AreEqual(expected.Items[i], actual.Items[i], message + ".Items[" + i + "]");
            }
        }

        public static void AreEqual(ActionPushItem expected, ActionPushItem actual, string message) {
            Assert.AreEqual(expected.Type, actual.Type, message + ".Type");

            Assert.AreEqual(expected.Boolean, actual.Boolean, message + ".Boolean");
            Assert.AreEqual(expected.Constant16, actual.Constant16, message + ".Constant16");
            Assert.AreEqual(expected.Constant8, actual.Constant8, message + ".Constant8");
            Assert.AreEqual(expected.Double, actual.Double, message + ".Double");
            Assert.AreEqual(expected.Float, actual.Float, message + ".Float");
            Assert.AreEqual(expected.Integer, actual.Integer, message + ".Integer");
            Assert.AreEqual(expected.Register, actual.Register, message + ".Register");
            Assert.AreEqual(expected.String, actual.String, message + ".String");
        }
    }
}

using System;
using NUnit.Framework;
using SwfLib.Actions;

namespace SwfLib.Tests.Asserts {
    public static class AssertAction {

        public static void AreEqual(ActionDefineFunction2 expected, ActionDefineFunction2 actual, string message) {
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.RegisterCount, actual.RegisterCount);
            Assert.AreEqual(expected.PreloadParent, actual.PreloadParent);
            Assert.AreEqual(expected.PreloadRoot, actual.PreloadRoot);
            Assert.AreEqual(expected.SuppressSuper, actual.SuppressSuper);
            Assert.AreEqual(expected.PreloadSuper, actual.PreloadSuper);
            Assert.AreEqual(expected.SuppressArguments, actual.SuppressArguments);
            Assert.AreEqual(expected.PreloadArguments, actual.PreloadArguments);
            Assert.AreEqual(expected.SuppressThis, actual.SuppressThis);
            Assert.AreEqual(expected.PreloadThis, actual.PreloadThis);

            Assert.AreEqual(expected.Reserved, actual.Reserved);
            Assert.AreEqual(expected.PreloadGlobal, actual.PreloadGlobal);

            Assert.AreEqual(expected.Parameters.Count, actual.Parameters.Count, message + ".Parameters.Count");
            for (var i = 0; i < expected.Parameters.Count; i++) {
                AreEqual(expected.Parameters[i], actual.Parameters[i], message + ".Parameters[" + i + "]");
            }

            Assert.AreEqual(expected.Actions.Count, actual.Actions.Count, message + ".Actions.Count");
            for (var i = 0; i < expected.Actions.Count; i++) {
                AreEqual(expected.Actions[i], actual.Actions[i], message + ".Parameters[" + i + "]");
            }
        }

        public static void AreEqual(ActionWith expected, ActionWith actual, string message) {
            Assert.AreEqual(expected.Actions.Count, actual.Actions.Count, message + ".Actions.Count");
            for (var i = 0; i < expected.Actions.Count; i++) {
                AreEqual(expected.Actions[i], actual.Actions[i], message + ".Parameters[" + i + "]");
            }
        }

        public static void AreEqual(ActionPush expected, ActionPush actual, string message) {
            Assert.AreEqual(expected.Items.Count, actual.Items.Count, message + ".Items.Count");
            for (var i = 0; i < expected.Items.Count; i++) {
                AreEqual(expected.Items[i], actual.Items[i], message + ".Actions[" + i + "]");
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

        public static void AreEqual(RegisterParam expected, RegisterParam actual, string message) {
            Assert.AreEqual(expected.Name, actual.Name, message + ".Name");
            Assert.AreEqual(expected.Register, actual.Register, message + ".Register");
        }

        public static void AreEqual(ActionBase expected, ActionBase actual, string message) {
            Assert.AreEqual(expected.ActionCode, actual.ActionCode, message + ".ActionCode");
            if ((byte)expected.ActionCode < 0x80) {
                Assert.IsAssignableFrom(expected.GetType(), actual);
            } else {
                throw new NotImplementedException();
            }
        }
    }
}

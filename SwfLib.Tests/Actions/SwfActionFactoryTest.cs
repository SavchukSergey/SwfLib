using System;
using Code.SwfLib.Actions;
using NUnit.Framework;
using SwfLib.Actions;

namespace SwfLib.Tests.Actions {
    [TestFixture]
    public class SwfActionsFactoryTest {

        [Test]
        public void AllActionsBuildTest() {
            var factory = new ActionsFactory();
            var vals = Enum.GetValues(typeof(ActionCode));
            foreach (ActionCode type in vals) {
                var action = factory.Create(type);
                Assert.IsNotNull(action);
                if (action.GetType().Name != "Action" + type.ToString()) {
                    Console.WriteLine("Warning: Incosistent naming, Action code: {0}, Class: {1}", type, action.GetType().Name);
                }
                var actualType = action.ActionCode;
                Assert.AreEqual(type, actualType);
            }
        }
    }
}

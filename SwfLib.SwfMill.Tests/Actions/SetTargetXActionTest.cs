using NUnit.Framework;
using SwfLib.Actions;

namespace SwfLib.SwfMill.Tests.Actions {
    [TestFixture]
    public class SetTargetXActionTest : BaseXActionTest {
        private const string _etalon = @"<SetTarget label='abcd' />";

        [Test]
        public void ReadTest() {
            var action = ReadAction<ActionSetTarget>(_etalon);
            Assert.AreEqual("abcd", action.TargetName);
        }

        [Test]
        public void WriteTest() {
            WriteAction(new ActionSetTarget { TargetName = "abcd" }, _etalon);
        }

    }
}

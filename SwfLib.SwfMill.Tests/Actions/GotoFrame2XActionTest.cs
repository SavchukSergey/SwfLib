using Code.SwfLib.Actions;
using NUnit.Framework;
using SwfLib.Actions;
using SwfLib.SwfMill.Tests.Actions;

namespace Code.SwfLib.SwfMill.Tests.Actions {
    [TestFixture]
    public class GotoFrame2XActionTest : BaseXActionTest {
        private const string _etalon = @"<GotoExpression play='1' bias='18' />";

        [Test]
        public void ReadTest() {
            var action = ReadAction<ActionGotoFrame2>(_etalon);
            Assert.IsTrue(action.Play);
            Assert.AreEqual(0x12, action.SceneBias);
        }

        [Test]
        public void WriteTest() {
            WriteAction(new ActionGotoFrame2 { SceneBias = 0x12, Play = true }, _etalon);
        }
    }
}

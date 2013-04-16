using Code.SwfLib.Actions;
using Code.SwfLib.Tests.Actions;
using NUnit.Framework;
using SwfLib.Actions;

namespace SwfLib.Tests.Actions {
    [TestFixture]
    public class GotoFrame2ActionTest : BaseActionTest {

        private readonly byte[] _etalon = new byte[] { 0x9f, 0x03, 0x00, 0x03, 0x12, 0x00 };

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

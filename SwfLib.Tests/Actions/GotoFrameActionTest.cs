using Code.SwfLib.Actions;
using NUnit.Framework;
using SwfLib.Actions;
using SwfLib.Tests.Actions;

namespace Code.SwfLib.Tests.Actions {
    [TestFixture]
    public class GotoFrameActionTest : BaseActionTest {

        private readonly byte[] _etalon = new byte[] { 0x81, 0x02, 0x00, 0x34, 0x12 };

        [Test]
        public void ReadTest() {
            var action = ReadAction<ActionGotoFrame>(_etalon);
            Assert.AreEqual(0x1234, action.Frame);
        }

        [Test]
        public void WriteTest() {
            WriteAction(new ActionGotoFrame { Frame = 0x1234 }, _etalon);
        }
    }
}

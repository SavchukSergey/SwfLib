using Code.SwfLib.Actions;
using NUnit.Framework;

namespace Code.SwfLib.Tests.Actions {
    [TestFixture]
    public class WaitForFrameActionTest : BaseActionTest {

        private readonly byte[] _etalon = new byte[] { 0x8a, 0x03, 0x00, 0x34, 0x12, 0x05 };

        [Test]
        public void ReadTest() {
            var action = ReadAction<ActionWaitForFrame>(_etalon);
            Assert.AreEqual(0x1234, action.Frame);
            Assert.AreEqual(0x05, action.SkipCount);
        }

        [Test]
        public void WriteTest() {
            WriteAction(new ActionWaitForFrame { Frame = 0x1234, SkipCount = 0x05}, _etalon);
        }
    }
}

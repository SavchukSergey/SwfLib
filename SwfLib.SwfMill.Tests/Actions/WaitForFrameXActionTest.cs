using Code.SwfLib.Actions;
using NUnit.Framework;
using SwfLib.SwfMill.Tests.Actions;

namespace Code.SwfLib.SwfMill.Tests.Actions {
    [TestFixture]
    public class WaitForFrameXActionTest : BaseXActionTest {
        private const string _etalon = @"<WaitForFrame frame='4660' skipCount='5' />";

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

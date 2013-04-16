using Code.SwfLib.Actions;
using Code.SwfLib.SwfMill.Tests.Actions;
using NUnit.Framework;

namespace SwfLib.SwfMill.Tests.Actions {
    [TestFixture]
    public class GotoFrameXActionTest : BaseXActionTest {
        private const string _etalon = @"<GotoFrame frame='4660' />";

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

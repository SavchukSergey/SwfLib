using Code.SwfLib.Actions;
using NUnit.Framework;

namespace Code.SwfLib.SwfMill.Tests.Actions {
    [TestFixture]
    public class GotoFrameXActionTest : BaseXActionTest {
        private const string _etalon = @"<GoToFrame frame='4660' />";

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

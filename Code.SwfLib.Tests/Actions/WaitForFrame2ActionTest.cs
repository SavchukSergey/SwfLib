using Code.SwfLib.Actions;
using NUnit.Framework;

namespace Code.SwfLib.Tests.Actions {
    [TestFixture]
    public class WaitForFrame2ActionTest : BaseActionTest {

        private readonly byte[] _etalon = new byte[] { 0x8d, 0x01, 0x00, 0x34 };

        [Test]
        public void ReadTest() {
            var action = ReadAction<ActionWaitForFrame2>(_etalon);
            Assert.AreEqual(0x34, action.SkipCount);
        }

        [Test]
        public void WriteTest() {
            WriteAction(new ActionWaitForFrame2 { SkipCount = 0x34}, _etalon);
        }
    }
}

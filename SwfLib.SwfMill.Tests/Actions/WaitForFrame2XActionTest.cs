using NUnit.Framework;
using SwfLib.Actions;
using SwfLib.SwfMill.Tests.Actions;

namespace Code.SwfLib.SwfMill.Tests.Actions {
    [TestFixture]
    public class WaitForFrame2XActionTest : BaseXActionTest {
        private const string _etalon = @"<WaitForFrame2 skipCount='52' />";

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

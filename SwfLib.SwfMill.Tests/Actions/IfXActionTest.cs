using Code.SwfLib.Actions;
using Code.SwfLib.SwfMill.Tests.Actions;
using NUnit.Framework;

namespace SwfLib.SwfMill.Tests.Actions {
    public class IfXActionTest : BaseXActionTest {
        private const string _etalon = @"<BranchIfTrue byteOffset='1' />";

        [Test]
        public void ReadTest() {
            var action = ReadAction<ActionIf>(_etalon);
            Assert.IsNotNull(action);
            Assert.AreEqual(action.BranchOffset, 1);
        }

        [Test]
        public void WriteTest() {
            WriteAction(new ActionIf { BranchOffset = 1 }, _etalon);
        }
    }
}

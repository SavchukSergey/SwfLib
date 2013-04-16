using Code.SwfLib.Actions;
using Code.SwfLib.Tests.Actions;
using NUnit.Framework;

namespace SwfLib.Tests.Actions {
    public class JumpActionTest : BaseActionTest {

        private readonly byte[] _etalon = new byte[] { 0x99, 0x02, 0x00, 0x01, 0x00 };

        [Test]
        public void ReadTest() {
            var action = ReadAction<ActionJump>(_etalon);
            Assert.IsNotNull(action);
            Assert.AreEqual(action.BranchOffset, 1);
        }

        [Test]
        public void WriteTest() {
            WriteAction(new ActionJump { BranchOffset = 1 }, _etalon);
        }
    }
}

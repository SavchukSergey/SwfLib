using Code.SwfLib.Actions;
using NUnit.Framework;
using SwfLib.Actions;
using SwfLib.SwfMill.Tests.Actions;

namespace Code.SwfLib.SwfMill.Tests.Actions {
    public class JumpXActionTest : BaseXActionTest {

        private const string _etalon = @"<BranchAlways byteOffset='1' />";

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

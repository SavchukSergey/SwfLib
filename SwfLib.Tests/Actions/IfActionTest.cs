using Code.SwfLib.Actions;
using NUnit.Framework;
using SwfLib.Actions;
using SwfLib.Tests.Actions;

namespace Code.SwfLib.Tests.Actions {
    public class IfActionTest : BaseActionTest {

        private readonly byte[] _etalon = new byte[] { 0x9d, 0x02, 0x00, 0x01, 0x00 };

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

using Code.SwfLib.Actions;
using NUnit.Framework;

namespace Code.SwfLib.Tests.Actions {
    public class CallActionTest : BaseActionTest {

        private readonly byte[] _etalon = new byte[] { 0x9e, 0x00, 0x00 };

        [Test]
        public void ReadTest() {
            var action = ReadAction<ActionCall>(_etalon);
            Assert.IsNotNull(action);
        }

        [Test]
        public void WriteTest() {
            WriteAction(new ActionCall { }, _etalon);
        }
    }
}

using NUnit.Framework;
using SwfLib.Actions;
using SwfLib.Tests.Actions;

namespace Code.SwfLib.Tests.Actions {
    [TestFixture]
    public class GoToLabelActionTest : BaseActionTest {

        private readonly byte[] _etalon = new byte[] { 0x8c, 0x05, 0x00, (byte)'a', (byte)'b', (byte)'c', (byte)'d', 0x00 };

        [Test]
        public void ReadTest() {
            var action = ReadAction<ActionGoToLabel>(_etalon);
            Assert.AreEqual("abcd", action.Label);
        }

        [Test]
        public void WriteTest() {
            WriteAction(new ActionGoToLabel { Label = "abcd" }, _etalon);
        }

    }
}

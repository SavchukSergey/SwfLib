using Code.SwfLib.Actions;
using NUnit.Framework;
using SwfLib.Tests.Actions;

namespace Code.SwfLib.Tests.Actions {
    [TestFixture]
    public class SetTargetActionTest : BaseActionTest {

        private readonly byte[] _etalon = new byte[] { 0x8b, 0x05, 0x00, (byte)'a', (byte)'b', (byte)'c', (byte)'d', 0x00 };

        [Test]
        public void ReadTest() {
            var action = ReadAction<ActionSetTarget>(_etalon);
            Assert.AreEqual("abcd", action.TargetName);
        }

        [Test]
        public void WriteTest() {
            WriteAction(new ActionSetTarget { TargetName = "abcd" }, _etalon);
        }

    }
}

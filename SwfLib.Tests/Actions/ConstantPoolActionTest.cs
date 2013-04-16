using Code.SwfLib.Actions;
using Code.SwfLib.Tests.Actions;
using NUnit.Framework;
using SwfLib.Actions;

namespace SwfLib.Tests.Actions {
    [TestFixture]
    public class ConstantPoolActionTest : BaseActionTest {

        private readonly byte[] _etalon = new byte[] { 0x88, 0x08, 0x00, 0x02, 0x00, (byte)'a', (byte)'b', 0x00, (byte)'c', (byte)'d', 0x00 };

        [Test]
        public void ReadTest() {
            var action = ReadAction<ActionConstantPool>(_etalon);
            Assert.AreEqual(2, action.ConstantPool.Count);
            Assert.AreEqual("ab", action.ConstantPool[0]);
            Assert.AreEqual("cd", action.ConstantPool[1]);
        }

        [Test]
        public void WriteTest() {
            WriteAction(new ActionConstantPool { ConstantPool = { "ab", "cd" } }, _etalon);
        }

    }
}

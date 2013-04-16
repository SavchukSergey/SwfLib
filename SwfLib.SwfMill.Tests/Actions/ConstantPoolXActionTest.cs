using Code.SwfLib.Actions;
using NUnit.Framework;
using SwfLib.SwfMill.Tests.Actions;

namespace Code.SwfLib.SwfMill.Tests.Actions {
    [TestFixture]
    public class ConstantPoolXActionTest : BaseXActionTest {
        
        private const string _etalon = @"<Dictionary>
    <strings>
        <String value='ab' />
        <String value='cd' />
    </strings>
</Dictionary>";

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

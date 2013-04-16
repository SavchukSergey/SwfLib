using Code.SwfLib.Actions;
using NUnit.Framework;
using SwfLib.Tests.Actions;

namespace Code.SwfLib.Tests.Actions {
    [TestFixture]
    public class StoreRegisterActionTest : BaseActionTest {

        private readonly byte[] _etalon = new byte[] { 0x87, 0x01, 0x00, 0x15 };

        [Test]
        public void ReadTest() {
            var action = ReadAction<ActionStoreRegister>(_etalon);
            Assert.AreEqual(0x15, action.RegisterNumber);
        }

        [Test]
        public void WriteTest() {
            WriteAction(new ActionStoreRegister { RegisterNumber = 0x15 }, _etalon);
        }
    }
}

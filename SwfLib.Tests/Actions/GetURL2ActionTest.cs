using NUnit.Framework;
using SwfLib.Actions;

namespace SwfLib.Tests.Actions {
    [TestFixture]
    public class GetURL2ActionTest : BaseActionTest {

        private readonly byte[] _etalon = new byte[] { 0x9a, 0x01, 0x00, 0x80 };

        [Test]
        public void ReadTest() {
            var action = ReadAction<ActionGetURL2>(_etalon);
            Assert.AreEqual(0x80, action.Flags);
        }

        [Test]
        public void WriteTest() {
            WriteAction(new ActionGetURL2 { Flags = 0x80}, _etalon);
        }
    }
}

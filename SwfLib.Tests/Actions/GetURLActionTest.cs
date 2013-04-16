using Code.SwfLib.Actions;
using NUnit.Framework;
using SwfLib.Tests.Actions;

namespace Code.SwfLib.Tests.Actions {
    [TestFixture]
    public class GetURLActionTest : BaseActionTest {

        private readonly byte[] _etalon = new byte[] { 0x83, 0x06, 0x00, (byte) 'a', (byte) 'b', 0x00, (byte) 'c', (byte) 'd', 0x00 };

        [Test]
        public void ReadTest() {
            var action = ReadAction<ActionGetURL>(_etalon);
            Assert.AreEqual("ab", action.UrlString);
            Assert.AreEqual("cd", action.TargetString);
        }

        [Test]
        public void WriteTest() {
            WriteAction(new ActionGetURL { UrlString = "ab", TargetString = "cd"}, _etalon);
        }
    }
}

using NUnit.Framework;
using SwfLib.Actions;

namespace SwfLib.SwfMill.Tests.Actions {
    [TestFixture]
    public class GetURL2XActionTest : BaseXActionTest {
        private const string _etalon = @"<GetURL2 flags='128' />";

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

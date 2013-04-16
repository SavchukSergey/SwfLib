using Code.SwfLib.SwfMill.Tests.Actions;
using NUnit.Framework;
using SwfLib.Actions;

namespace SwfLib.SwfMill.Tests.Actions {
    [TestFixture]
    public class GetURLXActionTest : BaseXActionTest {
        private const string _etalon = @"<GetURL url='ab' target='cd' />";

        [Test]
        public void ReadTest() {
            var action = ReadAction<ActionGetURL>(_etalon);
            Assert.AreEqual("ab", action.UrlString);
            Assert.AreEqual("cd", action.TargetString);
        }

        [Test]
        public void WriteTest() {
            WriteAction(new ActionGetURL { UrlString = "ab", TargetString = "cd" }, _etalon);
        }
    }
}

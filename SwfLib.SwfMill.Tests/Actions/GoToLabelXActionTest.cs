using Code.SwfLib.Actions;
using NUnit.Framework;
using SwfLib.Actions;
using SwfLib.SwfMill.Tests.Actions;

namespace Code.SwfLib.SwfMill.Tests.Actions {
    [TestFixture]
    public class GoToLabelXActionTest : BaseXActionTest {
        private const string _etalon = @"<GotoLabel label='abcd' />";

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

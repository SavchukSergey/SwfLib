using Code.SwfLib.Actions;
using NUnit.Framework;
using SwfLib.SwfMill.Tests.Actions;

namespace Code.SwfLib.SwfMill.Tests.Actions {
    public class CallXActionTest : BaseXActionTest {
        private const string ETALON = @"<Call />";

        [Test]
        public void ReadTest() {
            var action = ReadAction<ActionCall>(ETALON);
            Assert.IsNotNull(action);
        }

        [Test]
        public void WriteTest() {
            WriteAction(new ActionCall (), ETALON);
        }
    }
}

using Code.SwfLib.Actions;
using NUnit.Framework;

namespace Code.SwfLib.SwfMill.Tests.Actions {
    public class CallXActionTest : BaseXActionTest {
        private const string _etalon = @"<Call />";

        [Test]
        public void ReadTest() {
            var action = ReadAction<ActionCall>(_etalon);
            Assert.IsNotNull(action);
        }

        [Test]
        public void WriteTest() {
            WriteAction(new ActionCall { }, _etalon);
        }
    }
}

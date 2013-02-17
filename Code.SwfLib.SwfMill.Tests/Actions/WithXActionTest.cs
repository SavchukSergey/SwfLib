using Code.SwfLib.Actions;
using NUnit.Framework;

namespace Code.SwfLib.SwfMill.Tests.Actions {
    [TestFixture]
    public class WithXActionTest : BaseXActionTest {
        private const string _etalon = @"<With size='1' />";

        [Test]
        public void ReadTest() {
            var action = ReadAction<ActionWith>(_etalon);
        }

        [Test]
        public void WriteTest() {
            WriteAction(new ActionWith { Size = 1 }, _etalon);
        }
    }
}

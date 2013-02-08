using Code.SwfLib.Actions;
using NUnit.Framework;

namespace Code.SwfLib.Tests.Actions {
    [TestFixture]
    public class WithActionTest : BaseActionTest {

        private readonly byte[] _etalon = new byte[] { 0x94, 0x02, 0x00, 0x01, 0x00 };

        [Test]
        public void ReadTest() {
            var action = ReadAction<ActionWith>(_etalon);
        }

        [Test]
        public void WriteTest() {
            WriteAction(new ActionWith { Size = 1}, _etalon);
        }
    }
}

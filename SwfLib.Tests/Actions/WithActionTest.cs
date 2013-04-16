using Code.SwfLib.Actions;
using Code.SwfLib.Tests.Actions;
using NUnit.Framework;
using SwfLib.Tests.Asserts;

namespace SwfLib.Tests.Actions {
    [TestFixture]
    public class WithActionTest : BaseActionTest {

        private readonly byte[] _etalon = new byte[] { 0x94, 0x02, 0x00, 0x01, 0x00, 0x34 };

        [Test]
        public void ReadTest() {
            var action = ReadAction<ActionWith>(_etalon);
            AssertAction.AreEqual(GetActionWith(), action, "ActionWith");
        }

        [Test]
        public void WriteTest() {
            WriteAction(GetActionWith(), _etalon);
        }

        private static ActionWith GetActionWith() {
            return new ActionWith {
                Actions = {
                    new ActionGetTime()
                }
            };
        }
    }
}

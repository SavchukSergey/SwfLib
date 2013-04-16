using Code.SwfLib.Actions;
using Code.SwfLib.SwfMill.Tests.Actions;
using NUnit.Framework;

namespace SwfLib.SwfMill.Tests.Actions {
    [TestFixture]
    public class WithXActionTest : BaseXActionTest {
        private const string _etalon = @"<With>
    <actions>
        <GetTimer />
    </actions>
</With>";

        [Test]
        public void ReadTest() {
            var action = ReadAction<ActionWith>(_etalon);
        }

        [Test]
        public void WriteTest() {
            WriteAction(new ActionWith {
                Actions = {
                    new ActionGetTime()
                }
            }, _etalon);
        }
    }
}

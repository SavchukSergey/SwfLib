using Code.SwfLib.Tests.Actions;
using NUnit.Framework;
using SwfLib.Actions;
using SwfLib.Tests.Asserts;

namespace SwfLib.Tests.Actions {
    [TestFixture]
    public class DefineFunction2ActionTest : BaseActionTest {

        private readonly byte[] _etalon = new byte[] { 0x8e, 0x18, 0x00, 
            (byte) 'f', (byte) 'u', (byte) 'n', (byte) 'c', 0x00, //name
            0x02, 0x00, //Two parameters
            0x0a, //10 Registers
            0xaa, 0xf1, //flags
            0x00, (byte) 'r', (byte) 'e', (byte) 'g', (byte) '1', 0x00, //Param 1
            0x01, (byte) 'r', (byte) 'e', (byte) 'g', (byte) '2', 0x00, //Param 2
            0x01, 0x00, 0x34};


        [Test]
        public void ReadTest() {
            var action = ReadAction<ActionDefineFunction2>(_etalon);
            AssertAction.AreEqual(GetActionDefineFunction2(), action, "DefineFunction2");

        }

        [Test]
        public void WriteTest() {
            WriteAction(GetActionDefineFunction2(), _etalon);
        }

        private static ActionDefineFunction2 GetActionDefineFunction2() {
            return new ActionDefineFunction2 {
                Name = "func",
                RegisterCount = 10,
                PreloadParent = true,
                PreloadRoot = false,
                SuppressSuper = true,
                PreloadSuper = false,
                SuppressArguments = true,
                PreloadArguments = false,
                SuppressThis = true,
                PreloadThis = false,
                Reserved = 0x78,
                PreloadGlobal = true,
                Parameters = {
                    new RegisterParam(0x00, "reg1"), 
                    new RegisterParam(0x01, "reg2")
                },
                Actions = {
                    new ActionGetTime()
                }
            };
        }
    }
}

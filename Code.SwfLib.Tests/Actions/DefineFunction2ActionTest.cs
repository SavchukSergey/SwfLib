using System.Diagnostics;
using Code.SwfLib.Actions;
using NUnit.Framework;

namespace Code.SwfLib.Tests.Actions {
    [TestFixture]
    public class DefineFunction2ActionTest : BaseActionTest {

        private readonly byte[] _etalon = new byte[] { 0x8e, 0x19, 0x00, 
            (byte) 'f', (byte) 'u', (byte) 'n', (byte) 'c', 0x00,
            0x02, 0x00,
            0x0a,
            0xaa, 0xf1,
            0x00, (byte) 'r', (byte) 'e', (byte) 'g', (byte) '1', 0x00,
            0x01, (byte) 'r', (byte) 'e', (byte) 'g', (byte) '2', 0x00,
            0x01, 0x00, 0x34};


        [Test]
        public void ReadTest()
        {
            var action = ReadAction<ActionDefineFunction2>(_etalon);
            Assert.AreEqual("func", action.Name);
            Assert.AreEqual(10, action.RegisterCount);
            Assert.IsTrue(action.PreloadParent);
            Assert.IsFalse(action.PreloadRoot);
            Assert.IsTrue(action.SuppressSuper);
            Assert.IsFalse(action.PreloadSuper);
            Assert.IsTrue(action.SuppressArguments);
            Assert.IsFalse(action.PreloadArguments);
            Assert.IsTrue(action.SuppressThis);
            Assert.IsFalse(action.PreloadThis);

            Assert.AreEqual(0x78, action.Reserved);
            Assert.IsTrue(action.PreloadGlobal);

            Assert.AreEqual(2, action.Parameters.Count);
            Assert.AreEqual("reg1", action.Parameters[0].Name);
            Assert.AreEqual(0x00, action.Parameters[0].Register);
            Assert.AreEqual("reg2", action.Parameters[1].Name);
            Assert.AreEqual(0x01, action.Parameters[1].Register);

            Assert.AreEqual(1, action.Actions.Count);
            Assert.IsAssignableFrom(typeof(ActionGetTime), action.Actions[0]);
        }

        [Test]
        public void WriteTest() {
            WriteAction(new ActionDefineFunction2 {
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
                Parameters = { new RegisterParam(0x00, "reg1"), new RegisterParam(0x01, "reg2") },
                Actions = {
                    new ActionGetTime()
                }
            }, _etalon);
        }
    }
}

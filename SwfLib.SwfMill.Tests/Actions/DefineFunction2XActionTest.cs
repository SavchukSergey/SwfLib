using NUnit.Framework;
using SwfLib.Actions;

namespace SwfLib.SwfMill.Tests.Actions {
    [TestFixture]
    public class DefineFunction2XActionTest : BaseXActionTest {
        private const string _etalon = @"<DeclareFunction2 name='func' argc='2' regc='10' preloadParent='1' preloadRoot='0' suppressSuper='1' preloadSuper='0' suppressArguments='1' preloadArguments='0' suppressThis='1' preloadThis='0'
    reserved='120' preloadGlobal='1'>
    <args>
        <Parameter reg='0' name='reg1'/>
        <Parameter reg='1' name='reg2'/>
    </args>
    <actions>
        <GetTimer />
    </actions>
</DeclareFunction2>";


        [Test]
        public void ReadTest() {
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

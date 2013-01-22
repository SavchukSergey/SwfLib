using System;
using System.IO;
using Code.SwfLib.Actions;
using NUnit.Framework;

namespace Code.SwfLib.Tests.Actions {
    [TestFixture]
    public class ActionWriterTest {

        [Test]
        public void OneByteActionsTest() {
            var vals = Enum.GetValues(typeof(ActionCode));
            var factory = new ActionsFactory();
            foreach (ActionCode type in vals) {
                if ((byte)type < 0x80) {
                    var action = factory.Create(type);
                    var mem = new MemoryStream();
                    var writer = new SwfStreamWriter(mem);
                    var actionWriter = new ActionWriter(writer);
                    actionWriter.WriteAction(action);
                    var buffer = mem.ToArray();
                    Assert.AreEqual(1, buffer.Length);
                    Assert.AreEqual((byte)type, buffer[0]);
                }
            }
        }
    }
}

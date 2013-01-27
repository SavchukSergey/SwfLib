using System;
using System.IO;
using Code.SwfLib.Actions;
using NUnit.Framework;

namespace Code.SwfLib.Tests.Actions {
    [TestFixture]
    public class ActionReaderTest {

        [Test]
        public void OneByteActionsTest() {
            var vals = Enum.GetValues(typeof(ActionCode));
            foreach (ActionCode type in vals) {
                if ((byte)type < 0x80) {
                    var mem = new MemoryStream();
                    mem.WriteByte((byte)type);
                    mem.Seek(0, SeekOrigin.Begin);
                    var reader = new SwfStreamReader(mem);
                    var actionReader = new ActionReader(reader);
                    var action = actionReader.ReadAction();
                    Assert.IsNotNull(action);
                    var actualType = action.ActionCode;
                    Assert.AreEqual(type, actualType);
                    Assert.AreEqual(1, mem.Position);
                }
            }
        }
    }
}

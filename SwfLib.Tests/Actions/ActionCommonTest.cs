using System;
using System.IO;
using NUnit.Framework;
using SwfLib.Actions;

namespace SwfLib.Tests.Actions {
    [TestFixture]
    public class ActionCommonTest {

        [Test]
        public void ReadOneByteActionsTest() {
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

        [Test]
        public void WriteOneByteActionsTest() {
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


        //TODO: Test for reading/writing Try action must exist
        //TODO: Test for reading/writing Push action must exist
        //TODO: Test for reading/writing DefineFunction action must exist
        [Test]
        public void MultiByteActionTestExistsTest() {
            var vals = Enum.GetValues(typeof(ActionCode));
            foreach (ActionCode type in vals) {
                if ((byte)type >= 0x80) {
                    var testTypeName = GetType().Namespace + "." + type + "ActionTest";
                    var testType = GetType().Assembly.GetType(testTypeName);
                    if (testType == null) {
                        Console.WriteLine("Test for reading/writing {0} action must exist", type);
                        continue;
                    }
                    Assert.IsNotNull(testType, "Test for reading/writing {0} action must exist", type);
                    var readMethod = testType.GetMethod("ReadTest");
                    Assert.IsNotNull(readMethod, "ReadTest must present");
                    var writeMethod = testType.GetMethod("WriteTest");
                    Assert.IsNotNull(writeMethod, "WriteTest must present");
                }
            }
        }
    }
}

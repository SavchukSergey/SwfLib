using System;
using System.Xml.Linq;
using Code.SwfLib.Actions;
using Code.SwfLib.SwfMill.Actions;
using NUnit.Framework;
using SwfLib.Actions;
using SwfLib.SwfMill.Actions;

namespace SwfLib.SwfMill.Tests.Actions {
    [TestFixture]
    public class XActionCommonTest {

        [Test]
        public void ReadOneByteActionsTest() {
            var vals = Enum.GetValues(typeof(ActionCode));
            foreach (ActionCode type in vals) {
                if ((byte)type < 0x80) {
                    var xAction = new XElement(XActionNames.FromActionCode(type));
                    var action = XAction.FromXml(xAction);
                    Assert.IsNotNull(action);
                    var actualType = action.ActionCode;
                    Assert.AreEqual(type, actualType);
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
                    var xAction = XAction.ToXml(action);
                    Assert.AreEqual(xAction.Name.LocalName, XActionNames.FromActionCode(type));
                }
            }
        }


        //TODO: Test for reading/writing Try action must exist
        //TODO: Test for reading/writing DefineFunction action must exist
        [Test]
        public void MultiByteActionTestExistsTest() {
            var vals = Enum.GetValues(typeof(ActionCode));
            foreach (ActionCode type in vals) {
                if ((byte)type >= 0x80) {
                    var testTypeName = GetType().Namespace + "." + type + "XActionTest";
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

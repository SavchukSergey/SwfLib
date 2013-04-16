using System;
using Code.SwfLib.Actions;
using Code.SwfLib.SwfMill.Actions;
using NUnit.Framework;

namespace Code.SwfLib.SwfMill.Tests {
    [TestFixture]
    public class ActionXmlSerializerTest {

        [Test]
        public void CreateTest() {
            var ser = new XActionWriter();
            var actionFactory = new ActionsFactory();
            var vals = Enum.GetValues(typeof(ActionCode));
            foreach (ActionCode type in vals) {
                if ((byte)type <= 0x80) {
                    var action = actionFactory.Create(type);
                    try {
                        var res = ser.Serialize(action);
                        var actualName = res.Name.LocalName;
                        var expectedName = type.ToString();
                        if (type == ActionCode.End) expectedName = "EndAction";
                        if (actualName != expectedName) {
                            Console.WriteLine("Warning: Incosistent naming, Action type: {0}, Class: {1}", type,
                                              actualName);
                        }
                    } catch (Exception) {
                        Assert.Fail("Couldnt serialize: {0}", type);
                    }
                }
            }
        }
    }
}

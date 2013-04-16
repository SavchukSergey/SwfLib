using Code.SwfLib.Tests.Actions;
using NUnit.Framework;
using SwfLib.Actions;
using SwfLib.Tests.Asserts;

namespace SwfLib.Tests.Actions {
    public class PushActionTest : BaseActionTest {

        private readonly byte[] ETALON = new byte[] {150, 35, 0,
            0, 97, 98, 99, 0, //Strign abc
            1, 154, 153, 25, 64, //Float 2.4f
            2, //Null
            3, //Undefined
            4, 12, //Register 12
            5, 1, //Boolean 1
            6, 118, 190, 243, 63, 88, 57, 180, 200, //Double 1.234
            7, 210, 4, 0, 0, //Integer 1234
            8, 23, //Constant8 32
            9, 46, 22 //Constant16 5678
        };

        [Test]
        public void ReadTest() {
            var action = ReadAction<ActionPush>(ETALON);
            Assert.IsNotNull(action);
            AssertAction.AreEqual(GetActionPush(), action, "PushData");
        }

        [Test]
        public void WriteTest() {
            WriteAction(GetActionPush(), ETALON);
        }

        private static ActionPush GetActionPush() {
            return new ActionPush {
                Items = {
                    new ActionPushItem {Type = ActionPushItemType.String, String = "abc"},
                    new ActionPushItem {Type = ActionPushItemType.Float, Float = 2.4f},
                    new ActionPushItem {Type = ActionPushItemType.Null},
                    new ActionPushItem {Type = ActionPushItemType.Undefined},
                    new ActionPushItem {Type = ActionPushItemType.Register, Register = 12},
                    new ActionPushItem {Type = ActionPushItemType.Boolean, Boolean = 1},
                    new ActionPushItem {Type = ActionPushItemType.Double, Double = 1.234},
                    new ActionPushItem {Type = ActionPushItemType.Integer, Integer = 1234},
                    new ActionPushItem {Type = ActionPushItemType.Constant8, Constant8 = 23},
                    new ActionPushItem {Type = ActionPushItemType.Constant16, Constant16 = 5678},
                }
            };
        }
    }
}

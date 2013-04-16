using NUnit.Framework;
using SwfLib.Actions;
using SwfLib.Tests.Asserts;

namespace SwfLib.SwfMill.Tests.Actions {
    public class PushXActionTest : BaseXActionTest {

        private const string ETALON = @"<PushData>
    <items>
        <StackString value='abc' />
        <StackFloat value='2.4' />
        <StackNull />
        <StackUndefined />
        <StackRegister reg='12' />
        <StackBoolean value='1' />
        <StackDouble value='1.234' />
        <StackInteger value='1234' />
        <StackDictionaryLookup index='23' />
        <StackConstant16 value='5678' />
    </items>
</PushData>";

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

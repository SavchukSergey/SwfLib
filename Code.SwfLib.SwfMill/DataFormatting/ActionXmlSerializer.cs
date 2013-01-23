using System;
using System.Xml.Linq;
using Code.SwfLib.Actions;

namespace Code.SwfLib.SwfMill.DataFormatting {
    public class ActionXmlSerializer : IActionVisitor<object, XElement> {

        public XElement Serialize(ActionBase action) {
            return action.AcceptVisitor(this, null);
        }

        #region SWF 3

        XElement IActionVisitor<object, XElement>.Visit(ActionGotoFrame action, object param) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionGetURL action, object param) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionNextFrame action, object param) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionPreviousFrame action, object param) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionPlay action, object param) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionStop action, object param) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionToggleQuality action, object param) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionStopSounds action, object param) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionWaitForFrame action, object param) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionSetTarget action, object param) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionGoToLabel action, object param) {
            throw new NotImplementedException();
        }

        #endregion

        #region SWF 4

        XElement IActionVisitor<object, XElement>.Visit(ActionAdd action, object param) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionDivide action, object param) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionMultiply action, object param) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionSubtract action, object param) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionEquals action, object param) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionLess action, object param) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionAnd action, object param) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionNot action, object param) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionOr action, object param) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionStringAdd action, object param) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionStringEquals action, object param) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionStringExtract action, object param) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionStringLength action, object param) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionMBStringExtract action, object param) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionMBStringLength action, object param) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionStringLess action, object param) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionPop action, object param) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionPush action, object param) {
            var xAction = new XElement("PushData");
            var xItems = new XElement("items");
            foreach (var item in action.Items) {
                switch (item.Type) {
                    case ActionPushItemType.String:
                        xItems.Add(new XElement("StackString", new XAttribute("value", item.String)));
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
            xAction.Add(xItems);
            return xAction;
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionAsciiToChar action, object param) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionCharToAscii action, object param) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionToInteger action, object param) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionMBAsciiToChar action, object param) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionMBCharToAscii action, object param) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionCall action, object param) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionIf action, object param) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionJump action, object param) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionGetVariable action, object param) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionSetVariable action, object param) {
            return new XElement("SetVariable");
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionGetURL2 action, object param) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionGetProperty action, object param) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionGotoFrame2 action, object param) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionRemoveSprite action, object param) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionSetProperty action, object param) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionSetTarget2 action, object param) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionStartDrag action, object param) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionWaitForFrame2 action, object param) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionCloneSprite action, object param) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionEndDrag action, object param) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionGetTime action, object param) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionRandomNumber action, object param) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionTrace action, object param) {
            throw new NotImplementedException();
        }

        #endregion

        #region SWF 5

        XElement IActionVisitor<object, XElement>.Visit(ActionCallFunction action, object arg) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionCallMethod action, object arg) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionConstantPool action, object param) {
            var res = new XElement("Dictionary");
            var strings = new XElement("strings");
            foreach (var item in action.ConstantPool) {
                strings.Add(new XElement("String", new XAttribute("value", item)));
            }
            res.Add(strings);
            return res;
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionDefineFunction action, object param) {
            var res = new XElement("DeclareFunction");
            res.Add(new XAttribute("name", action.FunctionName),
                new XAttribute("argc", action.Params.Length),
                new XAttribute("length", action.Body.Length)
            );
            //TODO: method body
            var args = new XElement("args");
            foreach (var arg in action.Params) {
                throw new NotImplementedException();
            }
            res.Add(args);
            return res;
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionDefineLocal action, object arg) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionDefineLocal2 action, object arg) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionDelete action, object arg) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionDelete2 action, object arg) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionEnumerate action, object arg) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionEquals2 action, object arg) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionGetMember action, object arg) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionInitArray action, object arg) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionInitObject action, object arg) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionNewMethod action, object arg) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionNewObject action, object arg) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionSetMember action, object param) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionTargetPath action, object arg) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionWith action, object arg) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionToNumber action, object arg) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionToString action, object arg) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionTypeOf action, object arg) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionAdd2 action, object arg) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionLess2 action, object arg) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionModulo action, object arg) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionBitAnd action, object arg) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionBitLShift action, object arg) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionBitOr action, object arg) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionBitRShift action, object arg) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionBitURShift action, object arg) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionBitXor action, object arg) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionDecrement action, object arg) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionIncrement action, object arg) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionPushDuplicate action, object arg) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionReturn action, object param) {
            throw new NotImplementedException();
        }


        XElement IActionVisitor<object, XElement>.Visit(ActionStackSwap action, object arg) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionStoreRegister action, object arg) {
            throw new NotImplementedException();
        }

        public XElement Visit(ActionEnd action, object arg) {
            return new XElement("EndAction");
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionUnknown action, object arg) {
            throw new NotImplementedException();
        }

        #endregion

        #region SWF 6

        XElement IActionVisitor<object, XElement>.Visit(ActionInstanceOf action, object param) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionEnumerate2 action, object param) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionStrictEquals action, object param) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionGreater action, object param) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionStringGreater action, object param) {
            throw new NotImplementedException();
        }

        #endregion

        #region SWF 7

        XElement IActionVisitor<object, XElement>.Visit(ActionDefineFunction2 action, object param) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionExtends action, object param) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionCastOp action, object param) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionImplementsOp action, object param) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionTry action, object param) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionThrow action, object param) {
            throw new NotImplementedException();
        }

        #endregion

        public XElement Visit(ActionUnknown action, object arg) {
            throw new NotImplementedException();
        }

    }
}

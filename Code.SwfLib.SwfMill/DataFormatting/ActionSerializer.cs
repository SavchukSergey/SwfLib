using System;
using System.Xml.Linq;
using Code.SwfLib.Actions;
using Code.SwfLib.Data.Actions;

namespace Code.SwfLib.SwfMill.DataFormatting {
    public class ActionSerializer : IActionVisitor<object, XElement> {

        public XElement Serialize(ActionBase action) {
            return action.AcceptVisitor(this, null);
        }

        #region IActionVisitor Members

        #region SWF 3

        #endregion

        #region SWF 4

        XElement IActionVisitor<object, XElement>.Visit(ActionAdd action, object writer) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionAnd action, object writer) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionDivide action, object writer) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionAsciiToChar action, object writer) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionCall action, object writer) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionCharToAscii action, object writer) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionCloneSprite action, object writer) {
            throw new NotImplementedException();
        }

        #endregion

        #region SWF 7

        public XElement Visit(ActionDefineFunction2 action, object arg) {
            throw new NotImplementedException();
        }

        public XElement Visit(ActionExtends action, object arg) {
            throw new NotImplementedException();
        }

        public XElement Visit(ActionCastOp action, object arg) {
            throw new NotImplementedException();
        }

        public XElement Visit(ActionImplementsOp action, object arg) {
            throw new NotImplementedException();
        }

        public XElement Visit(ActionTry action, object arg) {
            throw new NotImplementedException();
        }

        public XElement Visit(ActionThrow action, object arg) {
            throw new NotImplementedException();
        }

        #endregion

        XElement IActionVisitor<object, XElement>.Visit(ActionConstantPool action, object writer) {
            var res = new XElement("Dictionary");
            var strings = new XElement("strings");
            foreach (var item in action.ConstantPool) {
                strings.Add(new XElement("String", new XAttribute("value", item)));
            }
            res.Add(strings);
            return res;
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionDefineFunction action, object writer) {
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

        XElement IActionVisitor<object, XElement>.Visit(ActionEndDrag action, object writer) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionEquals action, object writer) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionGetProperty action, object writer) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionGetTime action, object writer) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionGetURL action, object writer) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionGetURL2 action, object writer) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionGetVariable action, object writer) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionGotoFrame action, object writer) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionGotoFrame2 action, object writer) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionGoToLabel action, object writer) {
            throw new NotImplementedException();
        }

        public XElement Visit(ActionIf action, object arg) {
            throw new NotImplementedException();
        }

        public XElement Visit(ActionJump action, object arg) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionLess action, object writer) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionMBAsciiToChar action, object writer) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionMBCharToAscii action, object writer) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionMBStringExtract action, object writer) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionMBStringLength action, object writer) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionMultiply action, object writer) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionNextFrame action, object writer) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionNot action, object writer) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionOr action, object writer) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionPlay action, object writer) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionPop action, object writer) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionPreviousFrame action, object writer) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionPush action, object writer) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionRandomNumber action, object writer) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionRemoveSprite action, object writer) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionReturn action, object writer) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionSetMember action, object writer) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionSetProperty action, object writer) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionSetTarget action, object writer) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionSetTarget2 action, object writer) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionSetVariable action, object writer) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionStartDrag action, object writer) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionStop action, object writer) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionStopSounds action, object writer) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionStringAdd action, object writer) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionStringEquals action, object writer) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionStringExtract action, object writer) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionStringLength action, object writer) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionStringLess action, object writer) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionSubtract action, object writer) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionToggleQuality action, object writer) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionToInteger action, object writer) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionTrace action, object writer) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionWaitForFrame action, object writer) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionWaitForFrame2 action, object writer) {
            throw new NotImplementedException();
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Code.SwfLib.Data.Actions;

namespace Code.SwfLib.SwfMill.DataFormatting {
    public class ActionSerializer : IActionVisitor {

        public XElement Serialize(ActionBase action) {
            return (XElement)action.AcceptVisitor(this);
        }

        #region IActionVisitor Members

        object IActionVisitor.Visit(ActionAdd action) {
            throw new NotImplementedException();
        }

        object IActionVisitor.Visit(ActionAnd action) {
            throw new NotImplementedException();
        }

        object IActionVisitor.Visit(ActionAsciiToChar action) {
            throw new NotImplementedException();
        }

        object IActionVisitor.Visit(ActionCall action) {
            throw new NotImplementedException();
        }

        object IActionVisitor.Visit(ActionCharToAscii action) {
            throw new NotImplementedException();
        }

        object IActionVisitor.Visit(ActionCloneSprite action) {
            throw new NotImplementedException();
        }

        object IActionVisitor.Visit(ActionConstantPool action) {
            var res = new XElement("Dictionary");
            var strings = new XElement("strings");
            foreach (var item in action.ConstantPool) {
                strings.Add(new XElement("String", new XAttribute("value", item)));
            }
            res.Add(strings);
            return res;
        }

        object IActionVisitor.Visit(ActionDefineFunction action) {
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

        object IActionVisitor.Visit(ActionDivide action) {
            throw new NotImplementedException();
        }

        object IActionVisitor.Visit(ActionEndDrag action) {
            throw new NotImplementedException();
        }

        object IActionVisitor.Visit(ActionEquals action) {
            throw new NotImplementedException();
        }

        object IActionVisitor.Visit(ActionGetProperty action) {
            throw new NotImplementedException();
        }

        object IActionVisitor.Visit(ActionGetTime action) {
            throw new NotImplementedException();
        }

        object IActionVisitor.Visit(ActionGetURL action) {
            throw new NotImplementedException();
        }

        object IActionVisitor.Visit(ActionGetURL2 action) {
            throw new NotImplementedException();
        }

        object IActionVisitor.Visit(ActionGetVariable action) {
            throw new NotImplementedException();
        }

        object IActionVisitor.Visit(ActionGotoFrame action) {
            throw new NotImplementedException();
        }

        object IActionVisitor.Visit(ActionGotoFrame2 action) {
            throw new NotImplementedException();
        }

        object IActionVisitor.Visit(ActionGoToLabel action) {
            throw new NotImplementedException();
        }

        object IActionVisitor.Visit(ActionIf action) {
            throw new NotImplementedException();
        }

        object IActionVisitor.Visit(ActionJump action) {
            throw new NotImplementedException();
        }

        object IActionVisitor.Visit(ActionLess action) {
            throw new NotImplementedException();
        }

        object IActionVisitor.Visit(ActionMBAsciiToChar action) {
            throw new NotImplementedException();
        }

        object IActionVisitor.Visit(ActionMBCharToAscii action) {
            throw new NotImplementedException();
        }

        object IActionVisitor.Visit(ActionMBStringExtract action) {
            throw new NotImplementedException();
        }

        object IActionVisitor.Visit(ActionMBStringLength action) {
            throw new NotImplementedException();
        }

        object IActionVisitor.Visit(ActionMultiply action) {
            throw new NotImplementedException();
        }

        object IActionVisitor.Visit(ActionNextFrame action) {
            throw new NotImplementedException();
        }

        object IActionVisitor.Visit(ActionNot action) {
            throw new NotImplementedException();
        }

        object IActionVisitor.Visit(ActionOr action) {
            throw new NotImplementedException();
        }

        object IActionVisitor.Visit(ActionPlay action) {
            throw new NotImplementedException();
        }

        object IActionVisitor.Visit(ActionPop action) {
            throw new NotImplementedException();
        }

        object IActionVisitor.Visit(ActionPreviousFrame action) {
            throw new NotImplementedException();
        }

        object IActionVisitor.Visit(ActionPush action) {
            throw new NotImplementedException();
        }

        object IActionVisitor.Visit(ActionRandomNumber action) {
            throw new NotImplementedException();
        }

        object IActionVisitor.Visit(ActionRemoveSprite action) {
            throw new NotImplementedException();
        }

        object IActionVisitor.Visit(ActionReturn action) {
            throw new NotImplementedException();
        }

        object IActionVisitor.Visit(ActionSetMember action) {
            throw new NotImplementedException();
        }

        object IActionVisitor.Visit(ActionSetProperty action) {
            throw new NotImplementedException();
        }

        object IActionVisitor.Visit(ActionSetTarget action) {
            throw new NotImplementedException();
        }

        object IActionVisitor.Visit(ActionSetTarget2 action) {
            throw new NotImplementedException();
        }

        object IActionVisitor.Visit(ActionSetVariable action) {
            throw new NotImplementedException();
        }

        object IActionVisitor.Visit(ActionStartDrag action) {
            throw new NotImplementedException();
        }

        object IActionVisitor.Visit(ActionStop action) {
            throw new NotImplementedException();
        }

        object IActionVisitor.Visit(ActionStopSounds action) {
            throw new NotImplementedException();
        }

        object IActionVisitor.Visit(ActionStringAdd action) {
            throw new NotImplementedException();
        }

        object IActionVisitor.Visit(ActionStringEquals action) {
            throw new NotImplementedException();
        }

        object IActionVisitor.Visit(ActionStringExtract action) {
            throw new NotImplementedException();
        }

        object IActionVisitor.Visit(ActionStringLength action) {
            throw new NotImplementedException();
        }

        object IActionVisitor.Visit(ActionStringLess action) {
            throw new NotImplementedException();
        }

        object IActionVisitor.Visit(ActionSubtract action) {
            throw new NotImplementedException();
        }

        object IActionVisitor.Visit(ActionToggleQuality action) {
            throw new NotImplementedException();
        }

        object IActionVisitor.Visit(ActionToInteger action) {
            throw new NotImplementedException();
        }

        object IActionVisitor.Visit(ActionTrace action) {
            throw new NotImplementedException();
        }

        object IActionVisitor.Visit(ActionWaitForFrame action) {
            throw new NotImplementedException();
        }

        object IActionVisitor.Visit(ActionWaitForFrame2 action) {
            throw new NotImplementedException();
        }

        #endregion
    }
}

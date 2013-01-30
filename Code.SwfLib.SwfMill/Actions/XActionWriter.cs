using System;
using System.Xml.Linq;
using Code.SwfLib.Actions;
using Code.SwfLib.SwfMill.Data;

namespace Code.SwfLib.SwfMill.Actions {
    public class XActionWriter : IActionVisitor<object, XElement> {

        public XElement Serialize(ActionBase action) {
            return action.AcceptVisitor(this, null);
        }

        #region SWF 3

        XElement IActionVisitor<object, XElement>.Visit(ActionGotoFrame action, object param) {
            return new XElement(XActionNames.FromAction(action), new XAttribute("frame", action.Frame));
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionGetURL action, object param) {
            return new XElement("GetURL",
                new XAttribute("url", action.UrlString),
                new XAttribute("target", action.TargetString));
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionNextFrame action, object param) {
            return new XElement("NextFrame");
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionPreviousFrame action, object param) {
            return new XElement("PreviousFrame");
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionPlay action, object param) {
            return new XElement("Play");
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionStop action, object param) {
            return new XElement("Stop");
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionToggleQuality action, object param) {
            return new XElement("ToggleQuality");
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionStopSounds action, object param) {
            return new XElement("StopSounds");
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionWaitForFrame action, object param) {
            return new XElement("WaitForFrame",
               new XAttribute("frame", action.Frame),
               new XAttribute("skipCount", action.SkipCount));
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionSetTarget action, object param) {
            return new XElement("SetTarget",
                 new XAttribute("target", action.TargetName));
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionGoToLabel action, object param) {
            return new XElement("GoToLabel",
                  new XAttribute("label", action.Label));
        }

        #endregion

        #region SWF 4

        XElement IActionVisitor<object, XElement>.Visit(ActionAdd action, object param) {
            return new XElement(XActionNames.FromAction(action));
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionDivide action, object param) {
            return new XElement(XActionNames.FromAction(action));
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionMultiply action, object param) {
            return new XElement(XActionNames.FromAction(action));
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionSubtract action, object param) {
            return new XElement(XActionNames.FromAction(action));
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionEquals action, object param) {
            return new XElement("Equals");
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionLess action, object param) {
            return new XElement("Less");
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionAnd action, object param) {
            return new XElement("And");
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionNot action, object param) {
            return new XElement(XActionNames.FromAction(action));
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionOr action, object param) {
            return new XElement("Or");
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionStringAdd action, object param) {
            return new XElement("StringAdd");
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionStringEquals action, object param) {
            return new XElement("StringEquals");
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionStringExtract action, object param) {
            return new XElement("StringExtract");
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionStringLength action, object param) {
            return new XElement("StringLength");
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionMBStringExtract action, object param) {
            return new XElement("MBStringExtract");
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionMBStringLength action, object param) {
            return new XElement("MBStringLength");
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionStringLess action, object param) {
            return new XElement("StringLess");
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionPop action, object param) {
            return new XElement(XActionNames.FromAction(action));
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionPush action, object param) {
            var xAction = new XElement("PushData");
            var xItems = new XElement("items");
            foreach (var item in action.Items) {
                switch (item.Type) {
                    case ActionPushItemType.String:
                        xItems.Add(new XElement("StackString", new XAttribute("value", item.String)));
                        break;
                    case ActionPushItemType.Float:
                        xItems.Add(new XElement("StackFloat", new XAttribute("value", item.Float)));
                        break;
                    case ActionPushItemType.Null:
                        xItems.Add(new XElement("StackNull"));
                        break;
                    case ActionPushItemType.Undefined:
                        xItems.Add(new XElement("StackUndefined"));
                        break;
                    case ActionPushItemType.Register:
                        xItems.Add(new XElement("StackRegister", new XAttribute("reg", item.Register)));
                        break;
                    case ActionPushItemType.Boolean:
                        xItems.Add(new XElement("StackBoolean", new XAttribute("value", item.Boolean)));
                        break;
                    case ActionPushItemType.Double:
                        xItems.Add(new XElement("StackDouble", new XAttribute("value", item.Double)));
                        break;
                    case ActionPushItemType.Integer:
                        xItems.Add(new XElement("StackInteger", new XAttribute("value", item.Integer)));
                        break;
                    case ActionPushItemType.Constant8:
                        xItems.Add(new XElement("StackDictionaryLookup", new XAttribute("index", item.Constant8)));
                        break;
                    case ActionPushItemType.Constant16:
                        xItems.Add(new XElement("StackConstant16", new XAttribute("value", item.Constant16)));
                        break;
                    default:
                        throw new NotSupportedException();
                }
            }
            xAction.Add(xItems);
            return xAction;
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionAsciiToChar action, object param) {
            return new XElement("AsciiToChar");
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionCharToAscii action, object param) {
            return new XElement("CharToAscii");
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionToInteger action, object param) {
            return new XElement("ToInteger");
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionMBAsciiToChar action, object param) {
            return new XElement("MBAsciiToChar");
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionMBCharToAscii action, object param) {
            return new XElement("MBCharToAscii");
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionCall action, object param) {
            //TODO; why it doesn't have args
            return new XElement("Call");
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionIf action, object param) {
            return new XElement(XActionNames.FromAction(action),
                new XAttribute("byteOffset", FormatBranchOffset(action.BranchOffset)));
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionJump action, object param) {
            return new XElement(XActionNames.FromAction(action),
              new XAttribute("byteOffset", FormatBranchOffset(action.BranchOffset)));
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionGetVariable action, object param) {
            return new XElement(XActionNames.FromAction(action));
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionSetVariable action, object param) {
            return new XElement(XActionNames.FromAction(action));
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionGetURL2 action, object param) {
            return new XElement(XActionNames.FromAction(action),
               new XAttribute("flags", action.Flags));
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionGetProperty action, object param) {
            return new XElement(XActionNames.FromAction(action));
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionGotoFrame2 action, object param) {
            var res = new XElement(XActionNames.FromAction(action),
                new XAttribute("play", CommonFormatter.Format(action.Play)));
            if (action.SceneBias.HasValue) {
                res.Add(new XAttribute("bias", action.SceneBias.Value));
            }
            if (action.Reserved != 0) {
                res.Add(new XAttribute("reserved", action.Reserved));
            }
            return res;
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionRemoveSprite action, object param) {
            return new XElement("RemoveSprite");
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionSetProperty action, object param) {
            return new XElement("SetProperty");
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionSetTarget2 action, object param) {
            return new XElement("SetTarget2");
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionStartDrag action, object param) {
            return new XElement("StartDrag");
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionWaitForFrame2 action, object param) {
            return new XElement("WaitForFrame2",
             new XAttribute("skipCount", action.SkipCount));
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionCloneSprite action, object param) {
            return new XElement("CloneSprite");
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionEndDrag action, object param) {
            return new XElement("EndDrag");
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionGetTime action, object param) {
            return new XElement(XActionNames.FromAction(action));
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionRandomNumber action, object param) {
            return new XElement("RandomNumber");
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionTrace action, object param) {
            return new XElement(XActionNames.FromAction(action));
        }

        #endregion

        #region SWF 5

        XElement IActionVisitor<object, XElement>.Visit(ActionCallFunction action, object arg) {
            return new XElement(XActionNames.FromAction(action));
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionCallMethod action, object arg) {
            return new XElement(XActionNames.FromAction(action));
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionConstantPool action, object param) {
            var res = new XElement(XActionNames.FromAction(action));
            var strings = new XElement("strings");
            foreach (var item in action.ConstantPool) {
                strings.Add(new XElement("String", new XAttribute("value", item)));
            }
            res.Add(strings);
            return res;
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionDefineFunction action, object param) {
            var res = new XElement(XActionNames.FromAction(action));
            res.Add(new XAttribute("name", action.Name),
                new XAttribute("argc", action.Args.Count)
            );
            var args = new XElement("args");
            foreach (var arg in action.Args) {
                res.Add(new XElement("Arg", new XAttribute("name", arg)));
            }
            res.Add(args);

            if (action.Actions.Count > 0) {
                var xActions = new XElement("actions");
                foreach (var subaction in action.Actions) {
                    xActions.Add(XAction.ToXml(subaction));
                }
                res.Add(xActions);
            }
            return res;
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionDefineLocal action, object arg) {
            return new XElement(XActionNames.FromAction(action));
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionDefineLocal2 action, object arg) {
            return new XElement("DefineLocal2");
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionDelete action, object arg) {
            return new XElement(XActionNames.FromAction(action));
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionDelete2 action, object arg) {
            return new XElement("Delete2");
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionEnumerate action, object arg) {
            return new XElement("Enumerate");
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionEquals2 action, object arg) {
            return new XElement(XActionNames.FromAction(action));
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionGetMember action, object arg) {
            return new XElement(XActionNames.FromAction(action));
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionInitArray action, object arg) {
            return new XElement(XActionNames.FromAction(action));
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionInitObject action, object arg) {
            return new XElement("InitObject");
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionNewMethod action, object arg) {
            return new XElement(XActionNames.FromAction(action));
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionNewObject action, object arg) {
            return new XElement(XActionNames.FromAction(action));
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionSetMember action, object param) {
            return new XElement(XActionNames.FromAction(action));
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionTargetPath action, object arg) {
            return new XElement("TargetPath");
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionWith action, object arg) {
            return new XElement("With",
              new XAttribute("size", action.Size));
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionToNumber action, object arg) {
            return new XElement("ToNumber");
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionToString action, object arg) {
            return new XElement(XActionNames.FromAction(action));
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionTypeOf action, object arg) {
            return new XElement("TypeOf");
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionAdd2 action, object arg) {
            return new XElement(XActionNames.FromAction(action));
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionLess2 action, object arg) {
            return new XElement(XActionNames.FromAction(action));
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionModulo action, object arg) {
            return new XElement("Modulo");
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionBitAnd action, object arg) {
            return new XElement("BitAnd");
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionBitLShift action, object arg) {
            return new XElement("BitLShift");
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionBitOr action, object arg) {
            return new XElement("BitOr");
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionBitRShift action, object arg) {
            return new XElement("BitRShift");
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionBitURShift action, object arg) {
            return new XElement("BitURShift");
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionBitXor action, object arg) {
            return new XElement("BitXor");
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionDecrement action, object arg) {
            return new XElement(XActionNames.FromAction(action));
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionIncrement action, object arg) {
            return new XElement(XActionNames.FromAction(action));
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionPushDuplicate action, object arg) {
            return new XElement(XActionNames.FromAction(action));
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionReturn action, object param) {
            return new XElement(XActionNames.FromAction(action));
        }


        XElement IActionVisitor<object, XElement>.Visit(ActionStackSwap action, object arg) {
            return new XElement("StackSwap");
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionStoreRegister action, object arg) {
            return new XElement(XActionNames.FromAction(action),
                new XAttribute("reg", action.RegisterNumber));
        }

        #endregion

        #region SWF 6

        XElement IActionVisitor<object, XElement>.Visit(ActionInstanceOf action, object param) {
            return new XElement("InstanceOf");
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionEnumerate2 action, object param) {
            return new XElement("Enumerate2");
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionStrictEquals action, object param) {
            return new XElement("StrictEquals");
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionGreater action, object param) {
            return new XElement(XActionNames.FromAction(action));
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionStringGreater action, object param) {
            return new XElement("StringGreater");
        }

        #endregion

        #region SWF 7

        XElement IActionVisitor<object, XElement>.Visit(ActionDefineFunction2 action, object param) {
            var res = new XElement(XActionNames.FromAction(action));
            res.Add(new XAttribute("name", action.Name ?? ""));
            res.Add(new XAttribute("argc", action.Args.Count));
            res.Add(new XAttribute("regc", action.RegisterCount));
            res.Add(new XAttribute("preloadParent", CommonFormatter.Format(action.PreloadParent)));
            res.Add(new XAttribute("preloadRoot", CommonFormatter.Format(action.PreloadRoot)));
            res.Add(new XAttribute("suppressSuper", CommonFormatter.Format(action.SuppressSuper)));
            res.Add(new XAttribute("preloadSuper", CommonFormatter.Format(action.PreloadSuper)));
            res.Add(new XAttribute("suppressArguments", CommonFormatter.Format(action.SuppressArguments)));
            res.Add(new XAttribute("preloadArguments", CommonFormatter.Format(action.PreloadArguments)));
            res.Add(new XAttribute("suppressThis", CommonFormatter.Format(action.SuppressThis)));
            res.Add(new XAttribute("preloadThis", CommonFormatter.Format(action.PreloadThis)));
            res.Add(new XAttribute("reserved", action.Reserved));
            res.Add(new XAttribute("preloadGlobal", CommonFormatter.Format(action.PreloadGlobal)));

            var xArgs = new XElement("args");
            foreach (var arg in action.Args) {
                xArgs.Add(new XElement("Parameter",
                    new XAttribute("reg", arg.Register),
                    new XAttribute("name", arg.Name)));
            }
            res.Add(xArgs);

            var xActions = new XElement("actions");
            foreach (var subaction in action.Actions) {
                xActions.Add(Serialize(subaction));
            }
            res.Add(xActions);

            return res;
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionExtends action, object param) {
            return new XElement("Extends");
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionCastOp action, object param) {
            return new XElement("CastOp");
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionImplementsOp action, object param) {
            return new XElement("ImplementsOp");
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionTry action, object param) {
            throw new NotImplementedException();
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionThrow action, object param) {
            return new XElement("Throw");
        }

        #endregion

        public XElement Visit(ActionEnd action, object arg) {
            return new XElement(XActionNames.FromAction(action));
        }

        XElement IActionVisitor<object, XElement>.Visit(ActionUnknown action, object arg) {
            return new XElement("Unknown",
                new XAttribute("type", action.ActionCode));
        }

        private static string FormatBranchOffset(short val) {
            var uval = (ushort)val;
            return uval.ToString();
        }
    }
}

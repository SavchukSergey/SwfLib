using System;
using System.Xml.Linq;
using Code.SwfLib.Actions;
using Code.SwfLib.SwfMill.Data;

namespace Code.SwfLib.SwfMill.Actions {
    public class XActionWriter : IActionVisitor<XElement, XElement> {

        public XElement Serialize(ActionBase action) {
            var xAction = new XElement(XActionNames.FromAction(action));
            return action.AcceptVisitor(this, xAction);
        }

        #region SWF 3

        XElement IActionVisitor<XElement, XElement>.Visit(ActionGotoFrame action, XElement param) {
            return new XElement(XActionNames.FromAction(action), new XAttribute("frame", action.Frame));
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionGetURL action, XElement param) {
            return new XElement("GetURL",
                new XAttribute("url", action.UrlString),
                new XAttribute("target", action.TargetString));
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionNextFrame action, XElement arg) {
            return arg;
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionPreviousFrame action, XElement arg) {
            return arg;
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionPlay action, XElement arg) {
            return arg;
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionStop action, XElement arg) {
            return arg;
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionToggleQuality action, XElement arg) {
            return arg;
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionStopSounds action, XElement arg) {
            return arg;
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionWaitForFrame action, XElement arg) {
            return new XElement("WaitForFrame",
               new XAttribute("frame", action.Frame),
               new XAttribute("skipCount", action.SkipCount));
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionSetTarget action, XElement arg) {
            return new XElement("SetTarget",
                 new XAttribute("target", action.TargetName));
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionGoToLabel action, XElement arg) {
            arg.Add(new XAttribute("label", action.Label));
            return arg;
        }

        #endregion

        #region SWF 4

        XElement IActionVisitor<XElement, XElement>.Visit(ActionAdd action, XElement arg) {
            return arg;
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionDivide action, XElement arg) {
            return arg;
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionMultiply action, XElement arg) {
            return arg;
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionSubtract action, XElement arg) {
            return arg;
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionEquals action, XElement arg) {
            return arg;
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionLess action, XElement arg) {
            return arg;
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionAnd action, XElement arg) {
            return arg;
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionNot action, XElement arg) {
            return arg;
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionOr action, XElement arg) {
            return arg;
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionStringAdd action, XElement arg) {
            return arg;
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionStringEquals action, XElement arg) {
            return arg;
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionStringExtract action, XElement arg) {
            return arg;
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionStringLength action, XElement arg) {
            return arg;
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionMBStringExtract action, XElement arg) {
            return arg;
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionMBStringLength action, XElement arg) {
            return arg;
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionStringLess action, XElement arg) {
            return arg;
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionPop action, XElement arg) {
            return arg;
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionPush action, XElement param) {
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

        XElement IActionVisitor<XElement, XElement>.Visit(ActionAsciiToChar action, XElement param) {
            return new XElement("AsciiToChar");
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionCharToAscii action, XElement param) {
            return new XElement("CharToAscii");
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionToInteger action, XElement param) {
            return new XElement("ToInteger");
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionMBAsciiToChar action, XElement param) {
            return new XElement("MBAsciiToChar");
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionMBCharToAscii action, XElement param) {
            return new XElement("MBCharToAscii");
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionCall action, XElement param) {
            //TODO; why it doesn't have args
            return new XElement("Call");
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionIf action, XElement param) {
            return new XElement(XActionNames.FromAction(action),
                new XAttribute("byteOffset", FormatBranchOffset(action.BranchOffset)));
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionJump action, XElement param) {
            return new XElement(XActionNames.FromAction(action),
              new XAttribute("byteOffset", FormatBranchOffset(action.BranchOffset)));
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionGetVariable action, XElement param) {
            return new XElement(XActionNames.FromAction(action));
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionSetVariable action, XElement param) {
            return new XElement(XActionNames.FromAction(action));
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionGetURL2 action, XElement param) {
            return new XElement(XActionNames.FromAction(action),
               new XAttribute("flags", action.Flags));
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionGetProperty action, XElement param) {
            return new XElement(XActionNames.FromAction(action));
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionGotoFrame2 action, XElement param) {
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

        XElement IActionVisitor<XElement, XElement>.Visit(ActionRemoveSprite action, XElement param) {
            return new XElement("RemoveSprite");
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionSetProperty action, XElement param) {
            return new XElement("SetProperty");
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionSetTarget2 action, XElement param) {
            return new XElement("SetTarget2");
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionStartDrag action, XElement param) {
            return new XElement("StartDrag");
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionWaitForFrame2 action, XElement param) {
            return new XElement("WaitForFrame2",
             new XAttribute("skipCount", action.SkipCount));
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionCloneSprite action, XElement param) {
            return new XElement("CloneSprite");
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionEndDrag action, XElement param) {
            return new XElement("EndDrag");
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionGetTime action, XElement param) {
            return new XElement(XActionNames.FromAction(action));
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionRandomNumber action, XElement param) {
            return new XElement("RandomNumber");
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionTrace action, XElement param) {
            return new XElement(XActionNames.FromAction(action));
        }

        #endregion

        #region SWF 5

        XElement IActionVisitor<XElement, XElement>.Visit(ActionCallFunction action, XElement arg) {
            return arg;
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionCallMethod action, XElement arg) {
            return arg;
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionConstantPool action, XElement param) {
            var res = new XElement(XActionNames.FromAction(action));
            var strings = new XElement("strings");
            foreach (var item in action.ConstantPool) {
                strings.Add(new XElement("String", new XAttribute("value", item)));
            }
            res.Add(strings);
            return res;
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionDefineFunction action, XElement param) {
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

        XElement IActionVisitor<XElement, XElement>.Visit(ActionDefineLocal action, XElement arg) {
            return arg;
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionDefineLocal2 action, XElement arg) {
            return arg;
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionDelete action, XElement arg) {
            return arg;
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionDelete2 action, XElement arg) {
            return arg;
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionEnumerate action, XElement arg) {
            return arg;
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionEquals2 action, XElement arg) {
            return arg;
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionGetMember action, XElement arg) {
            return arg;
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionInitArray action, XElement arg) {
            return arg;
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionInitObject action, XElement arg) {
            return arg;
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionNewMethod action, XElement arg) {
            return arg;
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionNewObject action, XElement arg) {
            return arg;
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionSetMember action, XElement arg) {
            return arg;
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionTargetPath action, XElement arg) {
            return arg;
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionWith action, XElement arg) {
            return new XElement("With",
              new XAttribute("size", action.Size));
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionToNumber action, XElement arg) {
            return new XElement("ToNumber");
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionToString action, XElement arg) {
            return new XElement(XActionNames.FromAction(action));
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionTypeOf action, XElement arg) {
            return new XElement("TypeOf");
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionAdd2 action, XElement arg) {
            return arg;
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionLess2 action, XElement arg) {
            return arg;
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionModulo action, XElement arg) {
            return arg;
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionBitAnd action, XElement arg) {
            return arg;
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionBitLShift action, XElement arg) {
            return arg;
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionBitOr action, XElement arg) {
            return arg;
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionBitRShift action, XElement arg) {
            return arg;
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionBitURShift action, XElement arg) {
            return arg;
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionBitXor action, XElement arg) {
            return arg;
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionDecrement action, XElement arg) {
            return arg;
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionIncrement action, XElement arg) {
            return arg;
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionPushDuplicate action, XElement arg) {
            return arg;
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionReturn action, XElement arg) {
            return arg;
        }


        XElement IActionVisitor<XElement, XElement>.Visit(ActionStackSwap action, XElement arg) {
            return arg;
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionStoreRegister action, XElement arg) {
            return new XElement(XActionNames.FromAction(action),
                new XAttribute("reg", action.RegisterNumber));
        }

        #endregion

        #region SWF 6

        XElement IActionVisitor<XElement, XElement>.Visit(ActionInstanceOf action, XElement param) {
            return new XElement("InstanceOf");
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionEnumerate2 action, XElement param) {
            return new XElement("Enumerate2");
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionStrictEquals action, XElement param) {
            return new XElement("StrictEquals");
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionGreater action, XElement param) {
            return new XElement(XActionNames.FromAction(action));
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionStringGreater action, XElement param) {
            return new XElement("StringGreater");
        }

        #endregion

        #region SWF 7

        XElement IActionVisitor<XElement, XElement>.Visit(ActionDefineFunction2 action, XElement param) {
            var res = new XElement(XActionNames.FromAction(action));
            res.Add(new XAttribute("name", action.Name ?? ""));
            res.Add(new XAttribute("argc", action.Parameters.Count));
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
            foreach (var arg in action.Parameters) {
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

        XElement IActionVisitor<XElement, XElement>.Visit(ActionExtends action, XElement param) {
            return new XElement("Extends");
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionCastOp action, XElement param) {
            return new XElement(XActionNames.FromAction(action));
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionImplementsOp action, XElement param) {
            return new XElement(XActionNames.FromAction(action));
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionTry action, XElement param) {
            var res = new XElement(XActionNames.FromAction(action));
            if (action.Reserved != 0) {
                res.Add(new XAttribute("reserved", action.Reserved));
            }
            if (action.CatchInRegister) {
                res.Add(new XAttribute("catchReg", action.CatchRegister));
            } else {
                res.Add(new XAttribute("catchName", action.CatchName));
            }
            res.Add(XAction.ToXml(action.Try, new XElement("try")));
            if (action.CatchBlock) {
                res.Add(XAction.ToXml(action.Catch, new XElement("catch")));
            }
            if (action.FinallyBlock) {
                res.Add(XAction.ToXml(action.Finally, new XElement("finally")));
            }
            return res;
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionThrow action, XElement param) {
            return new XElement("Throw");
        }

        #endregion

        public XElement Visit(ActionEnd action, XElement arg) {
            return new XElement(XActionNames.FromAction(action));
        }

        XElement IActionVisitor<XElement, XElement>.Visit(ActionUnknown action, XElement arg) {
            return new XElement("Unknown",
                new XAttribute("type", action.ActionCode));
        }

        private static string FormatBranchOffset(short val) {
            var uval = (ushort)val;
            return uval.ToString();
        }
    }
}

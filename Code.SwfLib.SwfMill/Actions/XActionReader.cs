using System;
using System.Xml.Linq;
using Code.SwfLib.Actions;
using Code.SwfLib.SwfMill.Data;
using Code.SwfLib.SwfMill.Utils;

namespace Code.SwfLib.SwfMill.Actions {
    public class XActionReader : IActionVisitor<XElement, ActionBase> {

        private readonly ActionsFactory _factory = new ActionsFactory();

        public ActionBase Deserialize(XElement xAction) {
            var actionCode = XActionNames.FromNodeName(xAction.Name.LocalName);
            var action = _factory.Create(actionCode);
            action.AcceptVisitor(this, xAction);
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionGotoFrame action, XElement xAction) {
            action.Frame = xAction.RequiredUShortAttribute("frame", "GotoFrame");
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionGetURL action, XElement xAction) {
            action.UrlString = xAction.RequiredStringAttribute("url", "GetURL");
            action.TargetString = xAction.RequiredStringAttribute("target", "GetURL");
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionNextFrame action, XElement xAction) {
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionPreviousFrame action, XElement xAction) {
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionPlay action, XElement xAction) {
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionStop action, XElement xAction) {
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionToggleQuality action, XElement xAction) {
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionStopSounds action, XElement xAction) {
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionWaitForFrame action, XElement xAction) {
            var xSkip = xAction.Attribute("skipCount");
            action.Frame = xAction.RequiredUShortAttribute("frame", "WaitForFrame");
            action.SkipCount = byte.Parse(xSkip.Value);
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionSetTarget action, XElement xAction) {
            action.TargetName = xAction.RequiredStringAttribute("target", "SetTarget");
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionGoToLabel action, XElement xAction) {
            action.Label = xAction.RequiredStringAttribute("label", "GoToLabel");
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionAdd action, XElement xAction) {
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionDivide action, XElement xAction) {
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionMultiply action, XElement xAction) {
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionSubtract action, XElement xAction) {
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionEquals action, XElement xAction) {
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionLess action, XElement xAction) {
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionAnd action, XElement xAction) {
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionNot action, XElement xAction) {
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionOr action, XElement xAction) {
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionStringAdd action, XElement xAction) {
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionStringEquals action, XElement xAction) {
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionStringExtract action, XElement xAction) {
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionStringLength action, XElement xAction) {
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionMBStringExtract action, XElement xAction) {
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionMBStringLength action, XElement xAction) {
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionStringLess action, XElement xAction) {
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionPop action, XElement xAction) {
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionPush action, XElement xAction) {
            var xItems = xAction.Element("items");
            foreach (var xItem in xItems.Elements()) {
                var xValue = xItem.Attribute("value");
                var xReg = xItem.Attribute("reg");
                var xIndex = xItem.Attribute("index");
                switch (xItem.Name.LocalName) {
                    case "StackString":
                        action.Items.Add(new ActionPushItem { Type = ActionPushItemType.String, String = xItem.RequiredStringAttribute("value", "StackString") });
                        break;
                    case "StackFloat":
                        action.Items.Add(new ActionPushItem { Type = ActionPushItemType.Float, Float = float.Parse(xValue.Value) });
                        break;
                    case "StackNull":
                        action.Items.Add(new ActionPushItem { Type = ActionPushItemType.Null });
                        break;
                    case "StackUndefined":
                        action.Items.Add(new ActionPushItem { Type = ActionPushItemType.Undefined });
                        break;
                    case "StackRegister":
                        action.Items.Add(new ActionPushItem { Type = ActionPushItemType.Register, Register = byte.Parse(xReg.Value) });
                        break;
                    case "StackBoolean":
                        action.Items.Add(new ActionPushItem { Type = ActionPushItemType.Boolean, Boolean = byte.Parse(xValue.Value) });
                        break;
                    case "StackDouble":
                        action.Items.Add(new ActionPushItem { Type = ActionPushItemType.Double, Double = xItem.RequiredDoubleAttribute("value", "StackDouble") });
                        break;
                    case "StackInteger":
                        action.Items.Add(new ActionPushItem { Type = ActionPushItemType.Integer, Integer = xItem.RequiredIntAttribute("value", "StackInteger") });
                        break;
                    case "StackDictionaryLookup":
                        action.Items.Add(new ActionPushItem { Type = ActionPushItemType.Constant8, Constant8 = byte.Parse(xIndex.Value) });
                        break;
                    case "StackConstant16":
                        action.Items.Add(new ActionPushItem { Type = ActionPushItemType.Constant16, Constant16 = xItem.RequiredUShortAttribute("value", "StackConstant16") });
                        break;
                    default:
                        throw new NotSupportedException();
                }
            }
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionAsciiToChar action, XElement xAction) {
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionCharToAscii action, XElement xAction) {
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionToInteger action, XElement xAction) {
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionMBAsciiToChar action, XElement xAction) {
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionMBCharToAscii action, XElement xAction) {
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionCall action, XElement xAction) {
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionIf action, XElement xAction) {
            action.BranchOffset = ParseBranchOffset(xAction.Attribute("byteOffset").Value);
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionJump action, XElement xAction) {
            action.BranchOffset = ParseBranchOffset(xAction.Attribute("byteOffset").Value);
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionGetVariable action, XElement xAction) {
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionSetVariable action, XElement xAction) {
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionGetURL2 action, XElement xAction) {
            var xFlags = xAction.Attribute("flags");
            action.Flags = byte.Parse(xFlags.Value);
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionGetProperty action, XElement xAction) {
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionGotoFrame2 action, XElement xAction) {
            var xPlay = xAction.Attribute("play");
            var xBias = xAction.Attribute("bias");
            var xReserved = xAction.Attribute("reserved");
            action.Play = CommonFormatter.ParseBool(xPlay.Value);
            if (xBias != null) {
                action.SceneBias = ushort.Parse(xBias.Value);
            }
            if (xReserved != null) {
                action.Reserved = byte.Parse(xReserved.Value);
            }
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionRemoveSprite action, XElement xAction) {
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionSetProperty action, XElement xAction) {
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionSetTarget2 action, XElement xAction) {
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionStartDrag action, XElement xAction) {
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionWaitForFrame2 action, XElement xAction) {
            var xSkip = xAction.Attribute("skipCount");
            action.SkipCount = byte.Parse(xSkip.Value);
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionCloneSprite action, XElement xAction) {
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionEndDrag action, XElement xAction) {
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionGetTime action, XElement xAction) {
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionRandomNumber action, XElement xAction) {
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionTrace action, XElement xAction) {
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionCallFunction action, XElement xAction) {
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionCallMethod action, XElement xAction) {
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionConstantPool action, XElement xAction) {
            var xStrings = xAction.Element("strings");
            foreach (var xString in xStrings.Elements()) {
                action.ConstantPool.Add(xString.Attribute("value").Value);
            }
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionDefineFunction action, XElement xAction) {
            var xArgs = xAction.Element("args");
            var xActions = xAction.Element("actions");

            action.Name = xAction.RequiredStringAttribute("name", "DefineFunction");
            foreach (var xArg in xArgs.Elements()) {
                action.Args.Add(xArg.Attribute("name").Value);
            }

            if (xActions != null) {
                foreach (var xSubAction in xActions.Elements()) {
                    action.Actions.Add(XAction.FromXml(xSubAction));
                }
            }
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionDefineLocal action, XElement xAction) {
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionDefineLocal2 action, XElement xAction) {
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionDelete action, XElement xAction) {
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionDelete2 action, XElement xAction) {
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionEnumerate action, XElement xAction) {
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionEquals2 action, XElement xAction) {
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionGetMember action, XElement xAction) {
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionInitArray action, XElement xAction) {
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionInitObject action, XElement xAction) {
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionNewMethod action, XElement xAction) {
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionNewObject action, XElement xAction) {
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionSetMember action, XElement xAction) {
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionTargetPath action, XElement xAction) {
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionWith action, XElement xAction) {
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionToNumber action, XElement xAction) {
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionToString action, XElement xAction) {
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionTypeOf action, XElement xAction) {
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionAdd2 action, XElement xAction) {
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionLess2 action, XElement xAction) {
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionModulo action, XElement xAction) {
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionBitAnd action, XElement xAction) {
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionBitLShift action, XElement xAction) {
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionBitOr action, XElement xAction) {
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionBitRShift action, XElement xAction) {
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionBitURShift action, XElement xAction) {
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionBitXor action, XElement xAction) {
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionDecrement action, XElement xAction) {
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionIncrement action, XElement xAction) {
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionPushDuplicate action, XElement xAction) {
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionReturn action, XElement xAction) {
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionStackSwap action, XElement xAction) {
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionStoreRegister action, XElement xAction) {
            var xRegister = xAction.Attribute("reg");
            action.RegisterNumber = byte.Parse(xRegister.Value);
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionInstanceOf action, XElement xAction) {
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionEnumerate2 action, XElement xAction) {
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionStrictEquals action, XElement xAction) {
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionGreater action, XElement xAction) {
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionStringGreater action, XElement xAction) {
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionDefineFunction2 action, XElement xAction) {
            var xName = xAction.Attribute("name");
            var xRegisterCount = xAction.Attribute("regc");
            var xPreloadParent = xAction.Attribute("preloadParent");
            var xPreloadRoot = xAction.Attribute("preloadRoot");
            var xSuppressSuper = xAction.Attribute("suppressSuper");
            var xPreloadSuper = xAction.Attribute("preloadSuper");
            var xSuppressArguments = xAction.Attribute("suppressArguments");
            var xPreloadArguments = xAction.Attribute("preloadArguments");
            var xSuppressThis = xAction.Attribute("suppressThis");
            var xPreloadThis = xAction.Attribute("preloadThis");
            var xReserved = xAction.Attribute("reserved");
            var xPreloadGlobal = xAction.Attribute("preloadGlobal");

            action.Name = xName != null ? xName.Value : "";
            action.RegisterCount = byte.Parse(xRegisterCount.Value);
            action.PreloadParent = CommonFormatter.ParseBool(xPreloadParent.Value);
            action.PreloadRoot = CommonFormatter.ParseBool(xPreloadRoot.Value);
            action.SuppressSuper = CommonFormatter.ParseBool(xSuppressSuper.Value);
            action.PreloadSuper = CommonFormatter.ParseBool(xPreloadSuper.Value);
            action.SuppressArguments = CommonFormatter.ParseBool(xSuppressArguments.Value);
            action.PreloadArguments = CommonFormatter.ParseBool(xPreloadArguments.Value);
            action.SuppressThis = CommonFormatter.ParseBool(xSuppressThis.Value);
            action.PreloadThis = CommonFormatter.ParseBool(xPreloadThis.Value);
            action.Reserved = byte.Parse(xReserved.Value);
            action.PreloadGlobal = CommonFormatter.ParseBool(xPreloadGlobal.Value);

            var xArgs = xAction.Element("args");
            foreach (var xArg in xArgs.Elements()) {
                var xReg = xArg.Attribute("reg");
                var xArgName = xArg.Attribute("name");
                action.Parameters.Add(new RegisterParam {
                    Register = byte.Parse(xReg.Value),
                    Name = xArgName.Value
                });
            }

            var xActions = xAction.Element("actions");
            foreach (var xSubAction in xActions.Elements()) {
                action.Actions.Add(Deserialize(xSubAction));
            }
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionExtends action, XElement xAction) {
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionCastOp action, XElement xAction) {
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionImplementsOp action, XElement xAction) {
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionTry action, XElement xAction) {
            var xReserved = xAction.Attribute("reserved");
            var xCatchReg = xAction.Attribute("catchReg");
            var xCatchName = xAction.Attribute("catchName");
            var xTry = xAction.Element("try");
            var xCatch = xAction.Element("catch");
            var xFinally = xAction.Element("finally");

            if (xReserved != null) {
                action.Reserved = byte.Parse(xReserved.Value);
            }
            if (xCatchReg != null && xCatchName == null) {
                action.CatchInRegister = true;
                action.CatchRegister = byte.Parse(xCatchReg.Value);
            } else if (xCatchReg == null && xCatchName != null) {
                action.CatchInRegister = false;
                action.CatchName = xCatchName.Value;
            } else if (xCatchReg != null && xCatchName != null) {
                throw new InvalidOperationException("catchReg and catchName are mutally exclusive");
            } else {
                throw new InvalidOperationException("Either catchReg or catchName must be specified");
            }

            XAction.FromXml(xTry, action.Try);
            if (xCatch != null) {
                action.CatchBlock = true;
                XAction.FromXml(xCatch, action.Catch);
            }
            if (xFinally != null) {
                action.FinallyBlock = true;
                XAction.FromXml(xFinally, action.Finally);
            }
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionThrow action, XElement xAction) {
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionEnd action, XElement xAction) {
            return action;
        }

        ActionBase IActionVisitor<XElement, ActionBase>.Visit(ActionUnknown action, XElement xAction) {
            return action;
        }


        private short ParseBranchOffset(string val) {
            var uval = ushort.Parse(val);
            return (short)uval;
        }
    }
}

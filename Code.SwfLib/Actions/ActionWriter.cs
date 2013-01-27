﻿using System;
using System.IO;

namespace Code.SwfLib.Actions {
    public class ActionWriter : IActionVisitor<SwfStreamWriter, object> {

        private readonly SwfStreamWriter _writer;

        public ActionWriter(SwfStreamWriter writer) {
            _writer = writer;
        }

        public void WriteAction(ActionBase action) {
            var type = action.ActionCode;
            _writer.WriteByte((byte)type);
            if ((byte)type >= 0x80) {
                var mem = new MemoryStream();
                var writer = new SwfStreamWriter(mem);
                action.AcceptVisitor(this, writer);
                _writer.WriteUInt16((ushort)writer.BaseStream.Length);
                _writer.WriteBytes(mem.ToArray());
            }
        }

        #region SWF 3

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionGotoFrame action, SwfStreamWriter writer) {
            writer.WriteUInt16(action.Frame);
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionGetURL action, SwfStreamWriter writer) {
            writer.WriteString(action.UrlString);
            writer.WriteString(action.TargetString);
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionNextFrame action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionPreviousFrame action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionPlay action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionStop action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionToggleQuality action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionStopSounds action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionWaitForFrame action, SwfStreamWriter writer) {
            writer.WriteUInt16(action.Frame);
            writer.WriteByte(action.SkipCount);
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionSetTarget action, SwfStreamWriter writer) {
            writer.WriteString(action.TargetName);
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionGoToLabel action, SwfStreamWriter writer) {
            writer.WriteString(action.Label);
            return null;
        }

        #endregion

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionAdd action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionDivide action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionMultiply action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionSubtract action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionEquals action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionLess action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionAnd action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionNot action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionOr action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionStringAdd action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionStringEquals action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionStringExtract action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionStringLength action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionMBStringExtract action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionMBStringLength action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionStringLess action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionPop action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionPush action, SwfStreamWriter writer) {
            foreach (var item in action.Items) {
                writer.WriteByte((byte)item.Type);
                switch (item.Type) {
                    case ActionPushItemType.String:
                        writer.WriteString(item.String);
                        break;
                    case ActionPushItemType.Float:
                        writer.WriteSingle(item.Float);
                        break;
                    case ActionPushItemType.Null:
                        break;
                    case ActionPushItemType.Undefined:
                        break;
                    case ActionPushItemType.Register:
                        writer.WriteByte(item.Register);
                        break;
                    case ActionPushItemType.Boolean:
                        writer.WriteByte(item.Boolean);
                        break;
                    case ActionPushItemType.Double:
                        writer.WriteDouble(item.Double);
                        break;
                    case ActionPushItemType.Integer:
                        writer.WriteUInt32(item.Integer);
                        break;
                    case ActionPushItemType.Constant8:
                        writer.WriteByte(item.Constant8);
                        break;
                    case ActionPushItemType.Constant16:
                        writer.WriteUInt16(item.Constant16);
                        break;
                    default:
                        throw new NotSupportedException("Unknown PushData type " + item.Type);
                }
            }
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionAsciiToChar action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionCharToAscii action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionToInteger action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionMBAsciiToChar action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionMBCharToAscii action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionCall action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionIf action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionJump action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionGetVariable action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionSetVariable action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionGetURL2 action, SwfStreamWriter writer) {
            writer.WriteByte(action.Flags);
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionGetProperty action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionGotoFrame2 action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionRemoveSprite action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionSetProperty action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionSetTarget2 action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionStartDrag action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionWaitForFrame2 action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionCloneSprite action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionEndDrag action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionGetTime action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionRandomNumber action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionTrace action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionCallFunction action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionCallMethod action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionConstantPool action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionDefineFunction action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionDefineLocal action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionDefineLocal2 action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionDelete action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionDelete2 action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionEnumerate action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionEquals2 action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionGetMember action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionInitArray action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionInitObject action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionNewMethod action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionNewObject action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionSetMember action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionTargetPath action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionWith action, SwfStreamWriter writer) {
            writer.WriteUInt16(action.Size);
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionToNumber action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionToString action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionTypeOf action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionAdd2 action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionLess2 action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionModulo action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionBitAnd action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionBitLShift action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionBitOr action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionBitRShift action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionBitURShift action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionBitXor action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionDecrement action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionIncrement action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionPushDuplicate action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionReturn action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionStackSwap action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionStoreRegister action, SwfStreamWriter writer) {
            writer.WriteByte(action.RegisterNumber);
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionInstanceOf action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionEnumerate2 action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionStrictEquals action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionGreater action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionStringGreater action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionDefineFunction2 action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionExtends action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionCastOp action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionImplementsOp action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionTry action, SwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionThrow action, SwfStreamWriter writer) {
            return null;
        }

        public object Visit(ActionEnd action, SwfStreamWriter arg) {
            return null;
        }

        object IActionVisitor<SwfStreamWriter, object>.Visit(ActionUnknown action, SwfStreamWriter writer) {
            return null;
        }
    }
}

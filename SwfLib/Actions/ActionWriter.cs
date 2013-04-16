using System;
using System.Collections.Generic;
using System.IO;
using Code.SwfLib.Actions;

namespace SwfLib.Actions {
    public class ActionWriter : IActionVisitor<ISwfStreamWriter, object> {

        private readonly ISwfStreamWriter _writer;

        public ActionWriter(ISwfStreamWriter writer) {
            _writer = writer;
        }

        public void WriteAction(ActionBase action) {
            var type = action.ActionCode;
            _writer.WriteByte((byte)type);
            if ((byte)type >= 0x80) {
                var mem = new MemoryStream();
                var writer = new SwfStreamWriter(mem);
                var rest = action.AcceptVisitor(this, writer) as byte[];
                _writer.WriteUInt16((ushort)writer.Length);
                _writer.WriteBytes(mem.ToArray());
                if (rest != null) {
                    _writer.WriteBytes(rest);
                }
#if DEBUG
            } else {
                action.AcceptVisitor(this, null);
#endif
            }
        }

        #region SWF 3

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionGotoFrame action, ISwfStreamWriter writer) {
            writer.WriteUInt16(action.Frame);
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionGetURL action, ISwfStreamWriter writer) {
            writer.WriteString(action.UrlString);
            writer.WriteString(action.TargetString);
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionNextFrame action, ISwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionPreviousFrame action, ISwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionPlay action, ISwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionStop action, ISwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionToggleQuality action, ISwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionStopSounds action, ISwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionWaitForFrame action, ISwfStreamWriter writer) {
            writer.WriteUInt16(action.Frame);
            writer.WriteByte(action.SkipCount);
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionSetTarget action, ISwfStreamWriter writer) {
            writer.WriteString(action.TargetName);
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionGoToLabel action, ISwfStreamWriter writer) {
            writer.WriteString(action.Label);
            return null;
        }

        #endregion

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionAdd action, ISwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionDivide action, ISwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionMultiply action, ISwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionSubtract action, ISwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionEquals action, ISwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionLess action, ISwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionAnd action, ISwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionNot action, ISwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionOr action, ISwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionStringAdd action, ISwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionStringEquals action, ISwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionStringExtract action, ISwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionStringLength action, ISwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionMBStringExtract action, ISwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionMBStringLength action, ISwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionStringLess action, ISwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionPop action, ISwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionPush action, ISwfStreamWriter writer) {
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
                        writer.WriteInt32(item.Integer);
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

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionAsciiToChar action, ISwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionCharToAscii action, ISwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionToInteger action, ISwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionMBAsciiToChar action, ISwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionMBCharToAscii action, ISwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionCall action, ISwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionIf action, ISwfStreamWriter writer) {
            writer.WriteSInt16(action.BranchOffset);
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionJump action, ISwfStreamWriter writer) {
            writer.WriteSInt16(action.BranchOffset);
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionGetVariable action, ISwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionSetVariable action, ISwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionGetURL2 action, ISwfStreamWriter writer) {
            writer.WriteByte(action.Flags);
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionGetProperty action, ISwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionGotoFrame2 action, ISwfStreamWriter writer) {
            writer.WriteUnsignedBits(action.Reserved, 6);
            writer.WriteBit(action.SceneBias.HasValue);
            writer.WriteBit(action.Play);
            if (action.SceneBias.HasValue) {
                writer.WriteUInt16(action.SceneBias.Value);
            }
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionRemoveSprite action, ISwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionSetProperty action, ISwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionSetTarget2 action, ISwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionStartDrag action, ISwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionWaitForFrame2 action, ISwfStreamWriter writer) {
            writer.WriteByte(action.SkipCount);
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionCloneSprite action, ISwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionEndDrag action, ISwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionGetTime action, ISwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionRandomNumber action, ISwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionTrace action, ISwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionCallFunction action, ISwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionCallMethod action, ISwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionConstantPool action, ISwfStreamWriter writer) {
            writer.WriteUInt16((ushort)action.ConstantPool.Count);
            foreach (var str in action.ConstantPool) {
                writer.WriteString(str);
            }
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionDefineFunction action, ISwfStreamWriter writer) {
            writer.WriteString(action.Name ?? "");
            writer.WriteUInt16((ushort)action.Args.Count);
            foreach (var arg in action.Args) {
                writer.WriteString(arg);
            }
            var awmem = new MemoryStream();
            var aw = new ActionWriter(new SwfStreamWriter(awmem));
            foreach (var subaction in action.Actions) {
                aw.WriteAction(subaction);
            }

            writer.WriteUInt16((ushort)awmem.Length);

            return awmem.ToArray();
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionDefineLocal action, ISwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionDefineLocal2 action, ISwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionDelete action, ISwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionDelete2 action, ISwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionEnumerate action, ISwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionEquals2 action, ISwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionGetMember action, ISwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionInitArray action, ISwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionInitObject action, ISwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionNewMethod action, ISwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionNewObject action, ISwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionSetMember action, ISwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionTargetPath action, ISwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionWith action, ISwfStreamWriter writer) {
            var awmem = new MemoryStream();
            var aw = new ActionWriter(new SwfStreamWriter(awmem));
            foreach (var subaction in action.Actions) {
                aw.WriteAction(subaction);
            }

            writer.WriteUInt16((ushort)awmem.Length);

            return awmem.ToArray();
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionToNumber action, ISwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionToString action, ISwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionTypeOf action, ISwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionAdd2 action, ISwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionLess2 action, ISwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionModulo action, ISwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionBitAnd action, ISwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionBitLShift action, ISwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionBitOr action, ISwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionBitRShift action, ISwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionBitURShift action, ISwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionBitXor action, ISwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionDecrement action, ISwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionIncrement action, ISwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionPushDuplicate action, ISwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionReturn action, ISwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionStackSwap action, ISwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionStoreRegister action, ISwfStreamWriter writer) {
            writer.WriteByte(action.RegisterNumber);
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionInstanceOf action, ISwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionEnumerate2 action, ISwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionStrictEquals action, ISwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionGreater action, ISwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionStringGreater action, ISwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionDefineFunction2 action, ISwfStreamWriter writer) {
            writer.WriteString(action.Name ?? "");
            writer.WriteUInt16((ushort)action.Parameters.Count);
            writer.WriteByte(action.RegisterCount);

            writer.WriteBit(action.PreloadParent);
            writer.WriteBit(action.PreloadRoot);
            writer.WriteBit(action.SuppressSuper);
            writer.WriteBit(action.PreloadSuper);
            writer.WriteBit(action.SuppressArguments);
            writer.WriteBit(action.PreloadArguments);
            writer.WriteBit(action.SuppressThis);
            writer.WriteBit(action.PreloadThis);
            writer.WriteUnsignedBits(action.Reserved, 7);
            writer.WriteBit(action.PreloadGlobal);

            foreach (var arg in action.Parameters) {
                writer.WriteByte(arg.Register);
                writer.WriteString(arg.Name);
            }

            var mem = new MemoryStream();
            var subWriter = new ActionWriter(new SwfStreamWriter(mem));
            foreach (var subAction in action.Actions) {
                subWriter.WriteAction(subAction);
            }

            writer.WriteUInt16((ushort)mem.Length);

            return mem.ToArray();
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionExtends action, ISwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionCastOp action, ISwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionImplementsOp action, ISwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionTry action, ISwfStreamWriter writer) {
            writer.WriteUnsignedBits(action.Reserved, 5);
            writer.WriteBit(action.CatchInRegister);
            writer.WriteBit(action.FinallyBlock);
            writer.WriteBit(action.CatchBlock);

            var tryBlock = GetBody(action.Try);
            var catchBlock = action.CatchBlock ? GetBody(action.Catch) : null;
            var finallyBlock = action.FinallyBlock ? GetBody(action.Finally) : null;

            writer.WriteUInt16((ushort)tryBlock.Length);
            writer.WriteUInt16(catchBlock != null ? (ushort)catchBlock.Length : (ushort)0);
            writer.WriteUInt16(finallyBlock != null ? (ushort)finallyBlock.Length : (ushort)0);

            if (action.CatchInRegister) {
                writer.WriteByte(action.CatchRegister);
            } else {
                writer.WriteString(action.CatchName);
            }

            writer.WriteBytes(tryBlock);
            if (catchBlock != null) writer.WriteBytes(catchBlock);
            if (finallyBlock != null) writer.WriteBytes(finallyBlock);
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionThrow action, ISwfStreamWriter writer) {
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionEnd action, ISwfStreamWriter arg) {
            return null;
        }

        object IActionVisitor<ISwfStreamWriter, object>.Visit(ActionUnknown action, ISwfStreamWriter writer) {
            writer.WriteBytes(action.Data);
            return null;
        }

        private static byte[] GetBody(IEnumerable<ActionBase> actions) {
            var mem = new MemoryStream();
            var aw = new ActionWriter(new SwfStreamWriter(mem));
            foreach (var action in actions) {
                aw.WriteAction(action);
            }
            return mem.ToArray();
        }
    }
}

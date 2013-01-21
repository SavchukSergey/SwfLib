using System;
using Code.SwfLib.Data.Actions;

namespace Code.SwfLib.Actions {
    public class ActionsReader {
        private readonly SwfStreamReader _reader;

        public ActionsReader(SwfStreamReader reader) {
            _reader = reader;
        }

        public ActionBase ReadAction() {
            var code = (ActionCode)_reader.ReadByte();

            ushort length = (byte)code >= 0x80 ? _reader.ReadUInt16() : (ushort)0;

            switch (code) {
                case ActionCode.Pop:
                case ActionCode.Equals:
                case ActionCode.Less:
                case ActionCode.Not:
                case ActionCode.StringLength:
                case ActionCode.StringAdd:
                case ActionCode.StringExtract:
                case ActionCode.StringLess:
                case ActionCode.MBStringLength:
                case ActionCode.MBStringExtract:
                case ActionCode.ToInteger:
                case ActionCode.CharToAscii:
                case ActionCode.AsciiToChar:
                case ActionCode.MBCharToAscii:
                case ActionCode.MBAsciiToChar:
                case ActionCode.If:
                case ActionCode.SetVariable:
                case ActionCode.GetURL2:
                case ActionCode.GotoFrame2:
                case ActionCode.SetTarget2:
                case ActionCode.GetProperty:
                case ActionCode.SetProperty:
                case ActionCode.CloneSprite:
                case ActionCode.RemoveSprite:
                case ActionCode.GetTime:
                    throw new NotImplementedException(code.ToString());

                case ActionCode.Empty:
                    return null;
                case ActionCode.Add:
                    return ReadActionAdd(length);
                case ActionCode.And:
                    return ReadActionAnd(length);
                case ActionCode.Call:
                    return ReadActionCall(length);
                case ActionCode.ConstantPool:
                    return ReadActionConstantPool(length);
                case ActionCode.DefineFunction:
                    return ReadActionDefineFunction(length);
                case ActionCode.Divide:
                    return ReadActionDivide(length);
                case ActionCode.EndDrag:
                    return ReadActionEndDrag(length);
                case ActionCode.GetURL:
                    return ReadActionGetURL(length);
                case ActionCode.GetVariable:
                    return ReadActionGetVariable(length);
                case ActionCode.GotoFrame:
                    return ReadActionGotoFrame(length);
                case ActionCode.GoToLabel:
                    return ReadActionGoToLabel(length);
                case ActionCode.Jump:
                    return ReadActionJump();
                case ActionCode.Multiply:
                    return ReadActionMultiply();
                case ActionCode.NextFrame:
                    return ReadActionNextFrame();
                case ActionCode.Or:
                    return ReadActionOr();
                case ActionCode.Play:
                    return ReadActionPlay();
                case ActionCode.PreviousFrame:
                    return ReadActionPreviousFrame();
                case ActionCode.Push:
                    return ReadActionPush(length);
                case ActionCode.RandomNumber:
                    return ReadActionRandomNumber(length);
                case ActionCode.SetMember:
                    return ReadActionSetMember(length);
                case ActionCode.SetTarget:
                    return ReadActionSetTarget(length);
                case ActionCode.StartDrag:
                    return ReadActionStartDrag();
                case ActionCode.Stop:
                    return ReadActionStop(length);
                case ActionCode.StopSounds:
                    return ReadActionStopSounds(length);
                case ActionCode.StringEquals:
                    return ReadActionStringEquals(length);
                case ActionCode.Substract:
                    return ReadActionSubtract();
                case ActionCode.ToggleQuality:
                    return ReadActionToggleQuality(length);
                case ActionCode.Trace:
                    return ReadActionTrace(length);
                case ActionCode.WaitForFrame:
                    return ReadActionWaitForFrame(length);
                case ActionCode.WaitForFrame2:
                    return ReadActionWaitForFrame2(length);
                default:
                    throw new NotSupportedException("ActionCode is " + code);
            }
            //TODO: other actions (SWF 5-10)
        }

        public ActionAdd ReadActionAdd(ushort length) {
            return new ActionAdd();
        }

        public ActionAnd ReadActionAnd(ushort length) {
            return new ActionAnd();
        }

        public ActionCall ReadActionCall(ushort length) {
            return new ActionCall();
        }

        public ActionConstantPool ReadActionConstantPool(ushort length) {
            ushort count = _reader.ReadUInt16();
            var pool = new string[count];
            for (var i = 0; i < count; i++) {
                pool[i] = _reader.ReadString();
            }
            return new ActionConstantPool { ConstantPool = pool };
        }

        public ActionDivide ReadActionDivide(ushort length) {
            return new ActionDivide();
        }

        public ActionEndDrag ReadActionEndDrag(ushort length) {
            return new ActionEndDrag();
        }

        public ActionDefineFunction ReadActionDefineFunction(ushort length) {
            string name = _reader.ReadString();
            ushort count = _reader.ReadUInt16();
            var parameters = new string[count];
            for (var i = 0; i < count; i++) {
                parameters[i] = _reader.ReadString();
            }
            ushort bodySize = _reader.ReadUInt16();
            return new ActionDefineFunction { FunctionName = name, Params = parameters, Body = _reader.ReadBytes(bodySize) };
        }

        public ActionGetURL ReadActionGetURL(ushort length) {
            return new ActionGetURL { UrlString = _reader.ReadString(), TargetString = _reader.ReadString() };
        }

        public ActionGetVariable ReadActionGetVariable(ushort length) {
            return new ActionGetVariable();
        }

        public ActionGotoFrame ReadActionGotoFrame(ushort length) {
            return new ActionGotoFrame { Frame = _reader.ReadUInt16() };
        }

        public ActionGoToLabel ReadActionGoToLabel(ushort length) {
            return new ActionGoToLabel { Label = _reader.ReadString() };
        }

        public ActionJump ReadActionJump() {
            return new ActionJump { BranchOffset = _reader.ReadSInt16() };
        }

        public ActionMultiply ReadActionMultiply() {
            return new ActionMultiply();
        }

        public ActionNextFrame ReadActionNextFrame() {
            return new ActionNextFrame();
        }

        public ActionOr ReadActionOr() {
            return new ActionOr();
        }

        public ActionPlay ReadActionPlay() {
            return new ActionPlay();
        }

        public ActionPreviousFrame ReadActionPreviousFrame() {
            return new ActionPreviousFrame();
        }

        public ActionPush ReadActionPush(ushort length) {
            var position = _reader.BaseStream.Position;
            var action = new ActionPush();
            while (_reader.BaseStream.Position - position < length) {
                var item = new ActionPushItem();
                var type = (ActionPushItemType)_reader.ReadByte();
                Console.WriteLine(type);
                item.Type = type;
                switch (type) {
                    case ActionPushItemType.Boolean:
                        item.Boolean = _reader.ReadByte();
                        break;
                    case ActionPushItemType.Constant8:
                        item.Constant8 = _reader.ReadByte();
                        break;
                    case ActionPushItemType.Constant16:
                        item.Constant16 = _reader.ReadUInt16();
                        break;
                    default:
                        throw new NotSupportedException("Unknown PushData type " + type);
                }
                action.Items.Add(item);
            }
            return action;
        }

        public ActionRandomNumber ReadActionRandomNumber(ushort length) {
            return new ActionRandomNumber();
        }

        public ActionSetMember ReadActionSetMember(ushort length) {
            return new ActionSetMember();
        }

        public ActionSetTarget ReadActionSetTarget(ushort length) {
            return new ActionSetTarget { TargetName = _reader.ReadString() };
        }

        public ActionStartDrag ReadActionStartDrag() {
            return new ActionStartDrag();
        }

        public ActionStop ReadActionStop(ushort length) {
            return new ActionStop();
        }

        public ActionStopSounds ReadActionStopSounds(ushort length) {
            return new ActionStopSounds();
        }

        public ActionStringEquals ReadActionStringEquals(ushort length) {
            return new ActionStringEquals();
        }

        public ActionSubtract ReadActionSubtract() {
            return new ActionSubtract();
        }

        public ActionToggleQuality ReadActionToggleQuality(ushort length) {
            return new ActionToggleQuality();
        }

        public ActionTrace ReadActionTrace(ushort length) {
            return new ActionTrace();
        }

        public ActionWaitForFrame ReadActionWaitForFrame(ushort length) {
            return new ActionWaitForFrame { Frame = _reader.ReadUInt16(), SkipCount = _reader.ReadByte() };
        }

        public ActionWaitForFrame2 ReadActionWaitForFrame2(ushort length) {
            return new ActionWaitForFrame2 { SkipCount = _reader.ReadByte() };
        }

    }
}

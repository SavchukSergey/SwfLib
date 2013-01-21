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
                //SWF 3
                case ActionCode.GotoFrame:
                    return ReadGotoFrame(length);
                case ActionCode.GetURL:
                    return ReadGetURL(length);
                case ActionCode.NextFrame:
                    return ReadNextFrame();
                case ActionCode.PreviousFrame:
                    return ReadPreviousFrame();
                case ActionCode.Play:
                    return ReadPlay();
                case ActionCode.Stop:
                    return ReadStop(length);
                case ActionCode.ToggleQuality:
                    return ReadToggleQuality(length);
                case ActionCode.StopSounds:
                    return ReadStopSounds(length);
                case ActionCode.WaitForFrame:
                    return ReadWaitForFrame(length);
                case ActionCode.SetTarget:
                    return ReadSetTarget(length);
                case ActionCode.GoToLabel:
                    return ReadGoToLabel(length);

                //SWF 4
                case ActionCode.Add:
                    return ReadAdd();
                case ActionCode.Divide:
                    return ReadDivide();
                case ActionCode.Multiply:
                    return ReadMultiply();
                case ActionCode.Subtract:
                    return ReadSubtract();

                case ActionCode.Equals:
                    return ReadEquals();
                case ActionCode.Less:
                    return ReadLess();

                case ActionCode.And:
                    return ReadAnd();
                case ActionCode.Not:
                    return ReadNot();
                case ActionCode.Or:
                    return ReadOr();
                case ActionCode.StringAdd:
                    return ReadStringAdd();
                case ActionCode.StringEquals:
                    return ReadStringEquals();
                case ActionCode.StringExtract:
                    return ReadStringExtract();
                case ActionCode.StringLength:
                    return ReadStringLength();
                case ActionCode.MBStringExtract:
                    return ReadMBStringExtract();
                case ActionCode.MBStringLength:
                    return ReadMBStringLength();
                case ActionCode.StringLess:
                    return ReadStringLess();

                case ActionCode.Pop:
                    return ReadPop();
                case ActionCode.Push:
                    return ReadPush(length);

                case ActionCode.AsciiToChar:
                    return ReadAsciiToChar();
                case ActionCode.CharToAscii:
                    return ReadCharToAscii();
                case ActionCode.ToInteger:
                    return ReadToInteger();
                case ActionCode.MBAsciiToChar:
                    return ReadMBAsciiToChar();
                case ActionCode.MBCharToAscii:
                    return ReadMBCharToAscii();

                case ActionCode.Call:
                    return ReadCall();
                case ActionCode.If:
                    return ReadIf();
                case ActionCode.Jump:
                    return ReadJump();

                case ActionCode.GetVariable:
                    return ReadGetVariable();
                case ActionCode.SetVariable:
                    return ReadSetVariable();

                case ActionCode.GetURL2:
                    return ReadGetURL2();
                case ActionCode.GetProperty:
                    return ReadGetProperty();
                case ActionCode.GotoFrame2:
                    return ReadGoToFrame2();
                case ActionCode.RemoveSprite:
                    return ReadRemoveSprite();
                case ActionCode.SetProperty:
                    return ReadSetProperty();
                case ActionCode.SetTarget2:
                    return ReadSetTarget2();
                case ActionCode.StartDrag:
                    return ReadStartDrag();
                case ActionCode.WaitForFrame2:
                    return ReadWaitForFrame2();
                case ActionCode.CloneSprite:
                    return ReadCloneSprite();
                case ActionCode.EndDrag:
                    return ReadEndDrag();

                case ActionCode.GetTime:
                    return ReadGetTime();
                case ActionCode.RandomNumber:
                    return ReadRandomNumber();
                case ActionCode.Trace:
                    return ReadTrace();


                //Other
                case ActionCode.Empty:
                    return null;
                case ActionCode.ConstantPool:
                    return ReadActionConstantPool(length);
                case ActionCode.DefineFunction:
                    return ReadActionDefineFunction(length);
                case ActionCode.SetMember:
                    return ReadActionSetMember(length);
                default:
                    throw new NotSupportedException("ActionCode is " + code);
            }
            //TODO: other actions (SWF 5-10)
        }

        #region SWF 3 actions

        public ActionGotoFrame ReadGotoFrame(ushort length) {
            return new ActionGotoFrame { Frame = _reader.ReadUInt16() };
        }

        public ActionGetURL ReadGetURL(ushort length) {
            return new ActionGetURL { UrlString = _reader.ReadString(), TargetString = _reader.ReadString() };
        }

        public ActionNextFrame ReadNextFrame() {
            return new ActionNextFrame();
        }

        public ActionPreviousFrame ReadPreviousFrame() {
            return new ActionPreviousFrame();
        }

        public ActionPlay ReadPlay() {
            return new ActionPlay();
        }

        public ActionStop ReadStop(ushort length) {
            return new ActionStop();
        }

        public ActionToggleQuality ReadToggleQuality(ushort length) {
            return new ActionToggleQuality();
        }

        public ActionStopSounds ReadStopSounds(ushort length) {
            return new ActionStopSounds();
        }

        public ActionWaitForFrame ReadWaitForFrame(ushort length) {
            return new ActionWaitForFrame { Frame = _reader.ReadUInt16(), SkipCount = _reader.ReadByte() };
        }

        public ActionSetTarget ReadSetTarget(ushort length) {
            return new ActionSetTarget { TargetName = _reader.ReadString() };
        }

        public ActionGoToLabel ReadGoToLabel(ushort length) {
            return new ActionGoToLabel { Label = _reader.ReadString() };
        }

        #endregion

        #region SWF 4 actions

        #region Arithmetic operators

        private ActionAdd ReadAdd() {
            return new ActionAdd();
        }

        private ActionDivide ReadDivide() {
            return new ActionDivide();
        }

        private ActionMultiply ReadMultiply() {
            return new ActionMultiply();
        }

        private ActionSubtract ReadSubtract() {
            return new ActionSubtract();
        }

        #endregion

        #region Numerical comparision

        private ActionEquals ReadEquals() {
            return new ActionEquals();
        }

        private ActionLess ReadLess() {
            return new ActionLess();
        }

        #endregion

        #region Logical operators

        private ActionAnd ReadAnd() {
            return new ActionAnd();
        }

        private ActionNot ReadNot() {
            return new ActionNot();
        }

        private ActionOr ReadOr() {
            return new ActionOr();
        }

        #endregion

        #region String manipulation

        private ActionStringAdd ReadStringAdd() {
            return new ActionStringAdd();
        }

        private ActionStringEquals ReadStringEquals() {
            return new ActionStringEquals();
        }

        private ActionStringExtract ReadStringExtract() {
            return new ActionStringExtract();
        }

        private ActionStringLength ReadStringLength() {
            return new ActionStringLength();
        }

        private ActionMBStringExtract ReadMBStringExtract() {
            return new ActionMBStringExtract();
        }

        private ActionMBStringLength ReadMBStringLength() {
            return new ActionMBStringLength();
        }

        private ActionStringEquals ReadStringLess() {
            return new ActionStringEquals();
        }

        #endregion

        #region Stack operations

        private ActionPop ReadPop() {
            return new ActionPop();
        }

        private ActionPush ReadPush(ushort length) {
            var position = _reader.BaseStream.Position;
            var action = new ActionPush();
            while (_reader.BaseStream.Position - position < length) {
                var item = new ActionPushItem();
                var type = (ActionPushItemType)_reader.ReadByte();
                item.Type = type;
                switch (type) {
                    case ActionPushItemType.String:
                        item.String = _reader.ReadString();
                        break;
                    case ActionPushItemType.Float:
                        item.Float = _reader.ReadSingle();
                        break;
                    case ActionPushItemType.Undefined:
                        break;
                    case ActionPushItemType.Register:
                        item.Register = _reader.ReadByte();
                        break;
                    case ActionPushItemType.Boolean:
                        item.Boolean = _reader.ReadByte();
                        break;
                    case ActionPushItemType.Double:
                        item.Double = _reader.ReadDouble();
                        break;
                    case ActionPushItemType.Integer:
                        item.Integer = _reader.ReadInt32();
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

        #endregion

        #region Type Conversion

        private ActionAsciiToChar ReadAsciiToChar() {
            return new ActionAsciiToChar();
        }

        private ActionCharToAscii ReadCharToAscii() {
            return new ActionCharToAscii();
        }

        private ActionToInteger ReadToInteger() {
            return new ActionToInteger();
        }

        private ActionMBAsciiToChar ReadMBAsciiToChar() {
            return new ActionMBAsciiToChar();
        }

        private ActionMBCharToAscii ReadMBCharToAscii() {
            return new ActionMBCharToAscii();
        }

        #endregion

        #region Control flow

        private ActionCall ReadCall() {
            return new ActionCall();
        }

        private ActionIf ReadIf() {
            return new ActionIf { BranchOffset = _reader.ReadSInt16() };
        }

        private ActionJump ReadJump() {
            return new ActionJump { BranchOffset = _reader.ReadSInt16() };
        }

        #endregion

        #region Variables

        private ActionGetVariable ReadGetVariable() {
            return new ActionGetVariable();
        }

        private ActionSetVariable ReadSetVariable() {
            return new ActionSetVariable();
        }

        #endregion

        #region Movie control

        private ActionGetURL2 ReadGetURL2() {
            return new ActionGetURL2();
        }

        private ActionGetProperty ReadGetProperty() {
            return new ActionGetProperty();
        }

        private ActionGotoFrame2 ReadGoToFrame2() {
            var res = new ActionGotoFrame2 { Flags = _reader.ReadByte() };
            if (res.SceneBiasFlag) {
                res.SceneBias = _reader.ReadUInt16();
            }
            return res;

        }

        private ActionRemoveSprite ReadRemoveSprite() {
            return new ActionRemoveSprite();
        }

        private ActionSetProperty ReadSetProperty() {
            return new ActionSetProperty();
        }

        private ActionSetTarget2 ReadSetTarget2() {
            return new ActionSetTarget2();
        }

        private ActionStartDrag ReadStartDrag() {
            return new ActionStartDrag();
        }

        private ActionWaitForFrame2 ReadWaitForFrame2() {
            return new ActionWaitForFrame2 { SkipCount = _reader.ReadByte() };
        }

        private ActionCloneSprite ReadCloneSprite() {
            return new ActionCloneSprite();
        }

        private ActionEndDrag ReadEndDrag() {
            return new ActionEndDrag();
        }

        #endregion

        #region Utilities

        private ActionGetTime ReadGetTime() {
            return new ActionGetTime();
        }

        private ActionRandomNumber ReadRandomNumber() {
            return new ActionRandomNumber();
        }

        private ActionTrace ReadTrace() {
            return new ActionTrace();
        }

        #endregion

        #endregion


        public ActionConstantPool ReadActionConstantPool(ushort length) {
            ushort count = _reader.ReadUInt16();
            var pool = new string[count];
            for (var i = 0; i < count; i++) {
                pool[i] = _reader.ReadString();
            }
            return new ActionConstantPool { ConstantPool = pool };
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





        public ActionSetMember ReadActionSetMember(ushort length) {
            return new ActionSetMember();
        }




    }
}

namespace SwfLib.Actions {
    public class ActionsFactory {

        /// <summary>
        /// Creates action by its code.
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public ActionBase Create(ActionCode code) {
            switch (code) {
                #region SWF 3

                case ActionCode.GotoFrame:
                    return new ActionGotoFrame();
                case ActionCode.GetURL:
                    return new ActionGetURL();
                case ActionCode.NextFrame:
                    return new ActionNextFrame();
                case ActionCode.PreviousFrame:
                    return new ActionPreviousFrame();
                case ActionCode.Play:
                    return new ActionPlay();
                case ActionCode.Stop:
                    return new ActionStop();
                case ActionCode.ToggleQuality:
                    return new ActionToggleQuality();
                case ActionCode.StopSounds:
                    return new ActionStopSounds();
                case ActionCode.WaitForFrame:
                    return new ActionWaitForFrame();
                case ActionCode.SetTarget:
                    return new ActionSetTarget();
                case ActionCode.GoToLabel:
                    return new ActionGoToLabel();
                #endregion

                #region SWF 4

                #region Arithmetic operators

                case ActionCode.Add:
                    return new ActionAdd();
                case ActionCode.Divide:
                    return new ActionDivide();
                case ActionCode.Multiply:
                    return new ActionMultiply();
                case ActionCode.Subtract:
                    return new ActionSubtract();

                #endregion

                #region Numerical comparision

                case ActionCode.Equals:
                    return new ActionEquals();
                case ActionCode.Less:
                    return new ActionLess();

                #endregion

                #region Logical operands

                case ActionCode.And:
                    return new ActionAnd();
                case ActionCode.Not:
                    return new ActionNot();
                case ActionCode.Or:
                    return new ActionOr();

                #endregion

                #region String manipulation

                case ActionCode.StringAdd:
                    return new ActionStringAdd();
                case ActionCode.StringEquals:
                    return new ActionStringEquals();
                case ActionCode.StringExtract:
                    return new ActionStringExtract();
                case ActionCode.StringLength:
                    return new ActionStringLength();
                case ActionCode.MBStringExtract:
                    return new ActionMBStringExtract();
                case ActionCode.MBStringLength:
                    return new ActionMBStringLength();
                case ActionCode.StringLess:
                    return new ActionStringLess();
                #endregion

                #region Stack operations

                case ActionCode.Pop:
                    return new ActionPop();
                case ActionCode.Push:
                    return new ActionPush();

                #endregion

                #region Type covnersion

                case ActionCode.AsciiToChar:
                    return new ActionAsciiToChar();
                case ActionCode.CharToAscii:
                    return new ActionCharToAscii();
                case ActionCode.ToInteger:
                    return new ActionToInteger();
                case ActionCode.MBAsciiToChar:
                    return new ActionMBAsciiToChar();
                case ActionCode.MBCharToAscii:
                    return new ActionMBCharToAscii();

                #endregion

                #region Control flow

                case ActionCode.Call:
                    return new ActionCall();
                case ActionCode.If:
                    return new ActionIf();
                case ActionCode.Jump:
                    return new ActionJump();

                #endregion

                #region Variables

                case ActionCode.GetVariable:
                    return new ActionGetVariable();
                case ActionCode.SetVariable:
                    return new ActionSetVariable();

                #endregion

                #region Movie control

                case ActionCode.GetURL2:
                    return new ActionGetURL2();
                case ActionCode.GetProperty:
                    return new ActionGetProperty();
                case ActionCode.GotoFrame2:
                    return new ActionGotoFrame2();
                case ActionCode.RemoveSprite:
                    return new ActionRemoveSprite();
                case ActionCode.SetProperty:
                    return new ActionSetProperty();
                case ActionCode.SetTarget2:
                    return new ActionSetTarget2();
                case ActionCode.StartDrag:
                    return new ActionStartDrag();
                case ActionCode.WaitForFrame2:
                    return new ActionWaitForFrame2();
                case ActionCode.CloneSprite:
                    return new ActionCloneSprite();
                case ActionCode.EndDrag:
                    return new ActionEndDrag();

                #endregion

                #region Utilities

                case ActionCode.GetTime:
                    return new ActionGetTime();
                case ActionCode.RandomNumber:
                    return new ActionRandomNumber();
                case ActionCode.Trace:
                    return new ActionTrace();

                #endregion

                #endregion

                #region SWF 5

                case ActionCode.CallFunction:
                    return new ActionCallFunction();
                case ActionCode.CallMethod:
                    return new ActionCallMethod();
                case ActionCode.ConstantPool:
                    return new ActionConstantPool();
                case ActionCode.DefineFunction:
                    return new ActionDefineFunction();
                case ActionCode.DefineLocal:
                    return new ActionDefineLocal();
                case ActionCode.DefineLocal2:
                    return new ActionDefineLocal2();
                case ActionCode.Delete:
                    return new ActionDelete();
                case ActionCode.Delete2:
                    return new ActionDelete2();
                case ActionCode.Enumerate:
                    return new ActionEnumerate();
                case ActionCode.Equals2:
                    return new ActionEquals2();
                case ActionCode.GetMember:
                    return new ActionGetMember();
                case ActionCode.InitArray:
                    return new ActionInitArray();
                case ActionCode.InitObject:
                    return new ActionInitObject();
                case ActionCode.NewMethod:
                    return new ActionNewMethod();
                case ActionCode.NewObject:
                    return new ActionNewObject();
                case ActionCode.SetMember:
                    return new ActionSetMember();
                case ActionCode.TargetPath:
                    return new ActionTargetPath();
                case ActionCode.With:
                    return new ActionWith();
                case ActionCode.ToNumber:
                    return new ActionToNumber();
                case ActionCode.ToString:
                    return new ActionToString();
                case ActionCode.TypeOf:
                    return new ActionTypeOf();
                case ActionCode.Add2:
                    return new ActionAdd2();
                case ActionCode.Less2:
                    return new ActionLess2();
                case ActionCode.Modulo:
                    return new ActionModulo();
                case ActionCode.BitAnd:
                    return new ActionBitAnd();
                case ActionCode.BitLShift:
                    return new ActionBitLShift();
                case ActionCode.BitOr:
                    return new ActionBitOr();
                case ActionCode.BitRShift:
                    return new ActionBitRShift();
                case ActionCode.BitURShift:
                    return new ActionBitURShift();
                case ActionCode.BitXor:
                    return new ActionBitXor();
                case ActionCode.Decrement:
                    return new ActionDecrement();
                case ActionCode.Increment:
                    return new ActionIncrement();
                case ActionCode.PushDuplicate:
                    return new ActionPushDuplicate();
                case ActionCode.Return:
                    return new ActionReturn();
                case ActionCode.StackSwap:
                    return new ActionStackSwap();
                case ActionCode.StoreRegister:
                    return new ActionStoreRegister();

                #endregion

                #region SWF 6


                case ActionCode.InstanceOf:
                    return new ActionInstanceOf();
                case ActionCode.Enumerate2:
                    return new ActionEnumerate2();
                case ActionCode.StrictEquals:
                    return new ActionStrictEquals();
                case ActionCode.Greater:
                    return new ActionGreater();
                case ActionCode.StringGreater:
                    return new ActionStringGreater();

                #endregion

                #region SWF 7

                case ActionCode.DefineFunction2:
                    return new ActionDefineFunction2();
                case ActionCode.Extends:
                    return new ActionExtends();
                case ActionCode.CastOp:
                    return new ActionCastOp();
                case ActionCode.ImplementsOp:
                    return new ActionImplementsOp();
                case ActionCode.Try:
                    return new ActionTry();
                case ActionCode.Throw:
                    return new ActionThrow();

                #endregion

                case ActionCode.End:
                    return new ActionEnd();
                default:
                    return new ActionUnknown(code);
            }
        }
    }
}

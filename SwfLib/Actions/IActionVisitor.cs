namespace SwfLib.Actions {
    public interface IActionVisitor<TArg, TResult> {

        #region SWF 3

        /// <summary>
        /// Visits GoToFrame action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionGotoFrame action, TArg arg);

        /// <summary>
        /// Visits GetURL action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionGetURL action, TArg arg);

        /// <summary>
        /// Visits NextFrame action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionNextFrame action, TArg arg);

        /// <summary>
        /// Visits previoudFrame action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionPreviousFrame action, TArg arg);

        /// <summary>
        /// Visits Play action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionPlay action, TArg arg);

        TResult Visit(ActionStop action, TArg arg);

        /// <summary>
        /// Visits ToggleQuality action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionToggleQuality action, TArg arg);

        TResult Visit(ActionStopSounds action, TArg arg);

        /// <summary>
        /// Visits WaitForFrame action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionWaitForFrame action, TArg arg);

        /// <summary>
        /// Visits SetTarget action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionSetTarget action, TArg arg);

        /// <summary>
        /// Visits GoToLabel action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionGoToLabel action, TArg arg);

        #endregion

        #region SWF 4

        #region Arithmetic operators

        /// <summary>
        /// Visits Add action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionAdd action, TArg arg);

        /// <summary>
        /// Visits Divide action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionDivide action, TArg arg);

        /// <summary>
        /// Visits Multiply action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionMultiply action, TArg arg);

        /// <summary>
        /// Visits Subtract action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionSubtract action, TArg arg);

        #endregion

        #region Numerical comparision

        /// <summary>
        /// Visits Equals action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionEquals action, TArg arg);

        /// <summary>
        /// Visits Less action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionLess action, TArg arg);

        #endregion

        #region Logical operands

        /// <summary>
        /// Visits And action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionAnd action, TArg arg);

        /// <summary>
        /// Visits Not action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionNot action, TArg arg);

        /// <summary>
        /// Visits Or action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionOr action, TArg arg);

        #endregion

        #region String manipulation

        /// <summary>
        /// Visits StringAdd action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionStringAdd action, TArg arg);

        /// <summary>
        /// Visits StringEquals action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionStringEquals action, TArg arg);

        /// <summary>
        /// Visits StringExtract action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionStringExtract action, TArg arg);

        /// <summary>
        /// Visits StringLength action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionStringLength action, TArg arg);

        /// <summary>
        /// Visits MBStringExtract action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionMBStringExtract action, TArg arg);

        /// <summary>
        /// Visits MBStringLength action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionMBStringLength action, TArg arg);

        /// <summary>
        /// Visits StringLess action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionStringLess action, TArg arg);

        #endregion

        #region Stack operations

        /// <summary>
        /// Visits Pop action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionPop action, TArg arg);

        /// <summary>
        /// Visits Push action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionPush action, TArg arg);

        #endregion

        #region Type covnersion

        /// <summary>
        /// Visits AsciiToChar action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionAsciiToChar action, TArg arg);

        /// <summary>
        /// Visits CharToAscii action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionCharToAscii action, TArg arg);

        /// <summary>
        /// Visits ToInteger action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionToInteger action, TArg arg);

        /// <summary>
        /// Visits MBAsciiToChar action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionMBAsciiToChar action, TArg arg);

        /// <summary>
        /// Visits MBCharToAscii action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionMBCharToAscii action, TArg arg);

        #endregion

        #region Control flow

        /// <summary>
        /// Visits Call action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionCall action, TArg arg);

        /// <summary>
        /// Visits If action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionIf action, TArg arg);

        /// <summary>
        /// Visits Jump action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionJump action, TArg arg);

        #endregion

        #region Variables

        /// <summary>
        /// Visits GetVariable action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionGetVariable action, TArg arg);

        /// <summary>
        /// Visits SetVariable action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionSetVariable action, TArg arg);

        #endregion

        #region Movie control

        /// <summary>
        /// Visits GetURL2 action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionGetURL2 action, TArg arg);

        /// <summary>
        /// Visits GetProeprty action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionGetProperty action, TArg arg);

        /// <summary>
        /// Visits GoToFrame2 action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionGotoFrame2 action, TArg arg);

        /// <summary>
        /// Visits RemoveSprite action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionRemoveSprite action, TArg arg);

        /// <summary>
        /// Visits SetProperty action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionSetProperty action, TArg arg);

        /// <summary>
        /// Visits SetTarget2 action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionSetTarget2 action, TArg arg);

        /// <summary>
        /// Visits StartDrag action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionStartDrag action, TArg arg);

        /// <summary>
        /// Visits WaitForFrame2 action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionWaitForFrame2 action, TArg arg);

        /// <summary>
        /// Visits CloneSprite action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionCloneSprite action, TArg arg);

        /// <summary>
        /// Visits EndDrag action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionEndDrag action, TArg arg);

        #endregion

        #region Utilities

        /// <summary>
        /// Visits GetTime action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionGetTime action, TArg arg);

        /// <summary>
        /// Visits RandomNumber action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionRandomNumber action, TArg arg);

        /// <summary>
        /// Visits Trace action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionTrace action, TArg arg);

        #endregion

        #endregion

        #region SWF 5

        #region ScriptObject actions

        /// <summary>
        /// Visits CallFunction action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionCallFunction action, TArg arg);

        /// <summary>
        /// Visits CallMethod action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionCallMethod action, TArg arg);

        /// <summary>
        /// Visits VonstantPool action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionConstantPool action, TArg arg);

        /// <summary>
        /// Visits DefineFunction action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionDefineFunction action, TArg arg);

        /// <summary>
        /// Visits DefineLocal action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionDefineLocal action, TArg arg);

        /// <summary>
        /// Visits DefineLocal2 action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionDefineLocal2 action, TArg arg);

        /// <summary>
        /// Visits Delete action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionDelete action, TArg arg);

        /// <summary>
        /// Visits Delete2 action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionDelete2 action, TArg arg);

        /// <summary>
        /// Visits Enumerate action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionEnumerate action, TArg arg);

        /// <summary>
        /// Visits Equals2 action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionEquals2 action, TArg arg);

        /// <summary>
        /// Visits GetMember action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionGetMember action, TArg arg);

        /// <summary>
        /// Visits InitArray action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionInitArray action, TArg arg);

        /// <summary>
        /// Visits InitObject action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionInitObject action, TArg arg);

        /// <summary>
        /// Visits NewMethod action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionNewMethod action, TArg arg);

        /// <summary>
        /// Visits NewObject action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionNewObject action, TArg arg);

        /// <summary>
        /// Visits SetMember action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionSetMember action, TArg arg);

        /// <summary>
        /// Visits TrgetPath action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionTargetPath action, TArg arg);

        /// <summary>
        /// Visits With action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionWith action, TArg arg);

        #endregion

        /// <summary>
        /// Visits ToNumber action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionToNumber action, TArg arg);

        /// <summary>
        /// Visits ToString action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionToString action, TArg arg);

        /// <summary>
        /// Visits TypeOf action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionTypeOf action, TArg arg);

        /// <summary>
        /// Visits Add2 action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionAdd2 action, TArg arg);

        /// <summary>
        /// Visits Less2 action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionLess2 action, TArg arg);

        /// <summary>
        /// Visits Modulo action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionModulo action, TArg arg);

        /// <summary>
        /// Visits BitAnd action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionBitAnd action, TArg arg);

        /// <summary>
        /// Visits BitLShift action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionBitLShift action, TArg arg);

        /// <summary>
        /// Visits BitOr action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionBitOr action, TArg arg);

        /// <summary>
        /// Visits ButRShift action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionBitRShift action, TArg arg);

        /// <summary>
        /// Visits BitURShift action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionBitURShift action, TArg arg);

        /// <summary>
        /// Visits BitXor action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionBitXor action, TArg arg);

        /// <summary>
        /// Visits Decrement action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionDecrement action, TArg arg);

        /// <summary>
        /// Visits Increment action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionIncrement action, TArg arg);

        /// <summary>
        /// Visits PushDuplicate action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionPushDuplicate action, TArg arg);

        /// <summary>
        /// Visits Return action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionReturn action, TArg arg);

        /// <summary>
        /// Visits StackSwap action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionStackSwap action, TArg arg);

        /// <summary>
        /// Visits StoreRegister action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionStoreRegister action, TArg arg);


        #endregion

        #region SWF 6

        /// <summary>
        /// Visits InstanceOf action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionInstanceOf action, TArg arg);

        /// <summary>
        /// Visits Enumerate2 action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionEnumerate2 action, TArg arg);

        /// <summary>
        /// Visits StrictEquals action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionStrictEquals action, TArg arg);

        /// <summary>
        /// Visits Greater action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionGreater action, TArg arg);

        /// <summary>
        /// Visits StringGreater action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionStringGreater action, TArg arg);

        #endregion

        #region SWF 7

        /// <summary>
        /// Visits DefineFunction2 action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionDefineFunction2 action, TArg arg);

        /// <summary>
        /// Visits Extends action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionExtends action, TArg arg);

        /// <summary>
        /// Visits CastOp action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionCastOp action, TArg arg);

        /// <summary>
        /// Visits ImplementsOp action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionImplementsOp action, TArg arg);

        /// <summary>
        /// Visits Try action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionTry action, TArg arg);

        /// <summary>
        /// Visits Throw action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionThrow action, TArg arg);

        #endregion

        /// <summary>
        /// Visits End action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionEnd action, TArg arg);

        /// <summary>
        /// Visits Unknown action.
        /// </summary>
        /// <param name="action">Action to be visitied</param>
        /// <param name="arg">Additional </param>
        /// <returns></returns>
        TResult Visit(ActionUnknown action, TArg arg);


    }
}

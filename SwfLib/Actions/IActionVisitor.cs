using Code.SwfLib.Actions;

namespace SwfLib.Actions {
    public interface IActionVisitor<TArg, TResult> {

        #region SWF 3

        TResult Visit(ActionGotoFrame action, TArg arg);

        TResult Visit(ActionGetURL action, TArg arg);

        TResult Visit(ActionNextFrame action, TArg arg);

        TResult Visit(ActionPreviousFrame action, TArg arg);

        TResult Visit(ActionPlay action, TArg arg);

        TResult Visit(ActionStop action, TArg arg);

        TResult Visit(ActionToggleQuality action, TArg arg);

        TResult Visit(ActionStopSounds action, TArg arg);

        TResult Visit(ActionWaitForFrame action, TArg arg);

        TResult Visit(ActionSetTarget action, TArg arg);

        TResult Visit(ActionGoToLabel action, TArg arg);

        #endregion

        #region SWF 4

        #region Arithmetic operators

        TResult Visit(ActionAdd action, TArg arg);

        TResult Visit(ActionDivide action, TArg arg);

        TResult Visit(ActionMultiply action, TArg arg);

        TResult Visit(ActionSubtract action, TArg arg);

        #endregion

        #region Numerical comparision

        TResult Visit(ActionEquals action, TArg arg);

        TResult Visit(ActionLess action, TArg arg);

        #endregion

        #region Logical operands

        TResult Visit(ActionAnd action, TArg arg);

        TResult Visit(ActionNot action, TArg arg);

        TResult Visit(ActionOr action, TArg arg);

        #endregion

        #region String manipulation

        TResult Visit(ActionStringAdd action, TArg arg);

        TResult Visit(ActionStringEquals action, TArg arg);

        TResult Visit(ActionStringExtract action, TArg arg);

        TResult Visit(ActionStringLength action, TArg arg);

        TResult Visit(ActionMBStringExtract action, TArg arg);

        TResult Visit(ActionMBStringLength action, TArg arg);

        TResult Visit(ActionStringLess action, TArg arg);

        #endregion

        #region Stack operations

        TResult Visit(ActionPop action, TArg arg);

        TResult Visit(ActionPush action, TArg arg);

        #endregion

        #region Type covnersion

        TResult Visit(ActionAsciiToChar action, TArg arg);

        TResult Visit(ActionCharToAscii action, TArg arg);

        TResult Visit(ActionToInteger action, TArg arg);

        TResult Visit(ActionMBAsciiToChar action, TArg arg);

        TResult Visit(ActionMBCharToAscii action, TArg arg);

        #endregion

        #region Control flow

        TResult Visit(ActionCall action, TArg arg);

        TResult Visit(ActionIf action, TArg arg);

        TResult Visit(ActionJump action, TArg arg);

        #endregion

        #region Variables

        TResult Visit(ActionGetVariable action, TArg arg);

        TResult Visit(ActionSetVariable action, TArg arg);

        #endregion

        #region Movie control

        TResult Visit(ActionGetURL2 action, TArg arg);

        TResult Visit(ActionGetProperty action, TArg arg);

        TResult Visit(ActionGotoFrame2 action, TArg arg);

        TResult Visit(ActionRemoveSprite action, TArg arg);

        TResult Visit(ActionSetProperty action, TArg arg);

        TResult Visit(ActionSetTarget2 action, TArg arg);

        TResult Visit(ActionStartDrag action, TArg arg);

        TResult Visit(ActionWaitForFrame2 action, TArg arg);

        TResult Visit(ActionCloneSprite action, TArg arg);

        TResult Visit(ActionEndDrag action, TArg arg);

        #endregion

        #region Utilities

        TResult Visit(ActionGetTime action, TArg arg);

        TResult Visit(ActionRandomNumber action, TArg arg);

        TResult Visit(ActionTrace action, TArg arg);

        #endregion

        #endregion

        #region SWF 5

        #region ScriptObject actions

        TResult Visit(ActionCallFunction action, TArg arg);

        TResult Visit(ActionCallMethod action, TArg arg);

        TResult Visit(ActionConstantPool action, TArg arg);

        TResult Visit(ActionDefineFunction action, TArg arg);

        TResult Visit(ActionDefineLocal action, TArg arg);

        TResult Visit(ActionDefineLocal2 action, TArg arg);

        TResult Visit(ActionDelete action, TArg arg);

        TResult Visit(ActionDelete2 action, TArg arg);

        TResult Visit(ActionEnumerate action, TArg arg);

        TResult Visit(ActionEquals2 action, TArg arg);

        TResult Visit(ActionGetMember action, TArg arg);

        TResult Visit(ActionInitArray action, TArg arg);

        TResult Visit(ActionInitObject action, TArg arg);

        TResult Visit(ActionNewMethod action, TArg arg);

        TResult Visit(ActionNewObject action, TArg arg);

        TResult Visit(ActionSetMember action, TArg arg);

        TResult Visit(ActionTargetPath action, TArg arg);

        TResult Visit(ActionWith action, TArg arg);

        #endregion

        TResult Visit(ActionToNumber action, TArg arg);

        TResult Visit(ActionToString action, TArg arg);

        TResult Visit(ActionTypeOf action, TArg arg);

        TResult Visit(ActionAdd2 action, TArg arg);

        TResult Visit(ActionLess2 action, TArg arg);

        TResult Visit(ActionModulo action, TArg arg);

        TResult Visit(ActionBitAnd action, TArg arg);

        TResult Visit(ActionBitLShift action, TArg arg);

        TResult Visit(ActionBitOr action, TArg arg);

        TResult Visit(ActionBitRShift action, TArg arg);

        TResult Visit(ActionBitURShift action, TArg arg);

        TResult Visit(ActionBitXor action, TArg arg);

        TResult Visit(ActionDecrement action, TArg arg);

        TResult Visit(ActionIncrement action, TArg arg);

        TResult Visit(ActionPushDuplicate action, TArg arg);

        TResult Visit(ActionReturn action, TArg arg);

        TResult Visit(ActionStackSwap action, TArg arg);

        TResult Visit(ActionStoreRegister action, TArg arg);


        #endregion

        #region SWF 6

        TResult Visit(ActionInstanceOf action, TArg arg);

        TResult Visit(ActionEnumerate2 action, TArg arg);

        TResult Visit(ActionStrictEquals action, TArg arg);

        TResult Visit(ActionGreater action, TArg arg);

        TResult Visit(ActionStringGreater action, TArg arg);

        #endregion

        #region SWF 7

        TResult Visit(ActionDefineFunction2 action, TArg arg);

        TResult Visit(ActionExtends action, TArg arg);

        TResult Visit(ActionCastOp action, TArg arg);

        TResult Visit(ActionImplementsOp action, TArg arg);

        TResult Visit(ActionTry action, TArg arg);

        TResult Visit(ActionThrow action, TArg arg);

        #endregion

        TResult Visit(ActionEnd action, TArg arg);

        TResult Visit(ActionUnknown action, TArg arg);


    }
}

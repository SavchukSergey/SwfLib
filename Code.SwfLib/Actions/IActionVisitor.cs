﻿using Code.SwfLib.Data.Actions;

namespace Code.SwfLib.Actions {
    public interface IActionVisitor<TArg, TResult> {

        #region SWF 4

        TResult Visit(ActionAdd action, TArg arg);

        TResult Visit(ActionDivide action, TArg arg);

        TResult Visit(ActionMultiply action, TArg arg);

        TResult Visit(ActionSubtract action, TArg arg);

        #region Logical operands

        TResult Visit(ActionAnd action, TArg arg);

        #endregion

        #region Control flow

        TResult Visit(ActionCall action, TArg arg);

        #endregion

        #endregion

        #region SWF 7

        TResult Visit(ActionDefineFunction2 action, TArg arg);

        TResult Visit(ActionExtends action, TArg arg);

        TResult Visit(ActionCastOp action, TArg arg);

        TResult Visit(ActionImplementsOp action, TArg arg);

        TResult Visit(ActionTry action, TArg arg);

        TResult Visit(ActionThrow action, TArg arg);

        #endregion


        TResult Visit(ActionAsciiToChar action, TArg arg);


        TResult Visit(ActionCharToAscii action, TArg arg);

        TResult Visit(ActionCloneSprite action, TArg arg);

        TResult Visit(ActionConstantPool action, TArg arg);

        TResult Visit(ActionDefineFunction action, TArg arg);

        TResult Visit(ActionEndDrag action, TArg arg);

        TResult Visit(ActionEquals action, TArg arg);

        TResult Visit(ActionGetProperty action, TArg arg);

        TResult Visit(ActionGetTime action, TArg arg);

        TResult Visit(ActionGetURL action, TArg arg);

        TResult Visit(ActionGetURL2 action, TArg arg);

        TResult Visit(ActionGetVariable action, TArg arg);

        TResult Visit(ActionGotoFrame action, TArg arg);

        TResult Visit(ActionGotoFrame2 action, TArg arg);

        TResult Visit(ActionGoToLabel action, TArg arg);

        TResult Visit(ActionIf action, TArg arg);

        TResult Visit(ActionJump action, TArg arg);

        TResult Visit(ActionLess action, TArg arg);

        TResult Visit(ActionMBAsciiToChar action, TArg arg);

        TResult Visit(ActionMBCharToAscii action, TArg arg);

        TResult Visit(ActionMBStringExtract action, TArg arg);

        TResult Visit(ActionMBStringLength action, TArg arg);

        TResult Visit(ActionNextFrame action, TArg arg);

        TResult Visit(ActionNot action, TArg arg);

        TResult Visit(ActionOr action, TArg arg);

        TResult Visit(ActionPlay action, TArg arg);

        TResult Visit(ActionPop action, TArg arg);

        TResult Visit(ActionPreviousFrame action, TArg arg);

        TResult Visit(ActionPush action, TArg arg);

        TResult Visit(ActionRandomNumber action, TArg arg);

        TResult Visit(ActionRemoveSprite action, TArg arg);

        TResult Visit(ActionReturn action, TArg arg);

        TResult Visit(ActionSetMember action, TArg arg);

        TResult Visit(ActionSetProperty action, TArg arg);

        TResult Visit(ActionSetTarget action, TArg arg);

        TResult Visit(ActionSetTarget2 action, TArg arg);

        TResult Visit(ActionSetVariable action, TArg arg);

        TResult Visit(ActionStartDrag action, TArg arg);

        TResult Visit(ActionStop action, TArg arg);

        TResult Visit(ActionStopSounds action, TArg arg);

        TResult Visit(ActionStringAdd action, TArg arg);

        TResult Visit(ActionStringEquals action, TArg arg);

        TResult Visit(ActionStringExtract action, TArg arg);

        TResult Visit(ActionStringLength action, TArg arg);

        TResult Visit(ActionStringLess action, TArg arg);

        TResult Visit(ActionToggleQuality action, TArg arg);

        TResult Visit(ActionToInteger action, TArg arg);

        TResult Visit(ActionTrace action, TArg arg);

        TResult Visit(ActionWaitForFrame action, TArg arg);

        TResult Visit(ActionWaitForFrame2 action, TArg arg);

    }
}
namespace Code.SwfLib.Data.Actions {
    public interface IActionVisitor {

        object Visit(ActionAdd action);

        object Visit(ActionAnd action);

        object Visit(ActionAsciiToChar action);

        object Visit(ActionCall action);

        object Visit(ActionCharToAscii action);

        object Visit(ActionCloneSprite action);

        object Visit(ActionDivide action);

        object Visit(ActionEndDrag action);

        object Visit(ActionEquals action);

        object Visit(ActionGetProperty action);

        object Visit(ActionGetTime action);

        object Visit(ActionGetURL action);

        object Visit(ActionGetURL2 action);

        object Visit(ActionGetVariable action);

        object Visit(ActionGotoFrame action);

        object Visit(ActionGotoFrame2 action);

        object Visit(ActionGoToLabel action);

        object Visit(ActionIf action);

        object Visit(ActionJump action);

        object Visit(ActionLess action);

        object Visit(ActionMBAsciiToChar action);

        object Visit(ActionMBCharToAscii action);

        object Visit(ActionMBStringExtract action);

        object Visit(ActionMBStringLength action);

        object Visit(ActionMultiply action);

        object Visit(ActionNextFrame action);

        object Visit(ActionNot action);

        object Visit(ActionOr action);

        object Visit(ActionPlay action);

        object Visit(ActionPop action);

        object Visit(ActionPreviousFrame action);

        object Visit(ActionPush action);

        object Visit(ActionRandomNumber action);

        object Visit(ActionRemoveSprite action);

        object Visit(ActionSetProperty action);

        object Visit(ActionSetTarget action);

        object Visit(ActionSetTarget2 action);

        object Visit(ActionSetVariable action);

        object Visit(ActionStartDrag action);

        object Visit(ActionStop action);

        object Visit(ActionStopSounds action);

        object Visit(ActionStringAdd action);

        object Visit(ActionStringEquals action);

        object Visit(ActionStringExtract action);

        object Visit(ActionStringLength action);

        object Visit(ActionStringLess action);

        object Visit(ActionSubtract action);

        object Visit(ActionToggleQuality action);

        object Visit(ActionToInteger action);

        object Visit(ActionTrace action);

        object Visit(ActionWaitForFrame action);

        object Visit(ActionWaitForFrame2 action);

    }
}

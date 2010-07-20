namespace Code.SwfLib.Data.Actions {
    public interface IActionVisitor {

        object Visit(ActionGetURL action);

        object Visit(ActionGotoFrame action);

        object Visit(ActionGoToLabel action);

        object Visit(ActionNextFrame action);

        object Visit(ActionPlay action);

        object Visit(ActionPreviousFrame action);

        object Visit(ActionSetTarget action);

        object Visit(ActionStop action);

        object Visit(ActionStopSounds action);

        object Visit(ActionToggleQuality action);

        object Visit(ActionWaitForFrame action);

    }
}

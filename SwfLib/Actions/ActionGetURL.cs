using SwfLib.Actions;

namespace Code.SwfLib.Actions {
    public class ActionGetURL : ActionBase {


        public string UrlString;

        public string TargetString;

        public override ActionCode ActionCode {
            get { return ActionCode.GetURL; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}

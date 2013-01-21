using Code.SwfLib.Actions;

namespace Code.SwfLib.Data.Actions {
    public class ActionGetURL : ActionBase {


        public string UrlString;

        public string TargetString;

        public override ActionCode ActionCode {
            get { return ActionCode.GetURL; }
        }

        public override object AcceptVisitor(IActionVisitor visitor) {
            return visitor.Visit(this);
        }
    }
}

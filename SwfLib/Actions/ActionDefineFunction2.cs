using System.Collections.Generic;

namespace SwfLib.Actions {
    public class ActionDefineFunction2 : ActionBase {

        public string Name;

        public byte RegisterCount;

        public bool PreloadParent { get; set; }

        public bool PreloadRoot { get; set; }

        public bool SuppressSuper { get; set; }

        public bool PreloadSuper { get; set; }

        public bool SuppressArguments { get; set; }

        public bool PreloadArguments { get; set; }

        public bool SuppressThis { get; set; }

        public bool PreloadThis { get; set; }

        public byte Reserved { get; set; }

        public bool PreloadGlobal { get; set; }

        public readonly IList<RegisterParam> Parameters = new List<RegisterParam>();

        public readonly List<ActionBase> Actions = new List<ActionBase>();

        public override ActionCode ActionCode {
            get { return ActionCode.DefineFunction2; }
        }


        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}

﻿using Code.SwfLib.Actions;

namespace Code.SwfLib.Data.Actions {
    public class ActionCall : ActionBase {

        public override ActionCode ActionCode {
            get { return ActionCode.Call; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
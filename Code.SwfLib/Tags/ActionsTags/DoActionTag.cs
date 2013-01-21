using System.Collections.Generic;
using Code.SwfLib.Actions;
using Code.SwfLib.Data.Actions;

namespace Code.SwfLib.Tags.ActionsTags {
    public class DoActionTag : ActionsBaseTag {

        public readonly IList<ActionBase> ActionRecords = new List<ActionBase>();

        public override SwfTagType TagType {
            get { return SwfTagType.DoAction; }
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
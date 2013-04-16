using System.Collections.Generic;
using Code.SwfLib.Actions;
using SwfLib.Tags;

namespace Code.SwfLib.Tags.ActionsTags {
    public class DoInitActionTag : ActionsBaseTag {

        public ushort SpriteId;

        public readonly IList<ActionBase> ActionRecords = new List<ActionBase>();

        public override SwfTagType TagType {
            get { return SwfTagType.DoInitAction; }
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
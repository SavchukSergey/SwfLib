using SwfLib.Tags;
using SwfLib.Tags.ControlTags;

namespace Code.SwfLib.Tags.ControlTags {
    public class DefineScalingGridTag : ControlBaseTag {

        public override SwfTagType TagType {
            get { return SwfTagType.DefineScalingGrid; }
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}

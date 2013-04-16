using SwfLib.Data;

namespace SwfLib.Tags.ControlTags {
    public class SetBackgroundColorTag : ControlBaseTag {

        public SwfRGB Color;

        public override SwfTagType TagType {
            get { return SwfTagType.SetBackgroundColor; }
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
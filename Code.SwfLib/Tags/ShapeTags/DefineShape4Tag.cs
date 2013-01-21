using Code.SwfLib.Data;

namespace Code.SwfLib.Tags.ShapeTags {
    public class DefineShape4Tag : ShapeBaseTag {

        public ushort ObjectID;

        public SwfRect Bounds;

        public override SwfTagType TagType {
            get { return SwfTagType.DefineShape4; }
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
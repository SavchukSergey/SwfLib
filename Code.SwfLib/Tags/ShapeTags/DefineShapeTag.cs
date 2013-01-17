using Code.SwfLib.Data;

namespace Code.SwfLib.Tags.ShapeTags {
    public class DefineShapeTag : ShapeBaseTag {

        public ushort ShapeID;

        public SwfRect ShapeBounds;

        public readonly ShapeWithStyle1 Shapes = new ShapeWithStyle1();

        public override SwfTagType TagType {
            get { return SwfTagType.DefineShape; }
        }

        public override object AcceptVistor(ISwfTagVisitor visitor) {
            return visitor.Visit(this);
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
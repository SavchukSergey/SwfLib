using Code.SwfLib.Data;

namespace Code.SwfLib.Tags.ShapeTags {
    public class DefineShapeTag : ShapeBaseTag {

        public readonly ShapeWithStyle1 Shapes = new ShapeWithStyle1();

        public override SwfTagType TagType {
            get { return SwfTagType.DefineShape; }
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
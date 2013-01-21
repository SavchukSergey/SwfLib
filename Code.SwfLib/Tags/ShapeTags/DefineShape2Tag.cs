using Code.SwfLib.Data;

namespace Code.SwfLib.Tags.ShapeTags {
    public class DefineShape2Tag : ShapeBaseTag {

        public ushort ShapeID { get; set; }

        public SwfRect ShapeBounds;

        public readonly ShapeWithStyle1 Shapes = new ShapeWithStyle1();

        public override SwfTagType TagType {
            get { return SwfTagType.DefineShape2; }
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
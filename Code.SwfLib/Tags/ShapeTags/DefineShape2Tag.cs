using Code.SwfLib.Data;

namespace Code.SwfLib.Tags.ShapeTags {
    public class DefineShape2Tag : ShapeBaseTag {

        public readonly ShapeWithStyle1 Shapes = new ShapeWithStyle1();

        public override SwfTagType TagType {
            get { return SwfTagType.DefineShape2; }
        }

        public override object AcceptVistor(ISwfTagVisitor visitor) {
            return visitor.Visit(this);
        }
    }
}
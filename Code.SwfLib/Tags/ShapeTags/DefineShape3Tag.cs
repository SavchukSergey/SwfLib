using Code.SwfLib.Data;

namespace Code.SwfLib.Tags.ShapeTags {
    public class DefineShape3Tag : SwfTagBase {

        public ushort ObjectID;

        public SwfRect Bounds;

        public override SwfTagType TagType {
            get { return SwfTagType.DefineShape3; }
        }

        public override object AcceptVistor(ISwfTagVisitor visitor) {
            return visitor.Visit(this);
        }
    }
}
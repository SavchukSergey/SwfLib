using Code.SwfLib.Data;

namespace Code.SwfLib.Tags.ControlTags {
    public class SetBackgroundColorTag : ControlBaseTag {

        public SwfRGB Color;

        public override object AcceptVistor(ISwfTagVisitor visitor) {
            return visitor.Visit(this);
        }
    }
}
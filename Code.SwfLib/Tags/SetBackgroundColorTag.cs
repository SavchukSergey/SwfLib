using Code.SwfLib.Data;

namespace Code.SwfLib.Tags
{
    public class SetBackgroundColorTag : SwfTagBase
    {

        public SwfRGB Color { get; set; }

        public override object AcceptVistor(ISwfTagVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
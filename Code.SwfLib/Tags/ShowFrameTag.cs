namespace Code.SwfLib.Tags
{
    public class ShowFrameTag : SwfTagBase
    {
        public override object AcceptVistor(ISwfTagVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}

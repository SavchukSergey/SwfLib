namespace Code.SwfLib.Tags
{
    public class EndTag : SwfTagBase
    {
        public override object AcceptVistor(ISwfTagVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}

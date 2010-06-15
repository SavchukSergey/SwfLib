namespace Code.SwfLib.Tags
{
    public class UnknownTag : SwfTagBase
    {

        public override object AcceptVistor(ISwfTagVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}

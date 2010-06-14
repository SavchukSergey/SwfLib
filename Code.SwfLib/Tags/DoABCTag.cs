namespace Code.SwfLib.Tags
{
    public class DoABCTag : SwfTagBase
    {

        public byte[] ABCData;

        public override object AcceptVistor(ISwfTagVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
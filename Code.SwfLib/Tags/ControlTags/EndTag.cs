namespace Code.SwfLib.Tags.ControlTags
{
    public class EndTag : ControlBaseTag
    {
        public override object AcceptVistor(ISwfTagVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
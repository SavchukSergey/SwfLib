namespace Code.SwfLib.Tags.FontTags
{
    public class DefineFont3Tag : SwfTagBase
    {
        public ushort ObjectID;

        public override object AcceptVistor(ISwfTagVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
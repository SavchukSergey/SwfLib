namespace Code.SwfLib.Tags.FontTags
{
    public class DefineFontAlignZonesTag : SwfTagBase
    {

        public ushort ObjectID;

        public override object AcceptVistor(ISwfTagVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
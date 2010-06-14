namespace Code.SwfLib.Tags
{
    public class MetadataTag : SwfTagBase{

        public string Metadata;

        public override object AcceptVistor(ISwfTagVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
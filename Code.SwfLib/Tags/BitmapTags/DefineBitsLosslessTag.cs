namespace Code.SwfLib.Tags.BitmapTags
{
    public class DefineBitsLosslessTag : DefineBitsBaseTag
    {

        public ushort ObjectID;

        public override object AcceptVistor(ISwfTagVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
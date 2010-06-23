namespace Code.SwfLib.Tags.BitmapTags
{
    public class DefineBitsJPEG2Tag : DefineBitsBaseTag
    {

        public ushort CharacterID;

        public byte[] ImageData;

        public override object AcceptVistor(ISwfTagVisitor visitor)
        {
            return visitor.Visit(this);
        }

    }
}
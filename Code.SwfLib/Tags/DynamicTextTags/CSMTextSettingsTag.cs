namespace Code.SwfLib.Tags.DynamicTextTags
{
    public class CSMTextSettingsTag : SwfTagBase
    {

        public ushort ObjectID;

        public byte UseType;

        public byte GridFit;

        public byte ReservedFlags;

        public float Thickness;

        public float Sharpness;

        public byte Reserved;

        public override object AcceptVistor(ISwfTagVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
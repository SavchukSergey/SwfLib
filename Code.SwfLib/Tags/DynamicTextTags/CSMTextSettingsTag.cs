namespace Code.SwfLib.Tags.DynamicTextTags
{
    public class CSMTextSettingsTag : SwfTagBase
    {

        public ushort TextID;

        public byte UseFlashType;

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
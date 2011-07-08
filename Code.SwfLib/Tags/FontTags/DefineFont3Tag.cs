namespace Code.SwfLib.Tags.FontTags {
    public class DefineFont3Tag : SwfTagBase {
        
        public ushort ObjectID;

        public DefineFont3Attributes Attributes;

        public byte Language;

        public string FontName;

        //TODO: parse & serialize
        public ushort GlyphsCount;

        public override SwfTagType TagType {
            get { return SwfTagType.DefineFont3; }
        }

        public override object AcceptVistor(ISwfTagVisitor visitor) {
            return visitor.Visit(this);
        }
    }
}
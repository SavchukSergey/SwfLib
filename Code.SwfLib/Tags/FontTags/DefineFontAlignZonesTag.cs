namespace Code.SwfLib.Tags.FontTags {
    public class DefineFontAlignZonesTag : FontBaseTag {

        public ushort FontID;

        public byte CsmTableHint;

        public SwfZoneArray[] Zones;

        public override SwfTagType TagType {
            get { return SwfTagType.DefineFontAlignZones; }
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
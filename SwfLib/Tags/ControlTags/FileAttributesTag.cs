namespace Code.SwfLib.Tags.ControlTags {
    public class FileAttributesTag : ControlBaseTag {

        public bool Reserved0;

        public bool UseDirectBlit;

        public bool UseGPU;

        public bool HasMetadata;

        public bool AllowAbc;

        public bool SuppressCrossDomainCaching;

        public bool SwfRelativeUrls;

        public bool UseNetwork;

        public uint Reserved;

        public override SwfTagType TagType {
            get { return SwfTagType.FileAttributes; }
        }


        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
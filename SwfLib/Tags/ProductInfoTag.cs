namespace SwfLib.Tags {
    public class ProductInfoTag : SwfTagBase {
        public uint ProductId { get; set; }

        public uint Edition { get; set; }

        public byte MajorVersion;

        public byte MinorVersion;

        public ulong BuildNumber;

        public ulong CompilationDate;

        public override SwfTagType TagType {
            get { return SwfTagType.ProductInfo; }
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
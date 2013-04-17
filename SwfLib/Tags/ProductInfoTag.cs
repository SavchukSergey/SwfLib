namespace SwfLib.Tags {
    public class ProductInfoTag : SwfTagBase {
        public uint ProductId { get; set; }

        public uint Edition { get; set; }

        public byte MajorVersion { get; set; }

        public byte MinorVersion { get; set; }

        public ulong BuildNumber { get; set; }

        public ulong CompilationDate { get; set; }

        /// <summary>
        /// Gets swf tag type.
        /// </summary>
        public override SwfTagType TagType {
            get { return SwfTagType.ProductInfo; }
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
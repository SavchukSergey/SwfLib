namespace Code.SwfLib.Tags
{
    public class ProductInfoTag : SwfTagBase
    {
        public uint ProductId { get; set;}

        public uint Edition { get; set; }

        public byte MajorVersion;

        public byte MinorVersion;

        public ulong BuildNumber;

        public ulong CompilationDate;

        public override object AcceptVistor(ISwfTagVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
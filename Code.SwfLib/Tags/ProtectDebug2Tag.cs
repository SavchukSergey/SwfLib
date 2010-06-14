namespace Code.SwfLib.Tags
{
    public class ProtectDebug2Tag : SwfTagBase{

        public byte[] Data { get; set; }

        public override object AcceptVistor(ISwfTagVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
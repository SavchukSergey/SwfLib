namespace Code.SwfLib.Tags
{
    public class DebugIDTag : SwfTagBase {

        public byte[] Data { get; set; }

        public override object AcceptVistor(ISwfTagVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
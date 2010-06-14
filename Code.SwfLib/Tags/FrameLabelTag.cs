namespace Code.SwfLib.Tags
{
    public class FrameLabelTag : SwfTagBase
    {

        public string Name { get; set; }

        public override object AcceptVistor(ISwfTagVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
namespace Code.SwfLib.Tags.ControlTags
{
    public class FrameLabelTag : ControlBaseTag
    {
        public bool IsAnchor;

        public string Name { get; set; }

        public override object AcceptVistor(ISwfTagVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
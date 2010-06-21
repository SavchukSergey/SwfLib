namespace Code.SwfLib.Tags.DisplayListTags
{
    public class RemoveObject2Tag : DisplayListBaseTag
    {

        public ushort Depth;

        public override object AcceptVistor(ISwfTagVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
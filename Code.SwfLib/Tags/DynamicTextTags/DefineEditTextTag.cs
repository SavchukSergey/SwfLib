namespace Code.SwfLib.Tags.DynamicTextTags
{
    public class DefineEditTextTag : SwfTagBase
    {

        public ushort ObjectID;

        public bool WordWrap;

        public override object AcceptVistor(ISwfTagVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
namespace Code.SwfLib.Tags
{
    public class DefineFontNameTag : SwfTagBase
    {

        public ushort FontNameId;

        public string DisplayName;

        public string Copyright;

        public override object AcceptVistor(ISwfTagVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}

using Code.SwfLib.Data;

namespace Code.SwfLib.Tags.ControlTags
{
    public class SymbolClassTag : ControlBaseTag
    {
        public SwfSymbolReference[] References;
        
        public override object AcceptVistor(ISwfTagVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
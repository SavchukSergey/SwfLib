using Code.SwfLib.Data;

namespace Code.SwfLib.Tags
{
    public class SymbolClassTag : SwfTagBase
    {
        public SwfSymbolReference[] References;
        
        public override object AcceptVistor(ISwfTagVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
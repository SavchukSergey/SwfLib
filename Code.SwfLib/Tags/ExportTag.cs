using System.Collections.Generic;
using Code.SwfLib.Data;

namespace Code.SwfLib.Tags
{
    public class ExportTag : SwfTagBase
    {

        public readonly IList<SwfSymbolReference> Symbols = new List<SwfSymbolReference>();

        public override object AcceptVistor(ISwfTagVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}

using System.Collections.Generic;
using SwfLib.Data;

namespace SwfLib.Tags.ControlTags {
    public class SymbolClassTag : ControlBaseTag {

        public readonly IList<SwfSymbolReference> References = new List<SwfSymbolReference>();

        public override SwfTagType TagType {
            get { return SwfTagType.SymbolClass; }
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
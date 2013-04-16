using System.Collections.Generic;
using SwfLib.Data;

namespace SwfLib.Tags.ControlTags {
    public class ExportAssetsTag : ControlBaseTag {

        public readonly IList<SwfSymbolReference> Symbols = new List<SwfSymbolReference>();

        public override SwfTagType TagType {
            get { return SwfTagType.ExportAssets; }
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}

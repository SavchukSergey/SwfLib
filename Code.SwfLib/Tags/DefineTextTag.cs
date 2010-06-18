using Code.SwfLib.Data;

namespace Code.SwfLib.Tags
{
    public class DefineTextTag : SwfTagBase
    {

        public ushort ObjectID;

        public SwfRect Bounds;

        public SwfMatrix? Matrix;

        //TODO: Remove it from here. It's fields size definition
        public byte GlyphBits;

        //TODO: Remove it from here. It's fields size definition
        public byte AdvanceBits;

        public SwfTextRecord Records;

        public override object AcceptVistor(ISwfTagVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}

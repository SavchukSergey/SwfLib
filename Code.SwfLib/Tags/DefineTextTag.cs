using Code.SwfLib.Data;

namespace Code.SwfLib.Tags
{
    public class DefineTextTag : SwfTagBase
    {

        public ushort TextID;

        public SwfRect Rectangle;

        public SwfMatrix Matrix;

        public byte GlyphBits;

        public byte AdvanceBits;

        public SwfTextRecord Records;

        public override object AcceptVistor(ISwfTagVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}

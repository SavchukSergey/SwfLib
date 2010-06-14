using System.Collections.Generic;

namespace Code.SwfLib.Tags
{
    public class DefineSpriteTag : SwfTagBase
    {

        public ushort SpriteID;

        public ushort FramesCount;

        public readonly IList<SwfTagBase> Tags = new List<SwfTagBase>();

        public override object AcceptVistor(ISwfTagVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}

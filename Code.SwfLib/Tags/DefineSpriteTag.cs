using System.Collections.Generic;

namespace Code.SwfLib.Tags {
    public class DefineSpriteTag : SwfTagBase {

        public ushort SpriteID;

        public ushort FramesCount;

        //TODO: create collection that will test added tags
        public readonly IList<SwfTagBase> Tags = new List<SwfTagBase>();

        public override SwfTagType TagType {
            get { return SwfTagType.DefineSprite; }
        }

        public override object AcceptVistor(ISwfTagVisitor visitor) {
            return visitor.Visit(this);
        }
    }
}

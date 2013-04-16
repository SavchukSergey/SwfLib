using SwfLib.Data;

namespace SwfLib.Tags.TextTags {
    public abstract class DefineTextBaseTag : SwfTagBase {

        public ushort CharacterID;

        public SwfRect TextBounds;

        public SwfMatrix TextMatrix;

    }
}

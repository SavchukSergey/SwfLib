using SwfLib.Data;
using SwfLib.Tags;

namespace Code.SwfLib.Tags.TextTags {
    public abstract class DefineTextBaseTag : SwfTagBase {

        public ushort CharacterID;

        public SwfRect TextBounds;

        public SwfMatrix TextMatrix;

    }
}

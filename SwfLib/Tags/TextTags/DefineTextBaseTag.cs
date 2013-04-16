using Code.SwfLib.Data;
using SwfLib.Data;

namespace Code.SwfLib.Tags.TextTags {
    public abstract class DefineTextBaseTag : SwfTagBase {

        public ushort CharacterID;

        public SwfRect TextBounds;

        public SwfMatrix TextMatrix;

    }
}

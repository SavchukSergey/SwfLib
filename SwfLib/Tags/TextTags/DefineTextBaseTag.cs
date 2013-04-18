using SwfLib.Data;

namespace SwfLib.Tags.TextTags {
    public abstract class DefineTextBaseTag : SwfTagBase {

        public ushort CharacterID { get; set; }

        public SwfRect TextBounds { get; set; }

        public SwfMatrix TextMatrix { get; set; }

    }
}

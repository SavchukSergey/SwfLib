using Code.SwfLib.Data;
using Code.SwfLib.Data.Actions;

namespace Code.SwfLib.Tags.DisplayListTags {
    public class PlaceObject2Tag : DisplayListBaseTag {

        public bool HasClipActions;

        public bool HasClipDepth;

        public bool HasName;

        public bool HasRatio;

        public bool HasColorTransform;

        public bool HasMatrix;

        public bool HasCharacter;

        public bool Move;

        /// <summary>
        /// The depth value determines the stacking order of the character.
        /// Characters with lower depth values are displayed underneath characters with higher depth values.
        /// A depth value of 1 means the character is displayed at the bottom of the stack.
        /// Any given depth can have only one character.
        /// This means a character that is already on the display list can be identified by its depth alone (that is, a CharacterId is not required).
        /// </summary>
        public ushort Depth;

        public ushort CharacterID;

        public SwfMatrix Matrix;

        public ColorTransformRGBA ColorTransform;

        public ushort Ratio;

        public string Name;

        public ushort ClipDepth;

        public ClipActions ClipActions;

        public override SwfTagType TagType {
            get { return SwfTagType.PlaceObject2; }
        }

        public override object AcceptVistor(ISwfTagVisitor visitor) {
            return visitor.Visit(this);
        }
    }
}
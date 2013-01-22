using Code.SwfLib.Data;

namespace Code.SwfLib.Tags.DisplayListTags {
    public abstract class PlaceObjectBaseTag : DisplayListBaseTag {

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


    }
}

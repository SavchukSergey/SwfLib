using Code.SwfLib.Data;

namespace Code.SwfLib.Tags.DisplayListTags
{
    public class PlaceObject2Tag : DisplayListBaseTag
    {

        public ushort? ObjectID;

        public string Name;

        /// <summary>
        /// The depth value determines the stacking order of the character.
        /// Characters with lower depth values are displayed underneath characters with higher depth values.
        /// A depth value of 1 means the character is displayed at the bottom of the stack.
        /// Any given depth can have only one character.
        /// This means a character that is already on the display list can be identified by its depth alone (that is, a CharacterId is not required).
        /// </summary>
        public ushort Depth;

        public SwfMatrix? Matrix;

        public SwfColorTransform ColorTransform;

        public ushort? MorphPosition;

        public ushort ActionsReserved;

        public uint ActionsFlags;

        public ushort? ClippingDepth;

        public override object AcceptVistor(ISwfTagVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
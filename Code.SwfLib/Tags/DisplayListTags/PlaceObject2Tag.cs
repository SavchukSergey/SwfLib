using Code.SwfLib.Data;

namespace Code.SwfLib.Tags.DisplayListTags
{
    public class PlaceObject2Tag : DisplayListBaseTag
    {

        public bool HasClipActions
        {
            //TODO: Implement
            get { return false; }
        }

        public bool HasClipDepth
        {
            get { return ClipDepth.HasValue; }
        }

        public bool HasName
        {
            get { return !string.IsNullOrEmpty(Name); }
        }

        public bool HasRatio
        {
            get { return Ratio.HasValue; }
        }

        public bool HasColorTransform
        {
            get { return ColorTransform.HasValue; }
        }

        public bool HasMatrix
        {
            get { return Matrix.HasValue; }
        }

        public bool HasCharacter
        {
            get { return CharacterID.HasValue; }
        }

        public bool Move
        {
            //TODO: Implement
            get { return false; }
        }

        public ushort? CharacterID;

        /// <summary>
        /// The depth value determines the stacking order of the character.
        /// Characters with lower depth values are displayed underneath characters with higher depth values.
        /// A depth value of 1 means the character is displayed at the bottom of the stack.
        /// Any given depth can have only one character.
        /// This means a character that is already on the display list can be identified by its depth alone (that is, a CharacterId is not required).
        /// </summary>
        public ushort Depth;

        public SwfMatrix? Matrix;

        public ColorTransformRGB? ColorTransform;

        public ushort? Ratio;

        public string Name;

        public ushort? ClipDepth;



        //TODO: move to Clip Actions
        public ushort ActionsReserved;

        public uint ActionsFlags;

        public override object AcceptVistor(ISwfTagVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
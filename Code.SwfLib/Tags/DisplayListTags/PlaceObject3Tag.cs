using Code.SwfLib.Actions;
using Code.SwfLib.Data;

namespace Code.SwfLib.Tags.DisplayListTags {
    public class PlaceObject3Tag : PlaceObjectBaseTag {

        public bool HasClipActions;

        public bool HasCharacter;

        public bool HasMatrix;

        public bool Move;

        public bool HasImage;

        public bool HasFilterList;


        public string Name;
        
        public string ClassName;

        public byte Reserved;

        public ushort? Ratio;

        public byte? BitmapCache;

        public ushort? ClipDepth;

        public ColorTransformRGBA? ColorTransform;

        public ClipActions ClipActions;

        public byte? BlendMode;

        public override SwfTagType TagType {
            get { return SwfTagType.PlaceObject3; }
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
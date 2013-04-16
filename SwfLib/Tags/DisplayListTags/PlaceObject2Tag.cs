using Code.SwfLib.ClipActions;
using Code.SwfLib.Data;
using SwfLib.Data;

namespace Code.SwfLib.Tags.DisplayListTags {
    public class PlaceObject2Tag : PlaceObjectBaseTag {

        public bool HasClipActions;

        public bool HasClipDepth;

        public bool HasName;

        public bool HasRatio;

        public bool HasColorTransform;

        public bool HasMatrix;

        public bool HasCharacter;

        public bool Move;

        public ColorTransformRGBA ColorTransform;

        public ushort Ratio;

        public string Name;

        public ushort ClipDepth;

        public readonly ClipActionsList ClipActions = new ClipActionsList();

        public override SwfTagType TagType {
            get { return SwfTagType.PlaceObject2; }
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
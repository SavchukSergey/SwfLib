using System.Collections.Generic;
using SwfLib.ClipActions;
using SwfLib.Data;
using SwfLib.Filters;

namespace SwfLib.Tags.DisplayListTags {
    public class PlaceObject3Tag : PlaceObjectBaseTag {

        public bool HasClipActions;

        public bool HasCharacter;

        public bool HasMatrix;

        public bool Move;

        public bool HasImage;


        public string Name;

        public string ClassName;

        public byte Reserved;

        public ushort? Ratio;

        public byte? BitmapCache;

        public ushort? ClipDepth;

        public ColorTransformRGBA? ColorTransform;

        public readonly ClipActionsList ClipActions = new ClipActionsList();

        public BlendMode? BlendMode;

        public readonly IList<BaseFilter> Filters = new List<BaseFilter>();

        public override SwfTagType TagType {
            get { return SwfTagType.PlaceObject3; }
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
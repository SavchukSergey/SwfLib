using SwfLib.ClipActions;
using SwfLib.Data;

namespace SwfLib.Tags.DisplayListTags {
    public class PlaceObject2Tag : PlaceObjectBaseTag {

        public bool HasClipActions { get; set; }

        public bool HasClipDepth { get; set; }

        public bool HasName { get; set; }

        public bool HasRatio { get; set; }

        public bool HasColorTransform { get; set; }

        public bool HasMatrix { get; set; }

        public bool HasCharacter { get; set; }

        public bool Move { get; set; }

        /// <summary>
        /// Gets or sets ColorTransform.
        /// </summary>
        public ColorTransformRGBA ColorTransform { get; set; }

        public ushort Ratio { get; set; }

        /// <summary>
        /// Gets or sets name.
        /// </summary>
        public string Name { get; set; }

        public ushort ClipDepth { get; set; }

        public readonly ClipActionsList ClipActions = new ClipActionsList();

        /// <summary>
        /// Gets swf tag type.
        /// </summary>
        public override SwfTagType TagType {
            get { return SwfTagType.PlaceObject2; }
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
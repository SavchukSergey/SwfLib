using System;
using System.Collections.Generic;
using SwfLib.ClipActions;
using SwfLib.Data;
using SwfLib.Filters;

namespace SwfLib.Tags.DisplayListTags {
    public class PlaceObject3Tag : PlaceObjectBaseTag {

        public bool HasClipActions { get; set; }
        public bool HasClipDepth { get; set; }
        public bool HasName { get; set; }
        public bool HasRatio { get; set; }
        public bool HasColorTransform { get; set; }
        public bool HasMatrix { get; set; }
        public bool HasCharacter { get; set; }
        public bool Move { get; set; }
        public bool Reserved { get; set; }
        public bool HasOpaqueBackground { get; set; }
        public bool HasVisible { get; set; }
        public bool HasImage { get; set; }
        public bool HasClassName { get; set; }
        public bool HasCacheAsBitmap { get; set; }
        public bool HasBlendMode { get; set; }
        public bool HasFilterList { get; set; }
        //Depth
        public string ClassName { get; set; }
        //Character ID
        //Matrix
        public ColorTransformRGBA? ColorTransform { get; set; }
        public ushort? Ratio { get; set; }
        public string Name { get; set; }
        public ushort? ClipDepth { get; set; }
        public readonly IList<BaseFilter> Filters = new List<BaseFilter>();
        public BlendMode? BlendMode { get; set; }
        public byte? BitmapCache { get; set; }
        public byte? Visible { get; set; }
        public SwfRGBA BackgroundColor { get; set; }
        public readonly ClipActionsList ClipActions = new ClipActionsList();

        public override SwfTagType TagType {
            get{return SwfTagType.PlaceObject3;}
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
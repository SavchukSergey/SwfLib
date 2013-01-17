using System;

namespace Code.SwfLib.Tags.BitmapTags {
    public class DefineBitsJPEG2Tag : BitmapBaseTag {

        public ushort CharacterID;

        public byte[] ImageData;

        public override SwfTagType TagType {
            get { return SwfTagType.DefineBitsJPEG2; }
        }

        public override object AcceptVistor(ISwfTagVisitor visitor) {
            return visitor.Visit(this);
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
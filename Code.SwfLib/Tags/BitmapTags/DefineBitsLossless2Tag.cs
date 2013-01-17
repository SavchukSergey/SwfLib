﻿namespace Code.SwfLib.Tags.BitmapTags {
    public class DefineBitsLossless2Tag : BitmapBaseTag {

        public override SwfTagType TagType {
            get { return SwfTagType.DefineBitsLossless2; }
        }

        public override object AcceptVistor(ISwfTagVisitor visitor) {
            return visitor.Visit(this);
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
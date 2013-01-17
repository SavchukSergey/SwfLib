﻿namespace Code.SwfLib.Tags.DisplayListTags {
    public class RemoveObject2Tag : DisplayListBaseTag {

        public ushort Depth;

        public override SwfTagType TagType {
            get { return SwfTagType.RemoveObject2; }
        }

        public override object AcceptVistor(ISwfTagVisitor visitor) {
            return visitor.Visit(this);
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
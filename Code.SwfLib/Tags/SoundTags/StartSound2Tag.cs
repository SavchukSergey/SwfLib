﻿namespace Code.SwfLib.Tags.SoundTags {
    public class StartSound2Tag : SwfTagBase {

        public override SwfTagType TagType {
            get { return SwfTagType.StartSound2; }
        }

        public override object AcceptVistor(ISwfTagVisitor visitor) {
            return visitor.Visit(this);
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}

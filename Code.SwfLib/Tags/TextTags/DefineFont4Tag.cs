﻿namespace Code.SwfLib.Tags.TextTags {
    public class DefineFont4Tag : TextBaseTag {

        public override SwfTagType TagType {
            get { return SwfTagType.DefineFont4; }
        }

        public override object AcceptVistor(ISwfTagVisitor visitor) {
            return visitor.Visit(this);
        }
    }
}
﻿namespace Code.SwfLib.Tags.FontTags {
    public class DefineFont2Tag : FontBaseTag {

        public override SwfTagType TagType {
            get { return SwfTagType.DefineFont2; }
        }

        public override object AcceptVistor(ISwfTagVisitor visitor) {
            return visitor.Visit(this);
        }

    }
}
﻿namespace Code.SwfLib.Tags.FontTags {
    public class DefineFontNameTag : FontBaseTag {

        public ushort FontId;

        public string FontName;

        public string FontCopyright;

        public override SwfTagType TagType {
            get { return SwfTagType.DefineFontName; }
        }

        public override object AcceptVistor(ISwfTagVisitor visitor) {
            return visitor.Visit(this);
        }
    }
}
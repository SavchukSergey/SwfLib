﻿namespace Code.SwfLib.Tags.ControlTags {
    public class ScriptLimitsTag : ControlBaseTag {

        public ushort MaxRecursionDepth;

        public ushort ScriptTimeoutSeconds;

        public override SwfTagType TagType {
            get { return SwfTagType.ScriptLimits; }
        }

        public override object AcceptVistor(ISwfTagVisitor visitor) {
            return visitor.Visit(this);
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
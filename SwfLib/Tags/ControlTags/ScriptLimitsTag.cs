namespace Code.SwfLib.Tags.ControlTags {
    public class ScriptLimitsTag : ControlBaseTag {

        public ushort MaxRecursionDepth;

        public ushort ScriptTimeoutSeconds;

        public override SwfTagType TagType {
            get { return SwfTagType.ScriptLimits; }
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
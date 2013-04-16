namespace Code.SwfLib.Tags.ControlTags {
    public class SetTabIndexTag : ControlBaseTag {
        
        public override SwfTagType TagType {
            get { return SwfTagType.SetTabIndex; }
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}

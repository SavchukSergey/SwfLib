namespace SwfLib.Tags.ControlTags {
    public class DefineScalingGridTag : ControlBaseTag {

        public ushort CharacterID { get; set; }

        public override SwfTagType TagType {
            get { return SwfTagType.DefineScalingGrid; }
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}

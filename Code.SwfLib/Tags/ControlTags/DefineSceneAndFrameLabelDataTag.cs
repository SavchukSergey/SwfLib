namespace Code.SwfLib.Tags.ControlTags {
    public class DefineSceneAndFrameLabelDataTag : ControlBaseTag {

        public override SwfTagType TagType {
            get { return SwfTagType.DefineSceneAndFrameLabelData; }
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}

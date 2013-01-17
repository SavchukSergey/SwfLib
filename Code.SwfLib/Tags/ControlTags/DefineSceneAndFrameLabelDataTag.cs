namespace Code.SwfLib.Tags.ControlTags {
    public class DefineSceneAndFrameLabelDataTag : ControlBaseTag {

        public override SwfTagType TagType {
            get { return SwfTagType.DefineSceneAndFrameLabelData; }
        }

        public override object AcceptVistor(ISwfTagVisitor visitor) {
            return visitor.Visit(this);
        }

    }
}

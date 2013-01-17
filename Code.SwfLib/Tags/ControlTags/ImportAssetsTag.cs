namespace Code.SwfLib.Tags.ControlTags {
    public class ImportAssetsTag : ControlBaseTag {
        public override SwfTagType TagType {
            get { return SwfTagType.ImportAssets; }
        }

        public override object AcceptVistor(ISwfTagVisitor visitor) {
            return visitor.Visit(this);
        }
    }
}

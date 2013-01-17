namespace Code.SwfLib.Tags {
    public abstract class SwfTagBase {

        public abstract SwfTagType TagType { get; }

        public abstract object AcceptVistor(ISwfTagVisitor visitor);

        public abstract TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg);

    }
}

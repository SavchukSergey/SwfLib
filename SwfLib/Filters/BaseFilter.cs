namespace SwfLib.Filters {
    public abstract class BaseFilter {

        public abstract FilterType Type { get; }

        public abstract TResult AcceptVisitor<TArg, TResult>(IFilterVisitor<TArg, TResult> visitor, TArg arg);

    }
}

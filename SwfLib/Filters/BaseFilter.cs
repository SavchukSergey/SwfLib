namespace SwfLib.Filters {
    /// <summary>
    /// Represents base class for filters.
    /// </summary>
    public abstract class BaseFilter {

        /// <summary>
        /// Gets type of filter.
        /// </summary>
        public abstract FilterType Type { get; }

        public abstract TResult AcceptVisitor<TArg, TResult>(IFilterVisitor<TArg, TResult> visitor, TArg arg);

    }
}

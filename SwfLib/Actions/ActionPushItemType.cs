namespace SwfLib.Actions {
    /// <summary>
    /// Represents type of PushItem.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1028:EnumStorageShouldBeInt32")]
    public enum ActionPushItemType : byte {
        /// <summary>
        /// String
        /// </summary>
        String = 0,
        /// <summary>
        /// Float
        /// </summary>
        Float = 1,
        /// <summary>
        /// Null
        /// </summary>
        Null = 2,
        /// <summary>
        /// Undefined
        /// </summary>
        Undefined = 3,
        /// <summary>
        /// Register
        /// </summary>
        Register = 4,
        /// <summary>
        /// Boolean
        /// </summary>
        Boolean = 5,
        /// <summary>
        /// Double
        /// </summary>
        Double = 6,
        /// <summary>
        /// Integer
        /// </summary>
        Integer = 7,
        /// <summary>
        /// Byte constant
        /// </summary>
        Constant8 = 8,
        /// <summary>
        /// Two byte constant
        /// </summary>
        Constant16 = 9,
    }

}

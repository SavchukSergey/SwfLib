namespace SwfLib.Avm2.Data {
    public struct AsExceptionInfo {
        
        /// <summary>
        /// The starting position in the code field from which the exception is enabled. 
        /// </summary>
        public uint From;

        /// <summary>
        /// The ending position in the code field after which the exception is disabled. 
        /// </summary>
        public uint To;

        /// <summary>
        /// The position in the code field to which control should jump if an exception of type exc_type is 
        /// encountered while executing instructions that lie within the region [from, to] of the code field. 
        /// </summary>
        public uint Target;

        /// <summary>
        /// An index into the string array of the constant pool that identifies the name of the type of exception that 
        /// is to be monitored during the reign of this handler. A value of zero means the any type (“*”) and implies 
        /// that this exception handler will catch any type of exception thrown. 
        /// </summary>
        public uint ExceptionType;
        
        /// <summary>
        /// This index into the string array of the constant pool defines the name of the variable that is to receive 
        /// the exception object when the exception is thrown and control is transferred to target location. If the 
        /// value is zero then there is no name associated with the exception object
        /// </summary>
        public uint VariableName;
    }
}

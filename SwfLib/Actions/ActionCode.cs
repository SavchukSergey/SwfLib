namespace SwfLib.Actions {
    public enum ActionCode : byte {

        End = 0x00,
        /// <summary>
        /// ActionNextFrame instructs Flash Player to go to the next frame in the current file.
        /// </summary>
        NextFrame = 0x04,
        /// <summary>
        /// ActionPreviousFrame instructs Flash Player to go to the previous frame of the current file. 
        /// </summary>
        PreviousFrame = 0x05,
        /// <summary>
        /// ActionPlay instructs Flash Player to start playing at the current frame.
        /// </summary>
        Play = 0x06,
        /// <summary>
        /// ActionStop instructs Flash Player to stop playing the file at the current frame.
        /// </summary>
        Stop = 0x07,
        /// <summary>
        /// ActionToggleQuality toggles the display between high and low quality.
        /// </summary>
        ToggleQuality = 0x08,
        /// <summary>
        /// ActionStopSounds instructs Flash Player to stop playing all sounds.
        /// </summary>
        StopSounds = 0x09,
        /// <summary>
        /// ActionAdd adds two numbers and pushes the result back to the stack.
        /// </summary>
        Add = 0x0a,
        /// <summary>
        /// ActionSubtract subtracts two numbers and pushes the result back to the stack.
        /// </summary>
        Subtract = 0x0b,
        /// <summary>
        /// ActionMultiply multiplies two numbers and pushes the result back to the stack.
        /// </summary>
        Multiply = 0x0c,
        /// <summary>
        /// ActionDivide divides two numbers and pushes the result back to the stack.
        /// </summary>
        Divide = 0x0d,
        /// <summary>
        /// ActionEquals tests two numbers for equality
        /// </summary>
        Equals = 0x0e,
        /// <summary>
        /// ActionLess tests if a number is less than another number
        /// </summary>
        Less = 0x0f,
        /// <summary>
        /// ActionAnd performs a logical AND of two numbers.
        /// </summary>
        And = 0x10,
        /// <summary>
        /// ActionOr performs a logical OR of two numbers. 
        /// </summary>
        Or = 0x11,
        /// <summary>
        /// ActionNot performs a logical NOT of a number. 
        /// </summary>
        Not = 0x12,
        /// <summary>
        /// ActionStringEquals tests two strings for equality.
        /// </summary>
        StringEquals = 0x13,
        /// <summary>
        /// ActionStringLength computes the length of a string. 
        /// </summary>
        StringLength = 0x14,
        /// <summary>
        /// ActionStringExtract extracts a substring from a string.
        /// </summary>
        StringExtract = 0x15,
        /// <summary>
        /// ActionPop pops a value from the stack and discards it. 
        /// </summary>
        Pop = 0x17,
        /// <summary>
        /// ActionToInteger converts a value to an integer. 
        /// </summary>
        ToInteger = 0x18,
        /// <summary>
        /// ActionGetVariable gets a variable’s value.
        /// </summary>
        GetVariable = 0x1c,
        /// <summary>
        /// ActionSetVariable sets a variable.
        /// </summary>
        SetVariable = 0x1d,
        /// <summary>
        /// ActionSetTarget2 sets the current context and is stack based. 
        /// </summary>
        SetTarget2 = 0x20,
        /// <summary>
        /// ActionStringAdd concatenates two strings.
        /// </summary>
        StringAdd = 0x21,
        /// <summary>
        /// ActionGetProperty gets a file property
        /// </summary>
        GetProperty = 0x22,
        /// <summary>
        /// ActionSetProperty sets a file property.
        /// </summary>
        SetProperty = 0x23,
        /// <summary>
        /// ActionCloneSprite clones a sprite.
        /// </summary>
        CloneSprite = 0x24,
        /// <summary>
        /// ActionRemoveSprite removes a clone sprite.
        /// </summary>
        RemoveSprite = 0x25,
        /// <summary>
        /// ActionTrace sends a debugging output string.
        /// </summary>
        Trace = 0x26,
        /// <summary>
        /// ActionStartDrag starts dragging a movie clip.
        /// </summary>
        StartDrag = 0x27,
        /// <summary>
        /// ActionEndDrag ends the drag operation in progress, if any.
        /// </summary>
        EndDrag = 0x28,
        Throw = 0x2a,
        CastOp = 0x2b,
        ImplementsOp = 0x2c,
        /// <summary>
        /// ActionStringLess tests to see if a string is less than another string 
        /// </summary>
        StringLess = 0x29,
        /// <summary>
        /// ActionRandomNumber calculates a random number.
        /// </summary>
        RandomNumber = 0x30,
        /// <summary>
        /// ActionMBStringLength computes the length of a string and is multi-byte aware. 
        /// </summary>
        MBStringLength = 0x31,
        /// <summary>
        /// ActionCharToAscii converts character code to ASCII.
        /// </summary>
        CharToAscii = 0x32,
        /// <summary>
        /// ActionAsciiToChar converts a value to an ASCII character code.
        /// </summary>
        AsciiToChar = 0x33,
        /// <summary>
        /// ActionGetTime reports the milliseconds since Adobe Flash Player started.
        /// </summary>
        GetTime = 0x34,
        /// <summary>
        /// ActionMBStringExtract extracts a substring from a string and is multi-byte aware.
        /// </summary>
        MBStringExtract = 0x35,
        /// <summary>
        /// ActionMBCharToAscii converts character code to ASCII and is multi-byte aware.
        /// </summary>
        MBCharToAscii = 0x36,
        /// <summary>
        /// ActionMBAsciiToChar converts ASCII to character code and is multi-byte aware.
        /// </summary>
        MBAsciiToChar = 0x37,
        Delete = 0x3a,
        Delete2 = 0x3b,
        DefineLocal = 0x3c,
        CallFunction = 0x3d,
        /// <summary>
        /// ActionReturn forces the return item to be pushed off the stack and returned. If a return is not 
        /// appropriate, the return item is discarded.
        /// </summary>
        Return = 0x3e,
        Modulo = 0x3f,
        NewObject = 0x40,
        DefineLocal2 = 0x41,
        InitArray = 0x42,
        InitObject = 0x43,
        TypeOf = 0x44,
        TargetPath = 0x45,
        Enumerate = 0x46,
        Add2 = 0x47,
        Less2 = 0x48,
        Equals2 = 0x49,
        ToNumber = 0x4a,
        ToString = 0x4b,
        PushDuplicate = 0x4c,
        StackSwap = 0x4d,
        GetMember = 0x4e,
        /// <summary>
        /// ActionSetMember sets a property of an object. If the property does not already exist, it is 
        /// created. Any existing value in the property is overwritten.
        /// </summary>
        SetMember = 0x4f,
        Increment = 0x50,
        Decrement = 0x51,
        CallMethod = 0x52,
        NewMethod = 0x53,
        InstanceOf = 0x54,
        Enumerate2 = 0x55,
        BitAnd = 0x60,
        BitOr = 0x61,
        BitXor = 0x62,
        BitLShift = 0x63,
        BitRShift = 0x64,
        BitURShift = 0x65,
        StrictEquals = 0x66,
        Greater = 0x67,
        StringGreater = 0x68,
        Extends = 0x69,
        /// <summary>
        /// ActionGotoFrame instructs Flash Player to go to the specified frame in the current file. 
        /// </summary>
        GotoFrame = 0x81,
        /// <summary>
        /// ActionGetURL instructs Flash Player to get the URL that UrlString specifies. The URL can 
        /// be of any type, including an HTML file, an image or another SWF file. If the file is playing in 
        /// a browser, the URL is displayed in the frame that TargetString specifies. The "_level0" and 
        /// "_level1" special target names are used to load another SWF file into levels 0 and 1 
        /// respectively. 
        /// </summary>
        GetURL = 0x83,
        StoreRegister = 0x87,
        /// <summary>
        /// ActionConstantPool creates a new constant pool, and replaces the old constant pool if one 
        /// already exists.
        /// </summary>
        ConstantPool = 0x88,
        /// <summary>
        /// ActionWaitForFrame instructs Flash Player to wait until the specified frame; otherwise skips 
        /// the specified number of actions.
        /// </summary>
        WaitForFrame = 0x8a,
        /// <summary>
        /// ActionSetTarget instructs Flash Player to change the context of subsequent actions, so they 
        /// apply to a named object (TargetName) rather than the current file.
        /// </summary>
        SetTarget = 0x8b,
        /// <summary>
        /// ActionGoToLabel instructs Flash Player to go to the frame associated with the specified label. 
        /// You can attach a label to a frame with the FrameLabel tag.
        /// </summary>
        GoToLabel = 0x8c,
        /// <summary>
        /// ActionWaitForFrame2 waits for a frame to be loaded and is stack based.
        /// </summary>
        WaitForFrame2 = 0x8d,
        DefineFunction2 = 0x8e,
        Try = 0x8f,
        With = 0x94,
        /// <summary>
        /// ActionPush pushes one or more values to the stack. 
        /// </summary>
        Push = 0x96,
        /// <summary>
        /// ActionJump creates an unconditional branch.
        /// </summary>
        Jump = 0x99,
        /// <summary>
        /// ActionGetURL2 gets a URL and is stack based.
        /// </summary>
        GetURL2 = 0x9a,
        /// <summary>
        /// ActionDefineFunction defines a function with a given name and body size.
        /// </summary>
        DefineFunction = 0x9b,
        /// <summary>
        /// ActionIf creates a conditional test and branch.
        /// </summary>
        If = 0x9d,
        /// <summary>
        /// ActionCall calls a subroutine. 
        /// </summary>
        Call = 0x9e,
        /// <summary>
        /// ActionGotoFrame2 goes to a frame and is stack based.
        /// </summary>
        GotoFrame2 = 0x9f,
    }
}

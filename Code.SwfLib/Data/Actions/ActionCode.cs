namespace Code.SwfLib.Data.Actions {
    public  enum ActionCode : byte {

        Empty = 0x00,
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
        Substract = 0x0b,
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
        /// ActionPop pops a value from the stack and discards it. 
        /// </summary>
        Pop = 0x17,
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
        /// ActionPush pushes one or more values to the stack. 
        /// </summary>
        Push = 0x96,
    }
}

namespace Code.SwfLib.Data.Actions {
    public  enum ActionCode : byte {

        Empty = 0x00,
        NextFrame = 0x04,
        PreviousFrame = 0x05,
        Play = 0x06,
        Stop = 0x07,
        ToggleQuality = 0x08,
        StopSounds = 0x09,
        GotoFrame = 0x81,
        GetURL = 0x83,
        WaitForFrame = 0x8a,
        SetTarget = 0x8b,
        GoToLabel = 0x8c,

    }
}

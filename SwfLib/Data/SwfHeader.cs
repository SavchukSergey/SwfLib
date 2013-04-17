namespace SwfLib.Data {

    public struct SwfHeader {
        public SwfRect FrameSize { get; set; }
        public double FrameRate { get; set; }
        public ushort FrameCount { get; set; }
    }

}
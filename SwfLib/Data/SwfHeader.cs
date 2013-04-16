using SwfLib.Data;

namespace Code.SwfLib.Data {

    public struct SwfHeader {
        public SwfRect FrameSize;
        public double FrameRate;
        public ushort FrameCount;
    }

}
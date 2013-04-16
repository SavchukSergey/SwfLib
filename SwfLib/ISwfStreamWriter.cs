namespace Code.SwfLib {
    public interface ISwfStreamWriter {
        long Position { get; }
        long Length { get; }

        /// <summary>
        /// Writes Fixed point decimal in 8:8 format
        /// </summary>
        /// <param name="val"></param>
        void WriteFixedPoint8(double val);
        void WriteFixed(double val);
        void WriteFixedPoint16(double val, uint bits);

        void WriteUInt16(ushort val);
        void WriteSInt16(short val);

        void WriteUInt32(uint val);
        void WriteInt32(int val);

        void WriteEncodedU32(uint val);

        void WriteByte(byte val);
        void WriteBytes(byte[] bytes);

        void WriteBit(bool val);

        void WriteString(string val);
        void WriteRawString(string val);

        void WriteSingle(float value);
        void WriteDouble(double value);
        void WriteShortFloat(double value);

        void WriteUnsignedBits(uint val, uint count);
        void WriteSignedBits(int val, uint count);
        void FlushBits();

        void Flush();
    }
}

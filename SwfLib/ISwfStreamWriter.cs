namespace SwfLib {
    /// <summary>
    /// Represents interface for writing swf file primitives.
    /// </summary>
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
        /// <summary>
        /// Writes the int32 value.
        /// </summary>
        /// <param name="val">The val.</param>
        void WriteInt32(int val);

        void WriteEncodedU32(uint val);

        /// <summary>
        /// Writes byte.
        /// </summary>
        /// <param name="val"></param>
        void WriteByte(byte val);
        /// <summary>
        /// Writes the bytes.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        void WriteBytes(byte[] bytes);

        /// <summary>
        /// Writes the bit.
        /// </summary>
        /// <param name="val">if set to <c>true</c> [val].</param>
        void WriteBit(bool val);

        void WriteString(string val);
        void WriteRawString(string val);

        /// <summary>
        /// Writes the single value.
        /// </summary>
        /// <param name="value">The value.</param>
        void WriteSingle(float value);
        /// <summary>
        /// Writes the double value.
        /// </summary>
        /// <param name="value">The value.</param>
        void WriteDouble(double value);
        void WriteShortFloat(double value);

        void WriteUnsignedBits(uint val, uint count);
        void WriteSignedBits(int val, uint count);
        /// <summary>
        /// Flushes bits.
        /// </summary>
        void FlushBits();

        void Flush();
    }
}

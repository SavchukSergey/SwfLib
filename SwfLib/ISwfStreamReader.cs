namespace SwfLib {
    public interface ISwfStreamReader {
        bool IsEOF { get; }
        long Position { get; }
        long BytesLeft { get; }
        
        double ReadFixedPoint8();
        double ReadFixed();
        double ReadFixedPoint16(uint bits);

        ushort ReadUInt16();
        short ReadSInt16();

        uint ReadUInt32();
        int ReadInt32();

        ulong ReadUInt64();

        uint ReadEncodedU32();
        
        byte ReadByte();
        byte[] ReadBytes(int count);
        byte[] ReadRest();

        /// <summary>
        /// Reads Null-terminated string
        /// </summary>
        /// <returns></returns>
        string ReadString();

        string ReadRawString(int count);
        
        float ReadSingle();
        double ReadDouble();
        float ReadShortFloat();
        
        bool ReadBit();
        int ReadSignedBits(uint count);
        uint ReadUnsignedBits(uint count);
        void AlignToByte();
    }
}
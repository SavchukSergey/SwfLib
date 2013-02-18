using System.IO;

namespace Code.SwfLib {
    public interface ISwfStreamReader {
        bool IsEOF { get; }
        Stream BaseStream { get; }
        long BytesLeft { get; }
        double ReadFixedPoint8();
        double ReadFixed();
        double ReadFixedPoint16(uint bits);
        ushort ReadUInt16();
        short ReadSInt16();
        uint ReadUInt32();
        ulong ReadUInt64();
        int ReadInt32();
        byte ReadByte();
        byte[] ReadBytes(int count);
        byte[] ReadRest();
        uint ReadEncodedU32();

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
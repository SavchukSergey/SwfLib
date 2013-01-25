﻿using System.IO;
using System.Text;
using Code.SwfLib.Tags;

namespace Code.SwfLib {
    public class SwfStreamReader {

        private readonly BinaryReader _reader;
        private readonly Stream _baseStream;

        public bool IsEOF {
            get { return _reader.BaseStream.Position == _reader.BaseStream.Length; }
        }

        public Stream BaseStream {
            get {
                return _baseStream;
            }
        }

        public SwfStreamReader(Stream stream) {
            _reader = new BinaryReader(stream);
            _baseStream = stream;
        }


        public SwfTagData ReadTagData() {
            ushort typeAndSize = ReadUInt16();
            var type = (SwfTagType)(typeAndSize >> 6);
            int shortSize = typeAndSize & 0x3f;
            int size = shortSize < 0x3f ? shortSize : ReadInt32();
            byte[] tagData = ReadBytes(size);
            return new SwfTagData { Type = type, Data = tagData };
        }

        public double ReadFixedPoint8() {
            return ReadUInt16() / 256.0;
        }

        public double ReadFixedPoint16(uint bits) {
            int value = ReadSignedBits(bits);
            return value / 65536.0;
        }

        public ushort ReadUInt16() {
            return _reader.ReadUInt16();
        }

        public short ReadSInt16() {
            return _reader.ReadInt16();
        }

        public uint ReadUInt32() {
            return _reader.ReadUInt32();
        }

        public ulong ReadUInt64() {
            return _reader.ReadUInt64();
        }

        public int ReadInt32() {
            return _reader.ReadInt32();
        }

        public byte ReadByte() {
            AlignToByte();
            return _reader.ReadByte();
        }

        public byte[] ReadBytes(int count) {
            return _reader.ReadBytes(count);
        }

        public byte[] ReadRest() {
            return ReadBytes((int)BytesLeft);
        }

        public long BytesLeft {
            get { return _reader.BaseStream.Length - _reader.BaseStream.Position; }
        }

        public uint ReadEncodedU32() {
            AlignToByte();
            uint val = 0;
            var bt = _reader.ReadByte();
            val |= bt & 0x7fu;
            if ((bt & 0x80) == 0) return val;

            bt = _reader.ReadByte();
            val |= (bt & 0x7fu) << 7;
            if ((bt & 0x80) == 0) return val;

            bt = _reader.ReadByte();
            val |= (bt & 0x7fu) << 14;
            if ((bt & 0x80) == 0) return val;

            bt = _reader.ReadByte();
            val |= (bt & 0x7fu) << 21;
            if ((bt & 0x80) == 0) return val;

            bt = _reader.ReadByte();
            val |= (bt & 0x7fu) << 28;
            return val;
        }

        /// <summary>
        /// Reads Null-terminated string
        /// </summary>
        /// <returns></returns>
        public string ReadString() {
            var dataStream = new MemoryStream();
            byte bt = 1;
            while (bt > 0) {
                bt = _reader.ReadByte();
                if (bt > 0) dataStream.WriteByte(bt);
            }
            return Encoding.UTF8.GetString(dataStream.ToArray());
        }

        public string ReadRawString(int count) {
            var dataStream = new MemoryStream();
            for (var i = 0; i < count; i++) {
                var bt = _reader.ReadByte();
                if (bt != 0) dataStream.WriteByte(bt);
            }
            return Encoding.UTF8.GetString(dataStream.ToArray());
        }

        public float ReadSingle() {
            return _reader.ReadSingle();
        }

        public double ReadDouble() {
            return _reader.ReadDouble();
        }

        public float ReadShortFloat() {
            var data = _reader.ReadUInt16();
            if (data == 0) return 0;
            var sign = data & 0x8000;
            var exp = (data & 0x7c00) >> 10;
            var m = (data & 0x3ff) | 0x400;
            if (sign != 0) m = -m;
            var k = 1 << exp;
            const float bias = 1 << 25;
            return ((float)m) * k / bias;
        }
        //0x42de, 3.43359375(879)
        #region Bit Reading

        private struct BitContext {

            public byte CachedByte;

            public byte BitIndex;

        }

        private BitContext _bitContext;

        public bool ReadBit() {
            var bitIndex = _bitContext.BitIndex & 0x07;
            if (bitIndex == 0) {
                _bitContext.CachedByte = ReadByte();
            }
            _bitContext.BitIndex++;
            return ((_bitContext.CachedByte << bitIndex) & 0x80) != 0;
        }

        public int ReadSignedBits(uint count) {
            if (count == 0) return 0;
            bool sign = ReadBit();
            var res = sign ? uint.MaxValue : 0;
            count--;
            for (var i = 0; i < count; i++) {
                var bit = ReadBit();
                res = (res << 1 | (bit ? 1u : 0u));
            }
            return (int)res;
        }

        public uint ReadUnsignedBits(uint count) {
            if (count == 0) return 0;
            uint res = 0;
            for (var i = 0; i < count; i++) {
                var bit = ReadBit();
                res = (res << 1 | (bit ? 1u : 0u));
            }
            return res;
        }

        public void AlignToByte() {
            _bitContext.BitIndex = 0;
            _bitContext.CachedByte = 0;
        }

        #endregion

    }
}

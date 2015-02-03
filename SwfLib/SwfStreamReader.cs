using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace SwfLib {
    public class SwfStreamReader : ISwfStreamReader {

        private readonly BinaryReader _reader;
        private readonly Stream _baseStream;

        public bool IsEOF {
            get { return _reader.BaseStream.Position == _reader.BaseStream.Length; }
        }

        public long Position { get { return _reader.BaseStream.Position; } }

        public SwfStreamReader(Stream stream) {
            _reader = new BinaryReader(stream);
            _baseStream = stream;
        }

        //TODO: Why unsigned
        public double ReadFixedPoint8() {
            return ReadUInt16() / 256.0;
        }

        public double ReadFixed() {
            return ReadInt32() / 65536.0;
        }

        public double ReadFixedPoint16(uint bits) {
            int value = ReadSignedBits(bits);
            return value / 65536.0;
        }

        public virtual ushort ReadUInt16() {
            return _reader.ReadUInt16();
        }

        public virtual short ReadSInt16() {
            return _reader.ReadInt16();
        }

        /// <summary>
        /// Reads signed 24-bit integer
        /// </summary>
        /// <returns></returns>
        public virtual int ReadSInt24() {
            var i0 = _reader.ReadByte();
            var i1 = _reader.ReadByte();
            var i2 = _reader.ReadByte();
            var res =  (i2 << 16) | (i1 << 8) | i0;
            if ((res & 0x800000) != 0) res = (int)(res | 0xff000000);
            return res;
        }

        public virtual uint ReadUInt32() {
            return _reader.ReadUInt32();
        }

        public virtual ulong ReadUInt64() {
            return _reader.ReadUInt64();
        }

        public virtual int ReadInt32() {
            return _reader.ReadInt32();
        }

        public virtual byte ReadByte() {
            AlignToByte();
            return _reader.ReadByte();
        }

        public virtual byte[] ReadBytes(int count) {
            return _reader.ReadBytes(count);
        }

        public byte[] ReadRest() {
            return ReadBytes((int)BytesLeft);
        }

        public virtual long BytesLeft {
            get { return _reader.BaseStream.Length - _reader.BaseStream.Position; }
        }

        /// <summary>
        /// Reads variable-length encoded unsigned 30-bit integer
        /// </summary>
        /// <returns></returns>
        public uint ReadEncodedU30() {
            return ReadEncodedU32() & 0x3fffffff;
        }

        /// <summary>
        /// Reads variable-length encoded unsigned 32-bit integer
        /// </summary>
        /// <returns></returns>
        public virtual uint ReadEncodedU32() {
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
        /// Reads variable-length encoded signed 32-bit integer
        /// </summary>
        /// <returns></returns>
        public virtual int ReadEncodedS32() {
            AlignToByte();
            uint val = 0;
            var bt = _reader.ReadByte();
            val |= bt & 0x7fu;
            if ((bt & 0x80) == 0) return ((bt & 0x40) == 0) ? (int)val : (int)(val | 0xffffff80);

            bt = _reader.ReadByte();
            val |= (bt & 0x7fu) << 7;
            if ((bt & 0x80) == 0) return ((bt & 0x40) == 0) ? (int)val : (int)(val | 0xffffc000);

            bt = _reader.ReadByte();
            val |= (bt & 0x7fu) << 14;
            if ((bt & 0x80) == 0) return ((bt & 0x40) == 0) ? (int)val : (int)(val | 0xffe00000);

            bt = _reader.ReadByte();
            val |= (bt & 0x7fu) << 21;
            if ((bt & 0x80) == 0) return ((bt & 0x40) == 0) ? (int)val : (int)(val | 0xf0000000);

            bt = _reader.ReadByte();
            val |= (bt & 0x7fu) << 28;
            return (int)val;
        }

        /// <summary>
        /// Reads Null-terminated string
        /// </summary>
        /// <returns></returns>
        public virtual string ReadString() {
            var dataStream = new MemoryStream();
            byte bt = 1;
            while (bt > 0) {
                bt = _reader.ReadByte();
                if (bt > 0) dataStream.WriteByte(bt);
            }
            return Encoding.UTF8.GetString(dataStream.ToArray());
        }

        public virtual float ReadSingle() {
            return _reader.ReadSingle();
        }

        public virtual double ReadDouble() {
            ulong hi = ReadUInt32();
            ulong low = ReadUInt32();
            var l = (hi << 32) | low;
            return BitConverter.Int64BitsToDouble((long)l);
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

        public virtual bool ReadBit() {
            var bitIndex = _bitContext.BitIndex & 0x07;
            if (bitIndex == 0) {
                _bitContext.CachedByte = ReadByte();
            }
            _bitContext.BitIndex++;
            return ((_bitContext.CachedByte << bitIndex) & 0x80) != 0;
        }

        public virtual int ReadSignedBits(uint count) {
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

        public virtual uint ReadUnsignedBits(uint count) {
            if (count == 0) return 0;
            uint res = 0;
            for (var i = 0; i < count; i++) {
                var bit = ReadBit();
                res = (res << 1 | (bit ? 1u : 0u));
            }
            return res;
        }

        public virtual void AlignToByte() {
            _bitContext.BitIndex = 0;
            _bitContext.CachedByte = 0;
        }

        #endregion

    }
}

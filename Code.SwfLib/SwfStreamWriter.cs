using System;
using System.IO;
using System.Text;
using Code.SwfLib.Data;
using Code.SwfLib.Data.FillStyles;
using Code.SwfLib.Data.Shapes;
using Code.SwfLib.Tags;

namespace Code.SwfLib
{
    public class SwfStreamWriter
    {

        private readonly BinaryWriter _writer;

        public SwfStreamWriter(Stream stream)
        {
            _writer = new BinaryWriter(stream);
        }

        public void WriteTagData(SwfTagData data)
        {
            var bytes = data.Data;
            if (bytes.Length >= 0x3f)
            {
                WriteUInt16((ushort)(((ushort)data.Type << 6) | 0x3f));
                WriteUInt32((uint)bytes.Length);
            }
            else
            {
                WriteUInt16((ushort)(((ushort)data.Type << 6) | bytes.Length));
            }
            WriteBytes(bytes);
        }

        /// <summary>
        /// Writes Fixed point decimal in 8:8 format
        /// </summary>
        /// <param name="val"></param>
        public void WriteFixedPoint8(double val)
        {
            var integer = Math.Floor(val);
            var fraction = val - integer;
            var hi = (byte)integer;
            var low = (byte)(fraction * 256.0);
            WriteByte(low);
            WriteByte(hi);
        }

        public void WriteFixedPoint16(double val, uint bits)
        {
            var integer = Math.Floor(val);
            var fraction = val - integer;
            var low = (ushort)(fraction*65536);
            var hi = (ushort) integer;
            WriteUnsignedBits(hi, bits - 16);
            WriteUnsignedBits(low, 16);
        }

        #region Bit writing

        private struct BitContext
        {

            public byte CachedByte;

            public byte BitIndex;

        }

        private BitContext _bitContext;

        public void WriteBit(bool val)
        {
            _bitContext.CachedByte <<= 1;
            if (val) _bitContext.CachedByte |= 0x01;
            _bitContext.BitIndex++;
            if (_bitContext.BitIndex >= 8)
            {
                _writer.Write(_bitContext.CachedByte);
                _bitContext.BitIndex = 0;
            }
        }

        public void WriteUnsignedBits(uint val, uint count)
        {
            if (count == 0) return;
            var test = 1 << ((int)count - 1);
            for (var i = 0; i < count; i++)
            {
                WriteBit((val & test) > 0);
                test >>= 1;
            }
        }

        public void WriteSignedBits(int val, uint count)
        {
            if (count == 0) return;
            var test = 1 << ((int)count - 1);
            for (var i = 0; i < count; i++)
            {
                WriteBit((val & test) > 0);
                test >>= 1;
            }
        }

        //TODO: rename to AlignToByte
        public void FlushBits()
        {
            if (_bitContext.BitIndex == 0) return;
            _bitContext.CachedByte <<= 8 - _bitContext.BitIndex;
            _writer.Write(_bitContext.CachedByte);
            _bitContext.BitIndex = 0;
        }

        #endregion

        public void WriteBytes(byte[] bytes)
        {
            FlushBits();
            _writer.Write(bytes);
        }

        public void WriteByte(byte val)
        {
            FlushBits();
            _writer.Write(val);
        }

        public void WriteUInt32(uint val)
        {
            FlushBits();
            _writer.Write(val);
        }

        public void WriteUInt16(ushort val)
        {
            FlushBits();
            _writer.Write(val);
        }

        public void WriteSInt16(short val) {
            FlushBits();
            _writer.Write(val);
        }

        public void WriteString(string val)
        {
            var bytes = Encoding.UTF8.GetBytes(val);
            _writer.Write(bytes);
            const byte terminator = 0x00;
            _writer.Write(terminator);
        }

    }
}

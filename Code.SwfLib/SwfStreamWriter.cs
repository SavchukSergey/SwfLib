using System;
using System.IO;
using System.Text;
using Code.SwfLib.Tags;

namespace Code.SwfLib {
    public class SwfStreamWriter {

        private readonly BinaryWriter _writer;

        public SwfStreamWriter(Stream stream) {
            _writer = new BinaryWriter(stream);
        }

        public void WriteTagData(SwfTagData data) {
            var bytes = data.Data;
            if (bytes.Length >= 0x3f) {
                WriteUInt16((ushort)(((ushort)data.Type << 6) | 0x3f));
                WriteUInt32((uint)bytes.Length);
            } else {
                WriteUInt16((ushort)(((ushort)data.Type << 6) | bytes.Length));
            }
            WriteBytes(bytes);
        }

        public void WriteFixedPoint16(double val) {
            var integer = Math.Floor(val);
            var fracton = val - integer;
            var hi = (byte)integer;
            var low = (byte)(fracton * 256.0);
            WriteByte(low);
            WriteByte(hi);
        }

        #region Bit writing

        private struct BitContext {

            public byte CachedByte;

            public byte BitIndex;

        }

        private BitContext _bitContext;

        public void WriteBit(bool val) {
            _bitContext.CachedByte <<= 1;
            if (val) _bitContext.CachedByte |= 0x01;
            _bitContext.BitIndex++;
            if (_bitContext.BitIndex >= 8) {
                _writer.Write(_bitContext.CachedByte);
                _bitContext.BitIndex = 0;
            }
        }

        public void WriteUnsignedBits(uint val, uint count) {
            if (count == 0) return;
            var test = 1 << ((int)count - 1);
            for (var i = 0; i < count; i++) {
                WriteBit((val & test) > 0);
                test >>= 1;
            }
        }

        public void WriteSignedBits(int val, uint count) {
            if (count == 0) return;
            var test = 1 << ((int)count - 1);
            for (var i = 0; i < count; i++) {
                WriteBit((val & test) > 0);
                test >>= 1;
            }
        }

        public void FlushBits() {
            if (_bitContext.BitIndex == 0) return;
            _bitContext.CachedByte <<= 8 - _bitContext.BitIndex;
            _writer.Write(_bitContext.CachedByte);
            _bitContext.BitIndex = 0;
        }

        #endregion

        private void WriteBytes(byte[] bytes) {
            FlushBits();
            _writer.Write(bytes);
        }

        public void WriteByte(byte val) {
            FlushBits();
            _writer.Write(val);
        }

        public void WriteUInt32(uint val) {
            FlushBits();
            _writer.Write(val);
        }

        public void WriteUInt16(ushort val) {
            FlushBits();
            _writer.Write(val);
        }

        public void WriteString(string val) {
            var bytes = Encoding.UTF8.GetBytes(val);
            _writer.Write(bytes);
            const byte terminator = 0x00;
            _writer.Write(terminator);
        }

    }
}

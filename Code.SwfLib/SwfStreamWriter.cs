using System;
using System.IO;
using System.Text;
using Code.SwfLib.Tags;

namespace Code.SwfLib {
    public class SwfStreamWriter {

        private readonly BinaryWriter _writer;
        private readonly Stream _baseStream;

        public Stream BaseStream {
            get {
                return _baseStream;
            }
        }

        public SwfStreamWriter(Stream stream) {
            _writer = new BinaryWriter(stream);
            _baseStream = stream;
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

        /// <summary>
        /// Writes Fixed point decimal in 8:8 format
        /// </summary>
        /// <param name="val"></param>
        public void WriteFixedPoint8(double val) {
            var integer = Math.Floor(val);
            var fraction = val - integer;
            var hi = (byte)integer;
            var low = (byte)(fraction * 256.0);
            WriteByte(low);
            WriteByte(hi);
        }

        public void WriteFixedPoint16(double val, uint bits) {
            var integer = Math.Floor(val);
            var fraction = val - integer;
            var low = (ushort)(fraction * 65536);
            var hi = (ushort)integer;
            WriteUnsignedBits(hi, bits - 16);
            WriteUnsignedBits(low, 16);
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

        public void WriteBytes(byte[] bytes) {
            FlushBits();
            _writer.Write(bytes);
        }

        public void WriteByte(byte val) {
            FlushBits();
            _writer.Write(val);
        }

        public void WriteUInt16(ushort val) {
            FlushBits();
            _writer.Write(val);
        }

        public void WriteUInt32(uint val) {
            FlushBits();
            _writer.Write(val);
        }

        public void WriteSInt16(short val) {
            FlushBits();
            _writer.Write(val);
        }

        public void WriteEncodedU32(uint val) {
            FlushBits();

            if (val < 0x80) {
                _writer.Write((byte)val);
            } else {
                _writer.Write((byte)((val & 0x7f) | 0x80));
                val = val >> 7;

                if (val < 0x80) {
                    _writer.Write((byte)val);
                } else {
                    _writer.Write((byte)((val & 0x7f) | 0x80));
                    val = val >> 7;

                    if (val < 0x80) {
                        _writer.Write((byte)val);
                    } else {
                        _writer.Write((byte)((val & 0x7f) | 0x80));
                        val = val >> 7;

                        if (val < 0x80) {
                            _writer.Write((byte)val);
                        } else {
                            _writer.Write((byte)((val & 0x7f) | 0x80));
                            val = val >> 7;

                            _writer.Write((byte)(val & 0x7f));
                        }
                    }
                }
            }
        }

        public void WriteString(string val) {
            var bytes = Encoding.UTF8.GetBytes(val);
            _writer.Write(bytes);
            const byte terminator = 0x00;
            _writer.Write(terminator);
        }

        public void WriteRawString(string val) {
            var bytes = Encoding.UTF8.GetBytes(val);
            _writer.Write(bytes);
            _writer.Write((byte)0);
        }

        public void WriteSingle(float value) {
            _writer.Write(value);
        }

        public void WriteDouble(double value) {
            _writer.Write(value);
        }

        public void WriteShortFloat(double value) {
            ushort res = 0;
            if (value != 0.0) {
                if (value < 0) {
                    res |= 0x8000;
                    value = -value;
                }
                int e = 0;
                while (value >= 1.0) {
                    e++;
                    value /= 2;
                }
                int m = 0;
                while ((m & 0x400) == 0) {
                    value *= 2;
                    m <<= 1;
                    if (value >= 1.0) {
                        m |= 1;
                        value -= 1.0f;
                    }
                    e--;
                }
                e += 25;
                if (e > 31 || e < 0) throw new InvalidDataException("Exponent is out of range");
                m = m & 0x3ff;
                res |= (ushort)(e << 10);
                res |= (ushort)m;
            }
            _writer.Write(res);
        }
    }
}

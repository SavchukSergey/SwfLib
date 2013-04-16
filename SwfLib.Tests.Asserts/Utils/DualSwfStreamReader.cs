using System;
using System.IO;
using Code.SwfLib;

namespace SwfLib.Tests.Asserts.Utils {
    public class DualSwfStreamReader : SwfStreamReader {

        private readonly SwfStreamReader _first;
        private readonly SwfStreamReader _second;

        public DualSwfStreamReader(Stream first, Stream second)
            : this(new SwfStreamReader(first), new SwfStreamReader(second)) {
        }

        public DualSwfStreamReader(SwfStreamReader first, SwfStreamReader second)
            : base(new MemoryStream()) {
            _first = first;
            _second = second;
        }

        public override ushort ReadUInt16() {
            var a = _first.ReadUInt16();
            var b = _second.ReadUInt16();
            if (a != b) {
                throw new Exception(string.Format("a={0}, b={1}", a, b));
            }
            return a;
        }

        public override short ReadSInt16() {
            var a = _first.ReadSInt16();
            var b = _second.ReadSInt16();
            if (a != b) {
                throw new Exception(string.Format("a={0}, b={1}", a, b));
            }
            return a;
        }

        public override uint ReadUInt32() {
            var a = _first.ReadUInt32();
            var b = _second.ReadUInt32();
            if (a != b) {
                throw new Exception(string.Format("a={0}, b={1}", a, b));
            }
            return a;
        }

        public override ulong ReadUInt64() {
            var a = _first.ReadUInt64();
            var b = _second.ReadUInt64();
            if (a != b) {
                throw new Exception(string.Format("a={0}, b={1}", a, b));
            }
            return a;
        }

        public override int ReadInt32() {
            var a = _first.ReadInt32();
            var b = _second.ReadInt32();
            if (a != b) {
                throw new Exception(string.Format("a={0}, b={1}", a, b));
            }
            return a;
        }

        public override byte ReadByte() {
            var a = _first.ReadByte();
            var b = _second.ReadByte();
            if (a != b) {
                throw new Exception(string.Format("a={0}, b={1}", a, b));
            }
            return a;
        }


        public override uint ReadEncodedU32() {
            var a = _first.ReadEncodedU32();
            var b = _second.ReadEncodedU32();
            if (a != b) {
                throw new Exception(string.Format("a={0}, b={1}", a, b));
            }
            return a;
        }

        public override bool ReadBit() {
            var a = _first.ReadBit();
            var b = _second.ReadBit();
            if (a != b) {
                throw new Exception(string.Format("a={0}, b={1}", a, b));
            }
            return a;
        }

        public override int ReadSignedBits(uint count) {
            var a = _first.ReadSignedBits(count);
            var b = _second.ReadSignedBits(count);
            if (a != b) {
                throw new Exception(string.Format("a={0}, b={1}", a, b));
            }
            return a;
        }

        public override uint ReadUnsignedBits(uint count) {
            var a = _first.ReadUnsignedBits(count);
            var b = _second.ReadUnsignedBits(count);
            if (a != b) {
                throw new Exception(string.Format("a={0}, b={1}", a, b));
            }
            return a;
        }

        public override void AlignToByte() {
            _first.AlignToByte();
            _second.AlignToByte();
        }

        public override float ReadSingle() {
            var a = _first.ReadSingle();
            var b = _second.ReadSingle();
            if (a != b) {
                throw new Exception(string.Format("a={0}, b={1}", a, b));
            }
            return a;
        }

        public override double ReadDouble() {
            var a = _first.ReadDouble();
            var b = _second.ReadDouble();
            if (a != b) {
                throw new InvalidOperationException();
            }
            return a;
        }
        public override byte[] ReadBytes(int count) {
            var a = _first.ReadBytes(count);
            var b = _second.ReadBytes(count);
            if (a.Length != b.Length) {
                throw new InvalidOperationException();
            }
            for (var i = 0; i < a.Length; i++) {
                if (a[i] != b[i]) throw new InvalidOperationException();
            }
            return a;
        }

        public override string ReadString() {
            var a = _first.ReadString();
            var b = _second.ReadString();
            if (a != b) {
                throw new Exception(string.Format("a={0}, b={1}", a, b));
            }
            return a;
        }

        public override long BytesLeft {
            get { return _first.BytesLeft; }
        }

    }
}

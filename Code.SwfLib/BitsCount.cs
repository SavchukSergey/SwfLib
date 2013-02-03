namespace Code.SwfLib {
    public struct BitsCount {

        private uint _positiveMask;
        private uint _negativeMask;

        public BitsCount(int originalValue) {
            _positiveMask = 0x00000000;
            _negativeMask = 0xffffffff;
            AddValue(originalValue);
        }

        public BitsCount(int originalValue1, int originalValue2) {
            _positiveMask = 0x00000000;
            _negativeMask = 0xffffffff;
            AddValue(originalValue1);
            AddValue(originalValue2);
        }

        public BitsCount(int originalValue1, int originalValue2, int originalValue3, int originalValue4) {
            _positiveMask = 0x00000000;
            _negativeMask = 0xffffffff;
            AddValue(originalValue1);
            AddValue(originalValue2);
            AddValue(originalValue3);
            AddValue(originalValue4);
        }

        public void AddValue(int val) {
            if (val < 0) val--; //TODO: Compensates adobe not optimal bit count calculation...

            if (val >= 0) _positiveMask |= (uint)val;
            else _negativeMask &= (uint)val;
        }

        public void AddValue(uint val) {
            _positiveMask |= val;
        }

        public bool IsEmpty {
            get { return _positiveMask == 0 && _negativeMask == 0xffffffff; }
        }

        public uint GetSignedBits() {
            uint mask = (_positiveMask | (~_negativeMask)) << 1;
            if (mask == 0) return 0;
            uint test = 0x80000000;
            for (uint j = 32; j >= 1; j--) {
                if ((mask & test) > 0) return j;
                test >>= 1;
            }
            return 0;
        }

        public uint GetUnsignedBits() {
            uint mask = _positiveMask | (~_negativeMask);
            if (mask == 0) return 0;
            uint test = 0x80000000;
            for (uint j = 32; j >= 1; j--) {
                if ((mask & test) > 0) return j;
                test >>= 1;
            }
            return 0;
        }

    }
}

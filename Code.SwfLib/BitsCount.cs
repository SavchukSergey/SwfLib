namespace Code.SwfLib {
    public struct BitsCount {

        private uint _positiveMask;
        private uint _negativeMask;

        public BitsCount(int originalValue)
        {
            _positiveMask = 0x00000000;
            _negativeMask = 0xffffffff;
            AddValue(originalValue);
        }

        public void AddValue(int val) {
            if (val >= 0) _positiveMask |= (uint)val;
            else _negativeMask &= (uint)val;
        }

        public void AddValue(uint val) {
            _positiveMask |= val;
        }

        public int GetSignedBits() {
            uint mask = (_positiveMask | (~_negativeMask)) << 1;
            if (mask == 0) return -1;
            uint test = 0x80000000;
            for (var j = 32; j >= 1; j--) {
                if ((mask & test) > 0) return j;
                test >>= 1;
            }
            return -1;
        }

        public int GetUnsignedBits() {
            uint mask = _positiveMask | (~_negativeMask);
            if (mask == 0) return -1;
            uint test = 0x80000000;
            for (var j = 32; j >= 1; j--) {
                if ((mask & test) > 0) return j;
                test >>= 1;
            }
            return -1;
        }

    }
}

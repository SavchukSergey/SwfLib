namespace Code.SwfLib.Utils {
    public struct UnsignedBitsCount {

        private uint _positiveMask;

        public UnsignedBitsCount(uint originalValue) {
            _positiveMask = 0x00000000;
            AddValue(originalValue);
        }

        public UnsignedBitsCount(uint originalValue1, uint originalValue2) {
            _positiveMask = 0x00000000;
            AddValue(originalValue1);
            AddValue(originalValue2);
        }

        public UnsignedBitsCount(uint originalValue1, uint originalValue2, uint originalValue3, uint originalValue4) {
            _positiveMask = 0x00000000;
            AddValue(originalValue1);
            AddValue(originalValue2);
            AddValue(originalValue3);
            AddValue(originalValue4);
        }

        public void AddValue(uint val) {
            _positiveMask |= val;
        }

        public bool IsEmpty {
            get { return _positiveMask == 0; }
        }

        public uint GetBits() {
            uint mask = _positiveMask;
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

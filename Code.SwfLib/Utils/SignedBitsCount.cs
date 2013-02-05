namespace Code.SwfLib.Utils {
    public struct SignedBitsCount {

        private int _min;
        private int _max;

        public SignedBitsCount(int originalValue) {
            _max = int.MinValue;
            _min = int.MaxValue;
            AddValue(originalValue);
        }

        public SignedBitsCount(int originalValue1, int originalValue2) {
            _max = int.MinValue;
            _min = int.MaxValue;
            AddValue(originalValue1);
            AddValue(originalValue2);
        }

        public SignedBitsCount(int originalValue1, int originalValue2, int originalValue3, int originalValue4) {
            _max = int.MinValue;
            _min = int.MaxValue;
            AddValue(originalValue1);
            AddValue(originalValue2);
            AddValue(originalValue3);
            AddValue(originalValue4);
        }

        public void AddValue(int val) {
            if (val > _max) _max = val;
            if (val < _min) _min = val;
        }

        public bool IsEmpty {
            get { return _max == int.MinValue && _min == int.MaxValue; }
        }

        public uint GetBits() {
            if (_min == 0 && _max == 0) return 1;
            uint mask = 0;
            if (_min != int.MaxValue && _min < 0) {
                mask |= ~(uint)_min;
            }
            if (_max != int.MinValue && _max > 0) {
                mask |= (uint)_max;
            }
            uint test = 0x80000000;
            for (uint j = 32; j >= 1; j--) {
                if ((mask & test) > 0) return j + 1;
                test >>= 1;
            }
            return 1;
        }

    }
}

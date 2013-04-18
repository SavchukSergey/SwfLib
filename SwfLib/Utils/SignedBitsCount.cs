namespace SwfLib.Utils {
    /// <summary>
    /// Represents utility class for calculating minimal bits count of signed integers.
    /// </summary>
    public struct SignedBitsCount {

        private int _min;
        private int _max;

        /// <summary>
        /// Initializes a new instance of the <see cref="SignedBitsCount"/> struct.
        /// </summary>
        /// <param name="originalValue">The original value.</param>
        public SignedBitsCount(int originalValue) {
            _max = int.MinValue;
            _min = int.MaxValue;
            AddValue(originalValue);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SignedBitsCount"/> struct.
        /// </summary>
        /// <param name="originalValue1">The original value1.</param>
        /// <param name="originalValue2">The original value2.</param>
        public SignedBitsCount(int originalValue1, int originalValue2) {
            _max = int.MinValue;
            _min = int.MaxValue;
            AddValue(originalValue1);
            AddValue(originalValue2);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SignedBitsCount"/> struct.
        /// </summary>
        /// <param name="originalValue1">The original value1.</param>
        /// <param name="originalValue2">The original value2.</param>
        /// <param name="originalValue3">The original value3.</param>
        /// <param name="originalValue4">The original value4.</param>
        public SignedBitsCount(int originalValue1, int originalValue2, int originalValue3, int originalValue4) {
            _max = int.MinValue;
            _min = int.MaxValue;
            AddValue(originalValue1);
            AddValue(originalValue2);
            AddValue(originalValue3);
            AddValue(originalValue4);
        }

        /// <summary>
        /// Registers new value to be measured.
        /// </summary>
        /// <param name="val">Value to measrue.</param>
        public void AddValue(int val) {
            if (val > _max) _max = val;
            if (val < _min) _min = val;
        }

        /// <summary>
        /// Gets a value indicating whether this instance is empty.
        /// </summary>
        public bool IsEmpty {
            get { return _max == int.MinValue && _min == int.MaxValue; }
        }

        /// <summary>
        /// Gets bits count.
        /// </summary>
        /// <returns></returns>
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

namespace SwfLib.Utils {
    /// <summary>
    /// Represents utility class for calculating minimal bits count of unsigned integers.
    /// </summary>
    public struct UnsignedBitsCount {

        private uint _positiveMask;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnsignedBitsCount"/> struct.
        /// </summary>
        /// <param name="originalValue">The original value.</param>
        public UnsignedBitsCount(uint originalValue) {
            _positiveMask = 0x00000000;
            AddValue(originalValue);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnsignedBitsCount"/> struct.
        /// </summary>
        /// <param name="originalValue1">The original value1.</param>
        /// <param name="originalValue2">The original value2.</param>
        public UnsignedBitsCount(uint originalValue1, uint originalValue2) {
            _positiveMask = 0x00000000;
            AddValue(originalValue1);
            AddValue(originalValue2);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnsignedBitsCount"/> struct.
        /// </summary>
        /// <param name="originalValue1">The original value1.</param>
        /// <param name="originalValue2">The original value2.</param>
        /// <param name="originalValue3">The original value3.</param>
        /// <param name="originalValue4">The original value4.</param>
        public UnsignedBitsCount(uint originalValue1, uint originalValue2, uint originalValue3, uint originalValue4) {
            _positiveMask = 0x00000000;
            AddValue(originalValue1);
            AddValue(originalValue2);
            AddValue(originalValue3);
            AddValue(originalValue4);
        }

        /// <summary>
        /// Registers new value to be measured.
        /// </summary>
        /// <param name="val">Value to measrue.</param>
        public void AddValue(uint val) {
            _positiveMask |= val;
        }

        /// <summary>
        /// Gets a value indicating whether this instance is empty.
        /// </summary>
        public bool IsEmpty {
            get { return _positiveMask == 0; }
        }

        /// <summary>
        /// Gets bits count.
        /// </summary>
        /// <returns></returns>
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

using Code.SwfLib.Utils;
using NUnit.Framework;

namespace SwfLib.Tests.Utils {
    [TestFixture]
    public class UnsignedBitsCountTest {

        [Test]
        public void GetBitsTest() {
            var bits = new UnsignedBitsCount(0);
            bits.AddValue(127);
            bits.AddValue(260);
            bits.AddValue(15);
            bits.AddValue(514);
            Assert.AreEqual(10, bits.GetBits());
        }

        [Test]
        public void GetBitsZeroTest() {
            var bits = new UnsignedBitsCount(0);
            Assert.AreEqual(0, bits.GetBits());
        }

        [Test]
        public void GetBitsOneTest() {
            var bits = new UnsignedBitsCount(1);
            Assert.AreEqual(1, bits.GetBits());
        }

        [Test]
        public void GetBitsTwoTest() {
            var bits = new UnsignedBitsCount(2);
            Assert.AreEqual(2, bits.GetBits());
        }
    }
}

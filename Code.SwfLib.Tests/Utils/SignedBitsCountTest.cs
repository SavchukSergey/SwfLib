using Code.SwfLib.Utils;
using NUnit.Framework;

namespace Code.SwfLib.Tests.Utils {
    [TestFixture]
    public class SignedBitsCountTest {

        [Test]
        public void GetBitsPositiveTest() {
            var bits = new SignedBitsCount(0);
            bits.AddValue(127);
            bits.AddValue(260);
            bits.AddValue(15);
            bits.AddValue(514);
            Assert.AreEqual(11, bits.GetBits());
        }

        [Test]
        public void GetBitsNegativeTest() {
            var bits = new SignedBitsCount(0);
            bits.AddValue(127);
            bits.AddValue(260);
            bits.AddValue(15);
            bits.AddValue(-514);
            Assert.AreEqual(11, bits.GetBits());
        }

        [Test]
        public void GetBitsZeroTest() {
            var bits = new SignedBitsCount(0);
            Assert.AreEqual(0, bits.GetBits());
        }

        [Test]
        public void GetBitsPositiveOneTest() {
            var bits = new SignedBitsCount(1);
            Assert.AreEqual(2, bits.GetBits());
        }

        [Test]
        public void GetBitsNegativeOneTest() {
            var bits = new SignedBitsCount(-1);
            Assert.AreEqual(1, bits.GetBits());
        }

        [Test]
        public void GetBitsNegativeTwoTest() {
            var bits = new SignedBitsCount(-2);
            Assert.AreEqual(2, bits.GetBits());
        }
    }

}

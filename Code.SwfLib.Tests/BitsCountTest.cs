using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Code.SwfLib.Tests {
    [TestFixture]
    public class BitsCountTest {

        [Test]
        public void GetUnsignedBitsTest()
        {
            BitsCount bits = new BitsCount(0);
            bits.AddValue(127);
            bits.AddValue(260);
            bits.AddValue(15);
            bits.AddValue(514);
            Assert.AreEqual(10, bits.GetUnsignedBits());
        }

        [Test]
        public void GetSignedBitsPositiveTest() {
            BitsCount bits = new BitsCount(0);
            bits.AddValue(127);
            bits.AddValue(260);
            bits.AddValue(15);
            bits.AddValue(514);
            Assert.AreEqual(11, bits.GetSignedBits());
        }

        [Test]
        public void GetSignedBitsNegativeTest() {
            BitsCount bits = new BitsCount(0);
            bits.AddValue(127);
            bits.AddValue(260);
            bits.AddValue(15);
            bits.AddValue(-514);
            Assert.AreEqual(11, bits.GetSignedBits());
        }

    }
}

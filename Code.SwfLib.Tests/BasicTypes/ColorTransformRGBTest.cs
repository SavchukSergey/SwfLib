using System.IO;
using Code.SwfLib.Data;
using Code.SwfLib.Tests.Asserts;
using NUnit.Framework;

namespace Code.SwfLib.Tests.BasicTypes {
    [TestFixture]
    public class ColorTransformRGBTest : TestFixtureBase {

        [Test]
        public void ReadEmptyColorTransformTest() {
            var mem = new MemoryStream(new byte[] { 0 });
            var reader = new SwfStreamReader(mem);
            var transform = reader.ReadColorTransformRGB();
            Assert.IsFalse(transform.HasAddTerms);
            Assert.IsFalse(transform.HasMultTerms);
        }

        [Test]
        public void WriteEmptyColorTransformTest() {
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            writer.WriteColorTransformRGB(new ColorTransformRGB());
            Assert.AreEqual(new byte[] { 4 }, mem.ToArray());
        }

        [Test]
        public void ReadColorTransformRGBFromBitsMultTest() {
            var mem = new MemoryStream();
            WriteBits(mem,
                "0", "1", "1001", "0.00001010", "0.11100000", "1.11110110");
            var reader = new SwfStreamReader(mem);
            var color = reader.ReadColorTransformRGB();
            Assert.AreEqual(mem.Length, mem.Position, "Should reach end of the stream");

            AssertData.AreEqual(new ColorTransformRGB {
                HasMultTerms = true,
                HasAddTerms = false,
                RedMultTerm = 10,
                GreenMultTerm = 224,
                BlueMultTerm = -10
            }, color, "ColorTransform");
        }

        [Test]
        public void ReadColorTransformRGBFromBitsAddTest() {
            var mem = new MemoryStream();
            WriteBits(mem,
                "1", "0", "1001", "0.00001010", "1.11110110", "0.11100000");
            var reader = new SwfStreamReader(mem);
            var color = reader.ReadColorTransformRGB();
            Assert.AreEqual(mem.Length, mem.Position, "Should reach end of the stream");
            AssertData.AreEqual(new ColorTransformRGB {
                HasAddTerms = true,
                HasMultTerms = false,
                RedAddTerm = 10,
                GreenAddTerm = -10,
                BlueAddTerm = 224
            }, color, "ColorTransform");
        }

        [Test]
        public void ReadColorTransformRGBFromBitsMultAddTest() {
            var mem = new MemoryStream();
            WriteBits(mem,
                "1", "1", "1001", "0.00001010", "1.11110110", "0.11100000", "1.11110111", "0.10000001", "0.00010000");
            var reader = new SwfStreamReader(mem);
            var color = reader.ReadColorTransformRGB();
            Assert.AreEqual(mem.Length, mem.Position, "Should reach end of the stream");
            AssertData.AreEqual(new ColorTransformRGB {
                HasAddTerms = true,
                HasMultTerms = true,
                RedMultTerm = 10,
                GreenMultTerm = -10,
                BlueMultTerm = 224,
                RedAddTerm = -9,
                GreenAddTerm = 129,
                BlueAddTerm = 16
            }, color, "ColorTransform");
        }

        [Test]
        public void WriteColorTransformRGBFromBitsMultTest() {
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            var tranform = new ColorTransformRGB {
                RedMultTerm = 10,
                GreenMultTerm = 224,
                BlueMultTerm = -10,
                HasMultTerms = true,
                RedAddTerm = 0,
                GreenAddTerm = 0,
                BlueAddTerm = 0,
                HasAddTerms = false
            };
            writer.WriteColorTransformRGB(ref tranform);
            CheckBits(mem,
                "0", "1", "1001", "0.00001010", "0.11100000", "1.11110110");
        }

        [Test]
        public void WriteColorTransformRGBFromBitsAddTest() {
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            var tranform = new ColorTransformRGB {
                RedMultTerm = 0,
                GreenMultTerm = 0,
                BlueMultTerm = 0,
                HasMultTerms = false,
                RedAddTerm = 10,
                GreenAddTerm = -10,
                BlueAddTerm = 224,
                HasAddTerms = true
            };
            writer.WriteColorTransformRGB(ref tranform);
            CheckBits(mem,
                "1", "0", "1001", "0.00001010", "1.11110110", "0.11100000");
        }

        [Test]
        public void WriteColorTransformRGBFromBitsMultAddTest() {
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            var tranform = new ColorTransformRGB {
                RedMultTerm = 10,
                GreenMultTerm = -10,
                BlueMultTerm = 224,
                HasMultTerms = true,
                RedAddTerm = -9,
                GreenAddTerm = 129,
                BlueAddTerm = 16,
                HasAddTerms = true
            };
            writer.WriteColorTransformRGB(ref tranform);
            CheckBits(mem,
                "1", "1", "1001", "0.00001010", "1.11110110", "0.11100000", "1.11110111", "0.10000001", "0.00010000");
        }

    }
}

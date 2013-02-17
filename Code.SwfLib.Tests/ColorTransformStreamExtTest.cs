using System.IO;
using Code.SwfLib.Data;
using Code.SwfLib.Tests.Asserts;
using NUnit.Framework;

namespace Code.SwfLib.Tests {
    [TestFixture]
    public class ColorTransformStreamExtTest : TestFixtureBase {

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
        public void ReadColorTransformRGBAFromBitsMultTest() {
            var mem = new MemoryStream();
            WriteBits(mem,
                "0", "1", "1001", "0.00001010", "0.11100000", "1.11110110", "0.00010001");
            var reader = new SwfStreamReader(mem);
            ColorTransformRGBA color;
            reader.ReadColorTransformRGBA(out color);
            Assert.AreEqual(mem.Length, mem.Position, "Should reach end of the stream");
            AssertData.AreEqual(new ColorTransformRGBA {
                HasAddTerms = false,
                HasMultTerms = true,
                RedMultTerm = 10,
                GreenMultTerm = 224,
                BlueMultTerm = -10,
                AlphaMultTerm = 17
            }, color, "ColorTransform");
        }

        [Test]
        public void ReadColorTransformRGBAFromBitsAddTest() {
            var mem = new MemoryStream();
            WriteBits(mem,
                "1", "0", "1001", "0.00001010", "1.11110110", "0.11100000", "0.11000000");
            var reader = new SwfStreamReader(mem);
            ColorTransformRGBA color;
            reader.ReadColorTransformRGBA(out color);
            Assert.AreEqual(mem.Length, mem.Position, "Should reach end of the stream");
            AssertData.AreEqual(new ColorTransformRGBA {
                HasAddTerms = true,
                HasMultTerms = false,
                RedAddTerm = 10,
                GreenAddTerm = -10,
                BlueAddTerm = 224,
                AlphaAddTerm = 192
            }, color, "ColorTransform");
        }

        [Test]
        public void ReadColorTransformRGBAFromBitsMultAddTest() {
            var mem = new MemoryStream();
            WriteBits(mem,
                "1", "1", "1001", "0.00001010", "1.11110110", "0.11100000", "0.10110000",
                                  "1.11110111", "0.10000001", "0.00010000", "0.00001111");
            var reader = new SwfStreamReader(mem);
            ColorTransformRGBA color;
            reader.ReadColorTransformRGBA(out color);
            Assert.AreEqual(mem.Length, mem.Position, "Should reach end of the stream");
            AssertData.AreEqual(new ColorTransformRGBA {
                HasAddTerms = true,
                HasMultTerms = true,
                RedMultTerm = 10,
                GreenMultTerm = -10,
                BlueMultTerm = 224,
                AlphaMultTerm = 176,
                RedAddTerm = -9,
                GreenAddTerm  =129,
                BlueAddTerm = 16,
                AlphaAddTerm = 15
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

        [Test]
        public void WriteColorTransformRGBAFromBitsMultTest() {
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            var tranform = new ColorTransformRGBA {
                RedMultTerm = 10,
                GreenMultTerm = 224,
                BlueMultTerm = -10,
                AlphaMultTerm = 17,
                HasMultTerms = true,
                RedAddTerm = 0,
                GreenAddTerm = 0,
                BlueAddTerm = 0,
                AlphaAddTerm = 0,
                HasAddTerms = false
            };
            writer.WriteColorTransformRGBA(ref tranform);
            CheckBits(mem,
                "0", "1", "1001", "0.00001010", "0.11100000", "1.11110110", "0.00010001");
        }

        [Test]
        public void WriteColorTransformRGBAFromBitsAddTest() {
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            var tranform = new ColorTransformRGBA {
                RedMultTerm = 0,
                GreenMultTerm = 0,
                BlueMultTerm = 0,
                AlphaMultTerm = 0,
                HasMultTerms = false,
                RedAddTerm = 10,
                GreenAddTerm = -10,
                BlueAddTerm = 224,
                AlphaAddTerm = 192,
                HasAddTerms = true
            };
            writer.WriteColorTransformRGBA(ref tranform);
            CheckBits(mem,
                "1", "0", "1001", "0.00001010", "1.11110110", "0.11100000", "0.11000000");
        }

        [Test]
        public void WriteColorTransformRGBAFromBitsMultAddTest() {
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            var tranform = new ColorTransformRGBA {
                RedMultTerm = 10,
                GreenMultTerm = -10,
                BlueMultTerm = 224,
                AlphaMultTerm = 176,
                HasMultTerms = true,
                RedAddTerm = -9,
                GreenAddTerm = 129,
                BlueAddTerm = 16,
                AlphaAddTerm = 15,
                HasAddTerms = true
            };
            writer.WriteColorTransformRGBA(ref tranform);
            CheckBits(mem,
                "1", "1", "1001", "0.00001010", "1.11110110", "0.11100000", "0.10110000",
                                  "1.11110111", "0.10000001", "0.00010000", "0.00001111");
        }

    }
}

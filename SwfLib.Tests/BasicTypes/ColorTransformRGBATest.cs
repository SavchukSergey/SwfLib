using System.IO;
using Code.SwfLib.Data;
using Code.SwfLib.Tests.Asserts;
using NUnit.Framework;
using SwfLib.Data;
using SwfLib.Tests.Asserts;

namespace Code.SwfLib.Tests.BasicTypes {
    [TestFixture]
    public class ColorTransformRGBATest : TestFixtureBase {

        [Test]
        public void ReadEmptyColorTransformTest() {
            var mem = new MemoryStream(new byte[] { 0 });
            var reader = new SwfStreamReader(mem);
            var transform = reader.ReadColorTransformRGBA();
            Assert.IsFalse(transform.HasAddTerms);
            Assert.IsFalse(transform.HasMultTerms);
        }

        [Test]
        public void WriteEmptyColorTransformTest() {
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            writer.WriteColorTransformRGBA(new ColorTransformRGBA());
            Assert.AreEqual(new byte[] { 4 }, mem.ToArray());
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
                GreenAddTerm = 129,
                BlueAddTerm = 16,
                AlphaAddTerm = 15
            }, color, "ColorTransform");
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

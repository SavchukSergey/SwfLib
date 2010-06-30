using System.IO;
using Code.SwfLib.Data;
using NUnit.Framework;

namespace Code.SwfLib.Tests
{
    [TestFixture]
    public class ColorTransformStreamExtTest : TestFixtureBase
    {

        [Test]
        public void ReadColorTransformRGBFromBitsMultTest()
        {
            var mem = new MemoryStream();
            WriteBits(mem,
                "0", "1", "1001", "0.00001010", "0.11100000", "1.11110110");
            var reader = new SwfStreamReader(mem);
            var color = reader.ReadColorTransformRGB();
            Assert.AreEqual(mem.Length, mem.Position, "Should reach end of the stream");
            Assert.AreEqual(10, color.RedMultTerm);
            Assert.AreEqual(224, color.GreenMultTerm);
            Assert.AreEqual(-10, color.BlueMultTerm);

            Assert.IsFalse(color.RedAddTerm.HasValue);
            Assert.IsFalse(color.GreenAddTerm.HasValue);
            Assert.IsFalse(color.BlueAddTerm.HasValue);

            Assert.AreEqual(mem.Length, mem.Position, "Should reach end of the stream");
        }

        [Test]
        public void ReadColorTransformRGBFromBitsAddTest()
        {
            var mem = new MemoryStream();
            WriteBits(mem,
                "1", "0", "1001", "0.00001010", "1.11110110", "0.11100000");
            var reader = new SwfStreamReader(mem);
            var color = reader.ReadColorTransformRGB();
            Assert.AreEqual(mem.Length, mem.Position, "Should reach end of the stream");
            Assert.AreEqual(10, color.RedAddTerm);
            Assert.AreEqual(-10, color.GreenAddTerm);
            Assert.AreEqual(224, color.BlueAddTerm);

            Assert.IsFalse(color.RedMultTerm.HasValue);
            Assert.IsFalse(color.GreenMultTerm.HasValue);
            Assert.IsFalse(color.BlueMultTerm.HasValue);

            Assert.AreEqual(mem.Length, mem.Position, "Should reach end of the stream");
        }

        [Test]
        public void ReadColorTransformRGBFromBitsMultAddTest()
        {
            var mem = new MemoryStream();
            WriteBits(mem,
                "1", "1", "1001", "0.00001010", "1.11110110", "0.11100000", "1.11110111", "0.10000001", "0.00010000");
            var reader = new SwfStreamReader(mem);
            var color = reader.ReadColorTransformRGB();
            Assert.AreEqual(mem.Length, mem.Position, "Should reach end of the stream");
            Assert.AreEqual(10, color.RedMultTerm);
            Assert.AreEqual(-10, color.GreenMultTerm);
            Assert.AreEqual(224, color.BlueMultTerm);

            Assert.AreEqual(-9, color.RedAddTerm);
            Assert.AreEqual(129, color.GreenAddTerm);
            Assert.AreEqual(16, color.BlueAddTerm);

            Assert.AreEqual(mem.Length, mem.Position, "Should reach end of the stream");
        }

        [Test]
        public void ReadColorTransformRGBAFromBitsMultTest()
        {
            var mem = new MemoryStream();
            WriteBits(mem,
                "0", "1", "1001", "0.00001010", "0.11100000", "1.11110110", "0.00010001");
            var reader = new SwfStreamReader(mem);
            ColorTransformRGBA color;
            reader.ReadColorTransformRGBA(out color);
            Assert.AreEqual(mem.Length, mem.Position, "Should reach end of the stream");
            Assert.AreEqual(10, color.RedMultTerm);
            Assert.AreEqual(224, color.GreenMultTerm);
            Assert.AreEqual(-10, color.BlueMultTerm);
            Assert.AreEqual(17, color.AlphaMultTerm);

            Assert.IsFalse(color.RedAddTerm.HasValue);
            Assert.IsFalse(color.GreenAddTerm.HasValue);
            Assert.IsFalse(color.BlueAddTerm.HasValue);
            Assert.IsFalse(color.AlphaAddTerm.HasValue);

            Assert.AreEqual(mem.Length, mem.Position, "Should reach end of the stream");
        }

        [Test]
        public void ReadColorTransformRGBAFromBitsAddTest()
        {
            var mem = new MemoryStream();
            WriteBits(mem,
                "1", "0", "1001", "0.00001010", "1.11110110", "0.11100000", "0.11000000");
            var reader = new SwfStreamReader(mem);
            ColorTransformRGBA color;
            reader.ReadColorTransformRGBA(out color);
            Assert.AreEqual(mem.Length, mem.Position, "Should reach end of the stream");
            Assert.AreEqual(10, color.RedAddTerm);
            Assert.AreEqual(-10, color.GreenAddTerm);
            Assert.AreEqual(224, color.BlueAddTerm);
            Assert.AreEqual(192, color.AlphaAddTerm);

            Assert.IsFalse(color.RedMultTerm.HasValue);
            Assert.IsFalse(color.GreenMultTerm.HasValue);
            Assert.IsFalse(color.BlueMultTerm.HasValue);
            Assert.IsFalse(color.AlphaMultTerm.HasValue);

            Assert.AreEqual(mem.Length, mem.Position, "Should reach end of the stream");
        }

        [Test]
        public void ReadColorTransformRGBAFromBitsMultAddTest()
        {
            var mem = new MemoryStream();
            WriteBits(mem,
                "1", "1", "1001", "0.00001010", "1.11110110", "0.11100000", "0.10110000",
                                  "1.11110111", "0.10000001", "0.00010000", "0.00001111");
            var reader = new SwfStreamReader(mem);
            ColorTransformRGBA color;
            reader.ReadColorTransformRGBA(out color);
            Assert.AreEqual(mem.Length, mem.Position, "Should reach end of the stream");
            Assert.AreEqual(10, color.RedMultTerm);
            Assert.AreEqual(-10, color.GreenMultTerm);
            Assert.AreEqual(224, color.BlueMultTerm);
            Assert.AreEqual(176, color.AlphaMultTerm);

            Assert.AreEqual(-9, color.RedAddTerm);
            Assert.AreEqual(129, color.GreenAddTerm);
            Assert.AreEqual(16, color.BlueAddTerm);
            Assert.AreEqual(15, color.AlphaAddTerm);

            Assert.AreEqual(mem.Length, mem.Position, "Should reach end of the stream");
        }

        [Test]
        public void WriteColorTransformRGBFromBitsMultTest()
        {
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            var tranform = new ColorTransformRGB
            {
                RedMultTerm = 10,
                GreenMultTerm = 224,
                BlueMultTerm = -10,
                RedAddTerm = null,
                GreenAddTerm = null,
                BlueAddTerm = null
            };
            writer.WriteColorTransformRGB(ref tranform);
            CheckBits(mem,
                "0", "1", "1001", "0.00001010", "0.11100000", "1.11110110");
        }

        [Test]
        public void WriteColorTransformRGBFromBitsAddTest()
        {
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            var tranform = new ColorTransformRGB
            {
                RedMultTerm = null,
                GreenMultTerm = null,
                BlueMultTerm = null,
                RedAddTerm = 10,
                GreenAddTerm = -10,
                BlueAddTerm = 224
            };
            writer.WriteColorTransformRGB(ref tranform);
            CheckBits(mem,
                "1", "0", "1001", "0.00001010", "1.11110110", "0.11100000");
        }

        [Test]
        public void WriteColorTransformRGBFromBitsMultAddTest()
        {
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            var tranform = new ColorTransformRGB
            {
                RedMultTerm = 10,
                GreenMultTerm = -10,
                BlueMultTerm = 224,
                RedAddTerm = -9,
                GreenAddTerm = 129,
                BlueAddTerm = 16
            };
            writer.WriteColorTransformRGB(ref tranform);
            CheckBits(mem,
                "1", "1", "1001", "0.00001010", "1.11110110", "0.11100000", "1.11110111", "0.10000001", "0.00010000");
        }

        [Test]
        public void WriteColorTransformRGBAFromBitsMultTest()
        {
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            var tranform = new ColorTransformRGBA
            {
                RedMultTerm = 10,
                GreenMultTerm = 224,
                BlueMultTerm = -10,
                AlphaMultTerm = 17,
                RedAddTerm = null,
                GreenAddTerm = null,
                BlueAddTerm = null,
                AlphaAddTerm = null
            };
            writer.WriteColorTransformRGBA(ref tranform);
            CheckBits(mem,
                "0", "1", "1001", "0.00001010", "0.11100000", "1.11110110", "0.00010001");
        }

        [Test]
        public void WriteColorTransformRGBAFromBitsAddTest()
        {
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            var tranform = new ColorTransformRGBA
            {
                RedMultTerm = null,
                GreenMultTerm = null,
                BlueMultTerm = null,
                AlphaMultTerm = null,
                RedAddTerm = 10,
                GreenAddTerm = -10,
                BlueAddTerm = 224,
                AlphaAddTerm = 192
            };
            writer.WriteColorTransformRGBA(ref tranform);
            CheckBits(mem,
                "1", "0", "1001", "0.00001010", "1.11110110", "0.11100000", "0.11000000");
        }

        [Test]
        public void WriteColorTransformRGBAFromBitsMultAddTest()
        {
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            var tranform = new ColorTransformRGBA
            {
                RedMultTerm = 10,
                GreenMultTerm = -10,
                BlueMultTerm = 224,
                AlphaMultTerm = 176,
                RedAddTerm = -9,
                GreenAddTerm = 129,
                BlueAddTerm = 16,
                AlphaAddTerm = 15
            };
            writer.WriteColorTransformRGBA(ref tranform);
            CheckBits(mem,
                "1", "1", "1001", "0.00001010", "1.11110110", "0.11100000", "0.10110000",
                                  "1.11110111", "0.10000001", "0.00010000", "0.00001111");
        }

    }
}

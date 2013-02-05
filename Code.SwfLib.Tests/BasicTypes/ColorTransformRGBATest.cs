using System.IO;
using Code.SwfLib.Data;
using NUnit.Framework;

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

    }
}

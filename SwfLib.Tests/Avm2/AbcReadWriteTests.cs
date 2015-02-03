using System.IO;
using NUnit.Framework;
using SwfLib.Avm2.Data;

namespace SwfLib.Tests.Avm2 {
    [TestFixture]
    public class AbcReadWriteTests {

        [Test]
        public void ReadD64Test() {
            var mem = new MemoryStream();
            mem.WriteByte(0x77);
            mem.WriteByte(0xbe);
            mem.WriteByte(0x9f);
            mem.WriteByte(0x1a);
            mem.WriteByte(0x2f);
            mem.WriteByte(0xdd);
            mem.WriteByte(0x5e);
            mem.WriteByte(0x40);
            mem.Seek(0, SeekOrigin.Begin);
            var reader = new AbcDataReader(new SwfStreamReader(mem));
            var d = reader.ReadD64();
            Assert.AreEqual(123.456, d);
        }

        [Test]
        public void ReadWriteConstantPoolTest() {
            var pool = new AsConstantPoolInfo {
                Doubles = new[] { double.NaN, 1.2, 5.3 },
                Integers = new[] { 0, -123, 456 },
                Multinames = new AsMultinameInfo[0],
                NamespaceSets = new AsNamespaceSetInfo[0],
                Namespaces = new AsNamespaceInfo[0],
                Strings = new[] { "", "abc", "def" },
                UnsignedIntegers = new uint[] { 0, 1, uint.MaxValue }
            };
            var mem = new MemoryStream();
            var writer = new AbcDataWriter(new SwfStreamWriter(mem));
            writer.WriteConstantPool(pool);
            mem.Seek(0, SeekOrigin.Begin);
            var reader = new AbcDataReader(new SwfStreamReader(mem));
            var res = reader.ReadConstantPool();

            Assert.AreEqual(pool.Doubles.Length, res.Doubles.Length);
            for (var i = 0; i < pool.Doubles.Length; i++) {
                Assert.AreEqual(pool.Doubles[i], res.Doubles[i]);
            }

            Assert.AreEqual(pool.Integers.Length, res.Integers.Length);
            for (var i = 0; i < pool.Integers.Length; i++) {
                Assert.AreEqual(pool.Integers[i], res.Integers[i]);
            }

            //Assert.AreEqual(pool.Multinames.Length, res.Multinames.Length);
            //Assert.AreEqual(pool.NamespaceSets.Length, res.NamespaceSets.Length);
            //Assert.AreEqual(pool.Namespaces.Length, res.Namespaces.Length);

            Assert.AreEqual(pool.Strings.Length, res.Strings.Length);
            for (var i = 0; i < pool.Strings.Length; i++) {
                Assert.AreEqual(pool.Strings[i], res.Strings[i]);
            }

            Assert.AreEqual(pool.UnsignedIntegers.Length, res.UnsignedIntegers.Length);
            for (var i = 0; i < pool.UnsignedIntegers.Length; i++) {
                Assert.AreEqual(pool.UnsignedIntegers[i], res.UnsignedIntegers[i]);
            }
        }
    }
}

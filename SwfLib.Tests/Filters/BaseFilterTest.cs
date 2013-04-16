using System.IO;
using Code.SwfLib;
using Code.SwfLib.Filters;
using Code.SwfLib.Tests;
using NUnit.Framework;

namespace SwfLib.Tests.Filters {
    public abstract class BaseFilterTest : TestFixtureBase {

        protected T ReadFilter<T>(byte[] source) where T : BaseFilter {
            var mem = new MemoryStream();
            mem.Write(source, 0, source.Length);
            mem.Seek(0, SeekOrigin.Begin);
            var reader = new SwfStreamReader(mem);
            var filterReader = new FilterReader();
            var filter = filterReader.Read(reader);
            Assert.AreEqual(mem.Length, mem.Position, "Should reach end of stream");
            return (T)filter;
        }

        protected void WriteFilter<T>(T filter, byte[] etalon) where T : BaseFilter {
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            var actionWriter = new FilterWriter();
            actionWriter.Write(writer, filter);
            var buffer = mem.ToArray();
            Assert.AreEqual(etalon, buffer);
        }

    }
}

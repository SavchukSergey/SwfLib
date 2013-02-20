using System.IO;
using NUnit.Framework;

namespace Code.SwfLib.Tests.Gradients {
    public abstract class BaseGradientTest<T> {

        protected T ReadGradient(byte[] source) {
            var mem = new MemoryStream();
            mem.Write(source, 0, source.Length);
            mem.Seek(0, SeekOrigin.Begin);
            var reader = new SwfStreamReader(mem);
            var gradient = Read(reader);
            Assert.AreEqual(mem.Length, mem.Position, "Should reach end of stream");
            return gradient;
        }

        protected void WriteGradient(T gradient, byte[] etalon)  {
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            Write(writer, gradient);
            var buffer = mem.ToArray();
            Assert.AreEqual(etalon, buffer);
        }

        protected abstract T Read(ISwfStreamReader reader);
        protected abstract void Write(ISwfStreamWriter writer, T gradient);
    }
}

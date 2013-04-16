using System.IO;
using NUnit.Framework;
using SwfLib.Actions;

namespace SwfLib.Tests.Actions {
    public abstract class BaseActionTest {

        protected T ReadAction<T>(byte[] source) where T : ActionBase {
            var mem = new MemoryStream();
            mem.Write(source, 0, source.Length);
            mem.Seek(0, SeekOrigin.Begin);
            var reader = new SwfStreamReader(mem);
            var actionReader = new ActionReader(reader);
            var action = actionReader.ReadAction();
            Assert.AreEqual(mem.Length, mem.Position, "Should reach end of stream");
            return (T)action;
        }

        protected void WriteAction<T>(T action, byte[] etalon) where T : ActionBase {
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            var actionWriter = new ActionWriter(writer);
            actionWriter.WriteAction(action);
            var buffer = mem.ToArray();
            Assert.AreEqual(etalon, buffer);
        }
    }
}

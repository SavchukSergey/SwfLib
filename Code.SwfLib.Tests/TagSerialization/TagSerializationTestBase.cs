using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Code.SwfLib.Tags;
using NUnit.Framework;

namespace Code.SwfLib.Tests.TagSerialization {
    public class TagSerializationTestBase : TestFixtureBase {

        private const int VERSION = 10;

        protected void SerializeAndCheck(SwfTagBase tag, params string[] bits) {
            var stream = SerializeTag(tag);
            CheckBits(stream, bits);
            Assert.AreEqual(stream.Length, stream.Position, "Should reach end of the stream");
        }

        protected T DeserializeTag<T>(params string[] bits) where T : SwfTagBase {
            var tag = DeserializeTag(bits);
            Assert.IsAssignableFrom(typeof(T), tag);
            return (T)tag;
        }

        protected SwfTagBase DeserializeTag(params string[] bits) {
            var mem = new MemoryStream();
            WriteBits(mem, bits);
            mem.Seek(0, SeekOrigin.Begin);
            var streamReader = new SwfStreamReader(mem);
            var file = new SwfFile();
            file.FileInfo.Version = VERSION;
            var tagReader = new SwfTagReader(file);
            var tag = tagReader.ReadTag(streamReader);
            Assert.IsNotNull(tag);
            return tag;
        }

        protected Stream SerializeTag(SwfTagBase tag) {
            var file = new SwfFile();
            file.FileInfo.Version = 10;

            var mem = new MemoryStream();
            var serializer = new SwfTagSerializer(file);
            var tagData = serializer.GetTagData(tag);
            var writer = new SwfStreamWriter(mem);
            writer.WriteTagData(tagData);
            mem.Seek(0, SeekOrigin.Begin);
            return mem;
        }
    }
}

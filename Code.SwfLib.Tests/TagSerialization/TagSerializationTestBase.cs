using System.IO;
using Code.SwfLib.Tags;
using NUnit.Framework;

namespace Code.SwfLib.Tests.TagSerialization {
    public class TagSerializationTestBase : TestFixtureBase {

        private const int VERSION = 10;

        protected SwfTagBase DeserializeTag(params string[] bits) {
            var mem = new MemoryStream();
            WriteBits(mem, bits);
            mem.Seek(0, SeekOrigin.Begin);
            var streamReader = new SwfStreamReader(mem);
            var file = new SwfFile();
            file.FileInfo.Version = VERSION;
            var tagReader = new SwfTagDeserializer(file);
            var tagData = streamReader.ReadTagData();
            var tag = tagReader.ReadTag(tagData);
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

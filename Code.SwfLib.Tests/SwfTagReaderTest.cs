using System;
using Code.SwfLib.Data;
using Code.SwfLib.Tags;
using Code.SwfLib.Tags.ControlTags;
using NUnit.Framework;

namespace Code.SwfLib.Tests {
    [TestFixture]
    public class SwfTagReaderTest {


        [Test]
        public void ReadSetBackgroundColorTagTest() {
            var tag = ReadTag<SetBackgroundColorTag>("SetBackgroundColorTag.bin");
            Assert.AreEqual(new SwfRGB(0x0a, 0xc0, 0x80), tag.Color);
        }

        private T ReadTag<T>(string resourceName) where T : SwfTagBase {
            var source = GetType().Assembly.GetManifestResourceStream("Code.SwfLib.Tests.Resources.SwfTagReader." + resourceName);
            if (source == null) throw new Exception("Source stream not found");
            var reader = new SwfStreamReader(source);
            var tagData = reader.ReadTagData();
            var file = new SwfFile { FileInfo = { Version = 9 } };
            var ser = new SwfTagDeserializer(file);
            var tag = ser.ReadTag(tagData);
            Assert.IsNotNull(tag);
            Assert.IsAssignableFrom(typeof(T), tag);
            return (T)tag;
        }

    }
}

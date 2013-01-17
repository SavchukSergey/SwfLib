using System;
using Code.SwfLib.Data;
using Code.SwfLib.Tags;
using Code.SwfLib.Tags.ControlTags;
using Code.SwfLib.Tags.DisplayListTags;
using NUnit.Framework;

namespace Code.SwfLib.Tests {
    [TestFixture]
    public class SwfTagReaderTest {


        [Test]
        public void ReadMetadataTagTest() {
            var file = new SwfFile();
            file.FileInfo.Version = 9;
            MetadataTag tag = ReadTag("MetadataTag.bin", data => new SwfTagReader(file).ReadMetadataTag(data));
            Assert.IsNotNull(tag);
            Assert.IsAssignableFrom(typeof(MetadataTag), tag);
            Assert.AreEqual("Test Meta Data", tag.Metadata);
        }

        [Test]
        public void ReadSetBackgroundColorTagTest() {
            var file = new SwfFile();
            file.FileInfo.Version = 9;
            SetBackgroundColorTag tag = ReadTag("SetBackgroundColorTag.bin", data => new SwfTagReader(file).ReadSetBackgroundColorTag(data));
            Assert.IsNotNull(tag);
            Assert.IsAssignableFrom(typeof(SetBackgroundColorTag), tag);
            Assert.AreEqual(new SwfRGB(0x0a, 0xc0, 0x80), tag.Color);
        }

        [Test]
        public void ReadShowFrameTagTest() {
            var file = new SwfFile();
            file.FileInfo.Version = 9;
            ShowFrameTag tag = ReadTag("ShowFrameTag.bin", data => new SwfTagReader(file).ReadShowFrameTag(data));
            Assert.IsNotNull(tag);
            Assert.IsAssignableFrom(typeof(ShowFrameTag), tag);
        }

        private T ReadTag<T>(string resourceName, Func<SwfTagData, T> readerFunction) where T : SwfTagBase {
            var source = GetType().Assembly.GetManifestResourceStream("Code.SwfLib.Tests.Resources.SwfTagReader." + resourceName);
            if (source == null) throw new Exception("Source stream not found");
            var reader = new SwfStreamReader(source);
            var tagData = reader.ReadTagData();
            return readerFunction(tagData);
        }

        private SwfTagBase ReadTagBase(string resourceName) {
            var source = GetType().Assembly.GetManifestResourceStream("Code.SwfLib.Tests.Resources.SwfTagReader." + resourceName);
            if (source == null) throw new Exception("Source stream not found");
            var file = new SwfFile();
            file.FileInfo.Version = 10;
            var reader = new SwfStreamReader(source);
            var tagReader = new SwfTagReader(file);
            return tagReader.ReadTag(reader);
        }


    }
}

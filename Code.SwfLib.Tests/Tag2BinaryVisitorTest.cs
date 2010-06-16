using System;
using System.IO;
using System.Linq;
using Code.SwfLib.Data;
using Code.SwfLib.Tags;
using Code.SwfLib.Tags.BitmapTags;
using Code.SwfLib.Tags.ControlTags;
using NUnit.Framework;

namespace Code.SwfLib.Tests {
    [TestFixture]
    public class Tag2BinaryVisitorTest : TestFixtureBase {

        [Test]
        public void DefineBitsJPEG2Test()
        {
            var tag = new DefineBitsJPEG2Tag();
            tag.ObjectID = 1;
            tag.ImageData = GetEmbeddedResourceData("DefineBitsJPEG2.jpg");
            var visitor = new Tag2BinaryVisitor();
            var res = visitor.GetTagData(tag);
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            writer.WriteTagData(res);

            var etalon = GetTagBinariesFromSwfResource("DefineBitsJPEG2.swf")
                .FirstOrDefault(item => item.Type == SwfTagType.DefineBitsJPEG2);
            if (etalon.Binary == null) throw new InvalidOperationException("Couldn't find etalon tag");

            AssertExt.AreEqual(etalon.Binary, mem.ToArray(), "Checking DefineBitsJPEG2");
        }

        [Test]
        public void EndTagTest() {
            var tag = new EndTag();
            Compare(tag, "EndTag.bin");
        }

        [Test]
        public void FileAttributesTest() {
            var tag = new FileAttributesTag {
                Attributes = SwfFileAttributes.HasMetadata | SwfFileAttributes.UseNetwork
            };
            Compare(tag, "FileAttributesTag.bin");
        }

        [Test]
        public void MetadataTagTest() {
            var tag = new MetadataTag { Metadata = "Test Meta Data" };
            Compare(tag, "MetadataTag.bin");
        }

        [Test]
        public void SetBackgroundColorTagTest()
        {
            var tag = new SetBackgroundColorTag {Color = new SwfRGB(0x0a, 0xc0, 0x80)};
            Compare(tag, "SetBackgroundColorTag.bin");
        }

        [Test]
        public void ShowFrameTagTest() {
            var tag = new ShowFrameTag();
            Compare(tag, "ShowFrameTag.bin");
        }

        private void Compare(SwfTagBase tag, string resourceName) {
            var visitor = new Tag2BinaryVisitor();
            var res = tag.AcceptVistor(visitor);
            Assert.IsNotNull(res, "Should return a value");
            Assert.IsTrue(res is SwfTagData, "Should return a value of SwfTagData type");
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            writer.WriteTagData((SwfTagData)res);
            mem.Seek(0, SeekOrigin.Begin);
            var etalonStream = GetType().Assembly.GetManifestResourceStream("Code.SwfLib.Tests.Resources.Tag2Binary." + resourceName);
            if (etalonStream == null) throw new Exception("Etalong stream not found");

            byte[] etalon = new byte[etalonStream.Length];
            etalonStream.Read(etalon, 0, etalon.Length);
            AssertExt.AreEqual(etalon, mem.ToArray(), "Checking with etalon data");
        }

        protected override string EmbeddedResourceFolder {
            get {
                return "Tag2Binary";
            }
        }
    }
}

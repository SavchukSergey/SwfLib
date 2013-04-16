using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using SwfLib.Tags;
using SwfLib.Tags.BitmapTags;

namespace SwfLib.Tests.ExternalEtalonTests {
    [TestFixture]
    public class Tag2BinaryVisitorTest : ExternalEtalonTestFixtureBase {

        [Test]
        public void DefineBitsJPEG2Test() {
            var file = new SwfFile();
            file.FileInfo.Version = 10;

            var tag = new DefineBitsJPEG2Tag();
            tag.CharacterID = 1;
            tag.ImageData = GetEmbeddedResourceData("DefineBitsJPEG2.jpg");
            var visitor = new SwfTagSerializer(file);
            var res = visitor.GetTagData(tag);
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            writer.WriteTagData(res);

            var etalon = GetTagFullBinariesFromSwfResource("DefineBitsJPEG2.swf")
                .FirstOrDefault(item => item.Type == SwfTagType.DefineBitsJPEG2);
            if (etalon.Binary == null) throw new InvalidOperationException("Couldn't find etalon tag");

            AssertExt.AreEqual(etalon.Binary, mem.ToArray(), "Checking DefineBitsJPEG2");
        }

        protected override string EmbeddedResourceFolder {
            get {
                return "Tag2Binary";
            }
        }
    }
}
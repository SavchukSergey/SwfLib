using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Code.SwfLib.SwfMill.Tests.Utils;
using Code.SwfLib.Tags;
using NUnit.Framework;

namespace Code.SwfLib.SwfMill.Tests {
    [TestFixture]
    public class SwfMillFacadeTest {

        [Test]
        [Ignore]
        public void SwfToXmlTest() {
            var source = GetType().Assembly.GetManifestResourceStream("Code.SwfLib.SwfMill.Tests.FlashTest.swf");
            var file = SwfFile.ReadFrom(source);
            var doc = new SwfMillFacade().ConvertToXml(file);
            doc.Declaration = new XDeclaration("1", "utf-8", "yes");
            var res = doc.ToString();
            using (StreamWriter writer = new StreamWriter(@"d:\Sergey\test.xml", false, Encoding.UTF8)) {
                doc.Save(writer);
            }
        }

        [Test]
        [Ignore]
        public void ReadHugeXml() {
            var sourceStream = OpenEmbeddedResource("HugeSwfXml.xml");
            var xml = XDocument.Load(new StreamReader(sourceStream));
            var file = new SwfMillFacade().ReadFromXml(xml);
            var mem = new MemoryStream();
            file.WriteTo(mem);
        }

        [Test]
        [Ignore]
        public void ReadHugeXml2() {
            var sourceStream = OpenEmbeddedResource("HugeSwfXml2.xml");
            var xml = XDocument.Load(new StreamReader(sourceStream));
            var file = new SwfMillFacade().ReadFromXml(xml);
            var mem = new MemoryStream();
            file.WriteTo(mem);
        }

        [Test]
        [Ignore]
        public void Sample2Test() {
            const string source = @"D:\Sergey\swf\first.swf";
            var secondTags = IterateTags(Cycle(source)).ToList();

            var firstFile = File.Open(source, FileMode.Open);
            var firstTags = IterateTags(firstFile).ToList();

            var deserializer = new SwfTagDeserializer(new SwfFile { FileInfo = { Version = 10 } });
            for (var i = 0; i < firstTags.Count; i++) {
                var firstTag = firstTags[i];
                var secondTag = secondTags[i];
                var firstType = firstTag.Type;
                var secondType = secondTag.Type;
                if (firstType == SwfTagType.DefineSprite) continue; //For now
                if (firstType != secondType) throw new InvalidOperationException();
                var dual = new DualSwfStreamReader(new MemoryStream(firstTag.Data), new MemoryStream(secondTag.Data));
                deserializer.ReadTag(firstType, dual);
            }
        }

        public Stream Cycle(string path) {
            var facade = new SwfMillFacade();
            using (var stream = File.Open(path, FileMode.Open)) {
                var xml = facade.ConvertToXml(SwfFile.ReadFrom(stream));
                var newFile = facade.ReadFromXml(xml);
                var mem = new MemoryStream();
                newFile.WriteTo(mem);
                mem.Seek(0, SeekOrigin.Begin);
                return mem;
            }
        }

        protected IEnumerable<SwfTagData> IterateTags(Stream stream) {
            var file = new SwfFile();
            var reader = new SwfStreamReader(stream);
            file.FileInfo = reader.ReadSwfFileInfo();
            reader = GetSwfStreamReader(file.FileInfo, stream);
            file.Header = reader.ReadSwfHeader();

            while (!reader.IsEOF) {
                var tagData = reader.ReadTagData();

                yield return tagData;
            }
        }


        protected static SwfStreamReader GetSwfStreamReader(SwfFileInfo info, Stream stream) {
            switch (info.Format) {
                case "CWS":
                    var mem = new MemoryStream();
                    SwfZip.Decompress(stream, mem);
                    return new SwfStreamReader(mem);
                case "FWS":
                    return new SwfStreamReader(stream);
                default:
                    throw new NotSupportedException("Illegal file format");
            }
        }

        private static Stream OpenEmbeddedResource(string name) {
            return typeof(SwfMillFacadeTest).Assembly.GetManifestResourceStream("Code.SwfLib.SwfMill.Tests.Resources." + name);
        }

    }
}
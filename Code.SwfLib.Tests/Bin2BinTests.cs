using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Code.SwfLib.Tags;
using Code.SwfLib.Tags.FontTags;
using NUnit.Framework;

namespace Code.SwfLib.Tests {
    [TestFixture]
    public class Bin2BinTests {


        [Test]
        public void DefineFont3Test() {
            Bin2BinBulkTest<DefineFont3Tag>("Code.SwfLib.Tests.Resources.Bin2Bin.DefineFont3Tag");
        }

        protected void Bin2BinBulkTest<T>(string resourceFolder) where T : SwfTagBase, new() {
            var resources = GetType().Assembly.GetManifestResourceNames()
                .Where(item => item.StartsWith(resourceFolder))
                .OrderBy(item => item)
                .ToList();
            foreach (var resourceName in resources) {
               Console.WriteLine("Checking resource name: {0}", resourceName);
                Bin2BinTest<T>(resourceName);
            }
        }

        protected void Bin2BinTest<T>(string resourceName) where T : SwfTagBase, new() {
            var stream = GetType().Assembly.GetManifestResourceStream(resourceName);
            var bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);
            var tag = DeserializeTag<T>(bytes);
            var newBytes = SerializeTag(tag);
            int min = bytes.Length < newBytes.Length ? bytes.Length : newBytes.Length;
            for (var i = 0; i < min; i++) {
                Assert.AreEqual(bytes[i], newBytes[i], string.Format("Checking resource {0}, index: {1}, original: {2}, actual: {3}",
                    resourceName,
                    i,
                    bytes[i],
                    newBytes[0]));
            }
            Assert.AreEqual(bytes.Length, newBytes.Length, "Checking length");
        }

        protected byte[] SerializeTag(SwfTagBase tag) {
            var file = new SwfFile();
            file.FileInfo.Version = 10;
            var tagData = new SwfTagSerializer(file).GetTagData(tag);
            return tagData.Data;
        }

        protected T DeserializeTag<T>(byte[] bytes) where T : SwfTagBase, new() {
            var tag = new T();
            var tagData = new SwfTagData {
                Type = tag.TagType,
                Data = bytes
            };
            //TODO: There is no need in second instance of tag
            return (T) tag.AcceptVistor(new SwfTagDeserializer { TagData = tagData });
        }

    }
}

using System;
using System.Linq;
using Code.SwfLib.Tags;
using Code.SwfLib.Tags.FontTags;
using NUnit.Framework;

namespace Code.SwfLib.Tests {
    [TestFixture]
    public class Bin2BinTests {

        [Test]
        public void DefineFont3TagTest() {
            Bin2BinBulkTest<DefineFont3Tag>("Code.SwfLib.Tests.Resources.Bin2Bin.DefineFont3Tag");
        }

        [Test]
        public void DefineFontAlignZonesTagTest() {
            Bin2BinBulkTest<DefineFontAlignZonesTag>("Code.SwfLib.Tests.Resources.Bin2Bin.DefineFontAlignZonesTag", file => {
                var resources = GetResourcesFromFolder("Code.SwfLib.Tests.Resources.Bin2Bin.DefineFont3Tag");
                foreach (var resourceName in resources) {
                    var tag = DeserializeTag<DefineFont3Tag>(file, resourceName);
                    file.Tags.Add(tag);
                }
            });
        }

        protected void Bin2BinBulkTest<T>(string resourceFolder) where T : SwfTagBase, new() {
            Bin2BinBulkTest<T>(resourceFolder, file => { });
        }

        protected void Bin2BinBulkTest<T>(string resourceFolder, Action<SwfFile> appendTagsCallback) where T : SwfTagBase, new() {
            var resources = GetResourcesFromFolder(resourceFolder);
            foreach (var resourceName in resources) {
                Console.WriteLine("Checking resource name: {0}", resourceName);
                Bin2BinTest<T>(resourceName, appendTagsCallback);
            }
        }

        protected void Bin2BinTest<T>(string resourceName) where T : SwfTagBase, new() {
            Bin2BinTest<T>(resourceName, file => {
            });
        }

        protected void Bin2BinTest<T>(string resourceName, Action<SwfFile> appendTagsCallback) where T : SwfTagBase, new() {
            var stream = GetType().Assembly.GetManifestResourceStream(resourceName);
            var bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);
            var file = new SwfFile();
            file.FileInfo.Version = 10;

            appendTagsCallback(file);

            var tag = DeserializeTag<T>(file, resourceName);
            var newBytes = SerializeTag(file, tag);
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

        protected byte[] SerializeTag(SwfFile file, SwfTagBase tag) {
            var tagData = new SwfTagSerializer(file).GetTagData(tag);
            return tagData.Data;
        }

        protected T DeserializeTag<T>(SwfFile file, string resourceName) where T : SwfTagBase, new() {
            using (var stream = GetType().Assembly.GetManifestResourceStream(resourceName)) {
                var bytes = new byte[stream.Length];
                stream.Read(bytes, 0, bytes.Length);
                var tag = DeserializeTag<T>(file, bytes);
                return tag;
            }
        }

        protected T DeserializeTag<T>(SwfFile file, byte[] bytes) where T : SwfTagBase, new() {
            var tag = new T();
            var tagData = new SwfTagData {
                Type = tag.TagType,
                Data = bytes
            };
            //TODO: There is no need in second instance of tag
            return (T)tag.AcceptVistor(new SwfTagDeserializer { TagData = tagData, SwfFile = file });
        }

        protected string[] GetResourcesFromFolder(string resourceFolder) {
            return GetType().Assembly.GetManifestResourceNames()
                            .Where(item => item.StartsWith(resourceFolder))
                            .OrderBy(item => item)
                            .ToArray();
        }
    }
}

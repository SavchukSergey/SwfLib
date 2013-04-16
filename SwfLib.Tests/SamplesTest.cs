using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Code.SwfLib;
using Code.SwfLib.Tests.Samples;
using NUnit.Framework;
using SwfLib.Tags;
using SwfLib.Tests.Asserts.Utils;

namespace SwfLib.Tests {
    [TestFixture]
    public class SamplesTest : BaseSampleTest {

        [Test]
        [Ignore]
        public void Sample1Test() {
            const string path = "Sample - 1.swf";
            var file = ReadSwfFile(path);
            var mem = new MemoryStream();
            file.WriteTo(mem);
            mem.Seek(0, SeekOrigin.Begin);

            var firstTags = IterateTags(OpenEmbeddedResource(path)).ToList();
            var secondTags = IterateTags(mem).ToList();

            var deserializer = new SwfTagDeserializer(file);
            for (var i = 0; i < firstTags.Count; i++) {
                var firstTag = firstTags[i];
                var secondTag = secondTags[i];
                var firstType = firstTag.Type;
                var secondType = secondTag.Type;
                if (firstType != secondType) throw new InvalidOperationException();
                //if (firstType == SwfTagType.DefineSprite) continue; //For now
                var dual = new DualSwfStreamReader(new MemoryStream(firstTag.Data), new MemoryStream(secondTag.Data));
                //var dual = new SwfStreamReader(new MemoryStream(firstTag.Data));
                deserializer.ReadTag(firstType, dual);
            }
        }

      
        [Ignore]
        [Test]
        public void Test() {
            const string source = @"D:\Sergey\swf\";
            var first = Path.Combine(source, "first.swf");
            var second = Path.Combine(source, "second.swf");
            var firstTags = GetTagsMap(IterateTags(first));
            var secondTags = GetTagsMap(IterateTags(second));

            foreach (var tag in firstTags.ToList()) {
                if (secondTags.ContainsKey(tag.Key)) {
                    firstTags.Remove(tag.Key);
                    secondTags.Remove(tag.Key);
                }
            }
            foreach (var tag in secondTags.ToList()) {
                if (firstTags.ContainsKey(tag.Key)) {
                    firstTags.Remove(tag.Key);
                    secondTags.Remove(tag.Key);
                }
            }

            foreach (var tag in firstTags) {
                if (tag.Value != null) {
                    SaveTag(tag.Value, Path.Combine(source, "first"));
                    ReadTag(tag.Value);
                }
            }
            foreach (var tag in secondTags) {
                if (tag.Value != null) {
                    SaveTag(tag.Value, Path.Combine(source, "second"));
                    ReadTag(tag.Value);
                }
            }
        }

        protected IDictionary<string, SwfTagData> GetTagsMap(IEnumerable<SwfTagData> tags) {
            return tags
                .Select(item => new { Hash = item.Type.ToString() + " " + GetTagHash(item), Tag = item })
                .GroupBy(item => item.Hash)
                .ToDictionary(item => item.Key, item => item.First().Tag);
        }

        protected void ReadTag(SwfTagData tagData) {
            try {
                var tagReader = new SwfTagDeserializer(new SwfFile()).ReadTag(tagData);
            } catch {

            }
        }

        [Test]
        [Ignore]
        public void GrabAllSwfsFromMachine() {
            var source = @"D:\Sergey\Samples\";
            var target = Path.Combine(source, "tags");
            if (!Directory.Exists(target)) {
                Directory.CreateDirectory(target);
            }
            var dirInfo = new DirectoryInfo(source);
            Grab(dirInfo, target);
        }

        public void Grab(DirectoryInfo source, string target) {
            foreach (var subdir in source.GetDirectories()) {
                Grab(subdir, target);
            }
            foreach (var f in source.GetFiles("*.swf")) {
                try {
                    var tags = IterateTags(f.FullName);
                    foreach (var tagData in tags) {
                        SaveTag(tagData, target);
                    }

                } catch {
                    Console.WriteLine("Couldn't grab {0}", f.FullName);
                }
            }
        }

        protected void SaveTag(SwfTagData tagData, string root) {
            var tagDir = Path.Combine(root, string.Format("{0}", tagData.Type));
            if (!Directory.Exists(tagDir)) {
                Directory.CreateDirectory(tagDir);
            }
            var binFilepath = Path.Combine(tagDir, GetFileName(tagData));
            using (var bin = File.Open(binFilepath, FileMode.Create)) {
                bin.Write(tagData.Data, 0, tagData.Data.Length);
                bin.Flush();
            }
        }

        protected IEnumerable<SwfTagData> IterateTags(string path) {
            var stream = File.Open(path, FileMode.Open);
            return IterateTags(stream);
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

        protected string GetFileName(SwfTagData tagData) {
            return string.Format("{0}.bin", GetTagHash(tagData));
        }

    }
}

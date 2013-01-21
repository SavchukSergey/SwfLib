using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using Code.SwfLib.Tags;
using NUnit.Framework;

namespace Code.SwfLib.Tests {
    [TestFixture]
    public class SamplesTest {

        private MD5 _md5 = MD5.Create();

        [Test]
        [Ignore]
        public void GrabAllSwfsFromMachine() {
            var source = @"D:\dev\Code.SwfLib\Code.SwfLib.SwfMill\bin\Debug\";
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
                    using (var stream = File.Open(f.FullName, FileMode.Open)) {
                        var file = new SwfFile();
                        var reader = new SwfStreamReader(stream);
                        file.FileInfo = reader.ReadSwfFileInfo();
                        reader = GetSWFStreamReader(file.FileInfo, stream);
                        file.Header = reader.ReadSwfHeader();

                        while (!reader.IsEOF) {
                            var tagData = reader.ReadTagData();

                            var tagDir = Path.Combine(target, string.Format("{0}", tagData.Type));
                            if (!Directory.Exists(tagDir)) {
                                Directory.CreateDirectory(tagDir);
                            }
                            var binFilepath = Path.Combine(tagDir, GetFileName(tagData));
                            using (var bin = File.Open(binFilepath, FileMode.Create)) {
                                bin.Write(tagData.Data, 0, tagData.Data.Length);
                                bin.Flush();
                            }
                        }

                    }
                } catch {
                    Console.WriteLine("Couldn't grab {0}", f.FullName);
                }
            }
        }

        protected string GetFileName(SwfTagData tagData) {
            var hash = _md5.ComputeHash(tagData.Data);
            return string.Format("{0}.bin", ToHex(hash));
        }

        protected string ToHex(byte[] data) {
            const string hex = "0123456789abcdef";
            return data.Aggregate("", (seed, bt) => seed + hex[bt >> 4] + hex[bt & 0x0f]);
        }

        protected static SwfStreamReader GetSWFStreamReader(SwfFileInfo info, Stream stream) {
            switch (info.Format) {
                case "CWS":
                    MemoryStream mem = new MemoryStream();
                    SwfZip.Decompress(stream, mem);
                    mem.Seek(8, SeekOrigin.Begin);
                    return new SwfStreamReader(mem);
                case "FWS":
                    return new SwfStreamReader(stream);
                default:
                    throw new NotSupportedException("Illegal file format");
            }
        }
    }
}

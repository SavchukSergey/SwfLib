using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using Code.SwfLib.Tags;

namespace Code.SwfLib.Tests.Samples {
    public abstract class BaseSampleTest : TestFixtureBase {

        private readonly MD5 _md5 = MD5.Create();

        protected T ReadTag<T>(string resourceName, string tagHash) where T : SwfTagBase {
            using (var stream = OpenEmbeddedResource(resourceName)) {
                var file = new SwfFile();
                var reader = new SwfStreamReader(stream);
                file.FileInfo = reader.ReadSwfFileInfo();
                reader = GetSwfStreamReader(file.FileInfo, stream);
                file.Header = reader.ReadSwfHeader();

                while (!reader.IsEOF) {
                    var tagData = reader.ReadTagData();

                    var hash = GetTagHash(tagData);
                    if (tagHash == hash) {
                        var tagReader = new SwfTagDeserializer(file);
                        //using (var dump = File.Open(@"D:\temp\1.bin", FileMode.Create)) {
                        //    dump.Write(tagData.Data, 0, tagData.Data.Length);
                        //    dump.Flush();
                        //}
                        return tagReader.ReadTag<T>(tagData);
                    }
                }
            }
            return null;
        }

        protected SwfTagData ReadTagData(string resourceName, string tagHash) {
            using (var stream = OpenEmbeddedResource(resourceName)) {
                var file = new SwfFile();
                var reader = new SwfStreamReader(stream);
                file.FileInfo = reader.ReadSwfFileInfo();
                reader = GetSwfStreamReader(file.FileInfo, stream);
                file.Header = reader.ReadSwfHeader();

                while (!reader.IsEOF) {
                    var tagData = reader.ReadTagData();

                    var hash = GetTagHash(tagData);
                    if (tagHash == hash) return tagData;
                }
            }
            return null;
        }

        protected static SwfStreamReader GetSwfStreamReader(SwfFileInfo info, Stream stream) {
            switch (info.Format) {
                case "CWS":
                    var mem = new MemoryStream();
                    SwfZip.Decompress(stream, mem);
                    mem.Seek(8, SeekOrigin.Begin);
                    return new SwfStreamReader(mem);
                case "FWS":
                    return new SwfStreamReader(stream);
                default:
                    throw new NotSupportedException("Illegal file format");
            }
        }

        protected string GetTagHash(SwfTagData tagData) {
            var hash = _md5.ComputeHash(tagData.Data);
            return ToHex(hash);
        }

        protected string GetTagHash(SwfTagBase tag) {
            var file = new SwfFile();
            file.FileInfo.Version = 10;
            var ser = new SwfTagSerializer(file);
            var tagData = ser.GetTagData(tag);
            return GetTagHash(tagData);
        }

        protected string ToHex(byte[] data) {
            const string hex = "0123456789abcdef";
            return data.Aggregate("", (seed, bt) => seed + hex[bt >> 4] + hex[bt & 0x0f]);
        }

        protected override string EmbeddedResourceFolder {
            get {
                return base.EmbeddedResourceFolder + "Samples";
            }
        }
    }
}

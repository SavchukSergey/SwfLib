using System;
using System.Collections.Generic;
using System.IO;
using Code.SwfLib.Tags;

namespace Code.SwfLib.Tests {
    public class TestFixtureBase {

        protected void WriteBits(Stream stream, params string[] bits) {
            var writer = new SwfStreamWriter(stream);
            foreach (var bitString in bits) {
                foreach (var ch in bitString) {
                    switch (ch) {
                        case '0':
                            writer.WriteBit(false);
                            break;
                        case '1':
                            writer.WriteBit(true);
                            break;
                        case '.':
                            break;
                        default:
                            throw new InvalidOperationException("Invalid character " + ch);
                    }
                }
            }
            writer.FlushBits();
            stream.Seek(0, SeekOrigin.Begin);
        }

        protected struct TagBinaryInfo {
            public SwfTagType Type;

            public byte[] Binary;

        }

        protected IEnumerable<TagBinaryInfo> GetTagFullBinariesFromSwfResource(string resourceName) {
            var file = new SwfFile();
            var stream = OpenEmbeddedResource(resourceName);
            SwfStreamReader reader = new SwfStreamReader(stream);
            file.FileInfo = reader.ReadSwfFileInfo();
            stream = DecompressIfNeeded(file.FileInfo, stream);
            stream.Seek(8, SeekOrigin.Begin);
            reader = new SwfStreamReader(stream);
            file.Header = reader.ReadSwfHeader();

            while (stream.Position < stream.Length) {
                var position = stream.Position;

                ushort typeAndSize = reader.ReadUInt16();
                SwfTagType type = (SwfTagType)(typeAndSize >> 6);
                int shortSize = typeAndSize & 0x3f;
                int size = shortSize < 0x3f ? shortSize : reader.ReadInt32();

                var length = stream.Position - position + size;

                stream.Seek(position, SeekOrigin.Begin);
                yield return new TagBinaryInfo { Type = type, Binary = reader.ReadBytes((int)length) };
            }
        }

        protected IEnumerable<SwfTagData> GetTagBinariesFromSwfResource(string resourceName) {
            var file = new SwfFile();
            var stream = OpenEmbeddedResource(resourceName);
            SwfStreamReader reader = new SwfStreamReader(stream);
            file.FileInfo = reader.ReadSwfFileInfo();
            stream = DecompressIfNeeded(file.FileInfo, stream);
            stream.Seek(8, SeekOrigin.Begin);
            reader = new SwfStreamReader(stream);
            file.Header = reader.ReadSwfHeader();

            while (stream.Position < stream.Length) {
                ushort typeAndSize = reader.ReadUInt16();
                SwfTagType type = (SwfTagType)(typeAndSize >> 6);
                int shortSize = typeAndSize & 0x3f;
                int size = shortSize < 0x3f ? shortSize : reader.ReadInt32();
                yield return new SwfTagData { Type = type, Data = reader.ReadBytes(size) };
            }
        }

        private static Stream DecompressIfNeeded(SwfFileInfo info, Stream stream) {
            switch (info.Format) {
                case "CWS":
                    MemoryStream mem = new MemoryStream();
                    SwfZip.Decompress(stream, mem);
                    mem.Seek(8, SeekOrigin.Begin);
                    return mem;
                case "FWS":
                    return stream;
                default:
                    throw new NotSupportedException("Illegal file format");
            }
        }

        protected Stream OpenEmbeddedResource(string resourceName) {
            var fullPath = "Code.SwfLib.Tests.Resources.";
            if (!string.IsNullOrEmpty(EmbeddedResourceFolder)) fullPath += EmbeddedResourceFolder + ".";
            fullPath += resourceName;
            var stream = GetType().Assembly.GetManifestResourceStream(fullPath);
            if (stream == null)
                throw new InvalidOperationException("Embedded resource " + resourceName + " is not found");
            return stream;
        }

        protected byte[] GetEmbeddedResourceData(string resourceName) {
            using (var stream = OpenEmbeddedResource(resourceName)) {
                byte[] data = new byte[stream.Length];
                stream.Read(data, 0, data.Length);
                return data;
            }
        }

        protected virtual string EmbeddedResourceFolder { get { return ""; } }
    }
}
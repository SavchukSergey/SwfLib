using System;
using System.Collections.Generic;
using System.IO;
using Code.SwfLib.Data;
using Code.SwfLib.Tags;

namespace Code.SwfLib {
    public class SwfFile {

        public SwfFileInfo FileInfo;

        public SwfHeader Header;

        public readonly IList<SwfTagBase> Tags = new List<SwfTagBase>();

        public static SwfFile ReadFrom(Stream stream) {
            var file = new SwfFile();
            var reader = new SwfStreamReader(stream);
            file.FileInfo = reader.ReadSwfFileInfo();
            reader = GetSwfStreamReader(file.FileInfo, stream);
            file.Header = reader.ReadSwfHeader();
            ReadTags(file, reader);
            return file;
        }

        public void WriteTo(Stream stream) {
            WriteTo(stream, FileInfo.Format == "CWS");
        }

        public void WriteTo(Stream stream, bool compress) {
            var outputWriter = new SwfStreamWriter(stream);

            if (compress) {
                var res = new MemoryStream();
                WriteTo(res, false);
                res.Seek(8, SeekOrigin.Begin);

                var compressed = new MemoryStream();
                SwfZip.Compress(res, compressed);

                outputWriter.WriteSwfFileInfo(new SwfFileInfo {
                    Format = "CWS",
                    FileLength = (uint)(res.Length),
                    Version = FileInfo.Version
                });

                compressed.WriteTo(outputWriter.BaseStream);
            } else {
                var mem = new MemoryStream();
                var writer = new SwfStreamWriter(mem);
                writer.WriteSwfHeader(Header);
                var bin = new SwfTagSerializer(this);
                foreach (var tag in Tags) {
                    var tagData = bin.GetTagData(tag);
                    writer.WriteTagData(tagData);
                }
                mem.Seek(0, SeekOrigin.Begin);

                outputWriter.WriteSwfFileInfo(new SwfFileInfo {
                    Format = "FWS",
                    FileLength = (uint)(mem.Length + 8),
                    Version = FileInfo.Version
                });
                mem.WriteTo(stream);
            }
            outputWriter.Flush();
            stream.Flush();
        }

        private static void ReadTags(SwfFile file, SwfStreamReader reader) {
            while (!reader.IsEOF) {
                var ser = new SwfTagDeserializer(file);
                var tagData = reader.ReadTagData();
                SwfTagBase tag = ser.ReadTag(tagData);
                if (tag != null) file.Tags.Add(tag);
                else throw new InvalidOperationException("Tag can't be null. Loss of data possible");
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

    }
}

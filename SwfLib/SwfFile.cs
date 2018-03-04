using System;
using System.Collections.Generic;
using System.IO;
using SwfLib.Data;
using SwfLib.Tags;

namespace SwfLib {
    public class SwfFile {

        public SwfFileInfo FileInfo;

        public SwfHeader Header;

        /// <summary>
        /// Gets list of tags.
        /// </summary>
        public readonly IList<SwfTagBase> Tags = new List<SwfTagBase>();

        public static SwfFile ReadFrom(Stream stream) {
            var file = new SwfFile();
            ISwfStreamReader reader = new SwfStreamReader(stream);
            file.FileInfo = reader.ReadSwfFileInfo();
            reader = GetSwfStreamReader(file.FileInfo, stream);
            file.Header = reader.ReadSwfHeader();
            ReadTags(file, reader);
            return file;
        }

        public void WriteTo(Stream stream) {
            WriteTo(stream, FileInfo.Format);
        }

        public void WriteTo(Stream stream, SwfFormat swfFormat) {
            var outputWriter = new SwfStreamWriter(stream);

            if (swfFormat != SwfFormat.FWS) {
                var res = new MemoryStream();
                WriteTo(res, SwfFormat.FWS);
                res.Seek(0, SeekOrigin.Begin);
                Compress(res, stream, swfFormat);
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
                    Format = SwfFormat.FWS,
                    FileLength = (uint)(mem.Length + 8),
                    Version = FileInfo.Version
                });
                mem.WriteTo(stream);
            }
            outputWriter.Flush();
            stream.Flush();
        }

        public static void Compress(Stream source, Stream target, SwfFormat compressionFormat) {

            var reader = new SwfStreamReader(source);
            var outputWriter = new SwfStreamWriter(target);

            var fileInfo = reader.ReadSwfFileInfo();
            var rest = reader.ReadRest();

            if (fileInfo.Format != SwfFormat.FWS) {
                MemoryStream mem = new MemoryStream();
                source.Seek(0, SeekOrigin.Begin);
                Decompress(source, mem);
                mem.Seek(0, SeekOrigin.Begin);
                reader = new SwfStreamReader(mem);
                fileInfo = reader.ReadSwfFileInfo();
                rest = reader.ReadRest();
            }

            outputWriter.WriteSwfFileInfo(new SwfFileInfo {
                Format = compressionFormat,
                FileLength = (uint)(rest.Length) + 8,
                Version = fileInfo.Version
            });

            var compressed = new MemoryStream();
            SwfZip.Compress(new MemoryStream(rest), compressed, compressionFormat);
            outputWriter.WriteBytes(compressed.ToArray());

            outputWriter.Flush();
        }

        public static void Decompress(Stream source, Stream target) {
            var reader = new SwfStreamReader(source);
            var outputWriter = new SwfStreamWriter(target);

            var fileInfo = reader.ReadSwfFileInfo();

            if (fileInfo.Format == SwfFormat.Unknown) {
                throw new NotSupportedException("Illegal file format");
            }

            var rest = reader.ReadRest();
            if (fileInfo.Format == SwfFormat.FWS) {
                outputWriter.WriteSwfFileInfo(fileInfo);
                outputWriter.WriteBytes(rest);
                return;
            }

            var uncompressed = new MemoryStream();
            SwfZip.Decompress(new MemoryStream(rest), uncompressed, fileInfo.Format);

            outputWriter.WriteSwfFileInfo(new SwfFileInfo {
                Format = SwfFormat.FWS,
                FileLength = (uint)(uncompressed.Length + 8),
                Version = fileInfo.Version
            });
            outputWriter.WriteBytes(uncompressed.ToArray());
            outputWriter.Flush();
        }

        private static void ReadTags(SwfFile file, ISwfStreamReader reader) {
            while (!reader.IsEOF) {
                var ser = new SwfTagDeserializer(file);
                var tagData = reader.ReadTagData();
                SwfTagBase tag = ser.ReadTag(tagData);
                if (tag != null) file.Tags.Add(tag);
                else throw new InvalidOperationException("Tag can't be null. Loss of data possible");
            }
        }

        protected static ISwfStreamReader GetSwfStreamReader(SwfFileInfo info, Stream stream) {
            if (info.Format == SwfFormat.FWS) {
                return new SwfStreamReader(stream);
            }

            MemoryStream memoryStream = new MemoryStream();
            SwfZip.Decompress(stream, memoryStream, info.Format);
            return new SwfStreamReader(memoryStream);
        }

    }
}

using System;
using System.Collections.Generic;
using System.IO;
using Code.SwfLib.Data;
using Code.SwfLib.Tags;
using zlib;

namespace Code.SwfLib {
    public class SwfFile {

        public SwfFileInfo FileInfo;

        public SwfHeader Header;

        public readonly IList<SwfTagBase> Tags = new List<SwfTagBase>();

        public static SwfFile ReadFrom(Stream stream) {
            var file = new SwfFile();
            SwfStreamReader reader = new SwfStreamReader(stream);
            file.FileInfo = reader.ReadSwfFileInfo();
            reader = GetSWFStreamReader(file.FileInfo, stream);
            file.Header = reader.ReadSwfHeader();
            ReadTags(file, reader);
            return file;
        }

        public void WriteTo(Stream stream) {
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            writer.WriteSwfFileInfo(FileInfo);
            writer.WriteSwfHeader(Header);
            var bin = new SwfTagSerializer(this);
            foreach (var tag in Tags) {
                var tagData = (SwfTagData)tag.AcceptVistor(bin);
                writer.WriteTagData(tagData);
            }
            mem.Seek(0, SeekOrigin.Begin);
            FileInfo.Format = "FWS";
            FileInfo.FileLength = (uint)mem.Length;
            writer.WriteSwfFileInfo(FileInfo);
            mem.WriteTo(stream);
        }

        private static void ReadTags(SwfFile file, SwfStreamReader reader) {
            while (!reader.IsEOF) {
                var tagReader = new SwfTagReader(file);
                SwfTagBase tag = tagReader.ReadTag(reader);
                if (tag != null) file.Tags.Add(tag);
                else throw new InvalidOperationException("Tag can't be null. Loss of data possible");
            }
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

        public IEnumerable<SwfTagBase> IterateTagsRecursively() {
            foreach (var tag in Tags) {
                //TODO: recursion
                yield return tag;
            }
        }

    }
}

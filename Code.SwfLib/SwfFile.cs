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

        public static SwfFile ReadFrom(Stream stream)
        {
            var file = new SwfFile();
            SwfStreamReader reader = new SwfStreamReader(stream);
            file.FileInfo = reader.ReadSwfFileInfo();
            reader = GetSWFStreamReader(file.FileInfo, stream);
            file.Header = reader.ReadSwfHeader();
            ReadTags(file, reader);
            return file;

        }

        public void WriteTo(Stream stream)
        {
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            writer.WriteSwfFileInfo(FileInfo);
            writer.WriteSwfHeader(Header);
            var bin = new Tag2BinaryVisitor();
            foreach (var tag in Tags)
            {
                var tagData = (SwfTagData)tag.AcceptVistor(bin);
                writer.WriteTagData(tagData);
            }
            mem.Seek(0, SeekOrigin.Begin);
            FileInfo.Format = "FWS";
            FileInfo.FileLength = (uint) mem.Length;
            writer.WriteSwfFileInfo(FileInfo);
            mem.WriteTo(stream);
        }

        private static void ReadTags(SwfFile file, SwfStreamReader reader)
        {
            while (!reader.IsEOF)
            {
                var tagReader = new SwfTagReader(file.FileInfo.Version);
                SwfTagBase tag = tagReader.ReadTag(reader);
                if (tag != null) file.Tags.Add(tag);
                else throw new InvalidOperationException("Tag can't be null. Loss of data possible");
            }
        }

        protected static SwfStreamReader GetSWFStreamReader(SwfFileInfo info, Stream stream)
        {
            switch (info.Format)
            {
                case "CWS":
                    MemoryStream mem = new MemoryStream();
                    byte[] headerStub = new byte[8];
                    mem.Write(headerStub, 0, headerStub.Length);
                    ZOutputStream zip = new ZOutputStream(mem);
                    int readBytes = 1;
                    byte[] buffer = new byte[512];
                    while (readBytes > 0)
                    {
                        readBytes = stream.Read(buffer, 0, buffer.Length);
                        zip.Write(buffer, 0, readBytes);
                    }
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

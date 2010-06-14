using System;
using System.IO;
using System.Text;
using Code.SwfLib.Tags;
using zlib;

namespace Code.SwfLib {
    public class SwfModel {

        public static void WriteSwf(SwfFile file, Stream stream) {
            var mem = new MemoryStream();
            mem.WriteSwfFileInfo(file.FileInfo);
            var writer = new SwfStreamWriter(mem);
            writer.WriteSwfHeader(file.Header);
            var bin = new Tag2BinaryVisitor();
            foreach (var tag in file.Tags) {
                var tagData = (SwfTagData)tag.AcceptVistor(bin);
                writer.WriteTagData(tagData);
            }
            mem.Seek(0, SeekOrigin.Begin);
            mem.WriteByte((byte) 'F');
            mem.Seek(4, SeekOrigin.Begin);
            var len = mem.Length;
            mem.WriteByte((byte)((len >> 0) & 0xff));
            mem.WriteByte((byte)((len >> 8) & 0xff));
            mem.WriteByte((byte)((len >> 16) & 0xff));
            mem.WriteByte((byte)((len >> 24) & 0xff));
            mem.WriteTo(stream);
        }

        public static SwfFile LoadSwf(Stream stream) {
            var file = new SwfFile();
            file.FileInfo = stream.ReadSwfFileInfo();
            var reader = GetSWFStreamReader(file.FileInfo, stream);
            file.Header = reader.ReadSwfHeader();
            ReadTags(file, reader);
            return file;
        }

        private static void ReadTags(SwfFile file, SwfStreamReader reader) {
            while (!reader.IsEOF) {
                var tagReader = new SwfTagReader(file.FileInfo.Version);
                SwfTagBase tag = tagReader.ReadTag(reader);
                if (tag != null) file.Tags.Add(tag);
                else throw new InvalidOperationException("Tag can't be null. Loss of data possible");
            }
        }

        protected static SwfStreamReader GetSWFStreamReader(SwfFileInfo info, Stream stream) {
            switch (info.Format) {
                case "CWS":
                    MemoryStream mem = new MemoryStream();
                    byte[] headerStub = new byte[8];
                    mem.Write(headerStub, 0, headerStub.Length);
                    ZOutputStream zip = new ZOutputStream(mem);
                    int readBytes = 1;
                    byte[] buffer = new byte[512];
                    while (readBytes > 0) {
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

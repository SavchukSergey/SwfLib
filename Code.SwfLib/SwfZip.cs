using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using zlib;

namespace Code.SwfLib
{
    public static class SwfZip
    {

        public static void Compress(Stream source, Stream target)
        {
            //TODO: Implement
            byte[] buffer = new byte[4096];
            int readBytes;
            do
            {
                readBytes = source.Read(buffer, 0, buffer.Length);
                target.Write(buffer, 0, readBytes);
            } while (readBytes > 0);
        }

        public static void Decompress(Stream source, Stream target)
        {
            source.Seek(0, SeekOrigin.Begin);

            var reader = new SwfStreamReader(source);
            var writer = new SwfStreamWriter(target);
            
            var hdr = reader.ReadSwfFileInfo();
            hdr.Format = "FWS";
            writer.WriteSwfFileInfo(hdr);

            ZOutputStream zip = new ZOutputStream(target);
            int readBytes;
            byte[] buffer = new byte[512];
            do
            {
                readBytes = source.Read(buffer, 0, buffer.Length);
                zip.Write(buffer, 0, readBytes);
            } while (readBytes > 0);
        }
    }
}

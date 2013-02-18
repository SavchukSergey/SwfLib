using System.IO;
using zlib;

namespace Code.SwfLib {
    public static class SwfZip {

        public static void Compress(Stream uncompressed, Stream target) {
            var buffer = new byte[4096];
            int readBytes;
            var zip = new ZOutputStream(target, zlibConst.Z_BEST_COMPRESSION);
            do {
                readBytes = uncompressed.Read(buffer, 0, buffer.Length);
                zip.Write(buffer, 0, readBytes);
            } while (readBytes > 0);
            zip.finish();
            zip.Flush();
        }

        public static void Decompress(Stream compressed, Stream target) {
            var zip = new ZOutputStream(target);
            int readBytes;
            var buffer = new byte[512];
            do {
                readBytes = compressed.Read(buffer, 0, buffer.Length);
                zip.Write(buffer, 0, readBytes);
            } while (readBytes > 0);
            zip.Flush();
            target.Seek(0, SeekOrigin.Begin);
        }
    }
}

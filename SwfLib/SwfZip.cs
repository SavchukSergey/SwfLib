using System;
using System.IO;
using SharpCompress.Compressors;
using SharpCompress.Compressors.Deflate;
using SharpCompress.Compressors.LZMA;

namespace SwfLib {
    public static class SwfZip {

        public static void Compress(Stream uncompressed, Stream target, SwfFormat compressionFormat) {
            switch (compressionFormat) {
                case SwfFormat.CWS:
                    CompressZlib(uncompressed, target);
                    break;
                case SwfFormat.ZWS:
                    CompressLzma(uncompressed, target);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Invalid Compression Format");
            }
        }

        public static void Decompress(Stream compressed, Stream target, SwfFormat compressionFormat) {
            switch (compressionFormat) {
                case SwfFormat.FWS:
                    return;
                case SwfFormat.CWS:
                    DecompressZlib(compressed, target);
                    break;
                case SwfFormat.ZWS:
                    DecompressLzma(compressed, target);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Invalid Compression Format");
            }
        }

        public static byte[] Decompress(byte[] compressed, SwfFormat compressionFormat) {
            var mem = new MemoryStream();
            Decompress(new MemoryStream(compressed, false), mem, compressionFormat);
            return mem.ToArray();
        }

        public static byte[] CompressZlib(byte[] uncompressed) {
            var mem = new MemoryStream();
            CompressZlib(new MemoryStream(uncompressed, false), mem);
            return mem.ToArray();
        }

        private static void CompressZlib(Stream uncompressed, Stream target) {
            var buffer = new byte[4096];
            int readBytes;

            var zip = new ZlibStream(target, CompressionMode.Compress) { BufferSize = 4096 };
            do {
                readBytes = uncompressed.Read(buffer, 0, buffer.Length);
                zip.Write(buffer, 0, readBytes);
            } while (readBytes > 0);
            zip.Close();
        }

        private static void CompressLzma(Stream uncompressed, Stream target) {
            var buffer = new byte[4096];
            int readBytes;

            var zip = new FlashLzipStream(target, CompressionMode.Compress);
            do {
                readBytes = uncompressed.Read(buffer, 0, buffer.Length);
                zip.Write(buffer, 0, readBytes);
            } while (readBytes > 0);
            zip.Finish();
            zip.Flush();
        }

        public static byte[] DecompressZlib(byte[] compressed) {
            var mem = new MemoryStream();
            DecompressZlib(new MemoryStream(compressed), mem);
            return mem.ToArray();
        }

        private static void DecompressZlib(Stream compressed, Stream target) {
            var zip = new ZlibStream(compressed, CompressionMode.Decompress);
            int readBytes;
            var buffer = new byte[512];
            do {
                readBytes = zip.Read(buffer, 0, buffer.Length);
                target.Write(buffer, 0, readBytes);
            } while (readBytes > 0);
            zip.Flush();
            target.Seek(0, SeekOrigin.Begin);
        }

        public static byte[] DecompressLzma(byte[] compressed) {
            var mem = new MemoryStream();
            DecompressLzma(new MemoryStream(compressed), mem);
            return mem.ToArray();
        }

        private static void DecompressLzma(Stream compressed, Stream target) {
            var lzmaProperties = new byte[5];
            compressed.Seek(4, SeekOrigin.Current);
            compressed.Read(lzmaProperties, 0, 5);
            var lzmaStream = new LzmaStream(lzmaProperties, compressed);
            int readBytes;
            var buffer = new byte[512];
            do {
                readBytes = lzmaStream.Read(buffer, 0, buffer.Length);
                target.Write(buffer, 0, readBytes);
            } while (readBytes > 0);
            target.Flush();
            target.Seek(0, SeekOrigin.Begin);
        }

    }
}

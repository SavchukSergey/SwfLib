using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpCompress.Compressors;
using SharpCompress.Compressors.LZMA;

namespace SwfLib
{
    class FlashLzipStream : LZipStream
    {
        public FlashLzipStream(Stream stream, CompressionMode mode, bool leaveOpen = false) : base(stream, mode, leaveOpen)
        {
            stream.Seek(0, SeekOrigin.Begin);
            WriteHeaderSize(stream);
        }

        public new void WriteHeaderSize(Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }
            // hard coding the dictionary size encoding
            byte[] header = { (byte)'L', (byte)'Z', (byte)'I', (byte)'P', 0x5D, 0x00, 0x00, 0x20, 0x00};
            stream.Write(header, 0, header.Length);
        }
    }
}

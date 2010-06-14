using System;
using System.IO;
using Code.SwfLib.Data;

namespace Code.SwfLib {
    public static class SwfStreamWriterExt {

        public static void WriteSwfFileInfo(this Stream stream, SwfFileInfo fileInfo) {
            string format = fileInfo.Format;
            if (format == null || format.Length != 3)
                throw new InvalidOperationException("Format should be of length 3");
            stream.WriteByte((byte) format[0]);
            stream.WriteByte((byte) format[1]);
            stream.WriteByte((byte) format[2]);

            stream.WriteByte(fileInfo.Version);

            var len = fileInfo.FileLength;
            stream.WriteByte((byte)((len >> 0) & 0xff));
            stream.WriteByte((byte)((len >> 8) & 0xff));
            stream.WriteByte((byte)((len >> 16) & 0xff));
            stream.WriteByte((byte)((len >> 24) & 0xff));
        }

        public static void WriteSwfHeader(this SwfStreamWriter writer, SwfHeader header) {
            writer.WriteRect(header.FrameSize);
            writer.WriteFixedPoint16(header.FrameRate);
            writer.WriteUInt16(header.FrameCount);
        }

        public static void WriteRect(this SwfStreamWriter writer, SwfRect rect) {
            BitsCount btCount = new BitsCount(0);
            btCount.AddValue(rect.XMin);
            btCount.AddValue(rect.XMax);
            btCount.AddValue(rect.YMin);
            btCount.AddValue(rect.YMax);
            var bits = btCount.GetSignedBits();
            if (bits < 1) bits = 1;
            writer.WriteUnsignedBits((uint) bits, 5);
            writer.WriteSignedBits(rect.XMin, (uint) bits);
            writer.WriteSignedBits(rect.XMax, (uint) bits);
            writer.WriteSignedBits(rect.YMin, (uint) bits);
            writer.WriteSignedBits(rect.YMax, (uint) bits);
        }

        public static void WriteRGB(this SwfStreamWriter writer, SwfRGB val) {
            writer.WriteByte(val.Red);
            writer.WriteByte(val.Green);
            writer.WriteByte(val.Blue);
        }

    }
}

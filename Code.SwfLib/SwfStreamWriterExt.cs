using System;
using System.IO;
using Code.SwfLib.Data;
using Code.SwfLib.Data.Shapes;

namespace Code.SwfLib {
    public static class SwfStreamWriterExt {

        public static void WriteSwfFileInfo(this SwfStreamWriter writer, SwfFileInfo fileInfo) {
            string format = fileInfo.Format;
            if (format == null || format.Length != 3)
                throw new InvalidOperationException("Format should be of length 3");
            writer.WriteByte((byte)format[0]);
            writer.WriteByte((byte)format[1]);
            writer.WriteByte((byte)format[2]);

            writer.WriteByte(fileInfo.Version);

            var len = fileInfo.FileLength;
            writer.WriteByte((byte)((len >> 0) & 0xff));
            writer.WriteByte((byte)((len >> 8) & 0xff));
            writer.WriteByte((byte)((len >> 16) & 0xff));
            writer.WriteByte((byte)((len >> 24) & 0xff));
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
            writer.WriteUnsignedBits((uint)bits, 5);
            writer.WriteSignedBits(rect.XMin, (uint)bits);
            writer.WriteSignedBits(rect.XMax, (uint)bits);
            writer.WriteSignedBits(rect.YMin, (uint)bits);
            writer.WriteSignedBits(rect.YMax, (uint)bits);
        }

        public static void WriteRGB(this SwfStreamWriter writer, SwfRGB val) {
            writer.WriteByte(val.Red);
            writer.WriteByte(val.Green);
            writer.WriteByte(val.Blue);
        }

        public static void WriteStyleChangeShapeRecord(this SwfStreamWriter writer, StyleChangeShapeRecord record, uint fillStylesBits, uint lineStylesBits) {
            writer.WriteBit(false);
            writer.WriteBit(false);
            writer.WriteBit(record.LineStyle.HasValue);
            writer.WriteBit(record.FillStyle1.HasValue);
            writer.WriteBit(record.FillStyle0.HasValue);
            bool stateMoveTo = record.MoveDeltaX != 0 || record.MoveDeltaY != 0;
            writer.WriteBit(stateMoveTo);
            if (stateMoveTo) {
                BitsCount cnt = new BitsCount(0);
                cnt.AddValue(record.MoveDeltaX);
                cnt.AddValue(record.MoveDeltaY);
                var bits = cnt.GetSignedBits();
                writer.WriteUnsignedBits((uint) bits, 5);
                writer.WriteSignedBits(record.MoveDeltaX, (uint)bits);
                writer.WriteSignedBits(record.MoveDeltaY, (uint)bits);
            }

        }
    }
}

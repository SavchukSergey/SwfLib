using System;
using Code.SwfLib.Data;

namespace Code.SwfLib
{
    public static class SwfStreamWriterExt
    {

        public static void WriteSwfFileInfo(this SwfStreamWriter writer, SwfFileInfo fileInfo)
        {
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

        public static void WriteSwfHeader(this SwfStreamWriter writer, SwfHeader header)
        {
            writer.WriteRect(header.FrameSize);
            writer.WriteFixedPoint8(header.FrameRate);
            writer.WriteUInt16(header.FrameCount);
        }

        public static void WriteRect(this SwfStreamWriter writer, SwfRect rect)
        {
            BitsCount btCount = new BitsCount(0);
            btCount.AddValue(rect.XMin);
            btCount.AddValue(rect.XMax);
            btCount.AddValue(rect.YMin);
            btCount.AddValue(rect.YMax);
            var bits = btCount.GetSignedBits();
            if (bits < 1) bits = 1;
            writer.WriteUnsignedBits(bits, 5);
            writer.WriteSignedBits(rect.XMin, bits);
            writer.WriteSignedBits(rect.XMax, bits);
            writer.WriteSignedBits(rect.YMin, bits);
            writer.WriteSignedBits(rect.YMax, bits);
        }

        public static void WriteColorTransform(this SwfStreamWriter writer, ColorTransform tranform)
        {
            throw new NotImplementedException();
        }

        public static void WriteMatrix(this SwfStreamWriter writer, SwfMatrix matrix)
        {
            bool hasScale = matrix.HasScale;
            writer.WriteBit(hasScale);
            if (hasScale)
            {
                var scaleBits = new BitsCount((int)matrix.ScaleX, (int)matrix.ScaleY).GetUnsignedBits() + 16u;
                writer.WriteFixedPoint16(matrix.ScaleX, scaleBits);
                writer.WriteFixedPoint16(matrix.ScaleY, scaleBits);
            }
            bool hasRotate = matrix.HasRotate;
            if (hasRotate)
            {
                var scaleBits = new BitsCount((int)matrix.RotateSkew0, (int)matrix.RotateSkew1).GetUnsignedBits() + 16u;
                writer.WriteFixedPoint16(matrix.RotateSkew0, scaleBits);
                writer.WriteFixedPoint16(matrix.RotateSkew1, scaleBits);
            }
            var translateBits = new BitsCount(matrix.TranslateX, matrix.TranslateY).GetUnsignedBits();
            writer.WriteUnsignedBits(translateBits, 5);
            writer.WriteSignedBits(matrix.TranslateX, translateBits);
            writer.WriteSignedBits(matrix.TranslateY, translateBits);
        }


        public static void WriteRGB(this SwfStreamWriter writer, SwfRGB val)
        {
            writer.WriteByte(val.Red);
            writer.WriteByte(val.Green);
            writer.WriteByte(val.Blue);
        }

        public static void WriteShapeWithStyle(this SwfStreamWriter writer, ShapeWithStyle1 shapeWithStyle)
        {
            writer.WriteFillStyles(shapeWithStyle.FillStyles);
            writer.WriteLineStyles(shapeWithStyle.LineStyles);
            var fillStyleBits = new BitsCount(shapeWithStyle.FillStyles.Count).GetUnsignedBits();
            var lineStyleBits = new BitsCount(shapeWithStyle.LineStyles.Count).GetUnsignedBits();
            writer.WriteUnsignedBits(fillStyleBits, 4);
            writer.WriteUnsignedBits(lineStyleBits, 4);
            writer.WriteShapeRecords(shapeWithStyle.ShapeRecords, ref fillStyleBits, ref lineStyleBits);
        }



    }
}

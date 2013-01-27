using System;
using System.Collections.Generic;
using Code.SwfLib.Shapes.LineStyles;
using Code.SwfLib.Tags.ShapeTags;

namespace Code.SwfLib.Shapes {
    public static class LineStyleStreamExt {

        public static void ReadToLineStylesRGB(this SwfStreamReader reader, IList<LineStyleRGB> lineStyles, bool allowBigArray) {
            ushort cnt = reader.ReadByte();
            if (allowBigArray && cnt == 255) {
                cnt = reader.ReadUInt16();
            }
            for (var i = 0; i < cnt; i++) {
                lineStyles.Add(reader.ReadLineStyleRGB());
            }
        }

        public static void ReadToLineStylesRGBA(this SwfStreamReader reader, IList<LineStyleRGBA> lineStyles, bool allowBigArray) {
            ushort cnt = reader.ReadByte();
            if (allowBigArray && cnt == 255) {
                cnt = reader.ReadUInt16();
            }
            for (var i = 0; i < cnt; i++) {
                lineStyles.Add(reader.ReadLineStyleRGBA());
            }
        }

        public static void ReadToLineStylesEx(this SwfStreamReader reader, IList<LineStyleEx> lineStyles, bool allowBigArray) {
            ushort cnt = reader.ReadByte();
            if (allowBigArray && cnt == 255) {
                cnt = reader.ReadUInt16();
            }
            for (var i = 0; i < cnt; i++) {
                lineStyles.Add(reader.ReadLineStyleEx());
            }
        }

        public static void WriteLineStylesRGB(this SwfStreamWriter writer, IList<LineStyleRGB> styles) {
            if (styles.Count < 255) {
                writer.WriteByte((byte)styles.Count);
            } else {
                writer.WriteByte(255);
                writer.WriteUInt16((ushort)styles.Count);
            }
            foreach (var lineStyle in styles) {
                var style = lineStyle;
                writer.WriteLineStyleRGB(style);
            }
        }

        public static void WriteLineStylesRGBA(this SwfStreamWriter writer, IList<LineStyleRGBA> styles) {
            if (styles.Count < 255) {
                writer.WriteByte((byte)styles.Count);
            } else {
                writer.WriteByte(255);
                writer.WriteUInt16((ushort)styles.Count);
            }
            foreach (var lineStyle in styles) {
                var style = lineStyle;
                writer.WriteLineStyleRGBA(style);
            }
        }

        public static void WriteLineStylesEx(this SwfStreamWriter writer, IList<LineStyleEx> styles) {
            if (styles.Count < 255) {
                writer.WriteByte((byte)styles.Count);
            } else {
                writer.WriteByte(255);
                writer.WriteUInt16((ushort)styles.Count);
            }
            foreach (var lineStyle in styles) {
                var style = lineStyle;
                writer.WriteLineStyleEx(style);
            }
        }

        public static LineStyleRGB ReadLineStyleRGB(this SwfStreamReader reader) {
            var lineStyle = new LineStyleRGB();
            lineStyle.Width = reader.ReadUInt16();
            reader.ReadRGB(out lineStyle.Color);
            return lineStyle;
        }

        public static LineStyleRGBA ReadLineStyleRGBA(this SwfStreamReader reader) {
            var lineStyle = new LineStyleRGBA();
            lineStyle.Width = reader.ReadUInt16();
            reader.ReadRGBA(out lineStyle.Color);
            return lineStyle;
        }

        public static LineStyleEx ReadLineStyleEx(this SwfStreamReader reader) {
            var lineStyle = new LineStyleEx();
            lineStyle.Width = reader.ReadUInt16();
            lineStyle.StartCapStyle = (CapStyle)reader.ReadUnsignedBits(2);
            lineStyle.JoinStyle = (JoinStyle)reader.ReadUnsignedBits(2);
            lineStyle.HasFill = reader.ReadBit();
            lineStyle.NoHScale = reader.ReadBit();
            lineStyle.NoVScale = reader.ReadBit();
            lineStyle.PixelHinting = reader.ReadBit();
            lineStyle.Reserved = (byte)reader.ReadUnsignedBits(5);
            lineStyle.NoClose = reader.ReadBit();
            lineStyle.EndCapStyle = (CapStyle)reader.ReadUnsignedBits(2);
            if (lineStyle.JoinStyle == JoinStyle.Miter) {
                lineStyle.MilterLimitFactor = reader.ReadFixedPoint8();
            }
            if (lineStyle.HasFill) {
                lineStyle.FillStyle = reader.ReadFillStyleRGBA();
            } else {
                lineStyle.Color = reader.ReadRGBA();
            }
            return lineStyle;
        }

        public static void WriteLineStyleRGB(this SwfStreamWriter writer, LineStyleRGB lineStyle) {
            writer.WriteUInt16(lineStyle.Width);
            writer.WriteRGB(ref lineStyle.Color);
        }

        public static void WriteLineStyleRGBA(this SwfStreamWriter writer, LineStyleRGBA lineStyle) {
            writer.WriteUInt16(lineStyle.Width);
            writer.WriteRGBA(ref lineStyle.Color);
        }

        public static void WriteLineStyleEx(this SwfStreamWriter writer, LineStyleEx lineStyle) {
            writer.WriteUInt16(lineStyle.Width);
            writer.WriteUnsignedBits((uint)lineStyle.StartCapStyle, 2);
            writer.WriteUnsignedBits((uint)lineStyle.JoinStyle, 2);
            writer.WriteBit(lineStyle.HasFill);
            writer.WriteBit(lineStyle.NoHScale);
            writer.WriteBit(lineStyle.NoVScale);
            writer.WriteBit(lineStyle.PixelHinting);
            writer.WriteUnsignedBits(lineStyle.Reserved, 5);
            writer.WriteBit(lineStyle.NoClose);
            writer.WriteUnsignedBits((uint)lineStyle.EndCapStyle, 2);
            if (lineStyle.JoinStyle == JoinStyle.Miter) {
                writer.WriteFixedPoint8(lineStyle.MilterLimitFactor);
            }
            if (lineStyle.HasFill) {
                writer.WriteFillStyleRGBA(ref lineStyle.FillStyle);
            } else {
                writer.WriteRGBA(ref lineStyle.Color);
            }
        }


    }
}

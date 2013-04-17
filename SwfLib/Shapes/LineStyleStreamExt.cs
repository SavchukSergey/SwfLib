using System;
using System.Collections.Generic;
using SwfLib.Data;
using SwfLib.Shapes.LineStyles;

namespace SwfLib.Shapes {
    public static class LineStyleStreamExt {

        public static void ReadToLineStylesRGB(this ISwfStreamReader reader, IList<LineStyleRGB> lineStyles, bool allowBigArray) {
            ushort cnt = reader.ReadByte();
            if (allowBigArray && cnt == 255) {
                cnt = reader.ReadUInt16();
            }
            for (var i = 0; i < cnt; i++) {
                lineStyles.Add(reader.ReadLineStyleRGB());
            }
        }

        public static void ReadToLineStylesRGBA(this ISwfStreamReader reader, IList<LineStyleRGBA> lineStyles) {
            ushort cnt = reader.ReadByte();
            if (cnt == 255) {
                cnt = reader.ReadUInt16();
            }
            for (var i = 0; i < cnt; i++) {
                lineStyles.Add(reader.ReadLineStyleRGBA());
            }
        }

        public static void ReadToLineStylesEx(this ISwfStreamReader reader, IList<LineStyleEx> lineStyles) {
            ushort cnt = reader.ReadByte();
            if (cnt == 255) {
                cnt = reader.ReadUInt16();
            }
            for (var i = 0; i < cnt; i++) {
                lineStyles.Add(reader.ReadLineStyleEx());
            }
        }

        public static void WriteLineStylesRGB(this ISwfStreamWriter writer, IList<LineStyleRGB> styles, bool allowBigArray) {
            if (styles.Count < 255) {
                writer.WriteByte((byte)styles.Count);
            } else {
                if (!allowBigArray) {
                    throw new InvalidOperationException("DefineShape supports up to 255 fill style records");
                }
                writer.WriteByte(255);
                writer.WriteUInt16((ushort)styles.Count);
            }
            foreach (var lineStyle in styles) {
                var style = lineStyle;
                writer.WriteLineStyleRGB(style);
            }
        }

        public static void WriteLineStylesRGBA(this ISwfStreamWriter writer, IList<LineStyleRGBA> styles) {
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

        public static void WriteLineStylesEx(this ISwfStreamWriter writer, IList<LineStyleEx> styles) {
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

        public static LineStyleRGB ReadLineStyleRGB(this ISwfStreamReader reader) {
            var lineStyle = new LineStyleRGB {
                Width = reader.ReadUInt16(),
                Color = reader.ReadRGB()
            };
            return lineStyle;
        }

        public static LineStyleRGBA ReadLineStyleRGBA(this ISwfStreamReader reader) {
            var lineStyle = new LineStyleRGBA {
                Width = reader.ReadUInt16(),
                Color = reader.ReadRGBA()
            };
            return lineStyle;
        }

        public static LineStyleEx ReadLineStyleEx(this ISwfStreamReader reader) {
            var lineStyle = new LineStyleEx {
                Width = reader.ReadUInt16(),
                StartCapStyle = (CapStyle)reader.ReadUnsignedBits(2),
                JoinStyle = (JoinStyle)reader.ReadUnsignedBits(2),
                HasFill = reader.ReadBit(),
                NoHScale = reader.ReadBit(),
                NoVScale = reader.ReadBit(),
                PixelHinting = reader.ReadBit(),
                Reserved = (byte)reader.ReadUnsignedBits(5),
                NoClose = reader.ReadBit(),
                EndCapStyle = (CapStyle)reader.ReadUnsignedBits(2)
            };
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

        public static void WriteLineStyleRGB(this ISwfStreamWriter writer, LineStyleRGB lineStyle) {
            writer.WriteUInt16(lineStyle.Width);
            writer.WriteRGB(ref lineStyle.Color);
        }

        public static void WriteLineStyleRGBA(this ISwfStreamWriter writer, LineStyleRGBA lineStyle) {
            writer.WriteUInt16(lineStyle.Width);
            writer.WriteRGBA(lineStyle.Color);
        }

        public static void WriteLineStyleEx(this ISwfStreamWriter writer, LineStyleEx lineStyle) {
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
                writer.WriteFillStyleRGBA(lineStyle.FillStyle);
            } else {
                writer.WriteRGBA(lineStyle.Color);
            }
        }

    }
}

using System;
using System.Collections.Generic;
using Code.SwfLib.Tags.ShapeTags;

namespace Code.SwfLib {
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
            lineStyle.StartCapStyle = reader.ReadCapStyle();
            lineStyle.JoinStyle = reader.ReadJoinStyle();
            lineStyle.HasFill = reader.ReadBit();
            lineStyle.NoHScale = reader.ReadBit();
            lineStyle.NoVScale = reader.ReadBit();
            lineStyle.PixelHinting = reader.ReadBit();
            lineStyle.NoClose = reader.ReadBit();
            lineStyle.EndCapStyle = reader.ReadCapStyle();
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
            throw new NotImplementedException();
        }

        private static CapStyle ReadCapStyle(this SwfStreamReader reader) {
            var bit0 = reader.ReadBit();
            var bit1 = reader.ReadBit();
            return (CapStyle)((bit1 ? 2 : 0) + (bit0 ? 1 : 0));
        }

        private static JoinStyle ReadJoinStyle(this SwfStreamReader reader) {
            var bit0 = reader.ReadBit();
            var bit1 = reader.ReadBit();
            return (JoinStyle)((bit1 ? 2 : 0) + (bit0 ? 1 : 0));
        }
    }
}

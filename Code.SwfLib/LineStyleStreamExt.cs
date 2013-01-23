using System;
using System.Collections.Generic;
using Code.SwfLib.Tags.ShapeTags;

namespace Code.SwfLib {
    public static class LineStyleStreamExt {

        public static void ReadToLineStylesRGB(this SwfStreamReader reader, IList<LineStyleRGB> lineStyles, bool allowBigArray) {
            ushort cnt = reader.ReadByte();
            if (allowBigArray && cnt == 0) {
                cnt = reader.ReadUInt16();
            }
            for (var i = 0; i < cnt; i++) {
                lineStyles.Add(reader.ReadLineStyleRGB());
            }
        }

        public static void ReadToLineStylesRGBA(this SwfStreamReader reader, IList<LineStyleRGBA> lineStyles, bool allowBigArray) {
            ushort cnt = reader.ReadByte();
            if (allowBigArray && cnt == 0) {
                cnt = reader.ReadUInt16();
            }
            for (var i = 0; i < cnt; i++) {
                lineStyles.Add(reader.ReadLineStyleRGBA());
            }
        }

        public static void ReadToLineStylesEx(this SwfStreamReader reader, IList<LineStyleEx> lineStyles, bool allowBigArray) {
            ushort cnt = reader.ReadByte();
            if (allowBigArray && cnt == 0) {
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
            throw new NotImplementedException();
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
    }
}

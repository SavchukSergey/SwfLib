using System;
using Code.SwfLib.Data.LineStyles;

namespace Code.SwfLib {
    public static class LineStyleStreamExt {

        public static void ReadToLineStyles1(this SwfStreamReader reader, LineStylesRGBList lineStyles) {
            var cnt = reader.ReadByte();
            for (var i = 0; i < cnt; i++) {
                lineStyles.Add(reader.ReadLineStyleRGB());
            }
        }

        public static void WriteLineStyles1(this SwfStreamWriter writer, LineStylesRGBList styles) {
            //TODO: Check boundaries
            byte count = (byte)styles.Count;
            writer.WriteByte(count);
            for (var i = 0; i < count; i++) {
                var style = styles[i];
                writer.WriteLineStyleRGB(style);
            }
        }

        public static LineStyleRGB ReadLineStyleRGB(this SwfStreamReader reader) {
            var lineStyle = new LineStyleRGB();
            lineStyle.Width = reader.ReadUInt16();
            reader.ReadRGB(out lineStyle.Color);
            return lineStyle;
        }

        public static void WriteLineStyleRGB(this SwfStreamWriter writer, LineStyleRGB lineStyle) {
            writer.WriteUInt16(lineStyle.Width);
            writer.WriteRGB(ref lineStyle.Color);
        }

    }
}

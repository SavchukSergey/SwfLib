using System;
using Code.SwfLib.Data.LineStyles;

namespace Code.SwfLib {
    public static class LineStyleStreamExt {

        public static void ReadToLineStyles(this SwfStreamReader reader, LineStyles1List lineStyles) {
            //TODO: read fill styles
        }

        public static void WriteLineStyles(this SwfStreamWriter writer, LineStyles1List styles) {
            //TODO: Check boundaries
            byte count = (byte) styles.Count;
            writer.WriteByte(count);
            for (var i = 0; i < count; i++) {
                var style = styles[i];
                switch (style.Type) {
                    default:
                        throw new InvalidOperationException("Unknown line style type " + style.Type);
                }
            }
        }

    }
}

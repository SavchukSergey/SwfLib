using System;
using Code.SwfLib.Data.LineStyles;

namespace Code.SwfLib {
    public static class LineStyleStreamExt {
        public static void WriteLineStyles(this SwfStreamWriter writer, LineStyles1List styles) {
            for (var i = 0; i < styles.Count; i++) {
                var style = styles[i];
                switch (style.Type) {
                    default:
                        throw new InvalidOperationException("Unknown line style type " + style.Type);
                }
            }
        }

    }
}

namespace SwfLib.Data {
    /// <summary>
    /// Represents extensions to ISwfStreamReader for reading color records.
    /// </summary>
    public static class ColorStreamExt {
        
        public static SwfRGB ReadRGB(this ISwfStreamReader reader) {
            SwfRGB color;
            reader.ReadRGB(out color);
            return color;
        }

        public static void ReadRGB(this ISwfStreamReader reader, out SwfRGB color) {
            color.Red = reader.ReadByte();
            color.Green = reader.ReadByte();
            color.Blue = reader.ReadByte();
        }

        public static SwfRGBA ReadRGBA(this ISwfStreamReader reader) {
            return new SwfRGBA {
                Red = reader.ReadByte(),
                Green = reader.ReadByte(),
                Blue = reader.ReadByte(),
                Alpha = reader.ReadByte()
            };
        }

        public static SwfRGBA ReadARGB(this ISwfStreamReader reader) {
            var rgb = new SwfRGBA {
                Alpha = reader.ReadByte(),
                Red = reader.ReadByte(),
                Green = reader.ReadByte(),
                Blue = reader.ReadByte()
            };
            return rgb;
        }

        /// <summary>
        /// Writes the RGB color to writer.
        /// </summary>
        /// <param name="writer">The writer to which to write color.</param>
        /// <param name="val">Color to be written.</param>
        public static void WriteRGB(this ISwfStreamWriter writer, SwfRGB val) {
            writer.WriteRGB(ref val);
        }

        /// <summary>
        /// Writes the RGB color to writer.
        /// </summary>
        /// <param name="writer">The writer to which to write color.</param>
        /// <param name="val">Color to be written.</param>
        public static void WriteRGB(this ISwfStreamWriter writer, ref SwfRGB val) {
            writer.WriteByte(val.Red);
            writer.WriteByte(val.Green);
            writer.WriteByte(val.Blue);
        }

        /// <summary>
        /// Writes the RGBA color to writer.
        /// </summary>
        /// <param name="writer">The writer to which to write color.</param>
        /// <param name="val">Color to be written.</param>
        public static void WriteRGBA(this ISwfStreamWriter writer, SwfRGBA val) {
            writer.WriteRGBA(ref val);
        }

        /// <summary>
        /// Writes the RGBA color to writer.
        /// </summary>
        /// <param name="writer">The writer to which to write color.</param>
        /// <param name="val">Color to be written.</param>
        public static void WriteRGBA(this ISwfStreamWriter writer, ref SwfRGBA val) {
            writer.WriteByte(val.Red);
            writer.WriteByte(val.Green);
            writer.WriteByte(val.Blue);
            writer.WriteByte(val.Alpha);
        }

        /// <summary>
        /// Writes the ARGB color to writer.
        /// </summary>
        /// <param name="writer">The writer to which to write color.</param>
        /// <param name="val">Color to be written.</param>
        public static void WriteARGB(this ISwfStreamWriter writer, SwfRGBA val) {
            writer.WriteByte(val.Alpha);
            writer.WriteByte(val.Red);
            writer.WriteByte(val.Green);
            writer.WriteByte(val.Blue);
        }
    }
}

using System;
using System.Collections.Generic;
using SwfLib.Shapes.FillStyles;

namespace SwfLib.Shapes {
    public static class FillStyleStreamExt {

        private static readonly FillStyleRGBReader _readerRGB = new FillStyleRGBReader();
        private static readonly FillStyleRGBAReader _readerRGBA = new FillStyleRGBAReader();
        private static readonly FillStyleRGBWriter _writerRGB = new FillStyleRGBWriter();
        private static readonly FillStyleRGBAWriter _writerRGBA = new FillStyleRGBAWriter();

        public static void ReadToFillStylesRGB(this ISwfStreamReader reader, IList<FillStyleRGB> fillStyles, bool allowBigArray) {
            ushort count = reader.ReadByte();
            if (allowBigArray && count == 255) {
                count = reader.ReadUInt16();
            }
            for (var i = 0; i < count; i++) {
                FillStyleRGB style = reader.ReadFillStyleRGB();
                fillStyles.Add(style);
            }
        }

        public static void ReadToFillStylesRGBA(this ISwfStreamReader reader, IList<FillStyleRGBA> fillStyles) {
            ushort count = reader.ReadByte();
            if (count == 255) {
                count = reader.ReadUInt16();
            }
            for (var i = 0; i < count; i++) {
                FillStyleRGBA style = reader.ReadFillStyleRGBA();
                fillStyles.Add(style);
            }
        }

        public static void WriteFillStylesRGB(this ISwfStreamWriter writer, IList<FillStyleRGB> styles, bool allowBigArray) {
            if (styles.Count < 255) {
                writer.WriteByte((byte)styles.Count);
            } else {
                if (!allowBigArray) {
                    throw new InvalidOperationException("DefineShape supports up to 255 fill style records");
                }
                writer.WriteByte(255);
                writer.WriteUInt16((ushort)styles.Count);
            }
            foreach (var fillStyle in styles) {
                var style = fillStyle;
                writer.WriteFillStyleRGB(style);
            }
        }

        public static void WriteFillStylesRGBA(this ISwfStreamWriter writer, IList<FillStyleRGBA> styles) {
            if (styles.Count < 255) {
                writer.WriteByte((byte)styles.Count);
            } else {
                writer.WriteByte(255);
                writer.WriteUInt16((ushort)styles.Count);
            }
            foreach (var fillStyle in styles) {
                var style = fillStyle;
                writer.WriteFillStyleRGBA(style);
            }
        }

        public static FillStyleRGB ReadFillStyleRGB(this ISwfStreamReader reader) {
            var type = (FillStyleType)reader.ReadByte();
            return _readerRGB.Read(reader, type);
        }

        public static FillStyleRGBA ReadFillStyleRGBA(this ISwfStreamReader reader) {
            var type = (FillStyleType)reader.ReadByte();
            return _readerRGBA.Read(reader, type);
        }

        /// <summary>
        /// Writes fill style to the writer.
        /// </summary>
        /// <param name="writer">Writer where to serialize fill style.</param>
        /// <param name="fillStyle">Fill style to be written.</param>
        public static void WriteFillStyleRGB(this ISwfStreamWriter writer, FillStyleRGB fillStyle) {
            _writerRGB.Write(writer, fillStyle);
        }

        /// <summary>
        /// Writes fill style to the writer.
        /// </summary>
        /// <param name="writer">Writer where to serialize fill style.</param>
        /// <param name="fillStyle">Fill style to be written.</param>
        public static void WriteFillStyleRGBA(this ISwfStreamWriter writer, FillStyleRGBA fillStyle) {
            _writerRGBA.Write(writer, fillStyle);
        }

    }
}

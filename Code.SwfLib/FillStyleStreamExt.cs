using System;
using System.Collections.Generic;
using Code.SwfLib.Gradients;
using Code.SwfLib.Tags.ShapeTags;

namespace Code.SwfLib {
    public static class FillStyleStreamExt {

        public static void ReadToFillStylesRGB(this SwfStreamReader reader, IList<FillStyleRGB> fillStyles, bool allowBigArray) {
            ushort count = reader.ReadByte();
            if (allowBigArray && count == 255) {
                count = reader.ReadUInt16();
            }
            for (var i = 0; i < count; i++) {
                FillStyleRGB style;
                reader.ReadFillStyleRGB(out style);
                fillStyles.Add(style);
            }
        }

        public static void ReadToFillStylesRGBA(this SwfStreamReader reader, IList<FillStyleRGBA> fillStyles, bool allowBigArray) {
            ushort count = reader.ReadByte();
            if (allowBigArray && count == 255) {
                count = reader.ReadUInt16();
            }
            for (var i = 0; i < count; i++) {
                FillStyleRGBA style;
                reader.ReadFillStyleRGBA(out style);
                fillStyles.Add(style);
            }
        }

        public static void WriteFillStylesRGB(this SwfStreamWriter writer, IList<FillStyleRGB> styles) {
            if (styles.Count < 255) {
                writer.WriteByte((byte)styles.Count);
            } else {
                writer.WriteByte(255);
                writer.WriteUInt16((ushort)styles.Count);
            }
            foreach (var fillStyle in styles) {
                var style = fillStyle;
                writer.WriteFillStyleRGB(ref style);
            }
        }

        public static void WriteFillStylesRGBA(this SwfStreamWriter writer, IList<FillStyleRGBA> styles) {
            if (styles.Count < 255) {
                writer.WriteByte((byte)styles.Count);
            } else {
                writer.WriteByte(255);
                writer.WriteUInt16((ushort)styles.Count);
            }
            foreach (var fillStyle in styles) {
                var style = fillStyle;
                writer.WriteFillStyleRGBA(ref style);
            }
        }

        public static void ReadFillStyleRGB(this SwfStreamReader reader, out FillStyleRGB fillStyle) {
            var type = (FillStyleType)reader.ReadByte();
            fillStyle = new FillStyleRGB();
            fillStyle.FillStyleType = type;
            switch (type) {
                case FillStyleType.SolidColor:
                    reader.ReadRGB(out fillStyle.Color);
                    break;
                case FillStyleType.LinearGradient:
                case FillStyleType.RadialGradient:
                    reader.ReadMatrix(out fillStyle.GradientMatrix);
                    reader.ReadGradientRGB(out fillStyle.Gradient);
                    break;
                case FillStyleType.FocalGradient:
                    reader.ReadMatrix(out fillStyle.GradientMatrix);
                    reader.ReadFocalGradient(out fillStyle.FocalGradient);
                    break;
                case FillStyleType.RepeatingBitmap:
                case FillStyleType.ClippedBitmap:
                case FillStyleType.NonSmoothedRepeatingBitmap:
                case FillStyleType.NonSmoothedClippedBitmap:
                    fillStyle.BitmapID = reader.ReadUInt16();
                    reader.ReadMatrix(out fillStyle.BitmapMatrix);
                    break;
                default:
                    throw new NotSupportedException("Fill style " + type + " is not supported");
            }
        }

        public static FillStyleRGBA ReadFillStyleRGBA(this SwfStreamReader reader) {
            FillStyleRGBA fillStyle;
            reader.ReadFillStyleRGBA(out fillStyle);
            return fillStyle;
        }

        public static void ReadFillStyleRGBA(this SwfStreamReader reader, out FillStyleRGBA fillStyle) {
            var type = (FillStyleType)reader.ReadByte();
            fillStyle = new FillStyleRGBA();
            fillStyle.FillStyleType = type;
            switch (type) {
                case FillStyleType.SolidColor:
                    reader.ReadRGBA(out fillStyle.Color);
                    break;
                case FillStyleType.LinearGradient:
                case FillStyleType.RadialGradient:
                    reader.ReadMatrix(out fillStyle.GradientMatrix);
                    reader.ReadGradientRGBA(out fillStyle.Gradient);
                    break;
                case FillStyleType.FocalGradient:
                    reader.ReadMatrix(out fillStyle.GradientMatrix);
                    reader.ReadFocalGradient(out fillStyle.FocalGradient);
                    break;
                case FillStyleType.RepeatingBitmap:
                case FillStyleType.ClippedBitmap:
                case FillStyleType.NonSmoothedRepeatingBitmap:
                case FillStyleType.NonSmoothedClippedBitmap:
                    fillStyle.BitmapID = reader.ReadUInt16();
                    reader.ReadMatrix(out fillStyle.BitmapMatrix);
                    break;
                default:
                    throw new NotSupportedException("Fill style " + type + " is not supported");
            }
        }

        public static void WriteFillStyleRGB(this SwfStreamWriter writer, ref FillStyleRGB fillStyle) {
            writer.WriteByte((byte)fillStyle.FillStyleType);
            switch (fillStyle.FillStyleType) {
                case FillStyleType.SolidColor:
                    writer.WriteRGB(ref fillStyle.Color);
                    break;
                case FillStyleType.LinearGradient:
                case FillStyleType.RadialGradient:
                    writer.WriteMatrix(ref fillStyle.GradientMatrix);
                    writer.WriteGradientRGB(ref fillStyle.Gradient);
                    break;
                case FillStyleType.FocalGradient:
                    writer.WriteMatrix(ref fillStyle.GradientMatrix);
                    writer.WriteFocalGradient(ref fillStyle.FocalGradient);
                    break;
                case FillStyleType.RepeatingBitmap:
                case FillStyleType.ClippedBitmap:
                case FillStyleType.NonSmoothedRepeatingBitmap:
                case FillStyleType.NonSmoothedClippedBitmap:
                    writer.WriteUInt16(fillStyle.BitmapID);
                    writer.WriteMatrix(ref fillStyle.BitmapMatrix);
                    break;
                default:
                    throw new NotSupportedException("Fill style " + fillStyle.FillStyleType + " is not supported");
            }
        }

        public static void WriteFillStyleRGBA(this SwfStreamWriter writer, ref FillStyleRGBA fillStyle) {
            writer.WriteByte((byte)fillStyle.FillStyleType);
            switch (fillStyle.FillStyleType) {
                case FillStyleType.SolidColor:
                    writer.WriteRGBA(ref fillStyle.Color);
                    break;
                case FillStyleType.LinearGradient:
                case FillStyleType.RadialGradient:
                    writer.WriteMatrix(ref fillStyle.GradientMatrix);
                    writer.WriteGradientRGBA(ref fillStyle.Gradient);
                    break;
                case FillStyleType.FocalGradient:
                    writer.WriteMatrix(ref fillStyle.GradientMatrix);
                    writer.WriteFocalGradient(ref fillStyle.FocalGradient);
                    break;
                case FillStyleType.RepeatingBitmap:
                case FillStyleType.ClippedBitmap:
                case FillStyleType.NonSmoothedRepeatingBitmap:
                case FillStyleType.NonSmoothedClippedBitmap:
                    writer.WriteUInt16(fillStyle.BitmapID);
                    writer.WriteMatrix(ref fillStyle.BitmapMatrix);
                    break;
                default:
                    throw new NotSupportedException("Fill style " + fillStyle.FillStyleType + " is not supported");
            }
        }

    }
}

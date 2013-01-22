using System;
using System.Collections.Generic;
using Code.SwfLib.Data.FillStyles;

namespace Code.SwfLib {
    public static class FillStyleStreamExt {

        public static void ReadToFillStyles1(this SwfStreamReader reader, IList<FillStyle> fillStyles) {
            ushort count = reader.ReadByte();
            if (count == 255) {
                count = reader.ReadUInt16();
            }
            for (var i = 0; i < count; i++) {
                FillStyle style;
                reader.ReadFillStyle1(out style);
                fillStyles.Add(style);
            }
        }

        public static void WriteFillStyles1(this SwfStreamWriter writer, IList<FillStyle> styles) {
            if (styles.Count < 255) {
                writer.WriteByte((byte)styles.Count);
            } else {
                writer.WriteByte(255);
                writer.WriteUInt16((ushort)styles.Count);
            }
            foreach (FillStyle fillStyle in styles) {
                var style = fillStyle;
                writer.WriteFillStyle1(ref style);
            }
        }

        public static void ReadFillStyle1(this SwfStreamReader reader, out FillStyle fillStyle) {
            var type = (FillStyleType)reader.ReadByte();
            fillStyle = new FillStyle();
            fillStyle.FillStyleType = type;
            switch (type) {
                case FillStyleType.SolidColor:
                    reader.ReadRGB(out fillStyle.ColorRGB);
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

        public static void WriteFillStyle1(this SwfStreamWriter writer, ref FillStyle fillStyle) {
            writer.WriteByte((byte)fillStyle.FillStyleType);
            switch (fillStyle.FillStyleType) {
                case FillStyleType.SolidColor:
                    writer.WriteRGB(ref fillStyle.ColorRGB);
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

    }
}

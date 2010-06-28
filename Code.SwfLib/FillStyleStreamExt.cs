using System;
using System.Collections.Generic;
using Code.SwfLib.Data.FillStyles;

namespace Code.SwfLib {
    public static class FillStyleStreamExt {

        public static void ReadToFillStyles1(this SwfStreamReader reader, IList<FillStyle> fillStyles) {
            byte count = reader.ReadByte();
            for (var i = 0; i < count; i++) {
                FillStyle style;
                reader.ReadFillStyle1(out style);
                fillStyles.Add(style);
            }
        }

        public static void WriteFillStyles1(this SwfStreamWriter writer, IList<FillStyle> styles) {
            byte cnt = (byte)styles.Count;
            //TODO: Check boundaries
            writer.WriteByte(cnt);
            for (var i = 0; i < cnt; i++) {
                var style = styles[i];
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
                    fillStyle.GradientMatrix = reader.ReadMatrix();
                    reader.ReadGradientRGB(out fillStyle.Gradient);
                    break;
                case FillStyleType.FocalGradient:
                    fillStyle.GradientMatrix = reader.ReadMatrix();
                    reader.ReadFocalGradient(out fillStyle.FocalGradient);
                    break;
                case FillStyleType.RepeatingBitmap:
                case FillStyleType.ClippedBitmap:
                case FillStyleType.NonSmoothedRepeatingBitmap:
                case FillStyleType.NonSmoothedClippedBitmap:
                    fillStyle.BitmapID = reader.ReadUInt16();
                    fillStyle.BitmapMatrix = reader.ReadMatrix();
                    break;
                default:
                    throw new NotSupportedException("Fill style " + type + " is not supported");
            }
        }

        public static void WriteFillStyle1(this SwfStreamWriter writer, ref FillStyle fillStyle) {
            writer.WriteByte((byte) fillStyle.FillStyleType);
            switch (fillStyle.FillStyleType) {
                case FillStyleType.SolidColor:
                    writer.WriteRGB(ref fillStyle.ColorRGB);
                    break;
                case FillStyleType.LinearGradient:
                case FillStyleType.RadialGradient:
                    writer.WriteMatrix(fillStyle.GradientMatrix);
                    writer.WriteGradientRGB(ref fillStyle.Gradient);
                    break;
                case FillStyleType.FocalGradient:
                    writer.WriteMatrix(fillStyle.GradientMatrix);
                    writer.WriteFocalGradient(ref fillStyle.FocalGradient);
                    break;
                case FillStyleType.RepeatingBitmap:
                case FillStyleType.ClippedBitmap:
                case FillStyleType.NonSmoothedRepeatingBitmap:
                case FillStyleType.NonSmoothedClippedBitmap:
                    writer.WriteUInt16(fillStyle.BitmapID);
                    writer.WriteMatrix(fillStyle.BitmapMatrix);
                    break;
                default:
                    throw new NotSupportedException("Fill style " + fillStyle.FillStyleType + " is not supported");
            }
        }

    }
}

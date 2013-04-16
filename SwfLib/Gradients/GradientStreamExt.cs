using System;
using Code.SwfLib.Data;
using SwfLib;
using SwfLib.Data;
using SwfLib.Gradients;

namespace Code.SwfLib.Gradients {
    public static class GradientStreamExt {

        #region Linear Gradient

        public static GradientRGB ReadGradientRGB(this ISwfStreamReader reader) {
            var gradient = new GradientRGB {
                SpreadMode = (SpreadMode)reader.ReadUnsignedBits(2),
                InterpolationMode = (InterpolationMode)reader.ReadUnsignedBits(2)
            };
            var count = reader.ReadUnsignedBits(4);
            for (var i = 0; i < count; i++) {
                GradientRecordRGB record = reader.ReadGradientRecordRGB();
                gradient.GradientRecords.Add(record);
            }
            return gradient;
        }

        public static GradientRGBA ReadGradientRGBA(this ISwfStreamReader reader) {
            var gradient = new GradientRGBA {
                SpreadMode = (SpreadMode)reader.ReadUnsignedBits(2),
                InterpolationMode = (InterpolationMode)reader.ReadUnsignedBits(2)
            };
            var count = reader.ReadUnsignedBits(4);
            for (var i = 0; i < count; i++) {
                GradientRecordRGBA record = reader.ReadGradientRecordRGBA();
                gradient.GradientRecords.Add(record);
            }
            return gradient;
        }

        public static void WriteGradientRGBA(this ISwfStreamWriter writer, GradientRGBA gradient) {
            writer.WriteUnsignedBits((uint)gradient.SpreadMode, 2);
            writer.WriteUnsignedBits((uint)gradient.InterpolationMode, 2);
            var count = gradient.GradientRecords.Count;
            if (count > 15)
                throw new ArgumentOutOfRangeException("gradient", "Can't serialize more them 15 gradient points");
            writer.WriteUnsignedBits((uint)count, 4);
            for (var i = 0; i < count; i++) {
                var record = gradient.GradientRecords[i];
                writer.WriteGradientRecordRGBA(ref record);
            }
        }

        public static void WriteGradientRGB(this ISwfStreamWriter writer, GradientRGB gradient) {
            writer.WriteUnsignedBits((uint)gradient.SpreadMode, 2);
            writer.WriteUnsignedBits((uint)gradient.InterpolationMode, 2);
            var count = gradient.GradientRecords.Count;
            if (count > 15)
                throw new ArgumentOutOfRangeException("gradient", "Can't serialize more them 15 gradient points");
            writer.WriteUnsignedBits((uint)count, 4);
            for (var i = 0; i < count; i++) {
                GradientRecordRGB record = gradient.GradientRecords[i];
                writer.WriteGradientRecordRGB(ref record);
            }
        }

        #endregion

        #region Focal gradients

        public static FocalGradientRGB ReadFocalGradientRGB(this ISwfStreamReader reader) {
            var gradient = new FocalGradientRGB {
                SpreadMode = (SpreadMode)reader.ReadUnsignedBits(2),
                InterpolationMode = (InterpolationMode)reader.ReadUnsignedBits(2)
            };
            var count = reader.ReadUnsignedBits(4);
            for (var i = 0; i < count; i++) {
                GradientRecordRGB record = reader.ReadGradientRecordRGB();
                gradient.GradientRecords.Add(record);
            }
            gradient.FocalPoint = reader.ReadFixedPoint8();
            return gradient;
        }

        public static FocalGradientRGBA ReadFocalGradientRGBA(this ISwfStreamReader reader) {
            var gradient = new FocalGradientRGBA {
                SpreadMode = (SpreadMode)reader.ReadUnsignedBits(2),
                InterpolationMode = (InterpolationMode)reader.ReadUnsignedBits(2)
            };
            var count = reader.ReadUnsignedBits(4);
            for (var i = 0; i < count; i++) {
                GradientRecordRGBA record = reader.ReadGradientRecordRGBA();
                gradient.GradientRecords.Add(record);
            }
            gradient.FocalPoint = reader.ReadFixedPoint8();
            return gradient;
        }

        public static void WriteFocalGradientRGBA(this ISwfStreamWriter writer, FocalGradientRGBA gradient) {
            writer.WriteUnsignedBits((uint)gradient.SpreadMode, 2);
            writer.WriteUnsignedBits((uint)gradient.InterpolationMode, 2);
            var count = gradient.GradientRecords.Count;
            if (count > 15)
                throw new ArgumentOutOfRangeException("gradient", "Can't serialize more them 15 gradient points");
            writer.WriteUnsignedBits((uint)count, 4);
            for (var i = 0; i < count; i++) {
                var record = gradient.GradientRecords[i];
                writer.WriteGradientRecordRGBA(ref record);
            }
            writer.WriteFixedPoint8(gradient.FocalPoint);
        }

        public static void WriteFocalGradientRGB(this ISwfStreamWriter writer, FocalGradientRGB gradient) {
            writer.WriteUnsignedBits((uint)gradient.SpreadMode, 2);
            writer.WriteUnsignedBits((uint)gradient.InterpolationMode, 2);
            var count = gradient.GradientRecords.Count;
            if (count > 15)
                throw new ArgumentOutOfRangeException("gradient", "Can't serialize more them 15 gradient points");
            writer.WriteUnsignedBits((uint)count, 4);
            for (var i = 0; i < count; i++) {
                GradientRecordRGB record = gradient.GradientRecords[i];
                writer.WriteGradientRecordRGB(ref record);
            }
            writer.WriteFixedPoint8(gradient.FocalPoint);
        }

        #endregion

        #region Gradient records

        public static GradientRecordRGB ReadGradientRecordRGB(this ISwfStreamReader reader) {
            var record = new GradientRecordRGB {
                Ratio = reader.ReadByte(),
                Color = reader.ReadRGB()
            };
            return record;
        }

        public static GradientRecordRGBA ReadGradientRecordRGBA(this ISwfStreamReader reader) {
            var record = new GradientRecordRGBA {
                Ratio = reader.ReadByte(),
                Color = reader.ReadRGBA()
            };
            return record;
        }

        public static void WriteGradientRecordRGB(this ISwfStreamWriter writer, ref GradientRecordRGB record) {
            writer.WriteByte(record.Ratio);
            writer.WriteRGB(ref record.Color);
        }

        public static void WriteGradientRecordRGBA(this ISwfStreamWriter writer, ref GradientRecordRGBA record) {
            writer.WriteByte(record.Ratio);
            writer.WriteRGBA(ref record.Color);
        }

        #endregion

    }
}

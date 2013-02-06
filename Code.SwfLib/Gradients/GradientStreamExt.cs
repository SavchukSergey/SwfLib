using System;

namespace Code.SwfLib.Gradients {
    public static class GradientStreamExt {

        #region Linear Gradient

        public static GradientRGB ReadGradientRGB(this SwfStreamReader reader) {
            var gradient = new GradientRGB {
                SpreadMode = (SpreadMode)reader.ReadUnsignedBits(2),
                InterpolationMode = (InterpolationMode)reader.ReadUnsignedBits(2)
            };
            var count = reader.ReadUnsignedBits(4);
            for (var i = 0; i < count; i++) {
                GradientRecordRGB record;
                reader.ReadGradientRecordRGB(out record);
                gradient.GradientRecords.Add(record);
            }
            return gradient;
        }

        public static GradientRGBA ReadGradientRGBA(this SwfStreamReader reader) {
            var gradient = new GradientRGBA {
                SpreadMode = (SpreadMode)reader.ReadUnsignedBits(2),
                InterpolationMode = (InterpolationMode)reader.ReadUnsignedBits(2)
            };
            var count = reader.ReadUnsignedBits(4);
            for (var i = 0; i < count; i++) {
                GradientRecordRGBA record;
                reader.ReadGradientRecordRGBA(out record);
                gradient.GradientRecords.Add(record);
            }
            return gradient;
        }

        public static void WriteGradientRGBA(this SwfStreamWriter writer, GradientRGBA gradient) {
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

        public static void WriteGradientRGB(this SwfStreamWriter writer, GradientRGB gradient) {
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

        public static FocalGradientRGB ReadFocalGradientRGB(this SwfStreamReader reader) {
            var gradient = new FocalGradientRGB {
                SpreadMode = (SpreadMode)reader.ReadUnsignedBits(2),
                InterpolationMode = (InterpolationMode)reader.ReadUnsignedBits(2)
            };
            var count = reader.ReadUnsignedBits(4);
            for (var i = 0; i < count; i++) {
                GradientRecordRGB record;
                reader.ReadGradientRecordRGB(out record);
                gradient.GradientRecords.Add(record);
            }
            gradient.FocalPoint = reader.ReadFixedPoint8();
            return gradient;
        }

        public static FocalGradientRGBA ReadFocalGradientRGBA(this SwfStreamReader reader) {
            var gradient = new FocalGradientRGBA {
                SpreadMode = (SpreadMode)reader.ReadUnsignedBits(2),
                InterpolationMode = (InterpolationMode)reader.ReadUnsignedBits(2)
            };
            var count = reader.ReadUnsignedBits(4);
            for (var i = 0; i < count; i++) {
                GradientRecordRGBA record;
                reader.ReadGradientRecordRGBA(out record);
                gradient.GradientRecords.Add(record);
            }
            gradient.FocalPoint = reader.ReadFixedPoint8();
            return gradient;
        }

        public static void WriteFocalGradientRGBA(this SwfStreamWriter writer, FocalGradientRGBA gradient) {
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

        public static void WriteFocalGradientRGB(this SwfStreamWriter writer, FocalGradientRGB gradient) {
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

        public static void ReadGradientRecordRGB(this SwfStreamReader reader, out GradientRecordRGB record) {
            record.Ratio = reader.ReadByte();
            reader.ReadRGB(out record.Color);
        }

        public static void ReadGradientRecordRGBA(this SwfStreamReader reader, out GradientRecordRGBA record) {
            record.Ratio = reader.ReadByte();
            reader.ReadRGBA(out record.Color);
        }

        public static void WriteGradientRecordRGB(this SwfStreamWriter writer, ref GradientRecordRGB record) {
            writer.WriteByte(record.Ratio);
            writer.WriteRGB(ref record.Color);
        }

        public static void WriteGradientRecordRGBA(this SwfStreamWriter writer, ref GradientRecordRGBA record) {
            writer.WriteByte(record.Ratio);
            writer.WriteRGBA(ref record.Color);
        }

        #endregion

    }
}

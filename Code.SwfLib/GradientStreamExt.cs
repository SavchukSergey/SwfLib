using System;
using Code.SwfLib.Data.Gradients;

namespace Code.SwfLib {
    public static class GradientStreamExt {

        public static void ReadGradientRGB(this SwfStreamReader reader, out GradientRGB gradient) {
            gradient = new GradientRGB {
                SpreadMode = (SpreadMode)reader.ReadUnsignedBits(2),
                InterpolationMode = (InterpolationMode)reader.ReadUnsignedBits(2)
            };
            var count = reader.ReadUnsignedBits(4);
            Console.WriteLine("ReadGradientRGB records: {0}", count);
            for (var i = 0; i < count; i++) {
                GradientRecordRGB record;
                reader.ReadGradientRecordRGB(out record);
                gradient.GradientRecords.Add(record);
            }
        }

        public static void WriteGradientRGB(this SwfStreamWriter writer, ref GradientRGB gradient) {
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

        public static void ReadGradientRecordRGB(this SwfStreamReader reader, out GradientRecordRGB record) {
            record.Ratio = reader.ReadByte();
            record.Color = reader.ReadRGB();
        }

        public static void WriteGradientRecordRGB(this SwfStreamWriter writer, ref GradientRecordRGB record) {
            writer.WriteByte(record.Ratio);
            writer.WriteRGB(record.Color);
        }

        public static void ReadFocalGradient(this SwfStreamReader reader, out FocalGradient gradient) {
            throw new NotImplementedException();
        }

        public static void WriteFocalGradient(this SwfStreamWriter writer, ref FocalGradient gradient) {
            throw new NotImplementedException();
        }
    }
}

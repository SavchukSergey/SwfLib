using Code.SwfLib.Data;
using Code.SwfLib.Utils;

namespace Code.SwfLib {
    public static class ColorTransformStreamExt {

        public static ColorTransformRGB ReadColorTransformRGB(this SwfStreamReader reader) {
            ColorTransformRGB transform;
            bool hasAddTerms = reader.ReadBit();
            bool hasMultTerms = reader.ReadBit();
            var bits = reader.ReadUnsignedBits(4);
            if (hasMultTerms) {
                transform.RedMultTerm = (short)reader.ReadSignedBits(bits);
                transform.GreenMultTerm = (short)reader.ReadSignedBits(bits);
                transform.BlueMultTerm = (short)reader.ReadSignedBits(bits);
                transform.HasMultTerms = true;
            } else {
                transform.RedMultTerm = 0;
                transform.GreenMultTerm = 0;
                transform.BlueMultTerm = 0;
                transform.HasMultTerms = false;
            }
            if (hasAddTerms) {
                transform.RedAddTerm = (short)reader.ReadSignedBits(bits);
                transform.GreenAddTerm = (short)reader.ReadSignedBits(bits);
                transform.BlueAddTerm = (short)reader.ReadSignedBits(bits);
                transform.HasAddTerms = true;
            } else {
                transform.RedAddTerm = 0;
                transform.GreenAddTerm = 0;
                transform.BlueAddTerm = 0;
                transform.HasAddTerms = false;
            }
            reader.AlignToByte();
            return transform;
        }

        public static void WriteColorTransformRGB(this SwfStreamWriter writer, ColorTransformRGB tranform) {
            writer.WriteColorTransformRGB(ref tranform);
        }

        public static void WriteColorTransformRGB(this SwfStreamWriter writer, ref ColorTransformRGB tranform) {
            var bitsCounter = new SignedBitsCount(0);
            if (tranform.HasAddTerms) {
                bitsCounter.AddValue(tranform.RedAddTerm);
                bitsCounter.AddValue(tranform.GreenAddTerm);
                bitsCounter.AddValue(tranform.BlueAddTerm);
            }
            if (tranform.HasMultTerms) {
                bitsCounter.AddValue(tranform.RedMultTerm);
                bitsCounter.AddValue(tranform.GreenMultTerm);
                bitsCounter.AddValue(tranform.BlueMultTerm);
            }
            writer.WriteBit(tranform.HasAddTerms);
            writer.WriteBit(tranform.HasMultTerms);
            var bits = bitsCounter.GetBits();
            writer.WriteUnsignedBits(bits, 4);
            if (tranform.HasMultTerms) {
                writer.WriteSignedBits(tranform.RedMultTerm, bits);
                writer.WriteSignedBits(tranform.GreenMultTerm, bits);
                writer.WriteSignedBits(tranform.BlueMultTerm, bits);
            }
            if (tranform.HasAddTerms) {
                writer.WriteSignedBits(tranform.RedAddTerm, bits);
                writer.WriteSignedBits(tranform.GreenAddTerm, bits);
                writer.WriteSignedBits(tranform.BlueAddTerm, bits);
            }
            writer.FlushBits();
        }

        public static ColorTransformRGBA ReadColorTransformRGBA(this SwfStreamReader reader) {
            ColorTransformRGBA transform;
            reader.ReadColorTransformRGBA(out transform);
            return transform;
        }

        public static void ReadColorTransformRGBA(this SwfStreamReader reader, out ColorTransformRGBA transform) {
            bool hasAddTerms = reader.ReadBit();
            bool hasMultTerms = reader.ReadBit();
            var bits = reader.ReadUnsignedBits(4);
            if (hasMultTerms) {
                transform.RedMultTerm = (short)reader.ReadSignedBits(bits);
                transform.GreenMultTerm = (short)reader.ReadSignedBits(bits);
                transform.BlueMultTerm = (short)reader.ReadSignedBits(bits);
                transform.AlphaMultTerm = (short)reader.ReadSignedBits(bits);
                transform.HasMultTerms = true;
            } else {
                transform.RedMultTerm = 0;
                transform.GreenMultTerm = 0;
                transform.BlueMultTerm = 0;
                transform.AlphaMultTerm = 0;
                transform.HasMultTerms = false;
            }
            if (hasAddTerms) {
                transform.RedAddTerm = (short)reader.ReadSignedBits(bits);
                transform.GreenAddTerm = (short)reader.ReadSignedBits(bits);
                transform.BlueAddTerm = (short)reader.ReadSignedBits(bits);
                transform.AlphaAddTerm = (short)reader.ReadSignedBits(bits);
                transform.HasAddTerms = true;
            } else {
                transform.RedAddTerm = 0;
                transform.GreenAddTerm = 0;
                transform.BlueAddTerm = 0;
                transform.AlphaAddTerm = 0;
                transform.HasAddTerms = false;
            }
            reader.AlignToByte();
        }

        public static void WriteColorTransformRGBA(this SwfStreamWriter writer, ColorTransformRGBA transform) {
            WriteColorTransformRGBA(writer, ref transform);
        }

        public static void WriteColorTransformRGBA(this SwfStreamWriter writer, ref ColorTransformRGBA tranform) {
            var bitsCounter = new SignedBitsCount(0);
            if (tranform.HasAddTerms) {
                bitsCounter.AddValue(tranform.RedAddTerm);
                bitsCounter.AddValue(tranform.GreenAddTerm);
                bitsCounter.AddValue(tranform.BlueAddTerm);
                bitsCounter.AddValue(tranform.AlphaAddTerm);
            }
            if (tranform.HasMultTerms) {
                bitsCounter.AddValue(tranform.RedMultTerm);
                bitsCounter.AddValue(tranform.GreenMultTerm);
                bitsCounter.AddValue(tranform.BlueMultTerm);
                bitsCounter.AddValue(tranform.AlphaMultTerm);
            }
            writer.WriteBit(tranform.HasAddTerms);
            writer.WriteBit(tranform.HasMultTerms);
            var bits = bitsCounter.GetBits();
            writer.WriteUnsignedBits(bits, 4);
            if (tranform.HasMultTerms) {
                writer.WriteSignedBits(tranform.RedMultTerm, bits);
                writer.WriteSignedBits(tranform.GreenMultTerm, bits);
                writer.WriteSignedBits(tranform.BlueMultTerm, bits);
                writer.WriteSignedBits(tranform.AlphaMultTerm, bits);
            }
            if (tranform.HasAddTerms) {
                writer.WriteSignedBits(tranform.RedAddTerm, bits);
                writer.WriteSignedBits(tranform.GreenAddTerm, bits);
                writer.WriteSignedBits(tranform.BlueAddTerm, bits);
                writer.WriteSignedBits(tranform.AlphaAddTerm, bits);
            }
            writer.FlushBits();
        }
    }
}

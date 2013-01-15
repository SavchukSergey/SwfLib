using Code.SwfLib.Data;

namespace Code.SwfLib {
    public static class ColorTransformStreamExt {

        public static ColorTransformRGB ReadColorTransformRGB(this SwfStreamReader reader) {
            ColorTransformRGB transform;
            reader.AlignToByte();
            bool hasAddTerms = reader.ReadBit();
            bool hasMultTerms = reader.ReadBit();
            var bits = reader.ReadUnsignedBits(4);
            if (hasMultTerms) {
                transform.RedMultTerm = (short?)reader.ReadSignedBits(bits);
                transform.GreenMultTerm = (short?)reader.ReadSignedBits(bits);
                transform.BlueMultTerm = (short?)reader.ReadSignedBits(bits);
            } else {
                transform.RedMultTerm = null;
                transform.GreenMultTerm = null;
                transform.BlueMultTerm = null;
            }
            if (hasAddTerms) {
                transform.RedAddTerm = (short?)reader.ReadSignedBits(bits);
                transform.GreenAddTerm = (short?)reader.ReadSignedBits(bits);
                transform.BlueAddTerm = (short?)reader.ReadSignedBits(bits);
            } else {
                transform.RedAddTerm = null;
                transform.GreenAddTerm = null;
                transform.BlueAddTerm = null;
            }
            return transform;
        }

        public static void WriteColorTransformRGB(this SwfStreamWriter writer, ref ColorTransformRGB tranform) {
            writer.FlushBits();
            var bitsCounter = new BitsCount(0);
            if (tranform.HasAddTerms) {
                bitsCounter.AddValue(tranform.RedAddTerm.Value);
                bitsCounter.AddValue(tranform.GreenAddTerm.Value);
                bitsCounter.AddValue(tranform.BlueAddTerm.Value);
            }
            if (tranform.HasMultTerms) {
                bitsCounter.AddValue(tranform.RedMultTerm.Value);
                bitsCounter.AddValue(tranform.GreenMultTerm.Value);
                bitsCounter.AddValue(tranform.BlueMultTerm.Value);
            }
            writer.WriteBit(tranform.HasAddTerms);
            writer.WriteBit(tranform.HasMultTerms);
            var bits = bitsCounter.GetSignedBits();
            writer.WriteUnsignedBits(bits, 4);
            if (tranform.HasMultTerms) {
                writer.WriteSignedBits(tranform.RedMultTerm.Value, bits);
                writer.WriteSignedBits(tranform.GreenMultTerm.Value, bits);
                writer.WriteSignedBits(tranform.BlueMultTerm.Value, bits);
            }
            if (tranform.HasAddTerms) {
                writer.WriteSignedBits(tranform.RedAddTerm.Value, bits);
                writer.WriteSignedBits(tranform.GreenAddTerm.Value, bits);
                writer.WriteSignedBits(tranform.BlueAddTerm.Value, bits);
            }
            writer.FlushBits();
        }

        public static void ReadColorTransformRGBA(this SwfStreamReader reader, out ColorTransformRGBA transform) {
            reader.AlignToByte();
            bool hasAddTerms = reader.ReadBit();
            bool hasMultTerms = reader.ReadBit();
            var bits = reader.ReadUnsignedBits(4);
            if (hasMultTerms) {
                transform.RedMultTerm = (short?)reader.ReadSignedBits(bits);
                transform.GreenMultTerm = (short?)reader.ReadSignedBits(bits);
                transform.BlueMultTerm = (short?)reader.ReadSignedBits(bits);
                transform.AlphaMultTerm = (short?)reader.ReadSignedBits(bits);
            } else {
                transform.RedMultTerm = null;
                transform.GreenMultTerm = null;
                transform.BlueMultTerm = null;
                transform.AlphaMultTerm = null;
            }
            if (hasAddTerms) {
                transform.RedAddTerm = (short?)reader.ReadSignedBits(bits);
                transform.GreenAddTerm = (short?)reader.ReadSignedBits(bits);
                transform.BlueAddTerm = (short?)reader.ReadSignedBits(bits);
                transform.AlphaAddTerm = (short?)reader.ReadSignedBits(bits);
            } else {
                transform.RedAddTerm = null;
                transform.GreenAddTerm = null;
                transform.BlueAddTerm = null;
                transform.AlphaAddTerm = null;
            }
        }

        public static void WriteColorTransformRGBA(this SwfStreamWriter writer, ref ColorTransformRGBA tranform) {
            writer.FlushBits();
            var bitsCounter = new BitsCount(0);
            if (tranform.HasAddTerms) {
                bitsCounter.AddValue(tranform.RedAddTerm.Value);
                bitsCounter.AddValue(tranform.GreenAddTerm.Value);
                bitsCounter.AddValue(tranform.BlueAddTerm.Value);
                bitsCounter.AddValue(tranform.AlphaAddTerm.Value);
            }
            if (tranform.HasMultTerms) {
                bitsCounter.AddValue(tranform.RedMultTerm.Value);
                bitsCounter.AddValue(tranform.GreenMultTerm.Value);
                bitsCounter.AddValue(tranform.BlueMultTerm.Value);
                bitsCounter.AddValue(tranform.AlphaMultTerm.Value);
            }
            writer.WriteBit(tranform.HasAddTerms);
            writer.WriteBit(tranform.HasMultTerms);
            var bits = bitsCounter.GetSignedBits();
            writer.WriteUnsignedBits(bits, 4);
            if (tranform.HasMultTerms) {
                writer.WriteSignedBits(tranform.RedMultTerm.Value, bits);
                writer.WriteSignedBits(tranform.GreenMultTerm.Value, bits);
                writer.WriteSignedBits(tranform.BlueMultTerm.Value, bits);
                writer.WriteSignedBits(tranform.AlphaMultTerm.Value, bits);
            }
            if (tranform.HasAddTerms) {
                writer.WriteSignedBits(tranform.RedAddTerm.Value, bits);
                writer.WriteSignedBits(tranform.GreenAddTerm.Value, bits);
                writer.WriteSignedBits(tranform.BlueAddTerm.Value, bits);
                writer.WriteSignedBits(tranform.AlphaAddTerm.Value, bits);
            }
            writer.FlushBits();
        }
    }
}

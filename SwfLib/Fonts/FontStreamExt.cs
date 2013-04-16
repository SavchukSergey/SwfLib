using SwfLib;

namespace Code.SwfLib.Fonts {
    public static class FontStreamExt {

        public static KerningRecord ReadKerningRecord(this ISwfStreamReader reader, bool wideCodes) {
            var res = new KerningRecord {
                LeftCode = wideCodes ? reader.ReadUInt16() : reader.ReadByte(),
                RightCode = wideCodes ? reader.ReadUInt16() : reader.ReadByte(),
                Adjustment = reader.ReadSInt16()
            };
            return res;
        }

        public static void WriteKerningRecord(this ISwfStreamWriter writer, KerningRecord record, bool wideCodes) {
            if (wideCodes) {
                writer.WriteUInt16(record.LeftCode);
                writer.WriteUInt16(record.RightCode);
            } else {
                writer.WriteByte((byte)record.LeftCode);
                writer.WriteByte((byte)record.RightCode);
            }
            writer.WriteSInt16(record.Adjustment);
        }
    }
}

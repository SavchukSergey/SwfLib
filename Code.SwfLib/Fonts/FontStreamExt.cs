namespace Code.SwfLib.Fonts {
    public static class FontStreamExt {

        public static KerningRecord ReadKerningRecord(this SwfStreamReader reader, bool wideCodes) {
            var res = new KerningRecord {
                LeftCode = wideCodes ? reader.ReadUInt16() : reader.ReadByte(),
                RightCode = wideCodes ? reader.ReadUInt16() : reader.ReadByte(),
                Adjustment = reader.ReadSInt16()
            };
            return res;
        }
    }
}

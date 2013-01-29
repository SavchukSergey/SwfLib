using Code.SwfLib.Data;
using Code.SwfLib.Filters;

namespace Code.SwfLib.Buttons {
    public static class ButtonStreamExt {

        public static ButtonRecordEx ReadButtonRecordEx(this SwfStreamReader reader) {
            var button = new ButtonRecordEx();
            button.Reserved = (byte)reader.ReadUnsignedBits(2);
            var hasBlendMode = reader.ReadBit();
            var hasFilterList = reader.ReadBit();
            button.StateHitTest = reader.ReadBit();
            button.StateDown = reader.ReadBit();
            button.StateOver = reader.ReadBit();
            button.StateUp = reader.ReadBit();
            if (!button.IsEndButton) {
                button.CharacterID = reader.ReadUInt16();
                button.PlaceDepth = reader.ReadUInt16();
                button.PlaceMatrix = reader.ReadMatrix();
                button.ColorTransform = reader.ReadColorTransformRGBA();
                if (hasFilterList) {
                    reader.ReadFilterList(button.Filters);
                }
                if (hasBlendMode) {
                    button.BlendMode = (BlendMode)reader.ReadByte();
                }
            }
            return button;
        }

        public static void WriteButtonRecordEx(this SwfStreamWriter writer, ButtonRecordEx button) {
            writer.WriteUnsignedBits(button.Reserved, 2);
            writer.WriteBit(button.BlendMode.HasValue);
            writer.WriteBit(button.Filters.Count > 0);
            writer.WriteBit(button.StateHitTest);
            writer.WriteBit(button.StateDown);
            writer.WriteBit(button.StateOver);
            writer.WriteBit(button.StateUp);
            if (!button.IsEndButton) {
                writer.WriteUInt16(button.CharacterID);
                writer.WriteUInt16(button.PlaceDepth);
                writer.WriteMatrix(ref button.PlaceMatrix);
                writer.WriteColorTransformRGBA(button.ColorTransform);
                if (button.Filters.Count > 0) {
                    writer.WriteFilterList(button.Filters);
                }
                if (button.BlendMode.HasValue) {
                    writer.WriteByte((byte)button.BlendMode.Value);
                }
            }
        }
    }
}

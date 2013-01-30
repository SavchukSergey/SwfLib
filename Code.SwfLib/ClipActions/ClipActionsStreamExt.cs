using System.Collections.Generic;
using System.IO;
using Code.SwfLib.Actions;

namespace Code.SwfLib.ClipActions {
    public static class ClipActionsStreamExt {

        public static void ReadClipActions(this SwfStreamReader reader, byte swfVersion, ClipActionsList clipActions) {
            clipActions.Reserved = reader.ReadUInt16();
            clipActions.Flags = reader.ReadClipEventFlags(swfVersion);
            reader.ReadClipActionRecords(swfVersion, clipActions.Records);

        }

        public static void WriteClipActions(this SwfStreamWriter writer, byte swfVersion, ClipActionsList clipActions) {
            writer.WriteUInt16(clipActions.Reserved);
            writer.WriteClipEventFlags(swfVersion, clipActions.Flags);
            writer.WriteClipActionRecords(swfVersion, clipActions.Records);
        }

        public static void ReadClipActionRecords(this SwfStreamReader reader, byte swfVersion, IList<ClipActionRecord> target) {
            ClipActionRecord record;
            do {
                record = reader.ReadClipActionRecord(swfVersion);
                target.Add(record);
            } while (!record.Flags.IsEmpty);
        }

        public static void WriteClipActionRecords(this SwfStreamWriter writer, byte swfVersion, IList<ClipActionRecord> source) {
            foreach (var record in source) {
                writer.WriteClipActionRecord(swfVersion, record);
            }
        }

        public static ClipActionRecord ReadClipActionRecord(this SwfStreamReader reader, byte swfVersion) {
            var record = new ClipActionRecord();
            record.Flags = reader.ReadClipEventFlags(swfVersion);
            if (record.Flags.IsEmpty) return record;

            var offset = reader.ReadUInt32();
            if (record.Flags.ClipEventKeyPress) {
                record.KeyCode = reader.ReadByte();
            }

            ActionBase action;
            var ar = new ActionReader(reader);
            do {
                action = ar.ReadAction();
                record.Actions.Add(action);
            } while (!(action is ActionEnd));

            return record;
        }

        public static void WriteClipActionRecord(this SwfStreamWriter writer, byte swfVersion, ClipActionRecord record) {
            writer.WriteClipEventFlags(swfVersion, record.Flags);
            if (record.Flags.IsEmpty) return;

            var awmem = new MemoryStream();
            var aw = new ActionWriter(new SwfStreamWriter(awmem));
            foreach (var action in record.Actions) {
                aw.WriteAction(action);
            }

            var size = awmem.Length + (record.Flags.ClipEventKeyPress ? 1 : 0);
            writer.WriteUInt32((uint)size);

            if (record.Flags.ClipEventKeyPress) {
                writer.WriteByte(record.KeyCode);
            }

            writer.WriteBytes(awmem.ToArray());
        }

        public static ClipEventFlags ReadClipEventFlags(this SwfStreamReader reader, byte swfVersion) {
            var res = new ClipEventFlags {
                ClipEventKeyUp = reader.ReadBit(),
                ClipEventKeyDown = reader.ReadBit(),
                ClipEventMouseUp = reader.ReadBit(),
                ClipEventMouseDown = reader.ReadBit(),
                ClipEventMouseMove = reader.ReadBit(),
                ClipEventUnload = reader.ReadBit(),
                ClipEventEnterFrame = reader.ReadBit(),
                ClipEventLoad = reader.ReadBit(),

                ClipEventDragOver = reader.ReadBit(),
                ClipEventRollOut = reader.ReadBit(),
                ClipEventRollOver = reader.ReadBit(),
                ClipEventReleaseOutside = reader.ReadBit(),
                ClipEventRelease = reader.ReadBit(),
                ClipEventPress = reader.ReadBit(),
                ClipEventInitialize = reader.ReadBit(),
                ClipEventData = reader.ReadBit(),
            };

            if (swfVersion >= 6) {
                res.Reserved = (byte)reader.ReadUnsignedBits(5);
                res.ClipEventConstruct = reader.ReadBit();
                res.ClipEventKeyPress = reader.ReadBit();
                res.ClipEventDragOut = reader.ReadBit();

                res.Reserved2 = reader.ReadByte();
            }
            return res;
        }

        public static void WriteClipEventFlags(this SwfStreamWriter writer, byte swfVersion, ClipEventFlags flags) {
            writer.WriteBit(flags.ClipEventKeyUp);
            writer.WriteBit(flags.ClipEventKeyDown);
            writer.WriteBit(flags.ClipEventMouseUp);
            writer.WriteBit(flags.ClipEventMouseDown);
            writer.WriteBit(flags.ClipEventMouseMove);
            writer.WriteBit(flags.ClipEventUnload);
            writer.WriteBit(flags.ClipEventEnterFrame);
            writer.WriteBit(flags.ClipEventLoad);

            writer.WriteBit(flags.ClipEventDragOver);
            writer.WriteBit(flags.ClipEventRollOut);
            writer.WriteBit(flags.ClipEventRollOver);
            writer.WriteBit(flags.ClipEventReleaseOutside);
            writer.WriteBit(flags.ClipEventRelease);
            writer.WriteBit(flags.ClipEventPress);
            writer.WriteBit(flags.ClipEventInitialize);
            writer.WriteBit(flags.ClipEventData);

            if (swfVersion >= 6) {
                writer.WriteUnsignedBits(flags.Reserved, 5);
                writer.WriteBit(flags.ClipEventConstruct);
                writer.WriteBit(flags.ClipEventKeyPress);
                writer.WriteBit(flags.ClipEventDragOut);

                writer.WriteByte(flags.Reserved2);
            }

        }
    }
}

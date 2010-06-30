using System;
using Code.SwfLib.Data.Actions;

namespace Code.SwfLib
{
    public static class ClipActionsStreamExt
    {

        public static void ReadClipActions(this SwfStreamReader reader, byte swfVersion, out ClipActions clipActions)
        {
            throw new NotImplementedException();
            //    tag.ActionsReserved = reader.ReadUInt16();
            //    tag.ActionsFlags = _version >= 6 ? reader.ReadUInt32() : reader.ReadUInt16();
            //    //TODO: read other fields
            //TODO: read actions

        }

        public static void WriteClipActions(this SwfStreamWriter writer, byte swfVersion, ref ClipActions clipActions)
        {
            throw new NotImplementedException();
        }
    }
}

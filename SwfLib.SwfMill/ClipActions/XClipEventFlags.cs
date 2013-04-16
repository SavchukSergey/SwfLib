using SwfLib.ClipActions;

namespace SwfLib.SwfMill.ClipActions {
    public static class XClipEventFlags {

        public static int GetFlags1(ClipEventFlags flags) {
            var flag1 = 0;
            if (flags.ClipEventKeyUp) flag1 |= 128;
            if (flags.ClipEventKeyDown) flag1 |= 64;
            if (flags.ClipEventMouseUp) flag1 |= 32;
            if (flags.ClipEventMouseDown) flag1 |= 16;
            if (flags.ClipEventMouseMove) flag1 |= 8;
            if (flags.ClipEventUnload) flag1 |= 4;
            if (flags.ClipEventEnterFrame) flag1 |= 2;
            if (flags.ClipEventLoad) flag1 |= 1;

            if (flags.ClipEventDragOver) flag1 |= 32768;
            if (flags.ClipEventRollOut) flag1 |= 16384;
            if (flags.ClipEventRollOver) flag1 |= 8192;
            if (flags.ClipEventReleaseOutside) flag1 |= 4096;
            if (flags.ClipEventRelease) flag1 |= 2048;
            if (flags.ClipEventPress) flag1 |= 1024;
            if (flags.ClipEventInitialize) flag1 |= 512;
            if (flags.ClipEventData) flag1 |= 256;
            return flag1;
        }

        public static void SetFlags1(ref ClipEventFlags flags, int flag1) {
            flags.ClipEventKeyUp = (flag1 & 128) > 0;
            flags.ClipEventKeyDown = (flag1 & 64) > 0;
            flags.ClipEventMouseUp = (flag1 & 32) > 0;
            flags.ClipEventMouseDown = (flag1 & 16) > 0;
            flags.ClipEventMouseMove = (flag1 & 8) > 0;
            flags.ClipEventUnload = (flag1 & 4) > 0;
            flags.ClipEventEnterFrame = (flag1 & 2) > 0;
            flags.ClipEventLoad = (flag1 & 1) > 0;

            flags.ClipEventDragOver = (flag1 & 32768) > 0;
            flags.ClipEventRollOut = (flag1 & 16384) > 0;
            flags.ClipEventRollOver = (flag1 & 8192) > 0;
            flags.ClipEventReleaseOutside = (flag1 & 4096) > 0;
            flags.ClipEventRelease = (flag1 & 2048) > 0;
            flags.ClipEventPress = (flag1 & 1024) > 0;
            flags.ClipEventInitialize = (flag1 & 512) > 0;
            flags.ClipEventData = (flag1 & 256) > 0;
        }

        public static int GetFlags2(ClipEventFlags flags) {
            var flag2 = 0;
            flag2 |= (flags.Reserved & 0x1f);

            if (flags.ClipEventConstruct) flag2 |= 32;
            if (flags.ClipEventKeyPress) flag2 |= 64;
            if (flags.ClipEventDragOut) flag2 |= 128;

            flag2 |= (flags.Reserved >> 8);
            return flag2;
        }

        public static void SetFlags2(ref ClipEventFlags flags, int flag2) {
            flags.Reserved = (byte)(flag2 & 0x1f);

            flags.ClipEventConstruct = (flag2 & 32) > 0;
            flags.ClipEventKeyPress = (flag2 & 64) > 0;
            flags.ClipEventDragOut = (flag2 & 128) > 0;

            flags.Reserved2 = (byte)(flag2 >> 8);
        }

    }
}

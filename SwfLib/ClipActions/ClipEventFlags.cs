namespace SwfLib.ClipActions {
    public struct ClipEventFlags {

        public bool ClipEventKeyUp;
        public bool ClipEventKeyDown;
        public bool ClipEventMouseUp;
        public bool ClipEventMouseDown;
        public bool ClipEventMouseMove;
        public bool ClipEventUnload;
        public bool ClipEventEnterFrame;
        public bool ClipEventLoad;

        public bool ClipEventDragOver;
        public bool ClipEventRollOut;
        public bool ClipEventRollOver;
        public bool ClipEventReleaseOutside;
        public bool ClipEventRelease;
        public bool ClipEventPress;
        public bool ClipEventInitialize;
        public bool ClipEventData;

        public byte Reserved;
        public bool ClipEventConstruct;
        public bool ClipEventKeyPress;
        public bool ClipEventDragOut;
        public byte Reserved2;

        public bool IsEmpty {
            get {
                if (ClipEventKeyUp) return false;
                if (ClipEventKeyDown) return false;
                if (ClipEventMouseUp) return false;
                if (ClipEventMouseDown) return false;
                if (ClipEventMouseMove) return false;
                if (ClipEventUnload) return false;
                if (ClipEventEnterFrame) return false;
                if (ClipEventLoad) return false;

                if (ClipEventDragOver) return false;
                if (ClipEventRollOut) return false;
                if (ClipEventRollOver) return false;
                if (ClipEventReleaseOutside) return false;
                if (ClipEventRelease) return false;
                if (ClipEventPress) return false;
                if (ClipEventInitialize) return false;
                if (ClipEventData) return false;

                if (Reserved != 0) return false;
                if (ClipEventConstruct) return false;
                if (ClipEventKeyPress) return false;
                if (ClipEventDragOut) return false;
                if (Reserved2 != 0) return false;
                return true;
            }
        }
    }
}

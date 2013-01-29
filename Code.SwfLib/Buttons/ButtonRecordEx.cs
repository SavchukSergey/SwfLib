using System.Collections.Generic;
using Code.SwfLib.Data;
using Code.SwfLib.Filters;

namespace Code.SwfLib.Buttons {
    public class ButtonRecordEx {
        public byte Reserved;

        public bool StateHitTest;

        public bool StateDown;

        public bool StateOver;

        public bool StateUp;

        public bool IsEndButton {
            get {
                return Reserved == 0 && !BlendMode.HasValue && Filters.Count == 0 && !StateHitTest && !StateDown && !StateOver & !StateUp;
            }
        }

        public ushort CharacterID;

        public ushort PlaceDepth;

        public SwfMatrix PlaceMatrix;

        public ColorTransformRGBA ColorTransform;

        public readonly IList<BaseFilter> Filters = new List<BaseFilter>();

        public BlendMode? BlendMode;
    }
}

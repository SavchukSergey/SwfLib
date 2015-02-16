using System.Collections.Generic;
using SwfLib.Data;
using SwfLib.Filters;

namespace SwfLib.Buttons {
    public class ButtonRecordEx {
        public byte Reserved { get; set; }

        public bool StateHitTest { get; set; }

        public bool StateDown { get; set; }

        public bool StateOver { get; set; }

        public bool StateUp { get; set; }

        public bool IsEndButton {
            get {
                return Reserved == 0 && !BlendMode.HasValue && Filters.Count == 0 && !StateHitTest && !StateDown && !StateOver & !StateUp;
            }
        }

        public ushort CharacterID { get; set; }

        public ushort PlaceDepth { get; set; }

        public SwfMatrix PlaceMatrix = SwfMatrix.Identity;

        public ColorTransformRGBA ColorTransform { get; set; }

        public readonly IList<BaseFilter> Filters = new List<BaseFilter>();

        /// <summary>
        /// Gets or sets blend mode.
        /// </summary>
        public BlendMode? BlendMode { get; set; }
    }
}

using System.Collections.Generic;
using Code.SwfLib.Data;
using Code.SwfLib.Shapes.Records;

namespace Code.SwfLib.Tags.ShapeTags {
    public class DefineShape4Tag : ShapeBaseTag {

        public SwfRect EdgeBounds;

        public readonly IList<FillStyleRGBA> FillStyles = new List<FillStyleRGBA>();

        public readonly IList<LineStyleEx> LineStyles = new List<LineStyleEx>();

        public readonly IList<IShapeRecordEx> ShapeRecords = new List<IShapeRecordEx>();

        public byte Flags;

        public override SwfTagType TagType {
            get { return SwfTagType.DefineShape4; }
        }

        public bool UsesFillWindingRule {
            get { return (Flags & 0x04) > 0; }
            set {
                if (value) Flags |= 0x04;
                else Flags &= 0xfb;
            }
        }

        public bool UsesNonScalingStrokes {
            get { return (Flags & 0x02) > 0; }
            set {
                if (value) Flags |= 0x02;
                else Flags &= 0xfd;
            }
        }

        public bool UsesScalingStrokes {
            get { return (Flags & 0x01) > 0; }
            set {
                if (value) Flags |= 0x01;
                else Flags &= 0xfe;
            }
        }

        public byte ReservedFlags {
            get { return (byte)(Flags & 0xf8); }
            set { Flags = (byte)((Flags & 0x07) | (value & 0xf8)); }
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
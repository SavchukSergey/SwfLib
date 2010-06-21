using System.Collections.Generic;
using Code.SwfLib.Data;
using Code.SwfLib.Data.Shapes;

namespace Code.SwfLib.Tags.ShapeTags {
    public class DefineShapeTag : SwfTagBase {

        public ushort ObjectID;

        public SwfRect Bounds;

        public readonly IList<IDefineShape1FillStyle> FillStyles = new List<IDefineShape1FillStyle>();

        public readonly ShapeRecords1List Shapes = new ShapeRecords1List();

        public override object AcceptVistor(ISwfTagVisitor visitor) {
            return visitor.Visit(this);
        }
    }
}
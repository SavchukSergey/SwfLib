using System.Collections.Generic;
using Code.SwfLib.Data.FillStyles;
using Code.SwfLib.Data.LineStyles;
using Code.SwfLib.Data.Shapes;

namespace Code.SwfLib.Data {
    public class ShapeWithStyle1 {

        public readonly IList<FillStyle> FillStyles = new List<FillStyle>();

        public readonly LineStylesRGBList LineStyles = new LineStylesRGBList();

        public readonly ShapeRecords1List ShapeRecords = new ShapeRecords1List();

    }
}

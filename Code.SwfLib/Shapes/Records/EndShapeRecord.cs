namespace Code.SwfLib.Shapes.Records {
    public class EndShapeRecord : IShapeRecordRGB, IShapeRecordRGBA, IShapeRecordEx {
        
        public ShapeRecordType Type {
            get { return ShapeRecordType.EndRecord; }
        }

    }
}

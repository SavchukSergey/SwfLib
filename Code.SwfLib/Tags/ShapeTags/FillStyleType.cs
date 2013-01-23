namespace Code.SwfLib.Tags.ShapeTags {
    public enum FillStyleType : byte {
        SolidColor = 0x00,
        LinearGradient = 0x10,
        RadialGradient = 0x12,
        FocalGradient = 0x13,
        RepeatingBitmap = 0x40,
        ClippedBitmap = 0x41,
        NonSmoothedRepeatingBitmap = 0x42,
        NonSmoothedClippedBitmap = 0x43
    }
}
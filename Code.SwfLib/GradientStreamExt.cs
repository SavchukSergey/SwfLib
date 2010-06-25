using Code.SwfLib.Data.Gradients;

namespace Code.SwfLib
{
    public static class GradientStreamExt
    {

        public static GradientRGB ReadGradientRGB(this SwfStreamReader reader)
        {
            GradientRGB gradient = new GradientRGB();
            gradient.SpreadMode = (SpreadMode)reader.ReadUnsignedBits(2);
            gradient.InterpolationMode = (InterpolationMode)reader.ReadUnsignedBits(2);
            var count = reader.ReadUnsignedBits(4);
            for (var i = 0; i < count; i++)
            {
                reader.ReadGradientRecordRGB();
            }
            return gradient;
        }

        public static GradientRecordRGB ReadGradientRecordRGB(this SwfStreamReader reader)
        {
            GradientRecordRGB record;
            record.Ratio = reader.ReadByte();
            record.Color = reader.ReadRGB();
            return record;
        }
    }
}

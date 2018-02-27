#if NETFULL

using System.Drawing;

namespace SwfLib.Tags.BitmapTags {
    public abstract class DefineBitsJpegAlphaBase : DefineBitsJpegTagBase {

        public byte[] BitmapAlphaData;

        public override Bitmap BuildBitmap() {
            var bmp = base.BuildBitmap();
            bmp = SetAlphas(bmp, BitmapAlphaData);
            return bmp;
        }

    }
}

#endif

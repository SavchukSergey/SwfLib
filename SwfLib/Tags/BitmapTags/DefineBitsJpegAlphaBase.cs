#if NETFULL
using System.Drawing;
#endif

namespace SwfLib.Tags.BitmapTags {
    public abstract class DefineBitsJpegAlphaBase : DefineBitsJpegTagBase {

        public byte[] BitmapAlphaData;

        #if NETFULL

        public override Bitmap GetImage() {
            var bmp = base.GetImage();
            bmp = SetAlphas(bmp, BitmapAlphaData);
            return bmp;
        }

        #endif
        
    }
}

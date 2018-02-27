#if NETFULL

using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace SwfLib.Tags.BitmapTags {
    public abstract class DefineBitsJpegTagBase : BitmapBaseTag {

        public byte[] ImageData;

        public virtual Bitmap BuildBitmap() {
            MemoryStream mem;
            if (ImageData[0] == 0xff && ImageData[1] == 0xd8 && ImageData[2] == 0xff && ImageData[3] == 0xd9 &&
                ImageData[4] == 0xff && ImageData[5] == 0xd8) {
                mem = new MemoryStream(ImageData, 4, ImageData.Length - 4, false);
            } else {
                mem = new MemoryStream(ImageData, false);
            }
            var bmp = (Bitmap)Image.FromStream(mem);
            return bmp;
        }

        public void SetImage(Image image) {
            SetImage(image, ImageFormat.Jpeg);
        }

        public void SetImage(Image image, ImageFormat format) {
            var mem = new MemoryStream();
            image.Save(mem, format);
            ImageData = mem.ToArray();
        }

        protected static Bitmap SetAlphas(Bitmap bmp, byte[] compressedAlpha) {
            var alpha = SwfZip.Decompress(compressedAlpha, SwfFormat.CWS);
            var index = 0;
            var res = new Bitmap(bmp.Width, bmp.Height, PixelFormat.Format32bppArgb);
            for (var y = 0; y < bmp.Height; y++) {
                for (var x = 0; x < bmp.Width; x++) {
                    var clr = bmp.GetPixel(x, y);
                    clr = Color.FromArgb(alpha[index], clr);
                    res.SetPixel(x, y, clr);
                    index++;
                }
            }
            return res;
        }

    }
}

#endif

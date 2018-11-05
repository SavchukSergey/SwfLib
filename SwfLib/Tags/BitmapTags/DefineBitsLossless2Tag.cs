#if NETFULL
using System;
using System.Drawing;
using System.Drawing.Imaging;
#endif

namespace SwfLib.Tags.BitmapTags {
    /// <summary>
    /// Represents DefineBitsLossless2 tag.
    /// </summary>
    public class DefineBitsLossless2Tag : BitmapBaseTag {

        public byte BitmapFormat { get; set; }

        public ushort BitmapWidth { get; set; }

        public ushort BitmapHeight { get; set; }

        public byte BitmapColorTableSize;

        public byte[] ZlibBitmapData;

        #if NETFULL
        
        public virtual Bitmap GetImage() {
            var data = SwfZip.DecompressZlib(ZlibBitmapData);
            var bmp = new Bitmap(BitmapWidth, BitmapHeight);
            var lineSize = BitmapWidth;
            for (var y = 0; y < bmp.Height; y++) {
                for (var x = 0; x < bmp.Width; x++) {
                    var ind = (y * lineSize + x) * 4;
                    var alpha = data[ind];
                    if (alpha <= 0) {
                        alpha = 1;
                    }
                    var red = data[ind + 1] * 255 / alpha;
                    var green = data[ind + 2] * 255 / alpha;
                    var blue = data[ind + 3] * 255 / alpha;
                    var clr = Color.FromArgb(alpha, red, green, blue);
                    bmp.SetPixel(x, y, clr);
                }
            }
            return bmp;
        }

        public void SetImage(Bitmap bmp) {
            BitmapWidth = (ushort)bmp.Width;
            BitmapHeight = (ushort)bmp.Height;
            BitmapFormat = 5;
            var lineSize = BitmapWidth;
            var data = new byte[lineSize * BitmapHeight * 4];
            for (var y = 0; y < bmp.Height; y++) {
                for (var x = 0; x < bmp.Width; x++) {
                    var ind = (y * lineSize + x) * 4;
                    var clr = bmp.GetPixel(x, y);
                    data[ind] = clr.A;
                    data[ind + 1] = (byte)(clr.R * clr.A / 255);
                    data[ind + 2] = (byte)(clr.G * clr.A / 255);
                    data[ind + 3] = (byte)(clr.B * clr.A / 255);
                }
            }
            ZlibBitmapData = SwfZip.CompressZlib(data);
        }

        #endif

        /// <summary>
        /// Gets swf tag type.
        /// </summary>
        public override SwfTagType TagType {
            get { return SwfTagType.DefineBitsLossless2; }
        }

        /// <summary>
        /// Accept visitor.
        /// </summary>
        /// <typeparam name="TArg">Type of argument to be passed to visitor.</typeparam>
        /// <typeparam name="TResult">Type of result.</typeparam>
        /// <param name="visitor">Visitor.</param>
        /// <param name="arg">Argument to be passed to visitor.</param>
        /// <returns></returns>
        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
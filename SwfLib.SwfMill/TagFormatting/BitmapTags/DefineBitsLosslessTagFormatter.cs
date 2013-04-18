using System.Xml.Linq;
using SwfLib.Tags.BitmapTags;

namespace SwfLib.SwfMill.TagFormatting.BitmapTags {
    public class DefineBitsLosslessTagFormatter : DefineBitmapBaseTagFormatter<DefineBitsLosslessTag> {

        private const string FORMAT_ATTRIB = "format";
        private const string N_COLOR_MAP_ATTRIB = "n_colormap";

        protected override void FormatTagElement(DefineBitsLosslessTag tag, XElement xTag) {
            xTag.Add(new XAttribute(FORMAT_ATTRIB, tag.BitmapFormat));
            xTag.Add(new XAttribute(WIDTH_ATTRIB, tag.BitmapWidth));
            xTag.Add(new XAttribute(HEIGHT_ATTRIB, tag.BitmapHeight));
            if (tag.BitmapFormat == 3) {
                xTag.Add(new XAttribute(N_COLOR_MAP_ATTRIB, tag.BitmapColorTableSize));
            }
        }

        protected override bool AcceptTagAttribute(DefineBitsLosslessTag tag, XAttribute attrib) {
            switch (attrib.Name.LocalName) {
                case FORMAT_ATTRIB:
                    tag.BitmapFormat = byte.Parse(attrib.Value);
                    break;
                case WIDTH_ATTRIB:
                    tag.BitmapWidth = ushort.Parse(attrib.Value);
                    break;
                case HEIGHT_ATTRIB:
                    tag.BitmapHeight = ushort.Parse(attrib.Value);
                    break;
                case N_COLOR_MAP_ATTRIB:
                    tag.BitmapColorTableSize = byte.Parse(attrib.Value);
                    break;
                default:
                    return false;
            }
            return true;
        }

        protected override byte[] GetData(DefineBitsLosslessTag tag) {
            return tag.ZlibBitmapData;
        }

        protected override void SetData(DefineBitsLosslessTag tag, byte[] data) {
            tag.ZlibBitmapData = data;
        }

        /// <summary>
        /// Gets xml element name.
        /// </summary>
        public override string TagName {
            get { return "DefineBitsLossless"; }
        }

    }
}
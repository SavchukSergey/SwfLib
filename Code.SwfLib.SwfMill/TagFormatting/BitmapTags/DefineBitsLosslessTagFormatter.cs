using System;
using System.Xml.Linq;
using Code.SwfLib.SwfMill.Data;
using Code.SwfLib.Tags.BitmapTags;

namespace Code.SwfLib.SwfMill.TagFormatting.BitmapTags {
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

        protected override bool AcceptTagElement(DefineBitsLosslessTag tag, XElement element) {
            switch (element.Name.LocalName) {
                case DATA_TAG:
                    tag.ZlibBitmapData = XBinary.FromXml(element.Element("data"));
                    break;
                default:
                    return false;
            }
            return true;
        }

        protected override byte[] GetData(DefineBitsLosslessTag tag) {
            return tag.ZlibBitmapData;
        }

        public override string TagName {
            get { return "DefineBitsLossless"; }
        }

    }
}
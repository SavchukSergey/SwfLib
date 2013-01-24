using System;
using System.Xml.Linq;
using Code.SwfLib.Tags.BitmapTags;

namespace Code.SwfLib.SwfMill.TagFormatting.BitmapTags {
    public class DefineBitsLosslessTagFormatter : TagFormatterBase<DefineBitsLosslessTag> {
        private const string FORMAT_ATTRIB = "format";
        private const string N_COLOR_MAP_ATTRIB = "n_colormap";

        protected override void AcceptTagAttribute(DefineBitsLosslessTag tag, XAttribute attrib) {
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
                    throw new FormatException("Invalid attribute " + attrib.Name.LocalName);
            }
        }

        protected override void AcceptTagElement(DefineBitsLosslessTag tag, XElement element) {
            switch (element.Name.LocalName) {
                case DATA_TAG:
                    var dataElem = element.Element(XName.Get("data"));
                    tag.ZlibBitmapData = Convert.FromBase64String(dataElem.Value);
                    break;
                default:
                    throw new FormatException("Invalid element " + element.Name.LocalName);
            }
        }

        protected override XElement FormatTagElement(DefineBitsLosslessTag tag, XElement xTag) {
            xTag.Add(new XAttribute(FORMAT_ATTRIB, tag.BitmapFormat));
            xTag.Add(new XAttribute(WIDTH_ATTRIB, tag.BitmapWidth));
            xTag.Add(new XAttribute(HEIGHT_ATTRIB, tag.BitmapHeight));
            if (tag.BitmapFormat == 3) {
                xTag.Add(new XAttribute(N_COLOR_MAP_ATTRIB, tag.BitmapColorTableSize));
            }
            if (tag.ZlibBitmapData != null) {
                xTag.Add(new XElement(DATA_TAG, new XElement(DATA_TAG, Convert.ToBase64String(tag.ZlibBitmapData))));
            }
            return xTag;
        }

        public override string TagName {
            get { return "DefineBitsLossless"; }
        }

        protected override ushort? GetObjectID(DefineBitsLosslessTag tag) {
            return tag.CharacterID;
        }

        protected override void SetObjectID(DefineBitsLosslessTag tag, ushort value) {
            tag.CharacterID = value;
        }
    }
}
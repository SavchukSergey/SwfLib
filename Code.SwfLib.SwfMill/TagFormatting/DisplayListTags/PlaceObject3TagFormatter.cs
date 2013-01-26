using System;
using System.Xml.Linq;
using Code.SwfLib.SwfMill.Data;
using Code.SwfLib.Tags.DisplayListTags;

namespace Code.SwfLib.SwfMill.TagFormatting.DisplayListTags {
    public class PlaceObject3TagFormatter : PlaceObjectBaseFormatter<PlaceObject3Tag> {

        private const string REPLACE_ATTRIB = "replace";
        private const string MORPH_ATTRIB = "morph";
        private const string ALL_FLAGS1_ATTRIB = "allflags1";
        private const string ALL_FLAGS2_ATTRIB = "allflags2";
        private const string BITMAP_CACHING_ATTRIB = "bitmapCaching";
        private const string FILTERS_ELEM = "filters";
        private const string EVENTS_ELEM = "events";

        protected override void AcceptPlaceAttribute(PlaceObject3Tag tag, XAttribute attrib) {
            switch (attrib.Name.LocalName) {
                case NAME_ATTRIB:
                    tag.Name = attrib.Value;
                    break;
                case REPLACE_ATTRIB:
                    //TODO: read replace
                    break;
                case MORPH_ATTRIB:
                    //TODO: read morph
                    break;
                case ALL_FLAGS1_ATTRIB:
                    //TODO: read flags1
                    break;
                case ALL_FLAGS2_ATTRIB:
                    //TODO: read flags2
                    break;
                case BITMAP_CACHING_ATTRIB:
                    tag.BitmapCache = byte.Parse(attrib.Value);
                    break;
                default:
                    throw new FormatException("Invalid attribute " + attrib.Name.LocalName);
            }
        }

        protected override void AcceptPlaceTagElement(PlaceObject3Tag tag, XElement element) {
            switch (element.Name.LocalName) {
                case FILTERS_ELEM:
                    //TODO: Read filters
                    break;
                case EVENTS_ELEM:
                    //TODO: Read transform
                    break;
                case "colorTransform":
                    tag.ColorTransform = XColorTransformRGBA.FromXml(element.Element("ColorTransform2"));
                    break;
                default:
                    throw new FormatException("Invalid element " + element.Name.LocalName);
            }
        }

        protected override void FormatPlaceElement(PlaceObject3Tag tag, XElement elem) {
            if (tag.BitmapCache.HasValue) {
                elem.Add(new XAttribute(BITMAP_CACHING_ATTRIB, tag.BitmapCache.Value));
            }
            if (tag.ColorTransform.HasValue) {
                elem.Add(new XElement("colorTransform", XColorTransformRGBA.ToXml(tag.ColorTransform.Value)));
            }
        }

        protected override bool HasCharacter(PlaceObject3Tag tag) {
            return tag.HasCharacter;
        }

        protected override void HasCharacter(PlaceObject3Tag tag, bool val) {
            tag.HasCharacter = val;
        }

        protected override bool HasMatrix(PlaceObject3Tag tag) {
            return tag.HasMatrix;
        }

        protected override void HasMatrix(PlaceObject3Tag tag, bool val) {
            tag.HasMatrix = val;
        }

        public override string TagName {
            get { return "PlaceObject3"; }
        }

    }
}
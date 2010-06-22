using System;
using System.Xml.Linq;
using Code.SwfLib.Tags.DisplayListTags;

namespace Code.SwfLib.SwfMill.TagFormatting.DisplayListTags
{
    public class PlaceObject2TagFormatter : TagFormatterBase<PlaceObject2Tag> {

        private const string REPLACE_ATTRIB = "replace";
        private const string DEPTH_ATTRIB = "depth";
        private const string MORPH_ATTRIB = "morph";
        private const string NAME_ATTRIB = "name";
        private const string ALL_FLAGS1_ATTRIB = "allflags1";
        private const string ALL_FLAGS2_ATTRIB = "allflags2";
        private const string TRANSFORM_ELEM = "transform";
        private const string EVENTS_ELEM = "events";

        public override void AcceptAttribute(PlaceObject2Tag tag, XAttribute attrib) {
            switch (attrib.Name.LocalName) {
                case OBJECT_ID_ATTRIB:
                    tag.CharacterID = SwfMillPrimitives.ParseObjectID(attrib);
                    break;
                case NAME_ATTRIB:
                    tag.Name = attrib.Value;
                    break;
                case REPLACE_ATTRIB:
                    //TODO: read replace
                    break;
                case DEPTH_ATTRIB:
                    //TODO: read depth
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
                default:
                    throw new FormatException("Invalid attribute " + attrib.Name.LocalName);
            }
        }

        public override void AcceptElement(PlaceObject2Tag tag, XElement element) {
            switch (element.Name.LocalName) {
                case TRANSFORM_ELEM:
                    //TODO: Read transform
                    break;
                case EVENTS_ELEM:
                    //TODO: Read transform
                    break;
                default:
                    throw new FormatException("Invalid element " + element.Name.LocalName);
            }
        }

        public override XElement FormatTag(PlaceObject2Tag tag)
        {
            var res = new XElement(XName.Get(SwfTagNameMapping.PLACE_OBJECT2_TAG));
            if (tag.CharacterID.HasValue) {
                res.Add(new XAttribute(XName.Get("objectID"), tag.CharacterID.Value));
            }
            res.Add(new XAttribute(XName.Get("depth"), tag.Depth));
            if (tag.Matrix.HasValue) {
                res.Add(new XElement(XName.Get("transform"), GetTransformXml(tag.Matrix.Value)));
            }
            //TODO: Put other fields
            return res;
        }
    }
}
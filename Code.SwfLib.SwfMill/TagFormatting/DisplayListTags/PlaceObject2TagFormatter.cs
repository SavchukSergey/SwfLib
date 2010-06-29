using System;
using System.Xml.Linq;
using Code.SwfLib.Data;
using Code.SwfLib.Tags.DisplayListTags;

namespace Code.SwfLib.SwfMill.TagFormatting.DisplayListTags
{
    public class PlaceObject2TagFormatter : TagFormatterBase<PlaceObject2Tag>
    {

        private const string REPLACE_ATTRIB = "replace";
        private const string DEPTH_ATTRIB = "depth";
        private const string MORPH_ATTRIB = "morph";
        private const string NAME_ATTRIB = "name";
        private const string ALL_FLAGS1_ATTRIB = "allflags1";
        private const string ALL_FLAGS2_ATTRIB = "allflags2";
        private const string CLIP_DEPTH = "clipDepth";
        private const string TRANSFORM_ELEM = "transform";
        private const string EVENTS_ELEM = "events";

        public override void AcceptAttribute(PlaceObject2Tag tag, XAttribute attrib)
        {
            switch (attrib.Name.LocalName)
            {
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
                    tag.Depth = ushort.Parse(attrib.Value);
                    break;
                case CLIP_DEPTH:
                    tag.ClipDepth = ushort.Parse(attrib.Value);
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

        public override void AcceptElement(PlaceObject2Tag tag, XElement element)
        {
            switch (element.Name.LocalName)
            {
                case TRANSFORM_ELEM:
                    SwfMatrix matrix;
                    _formatters.Matrix.Parse(element.Element("Transform"), out matrix);
                    tag.Matrix = matrix;
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
            if (tag.CharacterID.HasValue)
            {
                res.Add(new XAttribute(OBJECT_ID_ATTRIB, tag.CharacterID.Value));
            }
            res.Add(new XAttribute(DEPTH_ATTRIB, tag.Depth));
            if (tag.Matrix.HasValue)
            {
                var matrix = tag.Matrix.Value;
                res.Add(new XElement(TRANSFORM_ELEM, _formatters.Matrix.Format(ref matrix)));
            }
            if (tag.ClipDepth.HasValue)
            {
                res.Add(new XAttribute(CLIP_DEPTH, tag.ClipDepth.Value));
            }
            //TODO: Put other fields
            return res;
        }
    }
}
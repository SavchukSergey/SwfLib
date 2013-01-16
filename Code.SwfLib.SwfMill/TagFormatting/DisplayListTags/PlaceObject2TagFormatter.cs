using System;
using System.Xml.Linq;
using Code.SwfLib.Data;
using Code.SwfLib.Tags.DisplayListTags;

namespace Code.SwfLib.SwfMill.TagFormatting.DisplayListTags {
    //TODO: Unit test
    public class PlaceObject2TagFormatter : TagFormatterBase<PlaceObject2Tag> {

        private const string REPLACE_ATTRIB = "replace";
        private const string DEPTH_ATTRIB = "depth";
        private const string MORPH_ATTRIB = "morph";
        private const string NAME_ATTRIB = "name";
        private const string ALL_FLAGS1_ATTRIB = "allflags1";
        private const string ALL_FLAGS2_ATTRIB = "allflags2";
        private const string CLIP_DEPTH = "clipDepth";
        private const string TRANSFORM_ELEM = "transform";
        private const string COLOR_TRANSFORM_ELEM = "color"; //TODO: Does name match swfmill
        private const string CLIP_ACTIONS_ELEM = "events";

        public override void AcceptAttribute(PlaceObject2Tag tag, XAttribute attrib) {
            tag.Move = true;

            switch (attrib.Name.LocalName) {
                case OBJECT_ID_ATTRIB:
                    tag.CharacterID = SwfMillPrimitives.ParseObjectID(attrib);
                    tag.HasCharacter = true;
                    break;
                case NAME_ATTRIB:
                    tag.Name = attrib.Value;
                    tag.HasName = true;
                    break;
                case CLIP_DEPTH:
                    tag.ClipDepth = ushort.Parse(attrib.Value);
                    tag.HasClipDepth = true;
                    break;
                case DEPTH_ATTRIB:
                    tag.Depth = ushort.Parse(attrib.Value);
                    break;
                case MORPH_ATTRIB:
                    tag.Ratio = ushort.Parse(attrib.Value);
                    tag.HasRatio = true;
                    break;
                case REPLACE_ATTRIB:
                    tag.Move = ParseBoolFromDigit(attrib);
                    break;

                case ALL_FLAGS1_ATTRIB:
                    //TODO: read flags1. Is this HasClipActions?
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
                    SwfMatrix matrix;
                    _formatters.Matrix.Parse(element.Element(TRANSFORM_TYPE_ELEM), out matrix);
                    tag.Matrix = matrix;
                    tag.HasMatrix = true;
                    break;
                case COLOR_TRANSFORM_ELEM:
                    _formatters.ColorTransformRGBA.Parse(element.Element(COLOR_TRANSFORM_TYPE_ELEM), out tag.ColorTransform);
                    tag.HasColorTransform = true;
                    break;
                case CLIP_ACTIONS_ELEM:
                    tag.ClipActions.RawData = Convert.FromBase64String(element.Value);
                    break;
                default:
                    throw new FormatException("Invalid element " + element.Name.LocalName);
            }
        }

        public override XElement FormatTag(PlaceObject2Tag tag) {
            var res = new XElement(XName.Get(SwfTagNameMapping.PLACE_OBJECT2_TAG));
            if (tag.HasCharacter) {
                res.Add(new XAttribute(OBJECT_ID_ATTRIB, tag.CharacterID));
            }
            if (tag.HasName) {
                res.Add(new XAttribute(NAME_ATTRIB, tag.Name));
            }
            res.Add(new XAttribute(DEPTH_ATTRIB, tag.Depth));
            if (tag.HasMatrix) {
                res.Add(new XElement(TRANSFORM_ELEM, _formatters.Matrix.Format(ref tag.Matrix)));
            }
            if (tag.HasColorTransform) {
                res.Add(new XElement(COLOR_TRANSFORM_ELEM, _formatters.ColorTransformRGBA.Format(ref tag.ColorTransform)));
            }
            if (tag.HasClipDepth) {
                res.Add(new XAttribute(CLIP_DEPTH, tag.ClipDepth));
            }
            if (tag.HasClipActions) {
                res.Add(new XElement(CLIP_ACTIONS_ELEM, Convert.ToBase64String(tag.ClipActions.RawData)));
            }
            if (tag.HasRatio) {
                res.Add(new XAttribute(MORPH_ATTRIB, tag.Ratio));
            }
            res.Add(new XAttribute(REPLACE_ATTRIB, FormatBoolToDigit(tag.Move)));
            return res;
        }
    }
}
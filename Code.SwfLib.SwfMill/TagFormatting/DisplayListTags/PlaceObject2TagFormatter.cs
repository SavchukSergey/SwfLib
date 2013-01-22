using System;
using System.Xml.Linq;
using Code.SwfLib.Data;
using Code.SwfLib.Tags.DisplayListTags;

namespace Code.SwfLib.SwfMill.TagFormatting.DisplayListTags {
    //TODO: Unit test
    public class PlaceObject2TagFormatter : PlaceObjectBaseFormatter<PlaceObject2Tag> {

        private const string REPLACE_ATTRIB = "replace";
        private const string MORPH_ATTRIB = "morph";
        private const string ALL_FLAGS1_ATTRIB = "allflags1";
        private const string ALL_FLAGS2_ATTRIB = "allflags2";
        private const string CLIP_DEPTH = "clipDepth";
        private const string COLOR_TRANSFORM_ELEM = "colorTransform";
        private const string CLIP_ACTIONS_ELEM = "events";

        protected override void AcceptPlaceAttribute(PlaceObject2Tag tag, XAttribute attrib) {
            tag.Move = true;

            switch (attrib.Name.LocalName) {
                case NAME_ATTRIB:
                    tag.Name = attrib.Value;
                    tag.HasName = true;
                    break;
                case CLIP_DEPTH:
                    tag.ClipDepth = ushort.Parse(attrib.Value);
                    tag.HasClipDepth = true;
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

        protected override void AcceptPlaceTagElement(PlaceObject2Tag tag, XElement element) {
            switch (element.Name.LocalName) {
                case COLOR_TRANSFORM_ELEM:
                    _formatters.ColorTransformRGBA.Parse(element.Element(COLOR_TRANSFORM_TYPE_ELEM), out tag.ColorTransform);
                    tag.HasColorTransform = true;
                    break;
                case CLIP_ACTIONS_ELEM:
                    tag.HasClipActions = true;
                    tag.ClipActions.RawData = Convert.FromBase64String(element.Value);
                    break;
                default:
                    throw new FormatException("Invalid element " + element.Name.LocalName);
            }
        }

        protected override void FormatPlaceElement(PlaceObject2Tag tag, XElement elem) {
            if (tag.HasName) {
                elem.Add(new XAttribute(NAME_ATTRIB, tag.Name));
            }
            if (tag.HasColorTransform) {
                elem.Add(new XElement(COLOR_TRANSFORM_ELEM, _formatters.ColorTransformRGBA.Format(ref tag.ColorTransform)));
            }
            if (tag.HasClipDepth) {
                elem.Add(new XAttribute(CLIP_DEPTH, tag.ClipDepth));
            }
            if (tag.HasClipActions) {
                elem.Add(new XElement(CLIP_ACTIONS_ELEM, Convert.ToBase64String(tag.ClipActions.RawData)));
            }
            if (tag.HasRatio) {
                elem.Add(new XAttribute(MORPH_ATTRIB, tag.Ratio));
            }
            elem.Add(new XAttribute(REPLACE_ATTRIB, FormatBoolToDigit(tag.Move)));
        }

        protected override bool HasCharacter(PlaceObject2Tag tag) {
            return tag.HasCharacter;
        }

        protected override void HasCharacter(PlaceObject2Tag tag, bool val) {
            tag.HasCharacter = val;
        }

        protected override bool HasMatrix(PlaceObject2Tag tag) {
            return tag.HasMatrix;
        }

        protected override void HasMatrix(PlaceObject2Tag tag, bool val) {
            tag.HasMatrix = val;
        }


        protected override string TagName {
            get { return SwfTagNameMapping.PLACE_OBJECT2_TAG; }
        }

    }
}
using System.Xml.Linq;
using Code.SwfLib.SwfMill.ClipActions;
using Code.SwfLib.SwfMill.Data;
using SwfLib.SwfMill.ClipActions;
using SwfLib.SwfMill.Data;
using SwfLib.Tags.DisplayListTags;

namespace SwfLib.SwfMill.TagFormatting.DisplayListTags {
    //TODO: Unit test
    public class PlaceObject2TagFormatter : PlaceObjectBaseFormatter<PlaceObject2Tag> {

        private const string REPLACE_ATTRIB = "replace";
        private const string MORPH_ATTRIB = "morph";
        private const string ALL_FLAGS1_ATTRIB = "allflags1";
        private const string ALL_FLAGS2_ATTRIB = "allflags2";
        private const string CLIP_DEPTH = "clipDepth";
        private const string COLOR_TRANSFORM_ELEM = "colorTransform";

        protected override bool AcceptPlaceAttribute(PlaceObject2Tag tag, XAttribute attrib) {
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
                    tag.Move = CommonFormatter.ParseBool(attrib.Value);
                    break;
                case ALL_FLAGS1_ATTRIB:
                    tag.HasClipActions = true;
                    var flags1 = int.Parse(attrib.Value);
                    XClipEventFlags.SetFlags1(ref tag.ClipActions.Flags, flags1);
                    break;
                case ALL_FLAGS2_ATTRIB:
                    tag.HasClipActions = true;
                   var flags2 = int.Parse(attrib.Value);
                    XClipEventFlags.SetFlags2(ref tag.ClipActions.Flags, flags2);
                    break;
                default:
                    return false;
            }
            return true;
        }

        protected override bool AcceptPlaceTagElement(PlaceObject2Tag tag, XElement element) {
            switch (element.Name.LocalName) {
                case COLOR_TRANSFORM_ELEM:
                    tag.ColorTransform = XColorTransformRGBA.FromXml(element.Element("ColorTransform2"));
                    tag.HasColorTransform = true;
                    break;
                case "events":
                    tag.HasClipActions = true;
                    XClipActionsList.FromXml(element, tag.ClipActions);
                    break;
                default:
                    return false;
            }
            return true;
        }

        protected override void FormatPlaceElement(PlaceObject2Tag tag, XElement elem) {
            if (tag.HasName) {
                elem.Add(new XAttribute(NAME_ATTRIB, tag.Name));
            }
            if (tag.HasClipActions) {
                var flags1 = XClipEventFlags.GetFlags1(tag.ClipActions.Flags);
                var flags2 = XClipEventFlags.GetFlags2(tag.ClipActions.Flags);
                elem.Add(new XAttribute("allflags1", flags1));
                elem.Add(new XAttribute("allflags2", flags2));
            }
            if (tag.HasColorTransform) {
                elem.Add(new XElement(COLOR_TRANSFORM_ELEM, XColorTransformRGBA.ToXml(tag.ColorTransform)));
            }
            if (tag.HasClipDepth) {
                elem.Add(new XAttribute(CLIP_DEPTH, tag.ClipDepth));
            }
            if (tag.HasClipActions) {
                elem.Add(XClipActionsList.ToXml(tag.ClipActions));
            }
            if (tag.HasRatio) {
                elem.Add(new XAttribute(MORPH_ATTRIB, tag.Ratio));
            }
            elem.Add(new XAttribute(REPLACE_ATTRIB, CommonFormatter.Format(tag.Move)));
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


        public override string TagName {
            get { return "PlaceObject2"; }
        }

    }
}
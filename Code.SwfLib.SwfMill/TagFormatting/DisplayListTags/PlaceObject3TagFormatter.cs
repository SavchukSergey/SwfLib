using System;
using System.Xml.Linq;
using Code.SwfLib.SwfMill.ClipActions;
using Code.SwfLib.SwfMill.Data;
using Code.SwfLib.SwfMill.Filters;
using Code.SwfLib.Tags.DisplayListTags;

namespace Code.SwfLib.SwfMill.TagFormatting.DisplayListTags {
    public class PlaceObject3TagFormatter : PlaceObjectBaseFormatter<PlaceObject3Tag> {

        private const string REPLACE_ATTRIB = "replace";
        private const string MORPH_ATTRIB = "morph";
        private const string ALL_FLAGS1_ATTRIB = "allflags1";
        private const string ALL_FLAGS2_ATTRIB = "allflags2";
        private const string BITMAP_CACHING_ATTRIB = "bitmapCaching";


        protected override bool AcceptPlaceAttribute(PlaceObject3Tag tag, XAttribute attrib) {
            switch (attrib.Name.LocalName) {
                case NAME_ATTRIB:
                    tag.Name = attrib.Value;
                    break;
                case "className":
                    tag.ClassName = attrib.Value;
                    break;
                case REPLACE_ATTRIB:
                    tag.Move = ParseBoolFromDigit(attrib);
                    break;
                case MORPH_ATTRIB:
                    tag.Ratio = ushort.Parse(attrib.Value);
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
                case "hasImage":
                    tag.HasImage = CommonFormatter.ParseBool(attrib.Value);
                    break;
                case BITMAP_CACHING_ATTRIB:
                    tag.BitmapCache = byte.Parse(attrib.Value);
                    break;
                default:
                    return false;
            }
            return true;
        }

        protected override bool AcceptPlaceTagElement(PlaceObject3Tag tag, XElement element) {
            switch (element.Name.LocalName) {
                case "filters":
                    foreach (var xFilter in element.Elements()) {
                        tag.Filters.Add(XFilter.FromXml(xFilter));
                    }
                    break;
                case "events":
                    tag.HasClipActions = true;
                    XClipActionsList.FromXml(element, tag.ClipActions);
                    break;
                case "colorTransform":
                    tag.ColorTransform = XColorTransformRGBA.FromXml(element.Element("ColorTransform2"));
                    break;
                default:
                    return false;
            }
            return true;
        }

        protected override void FormatPlaceElement(PlaceObject3Tag tag, XElement elem) {
            if (tag.Name != null) {
                elem.Add(new XAttribute("name", tag.Name));
            }
            if (tag.ClassName != null) {
                elem.Add(new XAttribute("className", tag.ClassName));
            }
            if (tag.HasClipActions) {
                var flags1 = XClipEventFlags.GetFlags1(tag.ClipActions.Flags);
                var flags2 = XClipEventFlags.GetFlags2(tag.ClipActions.Flags);
                elem.Add(new XAttribute("allflags1", flags1));
                elem.Add(new XAttribute("allflags2", flags2));
            }
            if (tag.Ratio.HasValue) {
                elem.Add(new XAttribute("morph", tag.Ratio.Value));
            }
            elem.Add(new XAttribute("replace", CommonFormatter.Format(tag.Move)));
            elem.Add(new XAttribute("hasImage", CommonFormatter.Format(tag.HasImage)));
            if (tag.BitmapCache.HasValue) {
                elem.Add(new XAttribute(BITMAP_CACHING_ATTRIB, tag.BitmapCache.Value));
            }
            if (tag.ColorTransform.HasValue) {
                elem.Add(new XElement("colorTransform", XColorTransformRGBA.ToXml(tag.ColorTransform.Value)));
            }
            if (tag.Filters.Count > 0) {
                var xFilters = new XElement("filters");
                foreach (var filter in tag.Filters) {
                    xFilters.Add(XFilter.ToXml(filter));
                }
                elem.Add(xFilters);
            }
            if (tag.HasClipActions) {
                elem.Add(XClipActionsList.ToXml(tag.ClipActions));
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
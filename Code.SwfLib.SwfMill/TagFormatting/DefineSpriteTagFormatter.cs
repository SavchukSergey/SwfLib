using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Code.SwfLib.Tags;

namespace Code.SwfLib.SwfMill.TagFormatting {
    public class DefineSpriteTagFormatter : TagFormatterBase<DefineSpriteTag> {
        private readonly ushort _version;
        private readonly TagFormatterFactory _subFormatterFactory;

        private const string OBJECT_ID_ATTRIB = "objectID";
        private const string FRAMES_ATTRIB = "frames";
        private const string TAGS_ELEMENTS = "tags";

        public DefineSpriteTagFormatter(ushort version) {
            _version = version;
            _subFormatterFactory = new TagFormatterFactory(version);
        }

        public override void AcceptAttribute(DefineSpriteTag tag, XAttribute attrib) {
            switch (attrib.Name.LocalName) {
                case OBJECT_ID_ATTRIB:
                    tag.SpriteID = ushort.Parse(attrib.Value);
                    break;
                case FRAMES_ATTRIB:
                    tag.FramesCount = ushort.Parse(attrib.Value);
                    break;
                default:
                    throw new FormatException("Invalid attribute " + attrib.Name.LocalName);
            }
        }

        public override void AcceptElement(DefineSpriteTag tag, XElement element) {
            switch (element.Name.LocalName) {
                case TAGS_ELEMENTS:
                    ReadTags(tag, element);
                    break;
                default:
                    throw new FormatException("Invalid element " + element.Name.LocalName);
            }
        }

        public override XElement FormatTag(DefineSpriteTag tag) {
            return new XElement(XName.Get(SwfTagNameMapping.DEFINE_SPRITE_TAG),
                               new XAttribute(XName.Get("objectID"), tag.SpriteID),
                               new XAttribute(XName.Get("frames"), tag.FramesCount),
                               new XElement(XName.Get("tags"), tag.Tags.Select(item => BuildTagXml(item))));
        }

        private static void ReadTags(DefineSpriteTag tag, XElement tagsElement)
        {
            //TODO: Implement
        }

        protected XElement BuildTagXml(SwfTagBase tag) {
            var subFormatter = _subFormatterFactory.GetFormatter(tag);
            return subFormatter.FormatTag(tag);
        }
    }
}

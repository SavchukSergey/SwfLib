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

        public DefineSpriteTagFormatter(ushort version) {
            _version = version;
            _subFormatterFactory = new TagFormatterFactory(version);
        }

        public override void AcceptAttribute(DefineSpriteTag tag, XAttribute attrib) {
            switch (attrib.Name.LocalName) {
                default:
                    throw new FormatException("Invalid attribute " + attrib.Name.LocalName);
            }
        }

        public override void AcceptElement(DefineSpriteTag tag, XElement element) {
            switch (element.Name.LocalName) {
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

        protected XElement BuildTagXml(SwfTagBase tag) {
            var subFormatter = _subFormatterFactory.GetFormatter(tag);
            return subFormatter.FormatTag(tag);
        }
    }
}

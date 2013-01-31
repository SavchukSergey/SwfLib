using System;
using System.Linq;
using System.Xml.Linq;
using Code.SwfLib.Tags;

namespace Code.SwfLib.SwfMill.TagFormatting {
    public class DefineSpriteTagFormatter : TagFormatterBase<DefineSpriteTag> {
        private readonly ushort _version;
        private readonly TagFormatterFactory _subFormatterFactory;

        private const string FRAMES_ATTRIB = "frames";
        private const string TAGS_ELEMENTS = "tags";

        public DefineSpriteTagFormatter(ushort version) {
            _version = version;
            _subFormatterFactory = new TagFormatterFactory(version);
        }

        protected override void AcceptTagAttribute(DefineSpriteTag tag, XAttribute attrib) {
            switch (attrib.Name.LocalName) {
                case FRAMES_ATTRIB:
                    tag.FramesCount = ushort.Parse(attrib.Value);
                    break;
                default:
                    throw new FormatException("Invalid attribute " + attrib.Name.LocalName);
            }
        }

        protected override void AcceptTagElement(DefineSpriteTag tag, XElement element) {
            switch (element.Name.LocalName) {
                case TAGS_ELEMENTS:
                    ReadTags(tag, element);
                    break;
                default:
                    throw new FormatException("Invalid element " + element.Name.LocalName);
            }
        }

        protected override void FormatTagElement(DefineSpriteTag tag, XElement xTag) {
            xTag.Add(new XAttribute(XName.Get("frames"), tag.FramesCount));
            xTag.Add(new XElement(XName.Get("tags"), tag.Tags.Select(BuildTagXml)));
        }

        private static void ReadTags(DefineSpriteTag tag, XElement tagsElement) {
            //TODO: Transfer version here
            var formatterFactory = new TagFormatterFactory(10);
            foreach (var tagElem in tagsElement.Elements()) {
                var subTag = SwfTagNameMapping.CreateTagByXmlName(tagElem.Name.LocalName);
                var formatter = formatterFactory.GetFormatter(subTag);
                formatter.InitTag(subTag, tagElem);
                foreach (var attrib in tagElem.Attributes()) {
                    formatter.AcceptAttribute(subTag, attrib);
                }
                foreach (var elem in tagElem.Elements()) {
                    formatter.AcceptElement(subTag, elem);
                }
                tag.Tags.Add(subTag);
            }

        }

        protected XElement BuildTagXml(SwfTagBase tag) {
            var subFormatter = _subFormatterFactory.GetFormatter(tag);
            return subFormatter.FormatTag(tag);
        }

        public override string TagName {
            get { return "DefineSprite"; }
        }

        protected override ushort? GetObjectID(DefineSpriteTag tag) {
            return tag.SpriteID;
        }

        protected override void SetObjectID(DefineSpriteTag tag, ushort value) {
            tag.SpriteID = value;
        }
    }
}

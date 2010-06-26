using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Code.SwfLib.Tags.ControlTags;

namespace Code.SwfLib.SwfMill.TagFormatting.ControlTags {
    public class MetadataTagFormatter : TagFormatterBase<MetadataTag> {


        public override void InitTag(MetadataTag tag, XElement element) {
            base.InitTag(tag, element);
            var val = element.Value.Trim();
            if (!string.IsNullOrEmpty(val)) {
                tag.Metadata = val;
            }
        }

        public override void AcceptAttribute(MetadataTag tag, XAttribute attrib) {
            switch (attrib.Name.LocalName) {
                default:
                    throw new FormatException("Invalid attribute " + attrib.Name.LocalName);
            }
        }

        //TODO:value can come as a text not an xml and though won't get here.

        public override void AcceptElement(MetadataTag tag, XElement element) {
            switch (element.Name.LocalName) {
                case "RDF":
                    tag.Metadata = element.ToString();
                    break;
                default:
                    throw new FormatException("Invalid element " + element.Name.LocalName);
            }
        }

        public override XElement FormatTag(MetadataTag tag) {
            return new XElement(XName.Get(SwfTagNameMapping.METADATA_TAG), tag.Metadata);
        }
    }
}
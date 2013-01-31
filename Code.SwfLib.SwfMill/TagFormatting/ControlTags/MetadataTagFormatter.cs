﻿using System;
using System.Xml.Linq;
using Code.SwfLib.Tags.ControlTags;

namespace Code.SwfLib.SwfMill.TagFormatting.ControlTags {
    public class MetadataTagFormatter : TagFormatterBase<MetadataTag> {

        protected override void FormatTagElement(MetadataTag tag, XElement xTag) {
            xTag.Add(XElement.Parse(tag.Metadata));
        }

        public override void InitTag(MetadataTag tag, XElement element) {
            base.InitTag(tag, element);
            var val = element.Value.Trim();
            if (!string.IsNullOrEmpty(val)) {
                tag.Metadata = val;
            }
        }

        //TODO:value can come as a text not an xml and though won't get here.

        protected override void AcceptTagElement(MetadataTag tag, XElement element) {
            switch (element.Name.LocalName) {
                case "RDF":
                    tag.Metadata = element.ToString();
                    break;
                default:
                    throw new FormatException("Invalid element " + element.Name.LocalName);
            }
        }

        public override string TagName {
            get { return "Metadata"; }
        }
    }
}
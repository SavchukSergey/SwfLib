using System;
using System.IO;
using System.Xml.Linq;
using SwfLib.Avm2;
using SwfLib.SwfMill.Data;
using SwfLib.SwfMill.Data.Avm2;
using SwfLib.Tags.ActionsTags;

namespace SwfLib.SwfMill.TagFormatting.ActionTags {
    public class DoABCTagFormatter : TagFormatterBase<DoABCTag> {

        protected override void FormatTagElement(DoABCTag tag, XElement xTag) {
            xTag.Add(new XAttribute("flags", tag.Flags));
            xTag.Add(new XAttribute("name", tag.Name));
            xTag.Add(new XElement("abc", FormatBase64(tag.ABCData)));

            var reader = new AbcReader(new SwfStreamReader(new MemoryStream(tag.ABCData)));
            var info = reader.ReadAbcFile();
            xTag.Add(XAbcFile.ToXml(info));
        }

        protected override bool AcceptTagAttribute(DoABCTag tag, XAttribute attrib) {
            switch (attrib.Name.LocalName) {
                case "flags":
                    tag.Flags = uint.Parse(attrib.Value);
                    break;
                case "name":
                    tag.Name = attrib.Value;
                    break;
                default:
                    return false;
            }
            return true;
        }

        protected override bool AcceptTagElement(DoABCTag tag, XElement element) {
            switch (element.Name.LocalName) {
                case "abc":
                    tag.ABCData = ParseBase64(element.Value);
                    return true;
                case XAbcFile.TAG_NAME:
                    return true;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Gets xml element name.
        /// </summary>
        public override string TagName {
            get { return "DoABCDefine"; }
        }

    }
}

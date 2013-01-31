using System;
using System.Xml.Linq;
using Code.SwfLib.SwfMill.Data;
using Code.SwfLib.Tags.BitmapTags;

namespace Code.SwfLib.SwfMill.TagFormatting.BitmapTags {
    public class JPEGTablesTagFormatter : TagFormatterBase<JPEGTablesTag> {
        
        protected override void FormatTagElement(JPEGTablesTag tag, XElement xTag) {
            xTag.Add(new XElement("data", XBinary.ToXml(tag.JPEGData))); 
        }

        protected override void AcceptTagAttribute(JPEGTablesTag tag, XAttribute attrib) {
        }

        protected override void AcceptTagElement(JPEGTablesTag tag, XElement element) {
            switch (element.Name.LocalName) {
                case "data":
                    tag.JPEGData = XBinary.FromXml(element.Element("data"));
                    break;
                default:
                    throw new FormatException("Invalid element " + element.Name.LocalName);
            }
        }

        public override string TagName {
            get { return "JPEGTables"; }
        }
    }
}

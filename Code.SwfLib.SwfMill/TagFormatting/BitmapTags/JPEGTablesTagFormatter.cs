using System;
using System.Xml.Linq;
using Code.SwfLib.SwfMill.Data;
using Code.SwfLib.Tags.BitmapTags;

namespace Code.SwfLib.SwfMill.TagFormatting.BitmapTags {
    public class JPEGTablesTagFormatter : TagFormatterBase<JPEGTablesTag> {

        protected override void FormatTagElement(JPEGTablesTag tag, XElement xTag) {
        }

        protected override bool AcceptTagElement(JPEGTablesTag tag, XElement element) {
            switch (element.Name.LocalName) {
                case "data":
                    tag.JPEGData = XBinary.FromXml(element.Element("data"));
                    break;
                default:
                    return false;
            }
            return true;
        }

        protected override byte[] GetData(JPEGTablesTag tag) {
            return tag.JPEGData;
        }

        public override string TagName {
            get { return "JPEGTables"; }
        }
    }
}

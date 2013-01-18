using System.Xml.Linq;
using Code.SwfLib.Tags.BitmapTags;

namespace Code.SwfLib.SwfMill.TagFormatting.BitmapTags {
    public class JPEGTablesTagFormatter : TagFormatterBase<JPEGTablesTag> {
        public override XElement FormatTag(JPEGTablesTag tag) {
            throw new System.NotImplementedException();
        }

        public override void AcceptAttribute(JPEGTablesTag tag, XAttribute attrib) {
            throw new System.NotImplementedException();
        }

        public override void AcceptElement(JPEGTablesTag tag, XElement element) {
            throw new System.NotImplementedException();
        }
    }
}

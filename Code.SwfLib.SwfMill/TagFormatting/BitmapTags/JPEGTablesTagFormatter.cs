using System.Xml.Linq;
using Code.SwfLib.Tags.BitmapTags;

namespace Code.SwfLib.SwfMill.TagFormatting.BitmapTags {
    public class JPEGTablesTagFormatter : TagFormatterBase<JPEGTablesTag> {
        protected override XElement FormatTagElement(JPEGTablesTag tag, XElement xTag) {
            throw new System.NotImplementedException();
        }

        protected override void AcceptTagAttribute(JPEGTablesTag tag, XAttribute attrib) {
            throw new System.NotImplementedException();
        }

        protected override void AcceptTagElement(JPEGTablesTag tag, XElement element) {
            throw new System.NotImplementedException();
        }
    }
}

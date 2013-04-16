using System.Xml.Linq;
using Code.SwfLib.Tags.BitmapTags;

namespace Code.SwfLib.SwfMill.TagFormatting.BitmapTags {
    public class JPEGTablesTagFormatter : TagFormatterBase<JPEGTablesTag> {

        protected override void FormatTagElement(JPEGTablesTag tag, XElement xTag) {
        }

        protected override byte[] GetData(JPEGTablesTag tag) {
            return tag.JPEGData;
        }

        protected override void SetData(JPEGTablesTag tag, byte[] data) {
            tag.JPEGData = data;
        }

        public override string TagName {
            get { return "JPEGTables"; }
        }
    }
}

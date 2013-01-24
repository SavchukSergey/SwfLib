using System.Xml.Linq;
using Code.SwfLib.SwfMill.Shapes;
using Code.SwfLib.Tags.ShapeTags;

namespace Code.SwfLib.SwfMill.TagFormatting.ShapeTags {
    public class DefineShape2TagFormatter : DefineShapeBaseFormatter<DefineShape2Tag> {

        protected override void FormatFillStyles(DefineShape2Tag tag, XElement xFillStyles) {
            foreach (var style in tag.FillStyles) {
                xFillStyles.Add(FormatFillStyle(style));
            }
        }

        protected override void FormatLineStyles(DefineShape2Tag tag, XElement xLineStyles) {
            foreach (var style in tag.LineStyles) {
                xLineStyles.Add(XLineStyleRGB.ToXml(style));
            }
        }

        protected override void AcceptShapeTagElement(DefineShape2Tag tag, XElement element) {
        }

        public override string TagName {
            get { return "DefineShape2"; }
        }
    }
}

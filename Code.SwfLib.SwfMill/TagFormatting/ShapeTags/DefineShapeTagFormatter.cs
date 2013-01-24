using System;
using System.Xml.Linq;
using Code.SwfLib.SwfMill.Shapes;
using Code.SwfLib.Tags.ShapeTags;

namespace Code.SwfLib.SwfMill.TagFormatting.ShapeTags {
    public class DefineShapeTagFormatter : DefineShapeBaseFormatter<DefineShapeTag> {

        private const string STYLES_ELEM = "styles";

        protected override void FormatFillStyles(DefineShapeTag tag, XElement xFillStyles) {
            foreach (var style in tag.FillStyles) {
                xFillStyles.Add(FormatFillStyle(style));
            }
        }

        protected override void FormatLineStyles(DefineShapeTag tag, XElement xLineStyles) {
            foreach (var style in tag.LineStyles) {
                xLineStyles.Add(XLineStyleRGB.ToXml(style));
            }
        }

        protected override void AcceptShapeTagElement(DefineShapeTag tag, XElement element) {
            switch (element.Name.LocalName) {
                case STYLES_ELEM:
                    ReadStyles(tag, element);
                    break;
                default:
                    throw new FormatException("Invalid xRecords " + element.Name.LocalName);
            }
        }

        private static void ReadStyles(DefineShapeTag tag, XElement styleElements) {
            var array = styleElements.Element(XName.Get("StyleList"));
            var fillStyles = array.Element("fillStyles");
            //TODO: line styles

            foreach (var styleElem in fillStyles.Elements()) {
                FillStyleRGB fillStyle;
                _formatters.FillStyleRGB.Parse(styleElem, out fillStyle);
                tag.FillStyles.Add(fillStyle);
            }
        }

        //TODO: Simulate swfmill ShapeSetup struct bug

        protected override string TagName {
            get { return "DefineShape"; }
        }


    }
}
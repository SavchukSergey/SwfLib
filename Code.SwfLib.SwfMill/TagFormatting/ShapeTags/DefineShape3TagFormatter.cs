using System;
using System.Xml.Linq;
using Code.SwfLib.Tags.ShapeTags;

namespace Code.SwfLib.SwfMill.TagFormatting.ShapeTags {
    public class DefineShape3TagFormatter : DefineShapeBaseFormatter<DefineShape3Tag> {

        private const string STYLES_ELEM = "styles";
        private const string SHAPES_ELEM = "shapes";

        protected override void FormatFillStyles(DefineShape3Tag tag, XElement xFillStyles) {
            foreach (var style in tag.FillStyles) {
                xFillStyles.Add(FormatFillStyle(style));
            }
        }

        protected override void FormatLineStyles(DefineShape3Tag tag, XElement xLineStyles) {
            foreach (var style in tag.LineStyles) {
                xLineStyles.Add(FormatLineStyle(style));
            }
        }

        protected override void FormatShapeElement(DefineShape3Tag tag, XElement elem) {
        }

        protected override void AcceptShapeTagElement(DefineShape3Tag tag, XElement element) {
            switch (element.Name.LocalName) {
                case STYLES_ELEM:
                    ReadStyles(tag, element);
                    break;
                case SHAPES_ELEM:
                    ReadShapes(tag, element);
                    break;
                default:
                    throw new FormatException("Invalid element " + element.Name.LocalName);
            }
        }

        protected override string TagName {
            get { return SwfTagNameMapping.DEFINE_SHAPE3_TAG; }
        }

        private static void ReadStyles(DefineShape3Tag tag, XElement styleElements) {
            //TODO: Implement styles reading;
        }

        private static void ReadShapes(DefineShape3Tag tag, XElement shapes) {
            //TODO: Implement shapes reading;
        }

    }
}
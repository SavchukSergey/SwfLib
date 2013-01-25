using System.Collections.Generic;
using System.Xml.Linq;
using Code.SwfLib.Tags.ShapeTags;

namespace Code.SwfLib.SwfMill.Shapes {
    public static class XStyleList {

        public static XElement ToXml(IList<FillStyleRGB> fillStyles, IList<LineStyleRGB> lineStyles) {
            var xStyleList = new XElement("StyleList");

            var xFillStyles = new XElement("fillStyles");
            xStyleList.Add(xFillStyles);

            var xLineStyles = new XElement("lineStyles");
            xStyleList.Add(xLineStyles);

            foreach (var fillStyle in fillStyles) {
                xFillStyles.Add(XFillStyleRGB.ToXml(fillStyle));
            }
            foreach (var lineStyle in lineStyles) {
                xLineStyles.Add(XLineStyleRGB.ToXml(lineStyle));
            }

            return xStyleList;


        }

        public static object ToXml(IList<FillStyleRGBA> fillStyles, IList<LineStyleRGBA> lineStyles) {
            var xStyleList = new XElement("StyleList");

            var xFillStyles = new XElement("fillStyles");
            xStyleList.Add(xFillStyles);

            var xLineStyles = new XElement("lineStyles");
            xStyleList.Add(xLineStyles);

            foreach (var fillStyle in fillStyles) {
                xFillStyles.Add(XFillStyleRGBA.ToXml(fillStyle));
            }
            foreach (var lineStyle in lineStyles) {
                xLineStyles.Add(XLineStyleRGBA.ToXml(lineStyle));
            }

            return xStyleList;
        }

        public static XElement ToXml(IList<FillStyleRGBA> fillStyles, IList<LineStyleEx> lineStyles) {
            var xStyleList = new XElement("StyleList");

            var xFillStyles = new XElement("fillStyles");
            xStyleList.Add(xFillStyles);

            var xLineStyles = new XElement("lineStyles");
            xStyleList.Add(xLineStyles);

            foreach (var fillStyle in fillStyles) {
                xFillStyles.Add(XFillStyleRGBA.ToXml(fillStyle));
            }
            foreach (var lineStyle in lineStyles) {
                xLineStyles.Add(XLineStyleEx.ToXml(lineStyle));
            }

            return xStyleList;
        }

    }
}

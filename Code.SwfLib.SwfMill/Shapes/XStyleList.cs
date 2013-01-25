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

        public static XElement ToXml(IList<FillStyleRGBA> fillStyles, IList<LineStyleRGBA> lineStyles) {
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

        public static void FromXml(XElement xStyleList, IList<FillStyleRGB> fillStyles, IList<LineStyleRGB> lineStyles) {
            var xFillStyles = xStyleList.Element("fillStyles");
            foreach (var xFillStyle in xFillStyles.Elements()) {
                var fillStyle = XFillStyleRGB.FromXml(xFillStyle);
                fillStyles.Add(fillStyle);
            }

            var xLineStyles = xStyleList.Element("lineStyles");
            foreach (var xLineStyle in xLineStyles.Elements()) {
                var fillStyle = XLineStyleRGB.FromXml(xLineStyle);
                fillStyles.Add(fillStyle);
            }
        }

        public static void FromXml(XElement xStyleList, IList<FillStyleRGBA> fillStyles, IList<LineStyleRGBA> lineStyles) {
            var xFillStyles = xStyleList.Element("fillStyles");
            foreach (var xFillStyle in xFillStyles.Elements()) {
                var fillStyle = XFillStyleRGBA.FromXml(xFillStyle);
                fillStyles.Add(fillStyle);
            }

            var xLineStyles = xStyleList.Element("lineStyles");
            foreach (var xLineStyle in xLineStyles.Elements()) {
                var fillStyle = XLineStyleRGBA.FromXml(xLineStyle);
                fillStyles.Add(fillStyle);
            }
        }

        public static void FromXml(XElement xStyleList, IList<FillStyleRGBA> fillStyles, IList<LineStyleEx> lineStyles) {
            var xFillStyles = xStyleList.Element("fillStyles");
            foreach (var xFillStyle in xFillStyles.Elements()) {
                var fillStyle = XFillStyleRGBA.FromXml(xFillStyle);
                fillStyles.Add(fillStyle);
            }

            var xLineStyles = xStyleList.Element("lineStyles");
            foreach (var xLineStyle in xLineStyles.Elements()) {
                var fillStyle = XLineStyleEx.FromXml(xLineStyle);
                fillStyles.Add(fillStyle);
            }
        }
    }
}

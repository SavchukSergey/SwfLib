using System.Collections.Generic;
using System.Xml.Linq;
using Code.SwfLib.Shapes.FillStyles;
using Code.SwfLib.Shapes.LineStyles;
using Code.SwfLib.SwfMill.Shapes;
using Code.SwfLib.SwfMill.Utils;
using SwfLib.Shapes.FillStyles;
using SwfLib.Shapes.LineStyles;

namespace SwfLib.SwfMill.Shapes {
    public static class XStyleList {

        public static XElement ToXml(IList<FillStyleRGB> fillStyles, IList<LineStyleRGB> lineStyles) {
            var xStyleList = new XElement("StyleList");

            var xFillStyles = new XElement("fillStyles");
            xStyleList.Add(xFillStyles);

            var xLineStyles = new XElement("lineStyles");
            xStyleList.Add(xLineStyles);

            foreach (var fillStyle in fillStyles) {
                xFillStyles.Add(XFillStyle.ToXml(fillStyle));
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
                xFillStyles.Add(XFillStyle.ToXml(fillStyle));
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
                xFillStyles.Add(XFillStyle.ToXml(fillStyle));
            }
            foreach (var lineStyle in lineStyles) {
                xLineStyles.Add(XLineStyleEx.ToXml(lineStyle));
            }

            return xStyleList;
        }

        public static void FromXml(XElement xStyleList, IList<FillStyleRGB> fillStyles, IList<LineStyleRGB> lineStyles) {
            var xFillStyles = xStyleList.RequiredElement("fillStyles");
            foreach (var xFillStyle in xFillStyles.Elements()) {
                var fillStyle = XFillStyle.FromXmlRGB(xFillStyle);
                fillStyles.Add(fillStyle);
            }

            var xLineStyles = xStyleList.RequiredElement("lineStyles");
            foreach (var xLineStyle in xLineStyles.Elements()) {
                var lineStyle = XLineStyleRGB.FromXml(xLineStyle);
                lineStyles.Add(lineStyle);
            }
        }

        public static void FromXml(XElement xStyleList, IList<FillStyleRGBA> fillStyles, IList<LineStyleRGBA> lineStyles) {
            var xFillStyles = xStyleList.RequiredElement("fillStyles");
            foreach (var xFillStyle in xFillStyles.Elements()) {
                var fillStyle = XFillStyle.FromXmlRGBA(xFillStyle);
                fillStyles.Add(fillStyle);
            }

            var xLineStyles = xStyleList.RequiredElement("lineStyles");
            foreach (var xLineStyle in xLineStyles.Elements()) {
                var lineStyle = XLineStyleRGBA.FromXml(xLineStyle);
                lineStyles.Add(lineStyle);
            }
        }

        public static void FromXml(XElement xStyleList, IList<FillStyleRGBA> fillStyles, IList<LineStyleEx> lineStyles) {
            var xFillStyles = xStyleList.RequiredElement("fillStyles");
            foreach (var xFillStyle in xFillStyles.Elements()) {
                var fillStyle = XFillStyle.FromXmlRGBA(xFillStyle);
                fillStyles.Add(fillStyle);
            }

            var xLineStyles = xStyleList.RequiredElement("lineStyles");
            foreach (var xLineStyle in xLineStyles.Elements()) {
                var lineStyle = XLineStyleEx.FromXml(xLineStyle);
                lineStyles.Add(lineStyle);
            }
        }
    }
}

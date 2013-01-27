using System;
using System.Linq;
using System.Xml.Linq;
using Code.SwfLib.Shapes.LineStyles;
using Code.SwfLib.SwfMill.Data;
using Code.SwfLib.Tags.ShapeTags;

namespace Code.SwfLib.SwfMill.Shapes {
    public class XLineStyleEx {

        public static XElement ToXml(LineStyleEx lineStyle) {
            var res = new XElement("LineStyle",
                new XAttribute("width", lineStyle.Width),
                new XAttribute("startCapStyle", (byte)lineStyle.StartCapStyle),
                new XAttribute("jointStyle", (byte)lineStyle.JoinStyle),
                new XAttribute("hasFill", lineStyle.HasFill ? "1" : "0"),
                new XAttribute("noHScale", lineStyle.NoHScale ? "1" : "0"),
                new XAttribute("noVScale", lineStyle.NoVScale ? "1" : "0"),
                new XAttribute("pixelHinting", lineStyle.PixelHinting ? "1" : "0"),
                new XAttribute("noClose", lineStyle.NoClose ? "1" : "0"),
                new XAttribute("endCapStyle", (byte)lineStyle.EndCapStyle)
                );
            if (lineStyle.Reserved != 0) {
                res.Add(new XAttribute("reserved", lineStyle.Reserved));
            }
            if (lineStyle.JoinStyle == JoinStyle.Miter) {
                res.Add(new XAttribute("miterFactor", CommonFormatter.Format(lineStyle.MilterLimitFactor)));
            }
            if (lineStyle.HasFill) {
                res.Add(new XElement("fillStyle", XFillStyle.ToXml(lineStyle.FillStyle)));
            } else {
                res.Add(new XElement("fillColor", XColorRGBA.ToXml(lineStyle.Color)));
            }
            return res;
        }

        public static LineStyleEx FromXml(XElement xLineStyle) {
            var xWidth = xLineStyle.Attribute("width");
            var xStartCapStyle = xLineStyle.Attribute("startCapStyle");
            var xJointStyle = xLineStyle.Attribute("jointStyle");
            var xHasFill = xLineStyle.Attribute("hasFill");
            var xNoHScale = xLineStyle.Attribute("noHScale");
            var xNoVScale = xLineStyle.Attribute("noVScale");
            var xPixelHinting = xLineStyle.Attribute("pixelHinting");
            var xNoClose = xLineStyle.Attribute("noClose");
            var xEndCapStyle = xLineStyle.Attribute("endCapStyle");

            var xReserved = xLineStyle.Attribute("reserved");

            var res = new LineStyleEx {
                Width = ushort.Parse(xWidth.Value),
                StartCapStyle = (CapStyle)byte.Parse(xStartCapStyle.Value),
                JoinStyle = (JoinStyle)byte.Parse(xJointStyle.Value),
                HasFill = CommonFormatter.ParseBool(xHasFill.Value),
                NoHScale = CommonFormatter.ParseBool(xNoHScale.Value),
                NoVScale = CommonFormatter.ParseBool(xNoVScale.Value),
                PixelHinting = CommonFormatter.ParseBool(xPixelHinting.Value),
                NoClose = CommonFormatter.ParseBool(xNoClose.Value),
                EndCapStyle = (CapStyle)byte.Parse(xEndCapStyle.Value)
            };

            if (xReserved != null) {
                res.Reserved = byte.Parse(xReserved.Value);
            }

            if (res.JoinStyle == JoinStyle.Miter) {
                var xMiterFactor = xLineStyle.Attribute("miterFactor");
                res.MilterLimitFactor = CommonFormatter.ParseDouble(xMiterFactor.Value);
            }

            var xFillStyle = xLineStyle.Element("fillStyle");
            var xFillColor = xLineStyle.Element("fillColor");
            if (xFillStyle != null) {
                res.FillStyle = XFillStyle.FromXmlRGBA(xFillStyle.Elements().First());
            }
            if (xFillColor != null) {
                res.Color = XColorRGBA.FromXml(xFillColor.Elements().First());
            }
            return res;
        }
    }
}

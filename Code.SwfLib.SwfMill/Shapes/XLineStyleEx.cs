using System;
using System.Xml.Linq;
using Code.SwfLib.SwfMill.Data;
using Code.SwfLib.Tags.ShapeTags;

namespace Code.SwfLib.SwfMill.Shapes {
    public class XLineStyleEx {

        public static XElement ToXml(LineStyleEx lineStyle) {
            var res = new XElement("LineStyle",
                new XAttribute("width", lineStyle.Width),
                new XAttribute("startCapStyle", (byte)lineStyle.StartCapStyle),
                new XAttribute("jointStyle", lineStyle.JoinStyle),
                new XAttribute("hasFill", lineStyle.HasFill ? "1" : "0"),
                new XAttribute("noHScale", lineStyle.NoHScale ? "1" : "0"),
                new XAttribute("noVScale", lineStyle.NoVScale ? "1" : "0"),
                new XAttribute("pixelHinting", lineStyle.PixelHinting ? "1" : "0"),
                new XAttribute("reserved", lineStyle.Reserved),
                new XAttribute("noClose", lineStyle.NoClose ? "1" : "0"),
                new XAttribute("endCapStyle", (byte)lineStyle.EndCapStyle)
                );
            if (lineStyle.JoinStyle == JoinStyle.Miter) {
                res.Add(new XAttribute("miterFactor", lineStyle.MilterLimitFactor));
            }
            if (lineStyle.HasFill) {
                res.Add(new XElement("fillStyle", XFillStyle.ToXml(lineStyle.FillStyle)));
            } else {
                res.Add(new XElement("fillColor", XColorRGBA.ToXml(lineStyle.Color)));
            }
            return res;
        }

        public static LineStyleEx FromXml(XElement xLineStyle) {
            throw new NotImplementedException();
        }
    }
}

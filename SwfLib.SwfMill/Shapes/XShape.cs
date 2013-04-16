using System.Collections.Generic;
using System.Xml.Linq;
using SwfLib.Shapes.Records;
using SwfLib.SwfMill.Utils;

namespace SwfLib.SwfMill.Shapes {
    public class XShape {

        public static XElement ToXml(IList<IShapeRecordRGB> records) {
            var xShape = new XElement("Shape");
            var xEdges = new XElement("edges");

            foreach (var shapeRecord in records) {
                xEdges.Add(XShapeRecord.ToXml(shapeRecord));
            }


            xShape.Add(xEdges);
            return xShape;
        }

        public static XElement ToXml(IList<IShapeRecordRGBA> records) {
            var xShape = new XElement("Shape");
            var xEdges = new XElement("edges");

            foreach (var shapeRecord in records) {
                xEdges.Add(XShapeRecord.ToXml(shapeRecord));
            }


            xShape.Add(xEdges);
            return xShape;
        }

        public static XElement ToXml(IList<IShapeRecordEx> records) {
            var xShape = new XElement("Shape");
            var xEdges = new XElement("edges");

            foreach (var shapeRecord in records) {
                xEdges.Add(XShapeRecord.ToXml(shapeRecord));
            }


            xShape.Add(xEdges);
            return xShape;
        }

        public static void FromXml(XElement xShape, IList<IShapeRecordRGB> records) {
            var xEdges = xShape.RequiredElement("edges");
            foreach (var xShapeRecord in xEdges.Elements()) {
                records.Add(XShapeRecord.RGBFromXml(xShapeRecord));
            }
        }

        public static void FromXml(XElement xShape, IList<IShapeRecordRGBA> records) {
            var xEdges = xShape.RequiredElement("edges");
            foreach (var xShapeRecord in xEdges.Elements()) {
                records.Add(XShapeRecord.RGBAFromXml(xShapeRecord));
            }
        }

        public static void FromXml(XElement xShape, IList<IShapeRecordEx> records) {
            var xEdges = xShape.RequiredElement("edges");
            foreach (var xShapeRecord in xEdges.Elements()) {
                records.Add(XShapeRecord.ExFromXml(xShapeRecord));
            }
        }
    }
}

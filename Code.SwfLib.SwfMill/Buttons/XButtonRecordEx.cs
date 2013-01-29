using System.Xml.Linq;
using Code.SwfLib.Buttons;
using Code.SwfLib.Data;
using Code.SwfLib.SwfMill.Data;
using Code.SwfLib.SwfMill.Filters;

namespace Code.SwfLib.SwfMill.Buttons {
    public static class XButtonRecordEx {

        public static ButtonRecordEx FromXml(XElement xRecord) {
            var res = new ButtonRecordEx();
            var xHitTest = xRecord.Attribute("hitTest");
            var xDown = xRecord.Attribute("down");
            var xOver = xRecord.Attribute("over");
            var xUp = xRecord.Attribute("up");
            var xReserved = xRecord.Attribute("reserved");
            var xBlendMode = xRecord.Attribute("blendMode");

            res.StateHitTest = CommonFormatter.ParseBool(xHitTest.Value);
            res.StateDown = CommonFormatter.ParseBool(xDown.Value);
            res.StateOver = CommonFormatter.ParseBool(xOver.Value);
            res.StateUp = CommonFormatter.ParseBool(xUp.Value);
            if (xReserved != null) {
                res.Reserved = byte.Parse(xReserved.Value);
            }
            res.BlendMode = (BlendMode)byte.Parse(xBlendMode.Value);

            if (!res.IsEndButton) {

                var xObjectId = xRecord.Attribute("objectID");
                res.CharacterID = ushort.Parse(xObjectId.Value);

                var xDepth = xRecord.Attribute("depth");
                res.PlaceDepth = ushort.Parse(xDepth.Value);

                var xMatrix = xRecord.Element("transform").Element("Transform");
                res.PlaceMatrix = XMatrix.FromXml(xMatrix);

                var xColorTransform = xRecord.Element("colorTransform").Element("ColorTransform2");
                res.ColorTransform = XColorTransformRGBA.FromXml(xColorTransform);

                var xFilters = xRecord.Element("filters");
                if (xFilters != null) {
                    foreach (var xFilter in xFilters.Elements()) {
                        res.Filters.Add(XFilter.FromXml(xFilter));
                    }
                }
            }
            return res;
        }

        public static XElement ToXml(ButtonRecordEx record) {
            var res = new XElement("Button",
                new XAttribute("hitTest", CommonFormatter.Format(record.StateHitTest)),
                new XAttribute("down", CommonFormatter.Format(record.StateDown)),
                new XAttribute("over", CommonFormatter.Format(record.StateOver)),
                new XAttribute("up", CommonFormatter.Format(record.StateUp))
            );
            if (record.Reserved != 0) {
                res.Add(new XAttribute("reserved", record.Reserved));
            }
            if (record.BlendMode.HasValue) {
                res.Add(new XAttribute("blendMode", (byte)record.BlendMode));
            }
            if (!record.IsEndButton) {
                res.Add(new XAttribute("objectID", record.CharacterID));
                res.Add(new XAttribute("depth", record.PlaceDepth));

                res.Add(new XElement("transform", XMatrix.ToXml(record.PlaceMatrix)));
                res.Add(new XElement("colorTransform", XColorTransformRGBA.ToXml(record.ColorTransform)));
                if (record.Filters.Count > 0) {
                    var xFilters = new XElement("filters");
                    foreach (var filter in record.Filters) {
                        xFilters.Add(XFilter.ToXml(filter));
                    }
                    res.Add(xFilters);
                }
            }
            return res;
        }
    }
}

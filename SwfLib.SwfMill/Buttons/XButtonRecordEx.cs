using System.Xml.Linq;
using SwfLib.Buttons;
using SwfLib.Data;
using SwfLib.SwfMill.Data;
using SwfLib.SwfMill.Filters;
using SwfLib.SwfMill.Utils;

namespace SwfLib.SwfMill.Buttons {
    public static class XButtonRecordEx {

        public static ButtonRecordEx FromXml(XElement xRecord) {
            var res = new ButtonRecordEx();
            var xReserved = xRecord.Attribute("reserved");
            var xBlendMode = xRecord.Attribute("blendMode");

            res.StateHitTest = xRecord.RequiredBoolAttribute("hitTest");
            res.StateDown = xRecord.RequiredBoolAttribute("down");
            res.StateOver = xRecord.RequiredBoolAttribute("over");
            res.StateUp = xRecord.RequiredBoolAttribute("up");
            if (xReserved != null) {
                res.Reserved = byte.Parse(xReserved.Value);
            }

            if (xBlendMode != null) {
                res.BlendMode = (BlendMode)byte.Parse(xBlendMode.Value);
            }

            if (!res.IsEndButton) {

                res.CharacterID = xRecord.RequiredUShortAttribute("objectID");
                res.PlaceDepth = xRecord.RequiredUShortAttribute("depth");

                var xMatrix = xRecord.RequiredElement("transform").Element(XMatrix.TAG_NAME);
                res.PlaceMatrix = XMatrix.FromXml(xMatrix);

                var xColorTransform = xRecord.RequiredElement("colorTransform").Element("ColorTransform2");
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

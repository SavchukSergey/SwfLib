using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Code.SwfLib.Tags;

namespace Code.SwfLib.SwfMill.TagFormatting {
    public class PlaceObject2TagFormatter : TagFormatterBase<PlaceObject2Tag> {

        public override void AcceptAttribute(PlaceObject2Tag tag, XAttribute attrib) {
            switch (attrib.Name.LocalName) {
                default:
                    throw new FormatException("Invalid attribute " + attrib.Name.LocalName);
            }
        }

        public override void AcceptElement(PlaceObject2Tag tag, XElement element) {
            switch (element.Name.LocalName) {
                default:
                    throw new FormatException("Invalid element " + element.Name.LocalName);
            }
        }

        public override XElement FormatTag(PlaceObject2Tag tag)
        {
            var res = new XElement(XName.Get(SwfTagNameMapping.PLACE_OBJECT2_TAG));
            if (tag.ObjectID.HasValue) {
                res.Add(new XAttribute(XName.Get("objectID"), tag.ObjectID.Value));
            }
            res.Add(new XAttribute(XName.Get("depth"), tag.Depth));
            if (tag.Matrix != null) {
                res.Add(new XElement(XName.Get("transform"), GetTransformXml(tag.Matrix)));
            }
            //TODO: Put other fields
            return res;
        }
    }
}

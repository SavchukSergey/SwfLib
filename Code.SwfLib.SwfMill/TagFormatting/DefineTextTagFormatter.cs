using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Code.SwfLib.Tags;

namespace Code.SwfLib.SwfMill.TagFormatting {
    public class DefineTextTagFormatter : TagFormatterBase<DefineTextTag> {

        public override void AcceptAttribute(DefineTextTag tag, XAttribute attrib) {
            switch (attrib.Name.LocalName) {
                default:
                    throw new FormatException("Invalid attribute " + attrib.Name.LocalName);
            }
        }

        public override void AcceptElement(DefineTextTag tag, XElement element) {
            switch (element.Name.LocalName) {
                default:
                    throw new FormatException("Invalid element " + element.Name.LocalName);
            }
        }

        public override XElement FormatTag(DefineTextTag tag) {
            var res = new XElement(XName.Get(SwfTagNameMapping.DEFINE_TEXT_TAG),
                                   new XAttribute(XName.Get("objectID"), tag.TextID));
            res.Add(new XElement(XName.Get("bounds"), GetRectangleXml(tag.Rectangle)));
            if (tag.Matrix != null) {
                res.Add(new XElement(XName.Get("transform"), GetTransformXml(tag.Matrix)));
            }
            //TODO: remove unnessary nested nodes. Swfmill requires them
            res.Add(new XElement(XName.Get("records"),
                                 new XElement(XName.Get("TextRecord"),
                                              new XElement(XName.Get("records"),
                                                           tag.Records.Entries.Select(item => GetTextRecordEntryXml(item))
                                                  )
                                     )));
            //TODO: Other fields
            return res;
        }
    }
}

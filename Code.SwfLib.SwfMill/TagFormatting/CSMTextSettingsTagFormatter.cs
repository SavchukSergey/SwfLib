using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Code.SwfLib.Tags;

namespace Code.SwfLib.SwfMill.TagFormatting {
    public class CSMTextSettingsTagFormatter : TagFormatterBase<CSMTextSettingsTag> {

        public override void AcceptAttribute(CSMTextSettingsTag tag, XAttribute attrib) {
            switch (attrib.Name.LocalName) {
                default:
                    throw new FormatException("Invalid attribute " + attrib.Name.LocalName);
            }
        }

        public override void AcceptElement(CSMTextSettingsTag tag, XElement element) {
            switch (element.Name.LocalName) {
                default:
                    throw new FormatException("Invalid element " + element.Name.LocalName);
            }
        }

        public override XElement FormatTag(CSMTextSettingsTag tag) {
            return new XElement(XName.Get(SwfTagNameMapping.CSM_TEXT_SETTINGS_TAG),
                                 new XAttribute(XName.Get("objectID"), tag.TextId),
                                 new XAttribute(XName.Get("useFlashType"), tag.UseType),
                                 new XAttribute(XName.Get("gridFit"), tag.GridFit),
                                 new XAttribute(XName.Get("reservedFlags"), tag.ReservedFlags),
                                 new XAttribute(XName.Get("thickness"), tag.Thickness),
                                 new XAttribute(XName.Get("sharpness"), tag.Sharpness),
                //TODO: hide reserved attr
                                 new XAttribute(XName.Get("reserved"), tag.Reserved));
        }
    }
}

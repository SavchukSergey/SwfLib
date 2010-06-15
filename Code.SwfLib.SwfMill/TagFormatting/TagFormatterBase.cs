using System;
using System.Xml.Linq;
using Code.SwfLib.Data;
using Code.SwfLib.Tags;

namespace Code.SwfLib.SwfMill.TagFormatting {
    public abstract class TagFormatterBase<T> : TagFormatterBase where T : SwfTagBase {

        protected T _tag;

        public override void AcceptTag(SwfTagBase tag) {
            _tag = (T)tag;
        }

        public override XElement Format(SwfTagBase tag) {
            return FormatTag((T)tag);
        }

        protected abstract XElement FormatTag(T tag);

    }

    public abstract class TagFormatterBase {

        public abstract XElement Format(SwfTagBase tag);

        public abstract void AcceptTag(SwfTagBase tag);

        public abstract void AcceptAttribute(XAttribute attrib);

        public abstract void AcceptElement(XElement element);

        protected uint SetFlagsValue(uint flags, uint shiftedBitFlags, bool flag) {
            if (flag) {
                return flags | shiftedBitFlags;
            }
            return flags & (~shiftedBitFlags);
        }

        protected bool ParseBoolFromDigit(XAttribute attrib) {
            switch (attrib.Value) {
                case "1":
                    return true;
                case "0":
                    return false;
                default:
                    throw new FormatException("Invalid attribute value");
            }
        }

        protected SwfRGB ParseRGBFromFirstChild(XElement elem) {
            var colorElem = elem.Element(XName.Get("Color"));
            SwfRGB rgb;
            rgb.Red = byte.Parse(colorElem.Attribute(XName.Get("red")).Value);
            rgb.Green = byte.Parse(colorElem.Attribute(XName.Get("green")).Value);
            rgb.Blue = byte.Parse(colorElem.Attribute(XName.Get("blue")).Value);
            return rgb;
        }

    }
}

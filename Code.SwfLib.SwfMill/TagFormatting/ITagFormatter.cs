using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Code.SwfLib.Tags;

namespace Code.SwfLib.SwfMill.TagFormatting {

    public interface ITagFormatter<T> : ITagFormatter where T : SwfTagBase {

        XElement FormatTag(T tag);

        void AcceptAttribute(T tag, XAttribute attrib);

        void AcceptElement(T tag, XElement element);

    }

    public interface ITagFormatter {

        XElement FormatTag(SwfTagBase tag);

        void AcceptAttribute(SwfTagBase tag, XAttribute attrib);

        void AcceptElement(SwfTagBase tag, XElement element);

    }
}

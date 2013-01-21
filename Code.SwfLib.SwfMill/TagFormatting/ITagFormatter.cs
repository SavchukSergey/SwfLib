using System.Xml.Linq;
using Code.SwfLib.Tags;

namespace Code.SwfLib.SwfMill.TagFormatting {

    public interface ITagFormatter<T> : ITagFormatter where T : SwfTagBase {

        void InitTag(T tag, XElement element);

        XElement FormatElement(T tag);

        void AcceptAttribute(T tag, XAttribute attrib);

        void AcceptElement(T tag, XElement element);

    }

    public interface ITagFormatter {

        void InitTag(SwfTagBase tag, XElement element);

        XElement FormatTag(SwfTagBase tag);

        void AcceptAttribute(SwfTagBase tag, XAttribute attrib);

        void AcceptElement(SwfTagBase tag, XElement element);

    }
}

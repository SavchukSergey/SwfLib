using System.Xml.Linq;
using Code.SwfLib.Tags;

namespace Code.SwfLib.SwfMill.TagFormatting {

    public interface ITagFormatter<T> : ITagFormatter where T : SwfTagBase {

        XElement FormatTag(T tag);

        T ParseTo(XElement xTag, T tag);

    }

    public interface ITagFormatter {

        XElement FormatTag(SwfTagBase tag);

        SwfTagBase ParseTo(XElement xTag, SwfTagBase tag);

        string TagName { get; }

    }
}

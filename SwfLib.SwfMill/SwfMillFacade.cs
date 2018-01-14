using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using SwfLib.SwfMill.Data;
using SwfLib.SwfMill.Utils;
using SwfLib.Tags;

namespace SwfLib.SwfMill {
    public class SwfMillFacade {

        private TagFormatterFactory _formatterFactory;

        /// <summary>
        /// Converts to XML.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <returns>Convert SwfFile to xml.</returns>
        public XDocument ConvertToXml(SwfFile file) {
            _formatterFactory = new TagFormatterFactory(file.FileInfo.Version);
            var doc = new XDocument(GetRoot(file));
            doc.Declaration = new XDeclaration("1.0", "utf-8", "yes");
            return doc;
        }

        /// <summary>
        /// Decompresses the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="target">The target.</param>
        public void Decompress(Stream source, Stream target) {
            SwfFile.Decompress(source, target);
        }

        /// <summary>
        /// Compresses the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="target">The target.</param>
        public void Compress(Stream source, Stream target, SwfFormat format) {
            SwfFile.Compress(source,  target, format);
        }

        public SwfFile ReadFromXml(XDocument doc) {
            var root = doc.Root;
            var file = new SwfFile();
            SwfFileInfo fileInfo;
            if (root == null || root.Name.LocalName != "swf") {
                throw new FormatException("Expected swf as root");
            }
            fileInfo.Version = root.RequiredByteAttribute("version");
            if (!Enum.TryParse(root.RequiredAttribute("format"), false, out fileInfo.Format))
            {
                throw new FormatException("Unable to parse file format");
            }
            if (fileInfo.Format == SwfFormat.Unknown)
            {
                throw new FormatException("Unsupported file format");
            }

            fileInfo.FileLength = 0;
            file.FileInfo = fileInfo;

            var hdr = root.RequiredElement("Header");
            file.Header.FrameRate = hdr.RequiredDoubleAttribute("framerate");
            file.Header.FrameCount = hdr.RequiredUShortAttribute("frames");
            file.Header.FrameSize = XRect.FromXml(hdr.RequiredElement("size").Element("Rectangle"));

            var formatterFactory = new TagFormatterFactory(fileInfo.Version);
            var tags = hdr.RequiredElement("tags");
            foreach (var xTag in tags.Elements()) {
                var tag = SwfTagNameMapping.CreateTagByXmlName(xTag.Name.LocalName);
                var formatter = formatterFactory.GetFormatter(tag);
                tag = formatter.ParseTo(xTag, tag);
                file.Tags.Add(tag);
            }
            return file;
        }

        private XElement GetRoot(SwfFile file) {
            return new XElement("swf",
                                new XAttribute("version", file.FileInfo.Version),
                                new XAttribute("format", file.FileInfo.Format.ToString()),
                                GetSwfHeaderXml(file)
                );
        }

        private XElement GetTagsXml(IEnumerable<SwfTagBase> tags) {
            return new XElement("tags", tags.Select(BuildTagXml));
        }

        private XElement BuildTagXml(SwfTagBase tag) {
            var formatter = _formatterFactory.GetFormatter(tag);
            return formatter.FormatTag(tag);
        }


        private XElement GetSwfHeaderXml(SwfFile file) {
            var header = file.Header;
            return new XElement("Header",
                                new XAttribute("framerate", header.FrameRate),
                                new XAttribute("frames", header.FrameCount),
                                new XElement("size", XRect.ToXml(header.FrameSize)),
                                GetTagsXml(file.Tags));
        }

        private static bool IsCompressed(SwfFile file) {
            if (file.FileInfo.Format == SwfFormat.Unknown)
            {
                throw new InvalidOperationException();
            }
            return file.FileInfo.Format != SwfFormat.FWS;
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Code.SwfLib.Tags.ControlTags;

namespace Code.SwfLib.SwfMill.TagFormatting {
    public class FileAttributesTagFormatter : TagFormatterBase<FileAttributesTag> {
        private readonly ushort _version;

        private const string HAS_METADATA_ATTRIB = "hasMetaData";
        private const string ALLOW_ABC_ATTRIB = "allowABC";
        private const string SUPPRESS_CROSSDOMAIN_CACHING_ATTRIB = "suppressCrossDomainCaching";
        private const string SWF_RELATIVE_URLS_ATTRIB = "swfRelativeURLs";
        private const string USE_NETWORK_ATTRIB = "useNetwork";

        public FileAttributesTagFormatter(ushort version) {
            _version = version;
        }

        public override void AcceptAttribute(FileAttributesTag tag, XAttribute attrib) {
            switch (attrib.Name.LocalName) {
                case HAS_METADATA_ATTRIB:
                    tag.Attributes = (SwfFileAttributes)SetFlagsValue((uint)tag.Attributes, (uint)SwfFileAttributes.HasMetadata, ParseBoolFromDigit(attrib));
                    break;
                case ALLOW_ABC_ATTRIB:
                    tag.Attributes = (SwfFileAttributes)SetFlagsValue((uint)tag.Attributes, (uint)SwfFileAttributes.AllowAbc, ParseBoolFromDigit(attrib));
                    break;
                case SUPPRESS_CROSSDOMAIN_CACHING_ATTRIB:
                    tag.Attributes = (SwfFileAttributes)SetFlagsValue((uint)tag.Attributes, (uint)SwfFileAttributes.SupressCrossDomainCaching, ParseBoolFromDigit(attrib));
                    break;
                case SWF_RELATIVE_URLS_ATTRIB:
                    tag.Attributes = (SwfFileAttributes)SetFlagsValue((uint)tag.Attributes, (uint)SwfFileAttributes.SwfRelativeUrls, ParseBoolFromDigit(attrib));
                    break;
                case USE_NETWORK_ATTRIB:
                    tag.Attributes = (SwfFileAttributes)SetFlagsValue((uint)tag.Attributes, (uint)SwfFileAttributes.UseNetwork, ParseBoolFromDigit(attrib));
                    break;
                default:
                    throw new FormatException("Invalid attribute " + attrib.Name.LocalName);
            }
        }

        public override void AcceptElement(FileAttributesTag tag, XElement element) {
            switch (element.Name.LocalName) {
                default:
                    throw new FormatException("Invalid element " + element.Name.LocalName);
            }
        }

        public override XElement FormatTag(FileAttributesTag tag) {
            var res = new XElement(XName.Get(SwfTagNameMapping.FILE_ATTRIBUTES_TAG),
                                    new XAttribute(XName.Get(HAS_METADATA_ATTRIB), CheckFileAttribute(tag.Attributes, SwfFileAttributes.HasMetadata)),
                                    new XAttribute(XName.Get(USE_NETWORK_ATTRIB), CheckFileAttribute(tag.Attributes, SwfFileAttributes.UseNetwork)),
                                    new XAttribute(XName.Get(ALLOW_ABC_ATTRIB), CheckFileAttribute(tag.Attributes, SwfFileAttributes.AllowAbc)),
                                    new XAttribute(XName.Get(SUPPRESS_CROSSDOMAIN_CACHING_ATTRIB), CheckFileAttribute(tag.Attributes, SwfFileAttributes.SupressCrossDomainCaching)),
                                    new XAttribute(XName.Get(SWF_RELATIVE_URLS_ATTRIB), CheckFileAttribute(tag.Attributes, SwfFileAttributes.SwfRelativeUrls))

                 );
            //TODO: other attributes
            if (_version >= 10) {
                res.Add(new XAttribute(XName.Get("useGPU"), CheckFileAttribute(tag.Attributes, SwfFileAttributes.UseGPU)));
                res.Add(new XAttribute(XName.Get("useDirectBlit"),
                                       CheckFileAttribute(tag.Attributes, SwfFileAttributes.UseDirectBlit)));
            }
            return res;
        }

        private static string CheckFileAttribute(SwfFileAttributes all, SwfFileAttributes toTest) {
            return (all & toTest) > 0 ? "1" : "0";
        }


    }
}

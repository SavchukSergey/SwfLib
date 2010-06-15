using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Code.SwfLib.Tags;

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

        public override void AcceptAttribute(XAttribute attrib) {
            switch (attrib.Name.LocalName) {
                case HAS_METADATA_ATTRIB:
                    _tag.Attributes = (SwfFileAttributes)SetFlagsValue((uint)_tag.Attributes, (uint)SwfFileAttributes.HasMetadata, ParseBoolFromDigit(attrib));
                    break;
                case ALLOW_ABC_ATTRIB:
                    _tag.Attributes = (SwfFileAttributes)SetFlagsValue((uint)_tag.Attributes, (uint)SwfFileAttributes.AllowAbc, ParseBoolFromDigit(attrib));
                    break;
                case SUPPRESS_CROSSDOMAIN_CACHING_ATTRIB:
                    _tag.Attributes = (SwfFileAttributes)SetFlagsValue((uint)_tag.Attributes, (uint)SwfFileAttributes.SupressCrossDomainCaching, ParseBoolFromDigit(attrib));
                    break;
                case SWF_RELATIVE_URLS_ATTRIB:
                    _tag.Attributes = (SwfFileAttributes)SetFlagsValue((uint)_tag.Attributes, (uint)SwfFileAttributes.SwfRelativeUrls, ParseBoolFromDigit(attrib));
                    break;
                case USE_NETWORK_ATTRIB:
                    _tag.Attributes = (SwfFileAttributes)SetFlagsValue((uint)_tag.Attributes, (uint)SwfFileAttributes.UseNetwork, ParseBoolFromDigit(attrib));
                    break;
                default:
                    throw new FormatException("Invalid attribute " + attrib.Name.LocalName);
            }
        }

        public override void AcceptElement(XElement element) {
            switch (element.Name.LocalName) {
                default:
                    throw new FormatException("Invalid element " + element.Name.LocalName);
            }
        }

        protected override XElement FormatTag(FileAttributesTag tag) {
            throw new NotImplementedException();
        }
    }
}

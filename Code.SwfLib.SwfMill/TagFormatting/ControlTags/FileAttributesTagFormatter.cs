using System;
using System.Xml.Linq;
using Code.SwfLib.Tags.ControlTags;

namespace Code.SwfLib.SwfMill.TagFormatting.ControlTags {
    public class FileAttributesTagFormatter : TagFormatterBase<FileAttributesTag> {
        private readonly ushort _version;

        private const string HAS_METADATA_ATTRIB = "hasMetaData";
        private const string ALLOW_ABC_ATTRIB = "allowABC";
        private const string SUPPRESS_CROSSDOMAIN_CACHING_ATTRIB = "suppressCrossDomainCaching";
        private const string SWF_RELATIVE_URLS_ATTRIB = "swfRelativeURLs";
        private const string USE_NETWORK_ATTRIB = "useNetwork";
        private const string USE_GPU = "useGPU";
        private const string USE_DIRECT_BLIT = "useDirectBlit";

        public FileAttributesTagFormatter(ushort version) {
            _version = version;
        }

        protected override void AcceptTagAttribute(FileAttributesTag tag, XAttribute attrib) {
            switch (attrib.Name.LocalName) {
                case HAS_METADATA_ATTRIB:
                    tag.HasMetadata = ParseBoolFromDigit(attrib);
                    break;
                case ALLOW_ABC_ATTRIB:
                    tag.AllowAbc = ParseBoolFromDigit(attrib);
                    break;
                case SUPPRESS_CROSSDOMAIN_CACHING_ATTRIB:
                    tag.SupressCrossDomainCaching = ParseBoolFromDigit(attrib);
                    break;
                case SWF_RELATIVE_URLS_ATTRIB:
                    tag.SwfRelativeUrls = ParseBoolFromDigit(attrib);
                    break;
                case USE_NETWORK_ATTRIB:
                    tag.UseNetwork = ParseBoolFromDigit(attrib);
                    break;
                case USE_GPU:
                    tag.UseGPU = SwfMillPrimitives.ParseBoolean(attrib);
                    break;
                case USE_DIRECT_BLIT:
                    tag.UseDirectBlit = SwfMillPrimitives.ParseBoolean(attrib);
                    break;
                default:
                    throw new FormatException("Invalid attribute " + attrib.Name.LocalName);
            }
        }

        protected override void AcceptTagElement(FileAttributesTag tag, XElement element) {
            switch (element.Name.LocalName) {
                default:
                    throw new FormatException("Invalid element " + element.Name.LocalName);
            }
        }

        protected override XElement FormatTagElement(FileAttributesTag tag, XElement xTag) {
            xTag.Add(new XAttribute(XName.Get(HAS_METADATA_ATTRIB), FormatBoolToDigit(tag.HasMetadata)));
            xTag.Add(new XAttribute(XName.Get(USE_NETWORK_ATTRIB), FormatBoolToDigit(tag.UseNetwork)));
            xTag.Add(new XAttribute(XName.Get(ALLOW_ABC_ATTRIB), FormatBoolToDigit(tag.AllowAbc)));
            xTag.Add(new XAttribute(XName.Get(SUPPRESS_CROSSDOMAIN_CACHING_ATTRIB), FormatBoolToDigit(tag.SupressCrossDomainCaching)));
            xTag.Add(new XAttribute(XName.Get(SWF_RELATIVE_URLS_ATTRIB), FormatBoolToDigit(tag.SwfRelativeUrls)));
            if (_version >= 10) {
                xTag.Add(new XAttribute(XName.Get(USE_GPU), FormatBoolToDigit(tag.UseGPU)));
                xTag.Add(new XAttribute(XName.Get(USE_DIRECT_BLIT), FormatBoolToDigit(tag.UseDirectBlit)));
            }
            return xTag;
        }

        private static string CheckFileAttribute(SwfFileAttributes all, SwfFileAttributes toTest) {
            return (all & toTest) > 0 ? "1" : "0";
        }

        protected override string TagName {
            get { return "FileAttributes"; }
        }
    }
}
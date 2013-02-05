using System;
using System.Xml.Linq;
using Code.SwfLib.SwfMill.Data;
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

        protected override bool AcceptTagAttribute(FileAttributesTag tag, XAttribute attrib) {
            switch (attrib.Name.LocalName) {
                case "reserved0":
                    tag.Reserved0 = CommonFormatter.ParseBool(attrib.Value);
                    break;
                case USE_DIRECT_BLIT:
                    tag.UseDirectBlit = SwfMillPrimitives.ParseBoolean(attrib);
                    break;
                case USE_GPU:
                    tag.UseGPU = SwfMillPrimitives.ParseBoolean(attrib);
                    break;
                case HAS_METADATA_ATTRIB:
                    tag.HasMetadata = ParseBoolFromDigit(attrib);
                    break;
                case ALLOW_ABC_ATTRIB:
                    tag.AllowAbc = ParseBoolFromDigit(attrib);
                    break;
                case SUPPRESS_CROSSDOMAIN_CACHING_ATTRIB:
                    tag.SuppressCrossDomainCaching = ParseBoolFromDigit(attrib);
                    break;
                case SWF_RELATIVE_URLS_ATTRIB:
                    tag.SwfRelativeUrls = ParseBoolFromDigit(attrib);
                    break;
                case USE_NETWORK_ATTRIB:
                    tag.UseNetwork = ParseBoolFromDigit(attrib);
                    break;
                case "reserved":
                    tag.Reserved = uint.Parse(attrib.Value);
                    break;
                default:
                    return false;
            }
            return true;
        }

        protected override void FormatTagElement(FileAttributesTag tag, XElement xTag) {
            if (tag.Reserved0) {
                xTag.Add(new XAttribute("reserved0", CommonFormatter.Format(tag.Reserved0)));
            }
            xTag.Add(new XAttribute(USE_DIRECT_BLIT, CommonFormatter.Format(tag.UseDirectBlit)));
            xTag.Add(new XAttribute(USE_GPU, CommonFormatter.Format(tag.UseGPU)));
            xTag.Add(new XAttribute(XName.Get(HAS_METADATA_ATTRIB), CommonFormatter.Format(tag.HasMetadata)));
            xTag.Add(new XAttribute(XName.Get(ALLOW_ABC_ATTRIB), CommonFormatter.Format(tag.AllowAbc)));
            xTag.Add(new XAttribute(XName.Get(SUPPRESS_CROSSDOMAIN_CACHING_ATTRIB), CommonFormatter.Format(tag.SuppressCrossDomainCaching)));
            xTag.Add(new XAttribute(XName.Get(SWF_RELATIVE_URLS_ATTRIB), CommonFormatter.Format(tag.SwfRelativeUrls)));
            xTag.Add(new XAttribute(XName.Get(USE_NETWORK_ATTRIB), CommonFormatter.Format(tag.UseNetwork)));
            if (tag.Reserved != 0) {
                xTag.Add(new XAttribute("reserved", tag.Reserved));
            }
        }


        public override string TagName {
            get { return "FileAttributes"; }
        }
    }
}
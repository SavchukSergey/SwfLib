using System;
using Code.SwfLib.SwfMill.TagFormatting;
using Code.SwfLib.Tags;

namespace Code.SwfLib.SwfMill {
    public class TagFormatterFactory : ISwfTagVisitor {
        private readonly ushort _version;

        private CSMTextSettingsTagFormatter _csmTextSettingsFormatter;
        private FileAttributesTagFormatter _fileAttributesFormatter;
        private ShowFrameTagFormatter _showFrameFormatter;

        public TagFormatterFactory(ushort version) {
            _version = version;
        }

        public ITagFormatter GetFormatter(SwfTagBase tag) {
            return (ITagFormatter)tag.AcceptVistor(this);
        }

        #region ISwfTagVisitor Members

        object ISwfTagVisitor.Visit(CSMTextSettingsTag tag) {
            if (_csmTextSettingsFormatter == null) {
                _csmTextSettingsFormatter = new CSMTextSettingsTagFormatter();
            }
            return _csmTextSettingsFormatter;
        }

        object ISwfTagVisitor.Visit(DefineFontNameTag tag) {
            return new DefineFontNameTagFormatter();
        }

        object ISwfTagVisitor.Visit(DefineSpriteTag tag) {
            return new DefineSpriteTagFormatter(_version);
        }

        object ISwfTagVisitor.Visit(DefineTextTag tag) {
            return new DefineTextTagFormatter();
        }

        object ISwfTagVisitor.Visit(EndTag tag) {
            return new EndTagFormatter();
        }

        object ISwfTagVisitor.Visit(ExportTag tag) {
            return new ExportTagFormatter();
        }

        object ISwfTagVisitor.Visit(FileAttributesTag tag) {
            if (_fileAttributesFormatter == null) {
                _fileAttributesFormatter = new FileAttributesTagFormatter(_version);
            }
            return _fileAttributesFormatter;
        }

        object ISwfTagVisitor.Visit(MetadataTag tag) {
            return new MetadataTagFormatter();
        }

        object ISwfTagVisitor.Visit(PlaceObject2Tag tag) {
            return new PlaceObject2TagFormatter();
        }

        object ISwfTagVisitor.Visit(SetBackgroundColorTag tag) {
            return new SetBackgroundColorTagFormatter();
        }

        object ISwfTagVisitor.Visit(ShowFrameTag tag) {
            if (_showFrameFormatter == null) {
                _showFrameFormatter = new ShowFrameTagFormatter();
            }
            return _showFrameFormatter;
        }

        object ISwfTagVisitor.Visit(SwfTagBase tag) {
            throw new InvalidOperationException("Couldn't create formatter for unregistered tag");
        }

        object ISwfTagVisitor.Visit(UnknownTag tag) {
            return new UnknownTagFormatter();
        }

        #endregion
    }
}

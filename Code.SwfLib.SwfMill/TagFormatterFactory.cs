using System;
using Code.SwfLib.SwfMill.TagFormatting;
using Code.SwfLib.Tags;

namespace Code.SwfLib.SwfMill
{
    public class TagFormatterFactory : ISwfTagVisitor
    {
        private readonly ushort _version;

        private CSMTextSettingsTagFormatter _csmTextSettingsFormatter;
        private DefineBitsJPEG2TagFormatter _defineBitsJpeg2Formatter;
        private DefineEditTextTagFormatter _defineEditTextFormatter;
        private DefineFontAlignZonesTagFormatter _defineFontAlignZonesFormatter;
        private DefineFontNameTagFormatter _defineFontNameFormater;
        private DefineFont3TagFormatter _defineFont3Formater;
        private DefineShapeTagFormatter _defineShapeFormater;
        private FileAttributesTagFormatter _fileAttributesFormatter;
        private ShowFrameTagFormatter _showFrameFormatter;

        public TagFormatterFactory(ushort version)
        {
            _version = version;
        }

        public ITagFormatter GetFormatter(SwfTagBase tag)
        {
            return (ITagFormatter)tag.AcceptVistor(this);
        }

        #region ISwfTagVisitor Members

        object ISwfTagVisitor.Visit(CSMTextSettingsTag tag)
        {
            if (_csmTextSettingsFormatter == null)
            {
                _csmTextSettingsFormatter = new CSMTextSettingsTagFormatter();
            }
            return _csmTextSettingsFormatter;
        }

        public object Visit(DefineBitsJPEG2Tag tag)
        {
            if (_defineBitsJpeg2Formatter == null)
            {
                _defineBitsJpeg2Formatter = new DefineBitsJPEG2TagFormatter();
            }
            return _defineBitsJpeg2Formatter;
        }

        public object Visit(DefineEditTextTag tag)
        {
            if (_defineEditTextFormatter == null)
            {
                _defineEditTextFormatter = new DefineEditTextTagFormatter();
            }
            return _defineEditTextFormatter;
        }

        public object Visit(DefineFont3Tag tag)
        {
            if (_defineFont3Formater == null)
            {
                _defineFont3Formater = new DefineFont3TagFormatter();
            }
            return _defineFont3Formater;
        }

        public object Visit(DefineFontAlignZonesTag tag)
        {
            if (_defineFontAlignZonesFormatter == null)
            {
                _defineFontAlignZonesFormatter = new DefineFontAlignZonesTagFormatter();
            }
            return _defineFontAlignZonesFormatter;
        }

        object ISwfTagVisitor.Visit(DefineFontNameTag tag)
        {
            if (_defineFontNameFormater == null)
            {
                _defineFontNameFormater = new DefineFontNameTagFormatter();
            }
            return _defineFontNameFormater;
        }

        public object Visit(DefineShapeTag tag)
        {
            if (_defineShapeFormater == null)
            {
                _defineShapeFormater = new DefineShapeTagFormatter();
            }
            return _defineShapeFormater;
        }

        object ISwfTagVisitor.Visit(DefineSpriteTag tag)
        {
            return new DefineSpriteTagFormatter(_version);
        }

        object ISwfTagVisitor.Visit(DefineTextTag tag)
        {
            return new DefineTextTagFormatter();
        }

        object ISwfTagVisitor.Visit(EndTag tag)
        {
            return new EndTagFormatter();
        }

        object ISwfTagVisitor.Visit(ExportTag tag)
        {
            return new ExportTagFormatter();
        }

        object ISwfTagVisitor.Visit(FileAttributesTag tag)
        {
            if (_fileAttributesFormatter == null)
            {
                _fileAttributesFormatter = new FileAttributesTagFormatter(_version);
            }
            return _fileAttributesFormatter;
        }

        object ISwfTagVisitor.Visit(MetadataTag tag)
        {
            return new MetadataTagFormatter();
        }

        object ISwfTagVisitor.Visit(PlaceObject2Tag tag)
        {
            return new PlaceObject2TagFormatter();
        }

        object ISwfTagVisitor.Visit(SetBackgroundColorTag tag)
        {
            return new SetBackgroundColorTagFormatter();
        }

        object ISwfTagVisitor.Visit(ShowFrameTag tag)
        {
            if (_showFrameFormatter == null)
            {
                _showFrameFormatter = new ShowFrameTagFormatter();
            }
            return _showFrameFormatter;
        }

        object ISwfTagVisitor.Visit(SwfTagBase tag)
        {
            throw new InvalidOperationException("Couldn't create formatter for unregistered tag");
        }

        object ISwfTagVisitor.Visit(UnknownTag tag)
        {
            return new UnknownTagFormatter();
        }

        #endregion
    }
}

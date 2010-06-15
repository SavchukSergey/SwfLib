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
        private DefineBitsLosslessTagFormatter _defineBitsLosslessFormatter;
        private DefineButton2TagFormatter _defineButton2TagFormatter;
        private DefineEditTextTagFormatter _defineEditTextFormatter;
        private DefineFontAlignZonesTagFormatter _defineFontAlignZonesFormatter;
        private DefineFontNameTagFormatter _defineFontNameFormater;
        private DefineFont3TagFormatter _defineFont3Formater;
        private DefineShapeTagFormatter _defineShapeFormater;
        private DefineShape3TagFormatter _defineShape3Formater;
        private DoActionTagFormatter _doActionTagFormatter;
        private DoInitActionTagFormatter _doInitActionTagFormatter;
        private FileAttributesTagFormatter _fileAttributesFormatter;
        private FrameLabelTagFormater _frameLabelFormatter;
        private PlaceObject2TagFormatter _placeObject2Formatter;
        private PlaceObject3TagFormatter _placeObject3Formatter;
        private RemoveObject2TagFormatter _removeObject2Formatter;
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

        object ISwfTagVisitor.Visit(DefineBitsJPEG2Tag tag)
        {
            if (_defineBitsJpeg2Formatter == null)
            {
                _defineBitsJpeg2Formatter = new DefineBitsJPEG2TagFormatter();
            }
            return _defineBitsJpeg2Formatter;
        }

        object ISwfTagVisitor.Visit(DefineBitsLosslessTag tag)
        {
            if (_defineBitsLosslessFormatter == null)
            {
                _defineBitsLosslessFormatter = new DefineBitsLosslessTagFormatter();
            }
            return _defineBitsLosslessFormatter;
        }

        object ISwfTagVisitor.Visit(DefineButton2Tag tag)
        {
            if (_defineButton2TagFormatter == null)
            {
                _defineButton2TagFormatter = new DefineButton2TagFormatter();
            }
            return _defineButton2TagFormatter;
        }

        object ISwfTagVisitor.Visit(DefineEditTextTag tag)
        {
            if (_defineEditTextFormatter == null)
            {
                _defineEditTextFormatter = new DefineEditTextTagFormatter();
            }
            return _defineEditTextFormatter;
        }

        object ISwfTagVisitor.Visit(DefineFont3Tag tag)
        {
            if (_defineFont3Formater == null)
            {
                _defineFont3Formater = new DefineFont3TagFormatter();
            }
            return _defineFont3Formater;
        }

        object ISwfTagVisitor.Visit(DefineFontAlignZonesTag tag)
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

        object ISwfTagVisitor.Visit(DefineShapeTag tag)
        {
            if (_defineShapeFormater == null)
            {
                _defineShapeFormater = new DefineShapeTagFormatter();
            }
            return _defineShapeFormater;
        }

        object ISwfTagVisitor.Visit(DefineShape3Tag tag)
        {
            if (_defineShape3Formater == null)
            {
                _defineShape3Formater = new DefineShape3TagFormatter();
            }
            return _defineShape3Formater;
        }

        object ISwfTagVisitor.Visit(DefineSpriteTag tag)
        {
            return new DefineSpriteTagFormatter(_version);
        }

        object ISwfTagVisitor.Visit(DefineTextTag tag)
        {
            return new DefineTextTagFormatter();
        }

        object ISwfTagVisitor.Visit(DoActionTag tag)
        {
            if (_doActionTagFormatter == null)
            {
                _doActionTagFormatter = new DoActionTagFormatter();
            }
            return _doActionTagFormatter;
        }

        object ISwfTagVisitor.Visit(DoInitActionTag tag)
        {
            if (_doInitActionTagFormatter == null)
            {
                _doInitActionTagFormatter = new DoInitActionTagFormatter();
            }
            return _doInitActionTagFormatter;
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

        object ISwfTagVisitor.Visit(FrameLabelTag tag)
        {
            if (_frameLabelFormatter == null)
            {
                _frameLabelFormatter = new FrameLabelTagFormater();
            }
            return _frameLabelFormatter;
        }

        object ISwfTagVisitor.Visit(MetadataTag tag)
        {
            return new MetadataTagFormatter();
        }

        object ISwfTagVisitor.Visit(PlaceObject2Tag tag)
        {
            if (_placeObject2Formatter == null)
            {
                _placeObject2Formatter = new PlaceObject2TagFormatter();
            }
            return _placeObject2Formatter;
        }

        object ISwfTagVisitor.Visit(PlaceObject3Tag tag)
        {
            if (_placeObject3Formatter == null)
            {
                _placeObject3Formatter = new PlaceObject3TagFormatter();
            }
            return _placeObject3Formatter;
        }

        object ISwfTagVisitor.Visit(RemoveObject2Tag tag)
        {
            if (_removeObject2Formatter == null)
            {
                _removeObject2Formatter = new RemoveObject2TagFormatter();
            }
            return _removeObject2Formatter;
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

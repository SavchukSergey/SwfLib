using System;
using Code.SwfLib.SwfMill.TagFormatting;
using Code.SwfLib.Tags;

namespace Code.SwfLib.SwfMill {
    public class TagFormatterFactory : ISwfTagVisitor {
        private readonly ushort _version;

        public TagFormatterFactory(ushort version) {
            _version = version;
        }

        public TagFormatterBase GetFormatter(SwfTagBase tag) {
            return (TagFormatterBase)tag.AcceptVistor(this);
        }

        #region ISwfTagVisitor Members

        object ISwfTagVisitor.Visit(CSMTextSettingsTag tag) {
            throw new NotImplementedException();
        }

        object ISwfTagVisitor.Visit(DefineFontNameTag tag) {
            throw new NotImplementedException();
        }

        object ISwfTagVisitor.Visit(DefineSpriteTag tag) {
            throw new NotImplementedException();
        }

        object ISwfTagVisitor.Visit(DefineTextTag tag) {
            throw new NotImplementedException();
        }

        object ISwfTagVisitor.Visit(EndTag tag) {
            return new EndTagFormatter();
        }

        object ISwfTagVisitor.Visit(ExportTag tag) {
            throw new NotImplementedException();
        }

        object ISwfTagVisitor.Visit(FileAttributesTag tag) {
            return new FileAttributesTagFormatter(_version);
        }

        object ISwfTagVisitor.Visit(MetadataTag tag) {
            throw new NotImplementedException();
        }

        object ISwfTagVisitor.Visit(PlaceObject2Tag tag) {
            throw new NotImplementedException();
        }

        object ISwfTagVisitor.Visit(SetBackgroundColorTag tag) {
            return new SetBackgroundColorTagFormatter();
        }

        object ISwfTagVisitor.Visit(ShowFrameTag tag) {
            return new ShowFrameTagFormatter();
        }

        object ISwfTagVisitor.Visit(SwfTagBase tag) {
            throw new NotImplementedException();
        }

        object ISwfTagVisitor.Visit(UnknownTag tag) {
            throw new NotImplementedException();
        }

        #endregion
    }
}

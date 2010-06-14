using System;
using System.Linq;
using System.Xml.Linq;
using Code.SwfLib.Data;
using Code.SwfLib.Tags;

namespace Code.SwfLib.SwfMill {
    public class Tag2XmlVisitor : ISwfTagVisitor {
        private readonly ushort _version;

        public Tag2XmlVisitor(ushort version) {
            _version = version;
        }

        public object Visit(SwfTagBase tag) {
            throw new NotImplementedException();
        }

        public object Visit(CSMTextSettingsTag tag) {
            return new XElement(XName.Get("CSMTextSettings"),
                                new XAttribute(XName.Get("objectID"), tag.TextId),
                                new XAttribute(XName.Get("useFlashType"), tag.UseType),
                                new XAttribute(XName.Get("gridFit"), tag.GridFit),
                                new XAttribute(XName.Get("reservedFlags"), tag.ReservedFlags),
                                new XAttribute(XName.Get("thickness"), tag.Thickness),
                                new XAttribute(XName.Get("sharpness"), tag.Sharpness),
                //TODO: hide reserved attr
                                new XAttribute(XName.Get("reserved"), tag.Reserved));
        }

        public object Visit(DefineFontNameTag tag) {
            return new XElement(XName.Get("DefineFontName"),
                                new XAttribute(XName.Get("objectID"), tag.FontNameId),
                                new XAttribute(XName.Get("name"), tag.DisplayName),
                                new XAttribute(XName.Get("copyright"), tag.Copyright));
        }

        public object Visit(DefineSpriteTag tag) {
            return new XElement(XName.Get("DefineSprite"),
                                new XAttribute(XName.Get("objectID"), tag.SpriteID),
                                new XAttribute(XName.Get("frames"), tag.FramesCount),
                                new XElement(XName.Get("tags"), tag.Tags.Select(item => item.AcceptVistor(this))));
        }

        public object Visit(DefineTextTag tag) {
            var res = new XElement(XName.Get("DefineText"),
                                   new XAttribute(XName.Get("objectID"), tag.TextID));
            res.Add(new XElement(XName.Get("bounds"), GetRectangleXml(tag.Rectangle)));
            if (tag.Matrix != null) {
                res.Add(new XElement(XName.Get("transform"), GetTransformXml(tag.Matrix)));
            }
            //TODO: remove unnessary nested nodes. Swfmill requires them
            res.Add(new XElement(XName.Get("records"),
                                 new XElement(XName.Get("TextRecord"),
                                              new XElement(XName.Get("records"),
                                                           tag.Records.Entries.Select(item => GetTextRecordEntryXml(item))
                                                  )
                                     )));
            //TODO: Other fields
            return res;
        }

        public object Visit(EndTag tag) {
            return new XElement(XName.Get("End"));
        }

        public object Visit(ExportTag tag) {
            return new XElement(XName.Get("Export"),
                                new XElement(XName.Get("symbols"), tag.Symbols.Select(item => GetSymbol(item))));
        }

        public object Visit(FileAttributesTag tag) {
            var res = new XElement(XName.Get("FileAttributes"),
                                   new XAttribute(XName.Get("hasMetaData"), CheckFileAttribute(tag.Attributes, SwfFileAttributes.HasMetadata)),
                                   new XAttribute(XName.Get("useNetwork"), CheckFileAttribute(tag.Attributes, SwfFileAttributes.UseNetwork))
                );
            //TODO: other attributes
            if (_version >= 10) {
                res.Add(new XAttribute(XName.Get("useGPU"), CheckFileAttribute(tag.Attributes, SwfFileAttributes.UseGPU)));
                res.Add(new XAttribute(XName.Get("useDirectBlit"),
                                       CheckFileAttribute(tag.Attributes, SwfFileAttributes.UseDirectBlit)));
            }
            return res;
        }

        public object Visit(MetadataTag tag) {
            return new XElement(XName.Get("Metadata"), tag.Metadata);
        }

        public object Visit(PlaceObject2Tag tag) {
            var res = new XElement(XName.Get("PlaceObject2"));
            if (tag.ObjectID.HasValue) {
                res.Add(new XAttribute(XName.Get("objectID"), tag.ObjectID.Value));
            }
            res.Add(new XAttribute(XName.Get("depth"), tag.Depth));
            if (tag.Matrix != null) {
                res.Add(new XElement(XName.Get("transform"), GetTransformXml(tag.Matrix)));
            }
            //TODO: Put other fields
            return res;
        }

        public object Visit(SetBackgroundColorTag tag) {
            return new XElement(XName.Get("SetBackgroundColor"),
                                new XElement(XName.Get("color"), GetColor(tag.Color)));
        }

        public object Visit(ShowFrameTag tag) {
            return new XElement(XName.Get("ShowFrame"));
        }

        //TODO: Check format
        public object Visit(UnknownTag tag) {
            return new XElement(XName.Get("UnknownTag"),
                                new XAttribute(XName.Get("id"), string.Format("0x{0:x}", (int)tag.RawData.Type)),
                                new XElement(XName.Get("data"), Convert.ToBase64String(tag.RawData.Data
                //, Base64FormattingOptions.InsertLineBreaks
                                                                    )));
        }

        private static string CheckFileAttribute(SwfFileAttributes all, SwfFileAttributes toTest) {
            return (all & toTest) > 0 ? "1" : "0";
        }

        private static XElement GetColor(SwfRGB rgb) {
            return new XElement(XName.Get("Color"),
                                new XAttribute(XName.Get("red"), rgb.Red),
                                new XAttribute(XName.Get("green"), rgb.Green),
                                new XAttribute(XName.Get("blue"), rgb.Blue));
        }

        private static XElement GetSymbol(SwfSymbolReference symbol) {
            return new XElement(XName.Get("Symbol"),
                                new XAttribute(XName.Get("objectID"), symbol.SymbolID),
                                new XAttribute(XName.Get("name"), symbol.SymbolName));
        }

        private static XElement GetTransformXml(SwfMatrix matrix) {
            //TODO: put other fields
            return new XElement(XName.Get("Transform"),
                                new XAttribute(XName.Get("transX"), matrix.TranslateX),
                                new XAttribute(XName.Get("transY"), matrix.TranslateY));
        }

        private static XElement GetRectangleXml(SwfRect rect) {
            return new XElement(XName.Get("Rectangle"),
                                new XAttribute(XName.Get("left"), rect.XMin),
                                new XAttribute(XName.Get("right"), rect.XMax),
                                new XAttribute(XName.Get("top"), rect.YMin),
                                new XAttribute(XName.Get("bottom"), rect.YMax));
        }

        private static XElement GetTextRecordEntryXml(SwfTextRecordEntry entry) {
            if (entry is SwfTextRecordSetupEntry) {
                return GetTextRecordEntryXml((SwfTextRecordSetupEntry)entry);
            }
            if (entry is SwfTextRecordGlyphEntry) {
                return GetTextRecordEntryXml((SwfTextRecordGlyphEntry)entry);
            }
            if (entry is SwfTextRecordEndEntry) {
                return GetTextRecordEntryXml((SwfTextRecordEndEntry)entry);
            }
            throw new InvalidOperationException();
        }

        private static XElement GetTextRecordEntryXml(SwfTextRecordSetupEntry entry) {
            var res = new XElement(XName.Get("TextRecord6"), new XAttribute(XName.Get("isSetup"), "1"));
            if (entry.FontID.HasValue) {
                res.Add(new XAttribute(XName.Get("objectID"), entry.FontID.Value));
            }
            if (entry.MoveX.HasValue) {
                res.Add(new XAttribute(XName.Get("x"), entry.MoveX.Value));
            }
            if (entry.MoveY.HasValue) {
                res.Add(new XAttribute(XName.Get("y"), entry.MoveY.Value));
            }
            if (entry.FontHeight.HasValue) {
                res.Add(new XAttribute(XName.Get("fontHeight"), entry.FontHeight.Value));
            }
            if (entry.RGB.HasValue) {
                res.Add(new XElement(XName.Get("color"), GetColor(entry.RGB.Value)));
            }
            //TODO: other fields
            return res;
        }

        private static XElement GetTextRecordEntryXml(SwfTextRecordGlyphEntry entry) {
            var res = new XElement(XName.Get("TextRecord6"), new XAttribute(XName.Get("isSetup"), "0"));
            res.Add(new XElement(XName.Get("glyphs"), entry.Glyphs.Select(item => GetGlyphXml(item))));
            //TODO: other fields
            return res;
        }

        private static XElement GetTextRecordEntryXml(SwfTextRecordEndEntry entry) {
            var res = new XElement(XName.Get("TextRecord6"), new XAttribute(XName.Get("isSetup"), "0"));
            res.Add(new XElement(XName.Get("glyphs")));
            return res;
        }

        private static XElement GetGlyphXml(SwfTextEntry entry) {
            return new XElement(XName.Get("TextEntry"),
                                new XAttribute(XName.Get("glyph"), entry.Index),
                                new XAttribute(XName.Get("advance"), entry.Advance));
        }
    }
}
using System;
using System.Xml.Linq;
using Code.SwfLib.Filters;

namespace Code.SwfLib.SwfMill.Filters {
    public static class XFilter {

        public class Writer : IFilterVisitor<object, XElement> {

            public XElement Visit(DropShadowFilter filter, object arg) {
                return XDropShadowFilter.ToXml(filter);
            }

            public XElement Visit(BlurFilter filter, object arg) {
                return XBlurFilter.ToXml(filter);
            }

            public XElement Visit(GlowFilter filter, object arg) {
                return XGlowFilter.ToXml(filter);
            }

            //TODO: other filters

            public XElement Visit(BevelFilter filter, object arg) {
                throw new NotImplementedException();
            }

            public XElement Visit(GradientGlowFilter filter, object arg) {
                throw new NotImplementedException();
            }

            public XElement Visit(ConvolutionFilter filter, object arg) {
                throw new NotImplementedException();
            }

            public XElement Visit(ColorMatrixFilter filter, object arg) {
                throw new NotImplementedException();
            }

            public XElement Visit(GradientBevelFilter filter, object arg) {
                throw new NotImplementedException();
            }
        }

        private static readonly Writer _writer = new Writer();

        public static XElement ToXml(BaseFilter filter) {
            return filter.AcceptVisitor(_writer, null);
        }

        public static BaseFilter FromXml(XElement xFilter) {
            switch (xFilter.Name.LocalName) {
                case XDropShadowFilter.TAG_NAME:
                    return XDropShadowFilter.FromXml(xFilter);
                case XBlurFilter.TAG_NAME:
                    return XBlurFilter.FromXml(xFilter);
                case XGlowFilter.TAG_NAME:
                    return XGlowFilter.FromXml(xFilter);
                //TODO: other filters
                default:
                    throw new NotSupportedException();
            }
        }
    }
}

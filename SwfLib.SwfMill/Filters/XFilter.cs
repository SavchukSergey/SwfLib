using System;
using System.Xml.Linq;
using Code.SwfLib.Filters;
using SwfLib.Filters;

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

            public XElement Visit(BevelFilter filter, object arg) {
                return XBevelFilter.ToXml(filter);
            }

            public XElement Visit(GradientGlowFilter filter, object arg) {
                return XGradientGlowFilter.ToXml(filter);
            }

            public XElement Visit(ConvolutionFilter filter, object arg) {
                return XConvolutionFilter.ToXml(filter);
            }

            public XElement Visit(ColorMatrixFilter filter, object arg) {
                return XColorMatrixFilter.ToXml(filter);
            }

            public XElement Visit(GradientBevelFilter filter, object arg) {
                return XGradientBevelFilter.ToXml(filter);
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
                case XBevelFilter.TAG_NAME:
                    return XBevelFilter.FromXml(xFilter);
                case XGradientGlowFilter.TAG_NAME:
                    return XGradientGlowFilter.FromXml(xFilter);
                case XConvolutionFilter.TAG_NAME:
                    return XConvolutionFilter.FromXml(xFilter);
                case XColorMatrixFilter.TAG_NAME:
                    return XColorMatrixFilter.FromXml(xFilter);
                case XGradientBevelFilter.TAG_NAME:
                    return XGradientBevelFilter.FromXml(xFilter);
                default:
                    throw new NotSupportedException();
            }
        }
    }
}

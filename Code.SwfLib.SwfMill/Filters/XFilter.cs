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
    }
}

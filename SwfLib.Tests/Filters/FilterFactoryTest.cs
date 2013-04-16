using Code.SwfLib.Filters;
using NUnit.Framework;
using SwfLib.Filters;

namespace Code.SwfLib.Tests.Filters {
    [TestFixture]
    public class FilterFactoryTest {

        private readonly FilterFactory _factory = new FilterFactory();

        [Test]
        public void DropShadowTest() {
            var filter = _factory.Create(FilterType.DropShadow);
            Assert.AreEqual(FilterType.DropShadow, filter.Type);
            Assert.IsAssignableFrom(typeof(DropShadowFilter), filter);
        }

        [Test]
        public void BlurTest() {
            var filter = _factory.Create(FilterType.Blur);
            Assert.AreEqual(FilterType.Blur, filter.Type);
            Assert.IsAssignableFrom(typeof(BlurFilter), filter);
        }

        [Test]
        public void GlowTest() {
            var filter = _factory.Create(FilterType.Glow);
            Assert.AreEqual(FilterType.Glow, filter.Type);
            Assert.IsAssignableFrom(typeof(GlowFilter), filter);
        }

        [Test]
        public void BevelTest() {
            var filter = _factory.Create(FilterType.Bevel);
            Assert.AreEqual(FilterType.Bevel, filter.Type);
            Assert.IsAssignableFrom(typeof(BevelFilter), filter);
        }

        [Test]
        public void GradientGlowTest() {
            var filter = _factory.Create(FilterType.GradientGlow);
            Assert.AreEqual(FilterType.GradientGlow, filter.Type);
            Assert.IsAssignableFrom(typeof(GradientGlowFilter), filter);
        }

        [Test]
        public void ConvolutionTest() {
            var filter = _factory.Create(FilterType.Convolution);
            Assert.AreEqual(FilterType.Convolution, filter.Type);
            Assert.IsAssignableFrom(typeof(ConvolutionFilter), filter);
        }

        [Test]
        public void ColorMatrixTest() {
            var filter = _factory.Create(FilterType.ColorMatrix);
            Assert.AreEqual(FilterType.ColorMatrix, filter.Type);
            Assert.IsAssignableFrom(typeof(ColorMatrixFilter), filter);
        }

        [Test]
        public void GradientBevelTest() {
            var filter = _factory.Create(FilterType.GradientBevel);
            Assert.AreEqual(FilterType.GradientBevel, filter.Type);
            Assert.IsAssignableFrom(typeof(GradientBevelFilter), filter);
        }
    }
}

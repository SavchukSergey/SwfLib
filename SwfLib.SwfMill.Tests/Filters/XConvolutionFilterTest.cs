using System.Xml.Linq;
using Code.SwfLib.SwfMill.Filters;
using Code.SwfLib.SwfMill.Tests;
using NUnit.Framework;
using SwfLib.Filters;
using SwfLib.Tests.Asserts;

namespace SwfLib.SwfMill.Tests.Filters {
    [TestFixture]
    public class XConvolutionFilterTest {
        private const string ETALON = @"<ConvolutionFilter divisor='15.5' bias='-3.2' reserved='1' clamp='1' preserveAlpha='0'>
    <matrix>
        <r><c>1</c><c>2</c></r>
        <r><c>3</c><c>4</c></r>
        <r><c>5</c><c>6</c></r>
    </matrix>
    <color>
        <Color red='11' green='12' blue='45' alpha='128' />
    </color>
</ConvolutionFilter>";

        [Test]
        public void FromXmlTest() {
            var filter = XConvolutionFilter.FromXml(XElement.Parse(ETALON));
            AssertFilters.AreEqual(GetSample(), filter, "Convolution");
        }

        [Test]
        public void ToXmlTest() {
            var filter = GetSample();
            var xResult = XConvolutionFilter.ToXml(filter);

            var xOriginal = XElement.Parse(ETALON);
            new XmlComparision(Assert.Fail).Compare(xOriginal, xResult);
        }

        private ConvolutionFilter GetSample() {
            return new ConvolutionFilter {
                Divisor = 15.5,
                Bias = -3.2,
                Matrix = new double[,] {{1,2}, {3,4}, {5,6}},
                DefaultColor = { Red = 11, Green = 12, Blue = 45, Alpha = 128 },
                Reserved = 1,
                Clamp = true,
                PreserveAlpha = false
            };
        }
    }
}

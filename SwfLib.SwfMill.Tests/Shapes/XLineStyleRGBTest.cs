using System.Xml.Linq;
using Code.SwfLib.SwfMill.Shapes;
using NUnit.Framework;
using SwfLib.Shapes.LineStyles;
using SwfLib.SwfMill.Tests;
using SwfLib.Tests.Asserts.Shapes;

namespace Code.SwfLib.SwfMill.Tests.Shapes {
    [TestFixture]
    public class XLineStyleRGBTest {

        private const string ETALON = @"<LineStyle width='2'>
    <color>
        <Color red='143' green='96' blue='224' />
    </color>
</LineStyle>";

        [Test]
        public void FormatTest() {
            var lineStyle = GetLineStyle();
            var xLineStyle = XLineStyleRGB.ToXml(lineStyle);
            new XmlComparision(Assert.Fail).Compare(XElement.Parse(ETALON), xLineStyle);
        }

        [Test]
        public void ParseTest() {
            var lineStyle = XLineStyleRGB.FromXml(XElement.Parse(ETALON));
            AssertShape.AreEqual(GetLineStyle(), lineStyle, "lineStyle");
        }

        private static LineStyleRGB GetLineStyle() {
            return new LineStyleRGB { Width = 2, Color = { Red = 143, Green = 96, Blue = 224 } };
        }
    }
}

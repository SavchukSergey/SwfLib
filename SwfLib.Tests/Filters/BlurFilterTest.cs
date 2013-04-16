using Code.SwfLib.Filters;
using Code.SwfLib.Tests.Asserts;
using Code.SwfLib.Tests.Filters;
using NUnit.Framework;
using SwfLib.Tests.Asserts;

namespace SwfLib.Tests.Filters {
    [TestFixture]
    public class BlurFilterTest : BaseFilterTest {

        private static readonly byte[] _etalon = new byte[] {1,
            0, 128, 1, 0, //BlurX
            0, 192, 2, 0, //BlurY,
            47
            };

        [Test]
        public void ReadTest() {
            var filter = ReadFilter<BlurFilter>(_etalon);
            AssertFilters.AreEqual(GetFilter(), filter, "BlurFilter");
        }

        [Test]
        public void WriteTest() {
            WriteFilter(GetFilter(), _etalon);
        }

        private static BlurFilter GetFilter() {
            return new BlurFilter {
                BlurX = 1.5,
                BlurY = 2.75,
                Passes = 5,
                Reserved = 7
            };
        }
    }
}

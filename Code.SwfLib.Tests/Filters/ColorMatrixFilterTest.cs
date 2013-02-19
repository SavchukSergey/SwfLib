using Code.SwfLib.Filters;
using Code.SwfLib.Tests.Asserts;
using NUnit.Framework;

namespace Code.SwfLib.Tests.Filters {
    [TestFixture]
    public class ColorMatrixFilterTest : BaseFilterTest {

        private static readonly byte[] _etalon = new byte[] {6,
            154, 153, 33, 65,
            143, 194, 49, 65,
            133, 235, 65, 65,
            123, 20, 82, 65,
            113, 61, 98, 65,
            154, 153, 161, 65,
            20, 174, 169, 65,
            143, 194, 177, 65,
            10, 215, 185, 65,
            133, 235, 193, 65,
            102, 102, 242, 65,
            225, 122, 250, 65,
            174, 71, 1, 66,
            236, 81, 5, 66,
            41, 92, 9, 66,
            154, 153, 33, 66,
            215, 163, 37, 66,
            20, 174, 41, 66,
            82, 184, 45, 66,
            143, 194, 49, 66
        };

        [Test]
        public void ReadTest() {
            var filter = ReadFilter<ColorMatrixFilter>(_etalon);
            AssertFilters.AreEqual(GetFilter(), filter, "ColorMatrix");
        }

        [Test]
        public void WriteTest() {
            WriteFilter(GetFilter(), _etalon);
        }

        private ColorMatrixFilter GetFilter() {
            return new ColorMatrixFilter {
                R0 = 10.10f,
                R1 = 11.11f,
                R2 = 12.12f,
                R3 = 13.13f,
                R4 = 14.14f,

                G0 = 20.20f,
                G1 = 21.21f,
                G2 = 22.22f,
                G3 = 23.23f,
                G4 = 24.24f,

                B0 = 30.30f,
                B1 = 31.31f,
                B2 = 32.32f,
                B3 = 33.33f,
                B4 = 34.34f,

                A0 = 40.40f,
                A1 = 41.41f,
                A2 = 42.42f,
                A3 = 43.43f,
                A4 = 44.44f
            };
        }
    }
}

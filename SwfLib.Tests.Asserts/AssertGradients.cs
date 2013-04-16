using System.Collections.Generic;
using NUnit.Framework;
using SwfLib.Gradients;

namespace SwfLib.Tests.Asserts {
    public static class AssertGradients {

        public static void AreEqual(GradientRGB expected, GradientRGB actual, string message) {
            AreEqualBase(expected, actual, message);
        }

        public static void AreEqual(GradientRGBA expected, GradientRGBA actual, string message) {
            AreEqualBase(expected, actual, message);
        }

        public static void AreEqual(FocalGradientRGB expected, FocalGradientRGB actual, string message) {
            AreEqualBase(expected, actual, message);
            if (expected != null && actual != null) {
                Assert.AreEqual(expected.FocalPoint, actual.FocalPoint);
            }
        }

        public static void AreEqual(FocalGradientRGBA expected, FocalGradientRGBA actual, string message) {
            AreEqualBase(expected, actual, message);
            if (expected != null && actual != null) {
                Assert.AreEqual(expected.FocalPoint, actual.FocalPoint);
            }
        }

        private static void AreEqualBase(BaseGradientRGB expected, BaseGradientRGB actual, string message) {
            if (expected != null && actual == null) Assert.Fail("Expected non-null gradient");
            if (actual != null && expected == null) Assert.Fail("Expected null gradient");
            if (expected == null && actual == null) return;
            Assert.AreEqual(expected.SpreadMode, actual.SpreadMode, message + ": SpreadMode");
            Assert.AreEqual(expected.InterpolationMode, actual.InterpolationMode, message + ": InterpolationMode");
            Assert.AreEqual(expected.GradientRecords.Count, actual.GradientRecords.Count, message + ": GradientRecords.Count");
            for (var i = 0; i < expected.GradientRecords.Count; i++) {
                var exp = expected.GradientRecords[i];
                var act = actual.GradientRecords[i];
                AreEqual(exp, act, message + ": GradientRecords[" + i + "]");
            }
        }

        private static void AreEqualBase(BaseGradientRGBA expected, BaseGradientRGBA actual, string message) {
            if (expected != null && actual == null) Assert.Fail("Expected non-null gradient");
            if (actual != null && expected == null) Assert.Fail("Expected null gradient");
            if (expected == null && actual == null) return;
            Assert.AreEqual(expected.SpreadMode, actual.SpreadMode, message + ": SpreadMode");
            Assert.AreEqual(expected.InterpolationMode, actual.InterpolationMode, message + ": InterpolationMode");
            Assert.AreEqual(expected.GradientRecords.Count, actual.GradientRecords.Count, message + ": GradientRecords.Count");
            for (var i = 0; i < expected.GradientRecords.Count; i++) {
                var exp = expected.GradientRecords[i];
                var act = actual.GradientRecords[i];
                AreEqual(exp, act, message + ": GradientRecords[" + i + "]");
            }
        }

        public static void AreEqual(GradientRecordRGB expected, GradientRecordRGB actual, string message) {
            Assert.AreEqual(expected.Ratio, actual.Ratio, message + ": Ratio");
            AssertColors.AreEqual(expected.Color, actual.Color, message + ": Color");
        }

        public static void AreEqual(GradientRecordRGBA expected, GradientRecordRGBA actual, string message) {
            Assert.AreEqual(expected.Ratio, actual.Ratio, message + ": Ratio");
            AssertColors.AreEqual(expected.Color, actual.Color, message + ": Color");
        }

        public static void AreEqual(IList<GradientRecordRGBA> expected, IList<GradientRecordRGBA> actual, string message) {
            Assert.AreEqual(expected.Count, actual.Count, message + ".Count");
            for (var i = 0; i < expected.Count; i++) {
                AreEqual(expected[i], actual[i], ".Item[" + i + "]");
            }
        }
    }
}

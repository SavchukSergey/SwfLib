using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Code.SwfLib.Gradients;
using NUnit.Framework;

namespace Code.SwfLib.Tests.Asserts {
    public static class AssertGradients {

        public static void AreEqual(GradientRGB expected, GradientRGB actual, string message) {
            Assert.AreEqual(expected.SpreadMode, actual.SpreadMode, message + ": SpreadMode");
            Assert.AreEqual(expected.InterpolationMode, actual.InterpolationMode, message + ": InterpolationMode");
            Assert.AreEqual(expected.GradientRecords.Count, actual.GradientRecords.Count, message + ": GradientRecords.Count");
            for (var i = 0; i < expected.GradientRecords.Count; i++) {
                var exp = expected.GradientRecords[i];
                var act = actual.GradientRecords[i];
                AreEqual(exp, act, message + ": GradientRecords[" + i + "]");
            }
        }

        public static void AreEqual(GradientRGBA expected, GradientRGBA actual, string message) {
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
    }
}

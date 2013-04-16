using System.Collections.Generic;
using Code.SwfLib.Data;
using Code.SwfLib.Tags.ControlTags;
using Code.SwfLib.Tags.DisplayListTags;
using Code.SwfLib.Tags.ShapeTags;
using Code.SwfLib.Tests.Asserts.Shapes;
using NUnit.Framework;
using SwfLib.Tests.Asserts;

namespace Code.SwfLib.Tests.Asserts.Tags {
    public static class AssertTag {

        public static void AreEqual(PlaceObject2Tag expected, PlaceObject2Tag actual) {
            Assert.AreEqual(expected.CharacterID, actual.CharacterID);
            Assert.AreEqual(expected.Depth, actual.Depth);
            AssertData.AreEqual(expected.Matrix, actual.Matrix, "Matrix");
            Assert.AreEqual(expected.HasColorTransform, actual.HasColorTransform, "HasColorTransform");
            AssertData.AreEqual(expected.ColorTransform, actual.ColorTransform, "ColorTransform");
            Assert.AreEqual(expected.RestData, actual.RestData);
        }

        public static void AreEqual(PlaceObject3Tag expected, PlaceObject3Tag actual) {
            Assert.AreEqual(expected.CharacterID, actual.CharacterID);
            Assert.AreEqual(expected.Depth, actual.Depth);
            AssertData.AreEqual(expected.Matrix, actual.Matrix, "Matrix");
            AssertFilters.AreEqual(expected.Filters, actual.Filters, "PlaceObject3.Filters");
            Assert.AreEqual(expected.RestData, actual.RestData);
        }

        public static void AreEqual(DefineShapeTag expected, DefineShapeTag actual) {
            Assert.AreEqual(expected.ShapeID, actual.ShapeID);
            AssertData.AreEqual(expected.ShapeBounds, actual.ShapeBounds, "ShapeBounds");
            Assert.AreEqual(expected.FillStyles.Count, actual.FillStyles.Count, "FillStyles.Count");
            for (var i = 0; i < expected.FillStyles.Count; i++) {
                var exp = expected.FillStyles[i];
                var act = actual.FillStyles[i];
                AssertFillStyles.AreEqual(exp, act, "FillStyles[" + i + "]");
            }
            Assert.AreEqual(expected.LineStyles.Count, actual.LineStyles.Count, "LineStyles.Count");
            for (var i = 0; i < expected.LineStyles.Count; i++) {
                var exp = expected.LineStyles[i];
                var act = actual.LineStyles[i];
                AssertShape.AreEqual(exp, act, "LineStyles[" + i + "]");
            }
            Assert.AreEqual(expected.ShapeRecords.Count, actual.ShapeRecords.Count, "ShapeRecords.Count");
            for (var i = 0; i < expected.ShapeRecords.Count; i++) {
                var exp = expected.ShapeRecords[i];
                var act = actual.ShapeRecords[i];
                AssertShape.AreEqual(exp, act, "ShapeRecords[" + i + "]");
            }
            Assert.AreEqual(expected.RestData, actual.RestData);
        }

        public static void AreEqual(FileAttributesTag expected, FileAttributesTag actual) {
            Assert.AreEqual(expected.AllowAbc, actual.AllowAbc);
            Assert.AreEqual(expected.HasMetadata, actual.HasMetadata);
            Assert.AreEqual(expected.Reserved, actual.Reserved);
            Assert.AreEqual(expected.Reserved0, actual.Reserved0);
            Assert.AreEqual(expected.SuppressCrossDomainCaching, actual.SuppressCrossDomainCaching);
            Assert.AreEqual(expected.SwfRelativeUrls, actual.SwfRelativeUrls);
            Assert.AreEqual(expected.UseDirectBlit, actual.UseDirectBlit);
            Assert.AreEqual(expected.UseGPU, actual.UseGPU);
            Assert.AreEqual(expected.UseNetwork, actual.UseNetwork);
            Assert.AreEqual(expected.RestData, actual.RestData);
        }

        public static void AreEqual(MetadataTag expected, MetadataTag actual) {
            Assert.AreEqual(expected.Metadata, actual.Metadata);
            Assert.AreEqual(expected.RestData, actual.RestData);
        }

        public static void AreEqual(SetBackgroundColorTag expected, SetBackgroundColorTag actual) {
            AssertColors.AreEqual(expected.Color, actual.Color, "Color");
            Assert.AreEqual(expected.RestData, actual.RestData);
        }

        public static void AreEqual(DefineSceneAndFrameLabelDataTag expected, DefineSceneAndFrameLabelDataTag actual, string message) {
            AreEqual(expected.Scenes, actual.Scenes, message + ".Scenes");
            AreEqual(expected.Frames, actual.Frames, message + ".Frames");
            Assert.AreEqual(expected.RestData, actual.RestData);
        }

        public static void AreEqual(IList<SceneOffsetData> expected, IList<SceneOffsetData> actual, string message) {
            Assert.AreEqual(expected.Count, actual.Count, message + ".Count");
            for (var i = 0; i < expected.Count; i++) {
                AreEqual(expected[i], actual[i], message + "[" + i + "]");
            }
        }

        public static void AreEqual(IList<FrameLabelData> expected, IList<FrameLabelData> actual, string message) {
            Assert.AreEqual(expected.Count, actual.Count, message + ".Count");
            for (var i = 0; i < expected.Count; i++) {
                AreEqual(expected[i], actual[i], message + "[" + i + "]");
            }
        }

        public static void AreEqual(SceneOffsetData expected, SceneOffsetData actual, string message) {
            Assert.AreEqual(expected.Name, actual.Name, message + ".Name");
            Assert.AreEqual(expected.Offset, actual.Offset, message + ".Offset");
        }

        public static void AreEqual(FrameLabelData expected, FrameLabelData actual, string message) {
            Assert.AreEqual(expected.Label, actual.Label, message + ".Label");
            Assert.AreEqual(expected.FrameNumber, actual.FrameNumber, message + ".FrameNumber");
        }
    }
}

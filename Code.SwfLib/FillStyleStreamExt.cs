﻿using System;
using Code.SwfLib.Data.FillStyles;

namespace Code.SwfLib {
    public static class FillStyleStreamExt {

        public static void WriteFillStyles(this SwfStreamWriter writer, FillStyles1List styles) {
            for (var i = 0; i < styles.Count; i++) {
                var style = styles[i];
                switch (style.Type) {
                    case FillStyleType.SolidRGB:
                        writer.WriteSolidRGBFillStyle((SolidRGBFillStyle)style);
                        break;
                    case FillStyleType.ClippedBitmap:
                        writer.WriteClippedBitmapFillStyle((ClippedBitmapFillStyle)style);
                        break;
                    case FillStyleType.LinearGradient:
                        writer.WriteLinearGradientFillStyle((LinearGradientFillStyle)style);
                        break;
                    case FillStyleType.NonSmoothedClippedBitmap:
                        writer.WriteNonSmoothedClippedBitmapFillStyle((NonSmoothedClippedBitmapFillStyle)style);
                        break;
                    default:
                        throw new InvalidOperationException("Unknown fill style type " + style.Type);
                }
            }
        }

        public static SolidRGBFillStyle ReadSolidRGBFillStyle(this SwfStreamReader reader)
        {
            var style = new SolidRGBFillStyle();
            style.Color = reader.ReadRGB();
            return style;
        }

        public static void WriteSolidRGBFillStyle(this SwfStreamWriter writer, SolidRGBFillStyle style) {
            writer.WriteByte(0x00);
            writer.WriteRGB(style.Color);
        }

        public static void WriteLinearGradientFillStyle(this SwfStreamWriter writer, LinearGradientFillStyle style) {
            writer.WriteByte(0x10);
            writer.WriteMatrix(style.GradientMatrix);
            //TODO: Other fields
        }

        public static LinearGradientFillStyle ReadLinearGradientFillStyle(this SwfStreamReader reader)
        {
            var style = new LinearGradientFillStyle();
            style.GradientMatrix = reader.ReadMatrix();
            //TODO: Read other fields
            return style;
        }

        public static void WriteNonSmoothedClippedBitmapFillStyle(this SwfStreamWriter writer, NonSmoothedClippedBitmapFillStyle style) {
            writer.WriteByte(0x42);
            //TODO: Other fields
        }

        public static void WriteClippedBitmapFillStyle(this SwfStreamWriter writer, ClippedBitmapFillStyle style) {
            writer.WriteByte(0x41);
            writer.WriteUInt16(style.BitmapID);
            writer.WriteMatrix(style.BitmapMatrix);
        }

        public static ClippedBitmapFillStyle ReadClippedBitmapFillStyle(this SwfStreamReader reader)
        {
            var style = new ClippedBitmapFillStyle();
            style.BitmapID = reader.ReadUInt16();
            style.BitmapMatrix = reader.ReadMatrix();
            return style;
        }

        public static FillStyle ReadFillStyle1(this SwfStreamReader reader)
        {
            var type = reader.ReadByte();
            switch (type)
            {
                    //TODO: Use correct enum
                case 0x00:
                    return reader.ReadSolidRGBFillStyle();
                case 0x10:
                    return reader.ReadLinearGradientFillStyle();
                case 0x41:
                    return reader.ReadClippedBitmapFillStyle();
                default:
                    throw new FormatException("Invalid fill style type " + type);
            }
        }


    }
}
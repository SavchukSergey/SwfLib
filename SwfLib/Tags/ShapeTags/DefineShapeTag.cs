﻿using System.Collections.Generic;
using Code.SwfLib.Shapes.FillStyles;
using Code.SwfLib.Shapes.LineStyles;
using Code.SwfLib.Shapes.Records;
using SwfLib.Tags;

namespace Code.SwfLib.Tags.ShapeTags {
    public class DefineShapeTag : ShapeBaseTag {

        public readonly IList<FillStyleRGB> FillStyles = new List<FillStyleRGB>();

        public readonly IList<LineStyleRGB> LineStyles = new List<LineStyleRGB>();

        public readonly IList<IShapeRecordRGB> ShapeRecords = new List<IShapeRecordRGB>();

        public override SwfTagType TagType {
            get { return SwfTagType.DefineShape; }
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
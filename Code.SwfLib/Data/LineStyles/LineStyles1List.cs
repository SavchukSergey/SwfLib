namespace Code.SwfLib.Data.LineStyles {
    public class LineStyles1List : LineStylesListBase {

        public override bool IsValid(LineStyle style) {
            if (style == null) return false;
            switch (style.Type) {
                default:
                    return false;
            }
        }

    }
}
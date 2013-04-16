namespace Code.SwfLib.Filters {
    public class ColorMatrixFilter : BaseFilter {

        public double R0;
        public double R1;
        public double R2;
        public double R3;
        public double R4;

        public double G0;
        public double G1;
        public double G2;
        public double G3;
        public double G4;

        public double B0;
        public double B1;
        public double B2;
        public double B3;
        public double B4;

        public double A0;
        public double A1;
        public double A2;
        public double A3;
        public double A4;

        public override FilterType Type {
            get { return FilterType.ColorMatrix; }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IFilterVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}

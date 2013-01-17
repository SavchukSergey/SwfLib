namespace Code.SwfLib.Data {
    public struct ColorTransformRGB {

        public short? RedMultTerm;

        public short? GreenMultTerm;

        public short? BlueMultTerm;


        public short? RedAddTerm;

        public short? GreenAddTerm;

        public short? BlueAddTerm;

        public bool HasAddTerms {
            get { return RedAddTerm.HasValue || GreenAddTerm.HasValue || BlueAddTerm.HasValue; }
        }

        public bool HasMultTerms {
            get { return RedMultTerm.HasValue || GreenMultTerm.HasValue || BlueMultTerm.HasValue; }
        }
    }
}
namespace Code.SwfLib.Data {
    public struct ColorTransformRGBA {

        public short? RedMultTerm;

        public short? GreenMultTerm;

        public short? BlueMultTerm;

        public short? AlphaMultTerm;


        public short? RedAddTerm;

        public short? GreenAddTerm;

        public short? BlueAddTerm;

        public short? AlphaAddTerm;


        public bool HasAddTerms {
            get { return RedAddTerm.HasValue || GreenAddTerm.HasValue || BlueAddTerm.HasValue || AlphaAddTerm.HasValue; }
        }

        public bool HasMultTerms {
            get { return RedMultTerm.HasValue || GreenMultTerm.HasValue || BlueMultTerm.HasValue || AlphaMultTerm.HasValue; }
        }
    }
}
namespace Code.SwfLib.SwfMill.Data {
    public static class CommonFormatter {

        public static string Format(double val) {
            return val.ToString("0.0000000000000");
        }

        public static double ParseDouble(string value) {
            return double.Parse(value);
        }
    }
}

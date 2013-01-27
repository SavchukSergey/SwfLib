namespace Code.SwfLib.SwfMill.Data {
    public static class CommonFormatter {

        public static string Format(double val) {
            return val.ToString();
        }

        public static string Format(bool val) {
            return val ? "1" : "0";
        }

        public static double ParseDouble(string value) {
            return double.Parse(value);
        }
    }
}

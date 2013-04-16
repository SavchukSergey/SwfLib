using System;

namespace SwfLib.SwfMill.Data {
    public static class CommonFormatter {

        public static string Format(double val) {
            return val.ToString();
        }

        public static string Format(bool val) {
            return val ? "1" : "0";
        }

        public static bool ParseBool(string val) {
            switch (val) {
                case "1":
                    return true;
                case "0":
                    return false;
                default:
                    throw new FormatException("Invalid attribute value");
            }
        }

        public static double ParseDouble(string value) {
            return double.Parse(value);
        }
    }
}

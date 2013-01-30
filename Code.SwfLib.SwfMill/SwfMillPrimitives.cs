using System;
using System.Xml.Linq;

namespace Code.SwfLib.SwfMill
{
    public static class SwfMillPrimitives
    {

        public static ushort ParseObjectID(XAttribute attrib)
        {
            return ushort.Parse(attrib.Value);
        }

        public static bool ParseBoolean(XAttribute attribute)
        {
            switch (attribute.Value)
            {
                case "0":
                    return false;
                case "1":
                    return true;
                default:
                    throw new FormatException("Unknown value");
            }
        }

        public static string GetStringValue(bool val)
        {
            return val ? "1" : "0";
        }

    }
}

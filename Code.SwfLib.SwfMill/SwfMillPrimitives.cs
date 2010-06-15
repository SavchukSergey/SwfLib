using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Code.SwfLib.Data;

namespace Code.SwfLib.SwfMill
{
    public static class SwfMillPrimitives
    {

        public static SwfMorphShapeWithStyle ParseSwfMorphShapeWithStyle(XElement element)
        {
            //TODO: Implement;
            return new SwfMorphShapeWithStyle();
        }

        public static SwfShapeWithStyle ParseSwfShapeWithStyle(XElement element)
        {
            //TODO: Implement;
            return new SwfShapeWithStyle();
        }

        public static ushort ParseObjectID(XAttribute attrib)
        {
            return ushort.Parse(attrib.Value);
        }
    }
}

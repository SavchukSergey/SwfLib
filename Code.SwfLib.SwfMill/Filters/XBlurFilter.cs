using System.Xml.Linq;
using Code.SwfLib.Filters;
using Code.SwfLib.SwfMill.Data;

namespace Code.SwfLib.SwfMill.Filters {
    public static class XBlurFilter {

        public static XElement ToXml(BlurFilter filter) {
            var res = new XElement("Blur",
                new XAttribute("blurX", CommonFormatter.Format(filter.BlurX)),
                new XAttribute("blurY", CommonFormatter.Format(filter.BlurY)),
                new XAttribute("passes", filter.Passes)
            );
            if (filter.Reserved != 0) {
                res.Add(new XAttribute("reserved", filter.Reserved));
            }
            return res;
        }
    }
}

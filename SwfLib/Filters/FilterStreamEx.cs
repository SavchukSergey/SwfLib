using System.Collections.Generic;

namespace Code.SwfLib.Filters {
    public static class FilterStreamEx {

        private static readonly FilterReader _reader = new FilterReader();
        private static readonly FilterWriter _writer = new FilterWriter();

        public static void ReadFilterList(this ISwfStreamReader reader, IList<BaseFilter> target) {
            var count = reader.ReadByte();
            for (var i = 0; i < count; i++) {
                var filter = reader.ReadFilter();
                target.Add(filter);
            }
        }

        public static void WriteFilterList(this ISwfStreamWriter writer, IList<BaseFilter> source) {
            writer.WriteByte((byte)source.Count);
            foreach (var filter in source) {
                writer.WriteFilter(filter);
            }
        }

        public static BaseFilter ReadFilter(this ISwfStreamReader reader) {
            return _reader.Read(reader);
        }

        public static void WriteFilter(this ISwfStreamWriter writer, BaseFilter filter) {
            _writer.Write(writer, filter);
        }

    }
}

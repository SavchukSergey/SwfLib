namespace Code.SwfLib.Filters {
    public static class FilterStreamEx {

        private static readonly FilterReader _reader = new FilterReader();
        private static readonly FilterWriter _writer = new FilterWriter();

        public static BaseFilter ReadFilter(this SwfStreamReader reader) {
            return _reader.Read(reader);
        }

        public static void WriteFilter(this SwfStreamWriter writer, BaseFilter filter) {
            _writer.Write(writer, filter);
        }

    }
}

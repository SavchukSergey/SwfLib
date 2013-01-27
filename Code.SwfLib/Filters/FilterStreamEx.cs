namespace Code.SwfLib.Filters {
    public static class FilterStreamEx {

        private static readonly FilterReader _reader = new FilterReader();

        public static BaseFilter ReadFilter(this SwfStreamReader reader) {
            return _reader.Read(reader);
        }

    }
}

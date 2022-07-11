namespace BaseApi.Converters
{
    public static class Converter
    {
        public static DateTime ConverterParaTimeStamp(DateTime data) =>
            DateTime.SpecifyKind(data, DateTimeKind.Utc);
    }
}

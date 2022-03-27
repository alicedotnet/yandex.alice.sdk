namespace Yandex.Alice.Sdk.Converters
{
    using System;
    using System.Globalization;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    public abstract class DateTimeOffsetConverter : JsonConverter<DateTimeOffset>
    {
        private readonly string _format;

        protected DateTimeOffsetConverter(string format)
        {
            _format = format;
        }

        public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var input = reader.GetString();
            DateTimeOffset.TryParseExact(input, _format, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out var response);
            return response;
        }

        public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options)
        {
            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }

            var result = value.ToString(_format, CultureInfo.InvariantCulture);
            writer.WriteStringValue(result);
        }
    }
}

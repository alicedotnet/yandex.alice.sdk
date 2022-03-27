namespace Yandex.Alice.Sdk.Converters
{
    using System;
    using System.Text.Json;
    using System.Text.Json.Serialization;
    using Yandex.Alice.Sdk.Models;

    public class AliceRequestTypeConverter : JsonConverter<AliceRequestType>
    {
        public override AliceRequestType Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            var input = reader.GetString();
            return AliceRequestTypeHelper.ConvertToType(input);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AliceRequestType value,
            JsonSerializerOptions options)
        {
            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }

            var result = AliceRequestTypeHelper.ConvertToString(value);
            writer.WriteStringValue(result);
        }
    }
}

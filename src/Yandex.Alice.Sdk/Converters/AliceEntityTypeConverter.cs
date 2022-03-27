namespace Yandex.Alice.Sdk.Converters
{
    using System;
    using System.Text.Json;
    using System.Text.Json.Serialization;
    using Yandex.Alice.Sdk.Models;

    public class AliceEntityTypeConverter : JsonConverter<AliceEntityType>
    {
        public override AliceEntityType Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            var input = reader.GetString();
            switch (input)
            {
                case AliceConstants.AliceEntityTypeValues.DateTime:
                    return AliceEntityType.Datetime;
                case AliceConstants.AliceEntityTypeValues.Fio:
                    return AliceEntityType.Fio;
                case AliceConstants.AliceEntityTypeValues.Geo:
                    return AliceEntityType.Geo;
                case AliceConstants.AliceEntityTypeValues.Number:
                    return AliceEntityType.Number;
                case AliceConstants.AliceEntityTypeValues.String:
                    return AliceEntityType.String;
                default:
                    return AliceEntityType.Unknown;
            }
        }

        public override void Write(
            Utf8JsonWriter writer,
            AliceEntityType value,
            JsonSerializerOptions options)
        {
            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }

            string result;
            switch (value)
            {
                case AliceEntityType.Datetime:
                    result = AliceConstants.AliceEntityTypeValues.DateTime;
                    break;
                case AliceEntityType.Fio:
                    result = AliceConstants.AliceEntityTypeValues.Fio;
                    break;
                case AliceEntityType.Geo:
                    result = AliceConstants.AliceEntityTypeValues.Geo;
                    break;
                case AliceEntityType.Number:
                    result = AliceConstants.AliceEntityTypeValues.Number;
                    break;
                case AliceEntityType.String:
                    result = AliceConstants.AliceEntityTypeValues.String;
                    break;
                case AliceEntityType.Unknown:
                    result = AliceConstants.AliceEntityTypeValues.Unknown;
                    break;
                default:
                    result = AliceConstants.AliceEntityTypeValues.Unknown;
                    break;
            }

            writer.WriteStringValue(result);
        }
    }
}

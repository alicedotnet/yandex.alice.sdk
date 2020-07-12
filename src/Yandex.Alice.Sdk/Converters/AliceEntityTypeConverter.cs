using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Yandex.Alice.Sdk.Models;

namespace Yandex.Alice.Sdk.Converters
{
    public class AliceEntityTypeConverter : JsonConverter<AliceEntityType>
    {
        public override AliceEntityType Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            string input = reader.GetString();
            switch (input)
            {
                case AliceConstants.AliceEntityTypeValues.DateTime:
                    return AliceEntityType.DATETIME;
                case AliceConstants.AliceEntityTypeValues.Fio:
                    return AliceEntityType.FIO;
                case AliceConstants.AliceEntityTypeValues.Geo:
                    return AliceEntityType.GEO;
                case AliceConstants.AliceEntityTypeValues.Number:
                    return AliceEntityType.NUMBER;
                case AliceConstants.AliceEntityTypeValues.String:
                    return AliceEntityType.STRING;
                default:
                    return AliceEntityType.Unknown;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
        public override void Write(
            Utf8JsonWriter writer,
            AliceEntityType entityType,
            JsonSerializerOptions options)
        {
            string result;
            switch (entityType)
            {
                case AliceEntityType.DATETIME:
                    result = AliceConstants.AliceEntityTypeValues.DateTime;
                    break;
                case AliceEntityType.FIO:
                    result = AliceConstants.AliceEntityTypeValues.Fio;
                    break;
                case AliceEntityType.GEO:
                    result = AliceConstants.AliceEntityTypeValues.Geo;
                    break;
                case AliceEntityType.NUMBER:
                    result = AliceConstants.AliceEntityTypeValues.Number;
                    break;
                case AliceEntityType.STRING:
                    result = AliceConstants.AliceEntityTypeValues.String;
                    break;
                default:
                    result = "unknown";
                    break;
            };
            writer.WriteStringValue(result);
        }
    }
}

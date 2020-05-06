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
                case Constants.AliceEntityTypeValues.DateTime:
                    return AliceEntityType.DATETIME;
                case Constants.AliceEntityTypeValues.Fio:
                    return AliceEntityType.FIO;
                case Constants.AliceEntityTypeValues.Geo:
                    return AliceEntityType.GEO;
                case Constants.AliceEntityTypeValues.Number:
                    return AliceEntityType.NUMBER;
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
                    result = Constants.AliceEntityTypeValues.DateTime;
                    break;
                case AliceEntityType.FIO:
                    result = Constants.AliceEntityTypeValues.Fio;
                    break;
                case AliceEntityType.GEO:
                    result = Constants.AliceEntityTypeValues.Geo;
                    break;
                case AliceEntityType.NUMBER:
                    result = Constants.AliceEntityTypeValues.Number;
                    break;
                default:
                    result = "unknown";
                    break;
            };
            writer.WriteStringValue(result);
        }
    }
}

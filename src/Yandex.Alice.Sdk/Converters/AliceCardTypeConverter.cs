using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Yandex.Alice.Sdk.Models;

namespace Yandex.Alice.Sdk.Converters
{
    public class AliceCardTypeConverter : JsonConverter<AliceCardType>
    {
        public override AliceCardType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string input = reader.GetString();
            switch (input)
            {
                case Constants.AliceCardTypeValues.BigImage:
                    return AliceCardType.BigImage;
                case Constants.AliceCardTypeValues.ItemsList:
                    return AliceCardType.ItemsList;
                default:
                    return AliceCardType.Undefined;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
        public override void Write(Utf8JsonWriter writer, AliceCardType cardType, JsonSerializerOptions options)
        {
            string result;
            switch (cardType)
            {
                case AliceCardType.BigImage:
                    result = Constants.AliceCardTypeValues.BigImage;
                    break;
                case AliceCardType.ItemsList:
                    result = Constants.AliceCardTypeValues.ItemsList;
                    break;
                default:
                    result = "unknown";
                    break;
            };
            writer.WriteStringValue(result);
        }
    }
}

namespace Yandex.Alice.Sdk.Converters
{
    using System;
    using System.Text.Json;
    using System.Text.Json.Serialization;
    using Yandex.Alice.Sdk.Models;

    public class AliceCardTypeConverter : JsonConverter<AliceCardType>
    {
        public override AliceCardType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string input = reader.GetString();
            switch (input)
            {
                case AliceConstants.AliceCardTypeValues.BigImage:
                    return AliceCardType.BigImage;
                case AliceConstants.AliceCardTypeValues.ItemsList:
                    return AliceCardType.ItemsList;
                default:
                    return AliceCardType.Undefined;
            }
        }

        public override void Write(Utf8JsonWriter writer, AliceCardType value, JsonSerializerOptions options)
        {
            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }

            string result;
            switch (value)
            {
                case AliceCardType.BigImage:
                    result = AliceConstants.AliceCardTypeValues.BigImage;
                    break;
                case AliceCardType.ItemsList:
                    result = AliceConstants.AliceCardTypeValues.ItemsList;
                    break;
                default:
                    result = "unknown";
                    break;
            }

            writer.WriteStringValue(result);
        }
    }
}

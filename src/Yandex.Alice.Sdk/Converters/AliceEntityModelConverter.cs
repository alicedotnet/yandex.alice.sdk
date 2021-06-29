namespace Yandex.Alice.Sdk.Converters
{
    using System;
    using System.Text.Json;
    using System.Text.Json.Serialization;
    using Yandex.Alice.Sdk.Models;

    public class AliceEntityModelConverter : JsonConverter<AliceEntityModel>
    {
        public override AliceEntityModel Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return AliceEntityModelConverterHelper.ToItem(ref reader, options);
        }

        public override void Write(Utf8JsonWriter writer, AliceEntityModel value, JsonSerializerOptions options)
        {
            AliceEntityModelConverterHelper.WriteItem(writer, value, options);
        }
    }
}

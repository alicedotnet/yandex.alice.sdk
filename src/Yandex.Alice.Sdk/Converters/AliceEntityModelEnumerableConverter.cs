namespace Yandex.Alice.Sdk.Converters
{
    using System.Text.Json;
    using Yandex.Alice.Sdk.Models;

    public class AliceEntityModelEnumerableConverter : EnumerableConverter<AliceEntityModel>
    {
        protected override AliceEntityModel ToItem(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            return AliceEntityModelConverterHelper.ToItem(ref reader, options);
        }

        protected override void WriteItem(Utf8JsonWriter writer, AliceEntityModel item, JsonSerializerOptions options)
        {
            AliceEntityModelConverterHelper.WriteItem(writer, item, options);
        }
    }
}

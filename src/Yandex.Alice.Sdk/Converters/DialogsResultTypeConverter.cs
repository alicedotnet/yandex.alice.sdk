namespace Yandex.Alice.Sdk.Converters
{
    using System;
    using System.Text.Json;
    using System.Text.Json.Serialization;
    using Yandex.Alice.Sdk.Models.DialogsApi;

    public class DialogsResultTypeConverter : JsonConverter<DialogsResultType>
    {
        public override DialogsResultType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var input = reader.GetString();
            return input == "ok" ? DialogsResultType.Ok : DialogsResultType.Fail;
        }

        public override void Write(Utf8JsonWriter writer, DialogsResultType value, JsonSerializerOptions options)
        {
            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }

            var result = value == DialogsResultType.Ok ? "ok" : "fail";

            writer.WriteStringValue(result);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Yandex.Alice.Sdk.Models.DialogsApi;

namespace Yandex.Alice.Sdk.Converters
{
    public class DialogsResultTypeConverter : JsonConverter<DialogsResultType>
    {
        public override DialogsResultType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string input = reader.GetString();
            switch (input)
            {
                case "ok":
                    return DialogsResultType.Ok;
                default:
                    return DialogsResultType.Fail;
            }
        }

        public override void Write(Utf8JsonWriter writer, DialogsResultType value, JsonSerializerOptions options)
        {
            string result;
            switch (value)
            {
                case DialogsResultType.Ok:
                    result = "ok";
                    break;
                default:
                    result = "fail";
                    break;
            };
            writer.WriteStringValue(result);
        }
    }
}

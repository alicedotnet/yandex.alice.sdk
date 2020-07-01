using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Schema;
using Yandex.Alice.Sdk.Models;

namespace Yandex.Alice.Sdk.Converters
{
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

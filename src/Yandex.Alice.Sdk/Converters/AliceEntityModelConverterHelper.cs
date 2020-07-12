using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using Yandex.Alice.Sdk.Models;

namespace Yandex.Alice.Sdk.Converters
{
    internal static class AliceEntityModelConverterHelper
    {
        private static readonly Dictionary<string, Type> _typeMap = new Dictionary<string, Type>()
        {
            { AliceConstants.AliceEntityTypeValues.Geo, typeof(AliceEntityGeoModel) },
            { AliceConstants.AliceEntityTypeValues.Fio, typeof(AliceEntityFioModel) },
            { AliceConstants.AliceEntityTypeValues.Number, typeof(AliceEntityNumberModel) },
            { AliceConstants.AliceEntityTypeValues.DateTime, typeof(AliceEntityDateTimeModel) },
            { AliceConstants.AliceEntityTypeValues.String, typeof(AliceEntityStringModel) }
        };

        public static AliceEntityModel ToItem(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null) return null;

            var readerAtStart = reader;

            string type = null;
            using (var jsonDocument = JsonDocument.ParseValue(ref reader))
            {
                var jsonObject = jsonDocument.RootElement;

                type = jsonObject
                    .EnumerateObject()
                    .FirstOrDefault(x => x.Name == AliceConstants.AliceEntityModelFields.Type)
                    .Value.GetString();
            }

            if (!string.IsNullOrEmpty(type) && _typeMap.TryGetValue(type, out var targetType))
            {
                return JsonSerializer.Deserialize(ref readerAtStart, targetType, options) as AliceEntityModel;
            }

            throw new NotSupportedException($"{type ?? "<unknown>"} can not be deserialized");
        }

        public static void WriteItem(Utf8JsonWriter writer, AliceEntityModel value, JsonSerializerOptions options)
        {
            object newValue = null;
            if (value != null)
            {
                newValue = Convert.ChangeType(value, value.GetType(), CultureInfo.InvariantCulture);
            }
            JsonSerializer.Serialize(writer, newValue, options);
        }

    }
}

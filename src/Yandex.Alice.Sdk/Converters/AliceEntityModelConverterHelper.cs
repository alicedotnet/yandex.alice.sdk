namespace Yandex.Alice.Sdk.Converters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.Json;
    using Yandex.Alice.Sdk.Models;

    internal static class AliceEntityModelConverterHelper
    {
        private static readonly Dictionary<string, Type> _typeMap = new Dictionary<string, Type>
        {
            { AliceConstants.AliceEntityTypeValues.Geo, typeof(AliceEntityGeoModel) },
            { AliceConstants.AliceEntityTypeValues.Fio, typeof(AliceEntityFioModel) },
            { AliceConstants.AliceEntityTypeValues.Number, typeof(AliceEntityNumberModel) },
            { AliceConstants.AliceEntityTypeValues.DateTime, typeof(AliceEntityDateTimeModel) },
            { AliceConstants.AliceEntityTypeValues.String, typeof(AliceEntityStringModel) },
        };

        public static AliceEntityModel ToItem(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null)
            {
                return null;
            }

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
    }
}

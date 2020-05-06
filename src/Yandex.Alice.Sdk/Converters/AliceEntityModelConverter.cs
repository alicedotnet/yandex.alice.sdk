using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Yandex.Alice.Sdk.Models;

namespace Yandex.Alice.Sdk.Converters
{
    public class AliceEntityModelConverter : EnumerableConverter<AliceEntityModel>
    {
        private static readonly Dictionary<string, Type> _typeMap = new Dictionary<string, Type>()
        {
            { Constants.AliceEntityTypeValues.Geo, typeof(AliceEntityGeoModel) },
            { Constants.AliceEntityTypeValues.Fio, typeof(AliceEntityFioModel) },
            { Constants.AliceEntityTypeValues.Number, typeof(AliceEntityNumberModel) },
            { Constants.AliceEntityTypeValues.DateTime, typeof(AliceEntityDateTimeModel) }
        };

        protected override AliceEntityModel ToItem(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null) return null;

            var readerAtStart = reader;

            string type = null;
            using (var jsonDocument = JsonDocument.ParseValue(ref reader))
            {
                var jsonObject = jsonDocument.RootElement;

                type = jsonObject
                    .EnumerateObject()
                    .FirstOrDefault(x => x.Name == Constants.AliceEntityModelFields.Type)
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

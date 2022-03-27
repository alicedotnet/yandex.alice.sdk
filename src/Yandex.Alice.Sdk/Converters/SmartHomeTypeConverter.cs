namespace Yandex.Alice.Sdk.Converters
{
    using System;
    using System.Collections.Generic;
    using System.Text.Json;

    public abstract class SmartHomeTypeConverter<T> : AliceConverter<T>
    {
        protected abstract IReadOnlyDictionary<string, Type> EntityNameTypeMap { get; }

        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var type = GetEntityType(reader);
            return (T)JsonSerializer.Deserialize(ref reader, type);
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            ConverterHelper.WriteItem(writer, value, options);
        }

        protected abstract string GetErrorMessage(string type);

        private Type GetEntityType(Utf8JsonReader reader)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException();
            }

            var type = GetPropertyValue(reader, "type");
            if (!EntityNameTypeMap.TryGetValue(type, out var capabilityType))
            {
                throw new NotSupportedException(GetErrorMessage(type));
            }

            return capabilityType;
        }
    }
}

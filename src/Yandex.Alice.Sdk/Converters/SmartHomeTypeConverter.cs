namespace Yandex.Alice.Sdk.Converters
{
    using System;
    using System.Collections.Generic;
    using System.Text.Json;

    public abstract class SmartHomeTypeConverter<T> : SmartHomeConverter<T>
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

        protected virtual Type GetEntityType(Utf8JsonReader reader)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException();
            }

            var type = GetPropertyValue(reader, "type");
            if (!EntityNameTypeMap.TryGetValue(type, out Type capabilityType))
            {
                throw new NotSupportedException(GetErrorMessage(type));
            }

            return capabilityType;
        }

        protected abstract string GetErrorMessage(string type);
    }
}

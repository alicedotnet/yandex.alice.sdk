namespace Yandex.Alice.Sdk.Converters
{
    using System;
    using System.Collections.Generic;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    public abstract class EnumerableConverter<TItem> : JsonConverter<IEnumerable<TItem>>
    {
        protected EnumerableConverter()
            : this(true)
        {
        }

        protected EnumerableConverter(bool canWrite) => CanWrite = canWrite;

        public bool CanWrite { get; }

        public override IEnumerable<TItem> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            switch (reader.TokenType)
            {
                case JsonTokenType.StartArray:
                    var list = new List<TItem>();
                    while (reader.Read())
                    {
                        if (reader.TokenType == JsonTokenType.EndArray)
                        {
                            break;
                        }

                        list.Add(ToItem(ref reader, options));
                    }

                    return list.ToArray();
                default:
                    return null;
            }
        }

        public override void Write(Utf8JsonWriter writer, IEnumerable<TItem> value, JsonSerializerOptions options)
        {
            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }

            if (value != null && CanWrite)
            {
                writer.WriteStartArray();
                foreach (var item in value)
                {
                    WriteItem(writer, item, options);
                }

                writer.WriteEndArray();
            }
        }

        protected abstract TItem ToItem(ref Utf8JsonReader reader, JsonSerializerOptions options);

        protected virtual void WriteItem(Utf8JsonWriter writer, TItem item, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, item, options);
        }
    }
}

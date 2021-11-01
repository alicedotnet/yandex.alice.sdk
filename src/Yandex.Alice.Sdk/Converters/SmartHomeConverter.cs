namespace Yandex.Alice.Sdk.Converters
{
    using System.Text.Json;
    using System.Text.Json.Serialization;

    public abstract class SmartHomeConverter<T> : JsonConverter<T>
    {
        protected virtual string GetPropertyValue(Utf8JsonReader reader, string propertyName)
        {
            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.PropertyName && reader.GetString() == propertyName
                    && reader.Read() && reader.TokenType == JsonTokenType.String)
                {
                    return reader.GetString();
                }
            }

            throw new JsonException();
        }
    }
}

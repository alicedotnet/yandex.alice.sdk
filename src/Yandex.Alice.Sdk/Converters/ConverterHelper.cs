namespace Yandex.Alice.Sdk.Converters
{
    using System;
    using System.Globalization;
    using System.Text.Json;

    public static class ConverterHelper
    {
        public static void WriteItem<T>(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
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

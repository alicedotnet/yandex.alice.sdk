namespace Yandex.Alice.Sdk.Converters
{
    using System;
    using System.Text.Json;
    using Yandex.Alice.Sdk.Models.SmartHome;

    public class SmartHomeDeviceColorSettingCapabilityStateValueConverter : SmartHomeConverter<SmartHomeDeviceColorSettingCapabilityStateValue>
    {
        public override SmartHomeDeviceColorSettingCapabilityStateValue Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var colorSettingState = new SmartHomeDeviceColorSettingCapabilityStateValue()
            {
                Instance = GetPropertyValue(reader, "instance"),
            };

            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.PropertyName && reader.GetString() == "value"
                    && reader.Read())
                {
                    switch (colorSettingState.Instance)
                    {
                        case SmartHomeConstants.ColorSettingFunction.Rgb:
                        case SmartHomeConstants.ColorSettingFunction.TemperatureK:
                            colorSettingState.Value = reader.GetInt32();
                            break;
                        case SmartHomeConstants.ColorSettingFunction.Scene:
                            colorSettingState.Value = reader.GetString();
                            break;
                        case SmartHomeConstants.ColorSettingFunction.Hsv:
                            colorSettingState.Value = JsonSerializer.Deserialize<SmartHomeHsv>(ref reader, options);
                            break;
                        default:
                            throw new NotSupportedException($"Can't read \"{colorSettingState.Instance}\" instance value of \"{SmartHomeConstants.Devices.Capabilities.ColorSetting}\" capability.");
                    }
                }
                else if (reader.TokenType == JsonTokenType.EndObject)
                {
                    break;
                }
            }

            return colorSettingState;
        }

        public override void Write(Utf8JsonWriter writer, SmartHomeDeviceColorSettingCapabilityStateValue value, JsonSerializerOptions options)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }

            writer.WriteStartObject();
            writer.WriteString("instance", value.Instance);
            writer.WritePropertyName("value");
            switch (value.Instance)
            {
                case SmartHomeConstants.ColorSettingFunction.Rgb:
                case SmartHomeConstants.ColorSettingFunction.TemperatureK:
                    writer.WriteNumberValue((int)value.Value);
                    break;
                case SmartHomeConstants.ColorSettingFunction.Scene:
                    writer.WriteStringValue((string)value.Value);
                    break;
                case SmartHomeConstants.ColorSettingFunction.Hsv:
                    JsonSerializer.Serialize(writer, value.Value, options);
                    break;
                default:
                    throw new NotSupportedException($"Can't write \"{value.Instance}\" instance value of \"{SmartHomeConstants.Devices.Capabilities.ColorSetting}\" capability.");
            }

            writer.WriteEndObject();
        }
    }
}

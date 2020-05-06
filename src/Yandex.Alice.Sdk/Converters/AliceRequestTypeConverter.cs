using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
using Yandex.Alice.Sdk.Models;
using Yandex.Alice.Sdk.Resources;

namespace Yandex.Alice.Sdk.Converters
{
    public class AliceRequestTypeConverter : JsonConverter<AliceRequestType>
    {
        public override AliceRequestType Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            string input = reader.GetString();
            switch(input)
            {
                case "SimpleUtterance":
                    return AliceRequestType.SimpleUtterance;
                case "ButtonPressed":
                    return AliceRequestType.ButtonPressed;
                default:
                    string message = string.Format(CultureInfo.CurrentCulture, Yandex_Alice_Sdk_Resources.Error_Unknown_Request_Type, input);
                    throw new Exception(message);
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
        public override void Write(
            Utf8JsonWriter writer,
            AliceRequestType requestType,
            JsonSerializerOptions options)
        {
            string result = requestType.ToString();
            writer.WriteStringValue(result);
        }
    }
}

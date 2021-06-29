namespace Yandex.Alice.Sdk.Converters
{
    using System;
    using System.Globalization;
    using System.Text.Json;
    using System.Text.Json.Serialization;
    using Yandex.Alice.Sdk.Exceptions;
    using Yandex.Alice.Sdk.Models;
    using Yandex.Alice.Sdk.Resources;

    public class AliceRequestTypeConverter : JsonConverter<AliceRequestType>
    {
        public override AliceRequestType Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            string input = reader.GetString();
            switch (input)
            {
                case "SimpleUtterance":
                    return AliceRequestType.SimpleUtterance;
                case "ButtonPressed":
                    return AliceRequestType.ButtonPressed;
                case "Geolocation.Allowed":
                    return AliceRequestType.GeolocationAllowed;
                case "Geolocation.Rejected":
                    return AliceRequestType.GeolocationRejected;
                default:
                    string message = string.Format(CultureInfo.CurrentCulture, Yandex_Alice_Sdk_Resources.Error_Unknown_Request_Type, input);
                    throw new UnknownRequestTypeException(message);
            }
        }

        public override void Write(
            Utf8JsonWriter writer,
            AliceRequestType value,
            JsonSerializerOptions options)
        {
            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }

            string result = value.ToString();
            writer.WriteStringValue(result);
        }
    }
}

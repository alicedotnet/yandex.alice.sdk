namespace Yandex.Alice.Sdk.Models
{
    using System.Text.Json;

    public static class AliceModelsExtensions
    {
        public static T GetPayload<T>(this AliceRequestModelBase model)
        {
            if (model?.Payload is JsonElement payloadJsonElement)
            {
                string text = payloadJsonElement.GetRawText();
                return JsonSerializer.Deserialize<T>(text);
            }

            return default;
        }
    }
}

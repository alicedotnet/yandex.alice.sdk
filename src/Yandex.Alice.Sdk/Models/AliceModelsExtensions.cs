namespace Yandex.Alice.Sdk.Models
{
    using System.Text.Json;

    public static class AliceModelsExtensions
    {
        public static TPayload GetPayload<TPayload>(this AliceRequestModel model)
        {
            return GetObject<TPayload>(model?.Payload);
        }

        public static TPayload GetPurchasePayload<TPayload>(this AliceRequestModel model)
        {
            return GetObject<TPayload>(model?.PurchasePayload);
        }

        private static T GetObject<T>(object value)
        {
            if (value is JsonElement payloadJsonElement)
            {
                string text = payloadJsonElement.GetRawText();
                return JsonSerializer.Deserialize<T>(text);
            }

            return default;
        }
    }
}

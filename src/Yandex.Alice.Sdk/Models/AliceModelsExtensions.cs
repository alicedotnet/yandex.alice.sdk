namespace Yandex.Alice.Sdk.Models
{
    using System.Collections.Generic;
    using System.Text.Json;

    public static class AliceModelsExtensions
    {
        public static TResponse WithAnalyticsEvent<TResponse>(this TResponse response, string eventName, object eventValue = null)
            where TResponse : IAliceResponseBase
        {
            return response.WithAnalyticsEvent(new AliceAnalyticsEvent(eventName, eventValue));
        }

        public static TResponse WithAnalyticsEvent<TResponse>(this TResponse response, AliceAnalyticsEvent analyticsEvent)
            where TResponse : IAliceResponseBase
        {
            if (response.Analytics == null)
            {
                response.Analytics = new AliceAnalytics()
                {
                    Events = new List<AliceAnalyticsEvent>(),
                };
            }

            response.Analytics.Events.Add(analyticsEvent);
            return response;
        }

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

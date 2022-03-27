namespace Yandex.Alice.Sdk.Models
{
    using System;
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class AliceButtonModel
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("payload")]
        public object Payload { get; set; }

        [JsonPropertyName("url")]
        public Uri Url { get; set; }

        [JsonPropertyName("hide")]
        public bool Hide { get; set; }

        public AliceButtonModel()
        {
            Payload = new object();
        }

        public AliceButtonModel(string title, bool hide = false, object payload = null, Uri url = null)
        {
            Title = title;
            Hide = hide;
            Payload = payload;
            Url = url;
        }
    }
}

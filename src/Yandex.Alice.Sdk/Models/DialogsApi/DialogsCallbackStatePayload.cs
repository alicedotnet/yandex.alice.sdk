namespace Yandex.Alice.Sdk.Models.DialogsApi
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class DialogsCallbackStatePayload
    {
        [JsonPropertyName("user_id")]
        public string UserId { get; set; }

        [JsonPropertyName("devices")]
        public List<DialogsCallbackStateDevice> Devices { get; set; }
    }
}

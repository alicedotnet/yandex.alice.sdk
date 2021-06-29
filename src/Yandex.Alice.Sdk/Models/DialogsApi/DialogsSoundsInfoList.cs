namespace Yandex.Alice.Sdk.Models.DialogsApi
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class DialogsSoundsInfoList
    {
        [JsonPropertyName("sounds")]
        public IEnumerable<DialogsImageInfo> Sounds { get; set; }

        [JsonPropertyName("total")]
        public int Total { get; set; }
    }
}

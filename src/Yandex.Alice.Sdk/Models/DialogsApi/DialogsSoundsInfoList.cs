using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Yandex.Alice.Sdk.Models.DialogsApi
{
    public class DialogsSoundsInfoList
    {
        [JsonPropertyName("sounds")]
        public IEnumerable<DialogsImageInfo> Sounds { get; set; }

        [JsonPropertyName("total")]
        public int Total { get; set; }
    }
}

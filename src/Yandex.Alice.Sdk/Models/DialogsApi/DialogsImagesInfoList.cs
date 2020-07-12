using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Yandex.Alice.Sdk.Models.DialogsApi
{
    public class DialogsImagesInfoList
    {
        [JsonPropertyName("images")]
        public IEnumerable<DialogsImageInfo> Images { get; set; }

        [JsonPropertyName("total")]
        public int Total { get; set; }
    }
}

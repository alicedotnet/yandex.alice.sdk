﻿namespace Yandex.Alice.Sdk.Models.DialogsApi
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class DialogsImagesInfoList
    {
        [JsonPropertyName("images")]
        public IEnumerable<DialogsImageInfo> Images { get; set; }

        [JsonPropertyName("total")]
        public int Total { get; set; }
    }
}

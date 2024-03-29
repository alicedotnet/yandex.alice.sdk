﻿namespace Yandex.Alice.Sdk.Models
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;
    using Yandex.Alice.Sdk.Converters;

    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class AliceGalleryCardModel
    {
        [JsonPropertyName("type")]
        [JsonConverter(typeof(AliceCardTypeConverter))]
        public AliceCardType Type { get; set; }

        [JsonPropertyName("header")]
        public AliceGalleryCardHeaderModel Header { get; set; }

        [JsonPropertyName("items")]
        public List<AliceGalleryCardItem> Items { get; set; }

        [JsonPropertyName("footer")]
        public AliceGalleryCardFooterModel Footer { get; set; }

        public AliceGalleryCardModel()
        {
            Type = AliceCardType.ItemsList;
            Items = new List<AliceGalleryCardItem>();
        }
    }
}

namespace Yandex.Alice.Sdk.Models
{
    using System.Text.Json.Serialization;

    public class AliceProduct
    {
        [JsonPropertyName("product_id")]
        public string ProductId { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("user_price")]
        public string UserPrice { get; set; }

        [JsonPropertyName("price")]
        public string Price { get; set; }

        [JsonPropertyName("nds_type")]
        public string NdsType { get; set; }

        [JsonPropertyName("quantity")]
        public string Quantity { get; set; }
    }
}

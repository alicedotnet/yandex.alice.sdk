namespace Yandex.Alice.Sdk.Models.SmartHome
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class SmartHomeDeviceColorScene
    {
        [JsonPropertyName("scenes")]
        public List<SmartHomeColorScene> Scenes { get; set; }
    }
}

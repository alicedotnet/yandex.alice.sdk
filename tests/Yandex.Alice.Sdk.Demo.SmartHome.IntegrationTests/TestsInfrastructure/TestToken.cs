namespace Yandex.Alice.Sdk.Demo.SmartHome.IntegrationTests.TestsInfrastructure
{
    using System.Text.Json.Serialization;

    public class TestToken
    {
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        [JsonPropertyName("refresh_token")]
        public string RefreshToken { get; set; }
    }
}

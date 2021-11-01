namespace Yandex.Alice.Sdk.Tests.Models.IoTApi
{
    using System.IO;
    using System.Text.Json;
    using FluentAssertions;
    using Xunit;
    using Yandex.Alice.Sdk.Models.IoTApi;
    using Yandex.Alice.Sdk.Tests.TestsInfrastructure;

    public class IoTUserInfoResponseTests
    {
        [Fact]
        public void ConvertFromJson()
        {
            // arrange
            string fileContent = File.ReadAllText(TestsConstants.Assets.IoTUserInfoFilePath);
            var jsonSerializerOptions = new JsonSerializerOptions()
            {
                ReadCommentHandling = JsonCommentHandling.Skip,
                AllowTrailingCommas = true,
            };

            // act
            var userInfo = JsonSerializer.Deserialize<IoTUserInfoResponse>(fileContent, jsonSerializerOptions);

            // assert
            userInfo.Should().NotBeNull();
            userInfo.Status.Should().NotBeNullOrEmpty();
        }
    }
}

namespace Yandex.Alice.Sdk.Tests.Models.DialogsApi
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Text.Json;
    using Xunit;
    using Xunit.Abstractions;
    using Yandex.Alice.Sdk.Models.DialogsApi;
    using Yandex.Alice.Sdk.Tests.TestsInfrastructure;

    public class DialogsImageInfoTests : BaseTests
    {
        public DialogsImageInfoTests(ITestOutputHelper testOutputHelper)
            : base(testOutputHelper)
        {
        }

        [Fact]
        public void ConvertCreatedAt()
        {
            string fileContent = File.ReadAllText(TestsConstants.Assets.DialogsImageInfoFilePath);
            var options = new JsonSerializerOptions()
            {
            };
            var imageInfo = JsonSerializer.Deserialize<DialogsImageInfo>(fileContent, options);
            Assert.NotEqual(default, imageInfo.CreatedAt);
            TestOutputHelper.WriteLine(imageInfo.CreatedAt.ToString(AliceConstants.DateTimeFormat, CultureInfo.InvariantCulture));
        }

        [Fact]
        public void TestDateTimeFormat()
        {
            string sample = "2020-07-12T08:14:09.980Z";
            DateTimeOffset.TryParseExact(sample, AliceConstants.DateTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out DateTimeOffset result);
            Assert.NotEqual(default, result);
            Assert.Equal(sample, result.ToString(AliceConstants.DateTimeFormat, CultureInfo.InvariantCulture));
        }
    }
}

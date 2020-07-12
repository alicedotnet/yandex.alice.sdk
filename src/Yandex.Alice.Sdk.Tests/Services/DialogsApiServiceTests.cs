using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using Yandex.Alice.Sdk.Models.DialogsApi;
using Yandex.Alice.Sdk.Services;
using Yandex.Alice.Sdk.Services.Interfaces;
using Yandex.Alice.Sdk.Tests.TestsInfrastructure;
using Yandex.Alice.Sdk.Tests.TestsInfrastructure.Fixtures;

namespace Yandex.Alice.Sdk.Tests.Services
{
    [Collection(TestsConstants.DialogsApiCollectionName)]
    public class DialogsApiServiceTests : BaseTests
    {
        private readonly IDialogsApiService _dialogsApiService;
        private readonly Guid _skillId;
        private const string _imageUrl = "https://previews.123rf.com/images/aquir/aquir1311/aquir131100316/23569861-sample-grunge-red-round-stamp.jpg";

        public DialogsApiServiceTests(DialogsApiFixture dialogsApiFixture, ITestOutputHelper testOutputHelper)
            :base(testOutputHelper)
        {
            _dialogsApiService = dialogsApiFixture.DialogsApiService;
            _skillId = dialogsApiFixture.SkillId;
        }

        [Fact]
        public async Task Status_NoAuthToken_Fail()
        {
            var settings = new DialogsApiSettings();
            using var dialogsApiService = new DialogsApiService(settings);
            var response = await dialogsApiService.StatusAsync().ConfigureAwait(false);
            Assert.False(response.IsSuccess);
            Assert.Contains("Unauthorized", response.ErrorMessage, StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public async Task Status_Ok()
        {
            var response = await _dialogsApiService.StatusAsync().ConfigureAwait(false);
            Assert.True(response.IsSuccess);
            Assert.NotNull(response.Content);
            ValidateDataUsage(response.Content.Images);
            ValidateDataUsage(response.Content.Sounds);
            WritePrettyJson(response);
        }

        private void ValidateDataUsage(DialogsDataUsageModel dialogsDataUsageModel)
        {
            Assert.NotNull(dialogsDataUsageModel);
            Assert.NotNull(dialogsDataUsageModel.Quota);            
        }

        [Fact]
        public async Task UploadImage_InvalidSkillId_Fail()
        {
            var response = await _dialogsApiService.UploadImageAsync(Guid.Empty, new DialogsImageUploadRequest(null)).ConfigureAwait(false);
            Assert.False(response.IsSuccess);
            Assert.Contains("Resource not found", response.ErrorMessage, StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public async Task UploadImage_InvalidUrl_Fail()
        {
            var response = await _dialogsApiService.UploadImageAsync(_skillId, new DialogsImageUploadRequest(new Uri("https://www.google.com/"))).ConfigureAwait(false);
            Assert.False(response.IsSuccess);
            Assert.Contains("Invalid image", response.ErrorMessage, StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public async Task UploadImage_Ok()
        {
            var response = await _dialogsApiService.UploadImageAsync(_skillId, new DialogsImageUploadRequest(new Uri(_imageUrl))).ConfigureAwait(false);
            Assert.True(response.IsSuccess, response.ErrorMessage);
            Assert.NotNull(response.Content);
            Assert.NotNull(response.Content.Image);
            Assert.NotNull(response.Content.Image.Id);
            Assert.NotNull(response.Content.Image.OriginalUrl);
            Assert.True(response.Content.Image.Size > 0);
            Assert.NotEqual(default, response.Content.Image.CreatedAt);
            TestOutputHelper.WriteLine($"CreatedAt: {response.Content.Image.CreatedAt.ToString(AliceConstants.DateTimeFormat, CultureInfo.InvariantCulture)}");
            await _dialogsApiService.DeleteImageAsync(_skillId, response.Content.Image.Id).ConfigureAwait(false);
        }

        [Fact]
        public async Task DeleteImage_InvalidImageId_Fail()
        {
            var response = await _dialogsApiService.DeleteImageAsync(_skillId, "iaminvalid").ConfigureAwait(false);
            Assert.False(response.IsSuccess);
        }

        [Fact]
        public async Task DeleteImage_Ok()
        {
            var uploadResponse = await _dialogsApiService.UploadImageAsync(_skillId, new DialogsImageUploadRequest(new Uri(_imageUrl))).ConfigureAwait(false);
            string imageId = uploadResponse.Content.Image.Id;
            var response = await _dialogsApiService.DeleteImageAsync(_skillId, imageId).ConfigureAwait(false);
            Assert.True(response.IsSuccess);
        }
    }
}

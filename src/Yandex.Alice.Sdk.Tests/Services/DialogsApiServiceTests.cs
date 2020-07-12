using System;
using System.Collections.Generic;
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
        private readonly ITestOutputHelper _testOutputHelper;

        public DialogsApiServiceTests(DialogsApiFixture dialogsApiFixture, ITestOutputHelper testOutputHelper)
            :base(testOutputHelper)
        {
            _dialogsApiService = dialogsApiFixture.DialogsApiService;
            _testOutputHelper = testOutputHelper;
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
    }
}

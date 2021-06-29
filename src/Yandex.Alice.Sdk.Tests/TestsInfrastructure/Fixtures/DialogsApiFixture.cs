namespace Yandex.Alice.Sdk.Tests.TestsInfrastructure.Fixtures
{
    using Microsoft.Extensions.Configuration;
    using Yandex.Alice.Sdk.Models.DialogsApi;
    using Yandex.Alice.Sdk.Services;
    using Yandex.Alice.Sdk.Tests.TestsInfrastructure.Models;

    public class DialogsApiFixture
    {
        public IDialogsApiService DialogsApiService { get; }

        public AliceSettings AliceSettings { get; }

        public DialogsApiFixture()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddUserSecrets<DialogsApiFixture>()
                .Build();
            var skillIdSection = configuration.GetSection("AliceSettings:SkillId");
            AliceSettings = new AliceSettings(skillIdSection.Value);
            var apiSettings = new DialogsApiSettings(configuration.GetSection("AliceSettings:DialogsOAuthToken").Value);
            DialogsApiService = new DialogsApiService(apiSettings);
        }
    }
}

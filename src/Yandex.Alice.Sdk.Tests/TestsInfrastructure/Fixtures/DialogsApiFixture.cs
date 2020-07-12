using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Yandex.Alice.Sdk.Models.DialogsApi;
using Yandex.Alice.Sdk.Services;

namespace Yandex.Alice.Sdk.Tests.TestsInfrastructure.Fixtures
{
    public class DialogsApiFixture
    {
        public IDialogsApiService DialogsApiService { get; }
        public SkillSettings SkillSettings { get; }

        public DialogsApiFixture()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddUserSecrets<DialogsApiFixture>()
                .Build();
            var dialogsApiSection = configuration.GetSection("DialogsApi");
            var dialogsApiSettings = new DialogsApiSettings();
            dialogsApiSection.Bind(dialogsApiSettings);
            DialogsApiService = new DialogsApiService(dialogsApiSettings);

            var skillSection = configuration.GetSection("Skill");
            SkillSettings = new SkillSettings();
            skillSection.Bind(SkillSettings);
        }
    }
}

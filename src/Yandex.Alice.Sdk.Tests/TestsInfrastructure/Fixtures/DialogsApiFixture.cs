using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Yandex.Alice.Sdk.Models.DialogsApi;
using Yandex.Alice.Sdk.Services;
using Yandex.Alice.Sdk.Services.Interfaces;

namespace Yandex.Alice.Sdk.Tests.TestsInfrastructure.Fixtures
{
    public class DialogsApiFixture
    {
        public IDialogsApiService DialogsApiService { get; }

        public DialogsApiFixture()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddUserSecrets<DialogsApiFixture>()
                .Build();
            var dialogsApiSection = configuration.GetSection("DialogsApi");
            var settings = new DialogsApiSettings();
            dialogsApiSection.Bind(settings);

            DialogsApiService = new DialogsApiService(settings);
        }
    }
}

using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yandex.Alice.Sdk.Demo.Models;
using Yandex.Alice.Sdk.Demo.Services.Interfaces;
using Yandex.Alice.Sdk.Models.DialogsApi;
using Yandex.Alice.Sdk.Services;

namespace Yandex.Alice.Sdk.Demo.Services
{
    public class CleanService : ICleanService
    {
        private readonly IDialogsApiService _dialogsApiService;
        private Guid _skillId;

        public CleanService(IDialogsApiService dialogsApiService, IOptions<SkillSettings> skillSettings)
        {
            _dialogsApiService = dialogsApiService;
            _skillId = skillSettings.Value.SkillId;
        }

        public async Task CleanResourcesAsync()
        {
            var imagesResponse = await _dialogsApiService.GetImagesAsync(_skillId).ConfigureAwait(false);
            foreach (var image in imagesResponse.Content.Images)
            {
                if (!DemoResources.Images.ImagesCollection.Contains(image.Id))
                {
                    await _dialogsApiService.DeleteImageAsync(_skillId, image.Id).ConfigureAwait(false);
                }
            }
        }
    }
}

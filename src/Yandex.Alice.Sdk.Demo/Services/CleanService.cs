namespace Yandex.Alice.Sdk.Demo.Services
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Yandex.Alice.Sdk.Demo.Models;
    using Yandex.Alice.Sdk.Demo.Services.Interfaces;
    using Yandex.Alice.Sdk.Services;

    public class CleanService : ICleanService
    {
        private readonly IDialogsApiService _dialogsApiService;
        private Guid _skillId;

        public CleanService(IDialogsApiService dialogsApiService, AliceSettings aliceSettings)
        {
            if (aliceSettings == null)
            {
                throw new ArgumentNullException(nameof(aliceSettings));
            }

            _dialogsApiService = dialogsApiService;
            _skillId = aliceSettings.SkillId;
        }

        public async Task CleanResourcesAsync()
        {
            var imagesResponse = await _dialogsApiService.GetImagesAsync(_skillId).ConfigureAwait(false);
            var images = imagesResponse.Content.Images
                .Where(image => !DemoResources.Images.ImagesCollection.Contains(image.Id))
                .ToArray();
            foreach (var image in images)
            {
                await _dialogsApiService.DeleteImageAsync(_skillId, image.Id).ConfigureAwait(false);
            }
        }
    }
}

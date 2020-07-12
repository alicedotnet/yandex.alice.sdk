using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Yandex.Alice.Sdk.Models.DialogsApi;
using Yandex.Alice.Sdk.Resources;

namespace Yandex.Alice.Sdk.Services
{
    public class DialogsApiService : IDialogsApiService, IDisposable
    {
        private readonly HttpClient _dialogsApiClient;

        public DialogsApiService(IOptions<DialogsApiSettings> dialogsApiSettings)
            : this(dialogsApiSettings?.Value)
        {

        }

        public DialogsApiService(DialogsApiSettings dialogsApiSettings)
        {
            if(dialogsApiSettings == null)
            {
                throw new ArgumentNullException(nameof(dialogsApiSettings));
            }

            _dialogsApiClient = new HttpClient()
            {
                BaseAddress = new Uri("https://dialogs.yandex.net")
            };
            _dialogsApiClient.DefaultRequestHeaders.Authorization = 
                new AuthenticationHeaderValue("OAuth", dialogsApiSettings.DialogsOAuthToken);
        }

        public async Task<DialogsApiResponse<DialogsStatus>> StatusAsync()
        {
            return await GetAsync<DialogsStatus>("/api/v1/status").ConfigureAwait(false);
        }

        #region Image       

        public async Task<DialogsApiResponse<DialogsImageUploadResponse>> UploadImageAsync(Guid skillId, DialogsWebUploadRequest request)
        {
            string requestUri = $"{GetSkillUrl(skillId)}/images";
            string json = JsonSerializer.Serialize(request);
            using (HttpContent requestContent = new StringContent(json, Encoding.UTF8, "application/json"))
            {
                return await PostAsync<DialogsImageUploadResponse>(requestUri, requestContent).ConfigureAwait(false);
            }
        }

        public async Task<DialogsApiResponse<DialogsImageUploadResponse>> UploadImageAsync(Guid skillId, DialogsFileUploadRequest request)
        {
            string url = $"{GetSkillUrl(skillId)}/images";
            return await PostFileAsync<DialogsImageUploadResponse>(url, request).ConfigureAwait(false);
        }

        public async Task<DialogsApiResponse<DialogsImagesInfoList>> GetImagesAsync(Guid skillId)
        {
            string url = $"{GetSkillUrl(skillId)}/images";
            return await GetAsync<DialogsImagesInfoList>(url).ConfigureAwait(false);
        }

        public async Task<DialogsApiResponse<DialogsDeleteResponse>> DeleteImageAsync(Guid skillId, string imageId)
        {
            string url = $"{GetSkillUrl(skillId)}/images/{imageId}";
            return await DeleteAsync<DialogsDeleteResponse>(url).ConfigureAwait(false);
        }

        #endregion

        #region Sound

        public async Task<DialogsApiResponse<DialogsSoundResponse>> UploadSoundAsync(Guid skillId, DialogsFileUploadRequest request)
        {
            string url = $"{GetSkillUrl(skillId)}/sounds";
            return await PostFileAsync<DialogsSoundResponse>(url, request).ConfigureAwait(false);
        }

        public async Task<DialogsApiResponse<DialogsSoundResponse>> GetSoundAsync(Guid skillId, Guid soundId)
        {
            string url = $"{GetSkillUrl(skillId)}/sounds/{soundId}";
            return await GetAsync<DialogsSoundResponse>(url).ConfigureAwait(false);
        }

        public async Task<DialogsApiResponse<DialogsSoundsInfoList>> GetSoundsAsync(Guid skillId)
        {
            string url = $"{GetSkillUrl(skillId)}/sounds";
            return await GetAsync<DialogsSoundsInfoList>(url).ConfigureAwait(false);
        }

        public async Task<DialogsApiResponse<DialogsDeleteResponse>> DeleteSoundAsync(Guid skillId, Guid soundId)
        {
            string url = $"{GetSkillUrl(skillId)}/sounds/{soundId}";
            return await DeleteAsync<DialogsDeleteResponse>(url).ConfigureAwait(false);
        }

        #endregion
        
        private string GetSkillUrl(Guid skillId)
        {
            if(skillId == Guid.Empty)
            {
                throw new ArgumentException(Yandex_Alice_Sdk_Resources.Error_NoSkillId, nameof(skillId));
            }
            return $"/api/v1/skills/{skillId}";
        }

        private async Task<DialogsApiResponse<TContent>> GetAsync<TContent>(string url)
        {
            using (var requestMessage = new HttpRequestMessage(HttpMethod.Get, url))
            {
                return await SendAsync<TContent>(requestMessage).ConfigureAwait(false);
            }
        }

        private async Task<DialogsApiResponse<TContent>> PostAsync<TContent>(string url, HttpContent content)
        {
            using (var requestMessage = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = content
            })
            {
                return await SendAsync<TContent>(requestMessage).ConfigureAwait(false);
            }
        }

        private async Task<DialogsApiResponse<TContent>> DeleteAsync<TContent>(string url)
        {
            using (var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, url))
            {
                return await SendAsync<TContent>(httpRequestMessage).ConfigureAwait(false);
            }
        }

        private async Task<DialogsApiResponse<TContent>> PostFileAsync<TContent>(string url, DialogsFileUploadRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            using (var streamContent = new StreamContent(request.Content))
            {
                using (var formContent = new MultipartFormDataContent
                    {
                        {streamContent,"file", request.FileName}
                    })
                {
                    return await PostAsync<TContent>(url, formContent).ConfigureAwait(false);
                }
            }
        }

        private async Task<DialogsApiResponse<TContent>> SendAsync<TContent>(HttpRequestMessage message)
        {
            var apiResponse = await _dialogsApiClient.SendAsync(message).ConfigureAwait(false);
            string contentString = await apiResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
            DialogsApiResponse<TContent> response;
            if (apiResponse.IsSuccessStatusCode)
            {
                var content = JsonSerializer.Deserialize<TContent>(contentString);
                response = new DialogsApiResponse<TContent>(content);
            }
            else if (apiResponse.Content.Headers.ContentType.MediaType == "application/json")
            {
                var content = JsonSerializer.Deserialize<DialogsResponseContent>(contentString);
                response = new DialogsApiResponse<TContent>(content.Message);
            }
            else
            {
                response = new DialogsApiResponse<TContent>(contentString);
            }
            return response;
        }

        #region Dispose

        private bool disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _dialogsApiClient.Dispose();
                }

                disposedValue = true;
            }
        }

        // ~DialogsApiService()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}

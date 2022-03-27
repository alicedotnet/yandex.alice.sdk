namespace Yandex.Alice.Sdk.Services
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Yandex.Alice.Sdk.Models.DialogsApi;
    using Yandex.Alice.Sdk.Resources;

    public class DialogsApiService : ApiServiceBase, IDialogsApiService
    {
        public DialogsApiService(DialogsApiSettings dialogsApiSettings)
        {
            if (dialogsApiSettings == null)
            {
                throw new ArgumentNullException(nameof(dialogsApiSettings));
            }

            if (string.IsNullOrEmpty(dialogsApiSettings.DialogsOAuthToken))
            {
                throw new ArgumentException(AliceResources.Error_NoOAuthToken);
            }

            ApiClient = new HttpClient
            {
                BaseAddress = new Uri(dialogsApiSettings.BaseAddress),
            };
            ApiClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("OAuth", dialogsApiSettings.DialogsOAuthToken);
        }

        public async Task<DialogsApiResponse<DialogsStatus>> StatusAsync()
        {
            return await GetAsync<DialogsStatus>("/api/v1/status").ConfigureAwait(false);
        }

        public Task<DialogsApiResponse<DialogsImageUploadResponse>> UploadImageAsync(Guid skillId, DialogsWebUploadRequest request)
        {
            var requestUri = $"{GetSkillUrl(skillId)}/images";
            return PostAsync<DialogsImageUploadResponse, DialogsWebUploadRequest>(requestUri, request);
        }

        public async Task<DialogsApiResponse<DialogsImageUploadResponse>> UploadImageAsync(Guid skillId, DialogsFileUploadRequest request)
        {
            var url = $"{GetSkillUrl(skillId)}/images";
            return await PostFileAsync<DialogsImageUploadResponse>(url, request).ConfigureAwait(false);
        }

        public async Task<DialogsApiResponse<DialogsImagesInfoList>> GetImagesAsync(Guid skillId)
        {
            var url = $"{GetSkillUrl(skillId)}/images";
            return await GetAsync<DialogsImagesInfoList>(url).ConfigureAwait(false);
        }

        public async Task<DialogsApiResponse<DialogsDeleteResponse>> DeleteImageAsync(Guid skillId, string imageId)
        {
            var url = $"{GetSkillUrl(skillId)}/images/{imageId}";
            return await DeleteAsync<DialogsDeleteResponse>(url).ConfigureAwait(false);
        }

        public async Task<DialogsApiResponse<DialogsSoundResponse>> UploadSoundAsync(Guid skillId, DialogsFileUploadRequest request)
        {
            var url = $"{GetSkillUrl(skillId)}/sounds";
            return await PostFileAsync<DialogsSoundResponse>(url, request).ConfigureAwait(false);
        }

        public async Task<DialogsApiResponse<DialogsSoundResponse>> GetSoundAsync(Guid skillId, Guid soundId)
        {
            var url = $"{GetSkillUrl(skillId)}/sounds/{soundId}";
            return await GetAsync<DialogsSoundResponse>(url).ConfigureAwait(false);
        }

        public async Task<DialogsApiResponse<DialogsSoundsInfoList>> GetSoundsAsync(Guid skillId)
        {
            var url = $"{GetSkillUrl(skillId)}/sounds";
            return await GetAsync<DialogsSoundsInfoList>(url).ConfigureAwait(false);
        }

        public async Task<DialogsApiResponse<DialogsDeleteResponse>> DeleteSoundAsync(Guid skillId, Guid soundId)
        {
            var url = $"{GetSkillUrl(skillId)}/sounds/{soundId}";
            return await DeleteAsync<DialogsDeleteResponse>(url).ConfigureAwait(false);
        }

        public Task<DialogsApiResponse<DialogsSmartHomeResponse>> CallbackStateAsync(Guid skillId, DialogsCallbackStateRequest request)
        {
            var url = $"{GetSkillUrl(skillId)}/callback/state";
            return PostAsync<DialogsSmartHomeResponse, DialogsCallbackStateRequest>(url, request);
        }

        public Task<DialogsApiResponse<DialogsSmartHomeResponse>> CallbackDiscoveryAsync(Guid skillId, DialogsCallbackDiscoveryRequest request)
        {
            var url = $"{GetSkillUrl(skillId)}/callback/discovery";
            return PostAsync<DialogsSmartHomeResponse, DialogsCallbackDiscoveryRequest>(url, request);
        }

        private static string GetSkillUrl(Guid skillId)
        {
            if (skillId == Guid.Empty)
            {
                throw new ArgumentException(AliceResources.Error_NoSkillId, nameof(skillId));
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

        private Task<DialogsApiResponse<TContent>> PostAsync<TContent, TPayload>(string url, TPayload payload)
        {
            var json = JsonSerializer.Serialize(payload);
            HttpContent requestContent = new StringContent(json, Encoding.UTF8, "application/json");
            return PostAsync<TContent>(url, requestContent);
        }

        private async Task<DialogsApiResponse<TContent>> PostAsync<TContent>(string url, HttpContent content)
        {
            using (var requestMessage = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = content,
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

        private Task<DialogsApiResponse<TContent>> PostFileAsync<TContent>(string url, DialogsFileUploadRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            return PostFileInternalAsync<TContent>(url, request);
        }

        private async Task<DialogsApiResponse<TContent>> PostFileInternalAsync<TContent>(string url, DialogsFileUploadRequest request)
        {
            using (var streamContent = new StreamContent(request.Content))
            {
                using (var formContent = new MultipartFormDataContent
                    {
                        { streamContent, "file", request.FileName },
                    })
                {
                    return await PostAsync<TContent>(url, formContent).ConfigureAwait(false);
                }
            }
        }

        private async Task<DialogsApiResponse<TContent>> SendAsync<TContent>(HttpRequestMessage message)
        {
            var apiResponse = await ApiClient.SendAsync(message).ConfigureAwait(false);
            var contentString = await apiResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
            DialogsApiResponse<TContent> response;
            if (apiResponse.IsSuccessStatusCode)
            {
                var content = JsonSerializer.Deserialize<TContent>(contentString);
                response = new DialogsApiResponse<TContent>(content);
            }
            else if (apiResponse.Content.Headers.ContentType.MediaType == "application/json")
            {
                var requestUrl = apiResponse.RequestMessage.RequestUri.AbsolutePath;
                string errorMessage, errorCode = null;
                if (requestUrl.EndsWith("/callback/state", StringComparison.OrdinalIgnoreCase)
                    || requestUrl.EndsWith("/callback/discovery", StringComparison.OrdinalIgnoreCase))
                {
                    var content = JsonSerializer.Deserialize<DialogsSmartHomeResponse>(contentString);
                    errorMessage = content.ErrorMessage;
                    errorCode = content.ErrorCode;
                }
                else
                {
                    var content = JsonSerializer.Deserialize<DialogsResponseContent>(contentString);
                    errorMessage = content.Message;
                }

                response = new DialogsApiResponse<TContent>(errorMessage, errorCode);
            }
            else
            {
                response = new DialogsApiResponse<TContent>(contentString);
            }

            return response;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Yandex.Alice.Sdk.Models.DialogsApi;
using Yandex.Alice.Sdk.Services.Interfaces;

namespace Yandex.Alice.Sdk.Services
{
    public class DialogsApiService : IDialogsApiService, IDisposable
    {
        private readonly HttpClient _dialogsApiClient;

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

        public async Task<DialogsApiResponse<DialogsStatusResponse>> StatusAsync()
        {
            var apiResponse = await _dialogsApiClient.GetAsync("/api/v1/status").ConfigureAwait(false);
            string contentString = await apiResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
            DialogsApiResponse<DialogsStatusResponse> response;
            if (apiResponse.IsSuccessStatusCode)
            {
                var content = JsonSerializer.Deserialize<DialogsStatusResponse>(contentString);
                response = new DialogsApiResponse<DialogsStatusResponse>(content);
            }
            else
            {
                response = new DialogsApiResponse<DialogsStatusResponse>(contentString);
            }
            return response;
        }

        public async Task<DialogsApiResponse<DialogsImageUploadResponse>> UploadImage(Guid skillId, DialogsImageUploadRequest request)
        {
            string requestUri = $"/api/v1/skills/{skillId}/images";
            string json = JsonSerializer.Serialize(request);
            DialogsApiResponse<DialogsImageUploadResponse> response = null;
            using (HttpContent requestContent = new StringContent(json, Encoding.UTF8, "application/json"))
            {
                var apiResponse = await _dialogsApiClient.PostAsync(requestUri, requestContent).ConfigureAwait(false);
                string contentString = await apiResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                if(apiResponse.IsSuccessStatusCode)
                {
                    var content = JsonSerializer.Deserialize<DialogsImageUploadResponse>(contentString);
                    response = new DialogsApiResponse<DialogsImageUploadResponse>(content);
                }
                else
                {
                    var content = JsonSerializer.Deserialize<DialogsResponseContent>(contentString);
                    response = new DialogsApiResponse<DialogsImageUploadResponse>(content.Message);
                }
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

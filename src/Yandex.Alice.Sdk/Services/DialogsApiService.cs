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

        public async Task<DialogsApiResponse<DialogsStatusModel>> StatusAsync()
        {
            var apiResponse = await _dialogsApiClient.GetAsync("/api/v1/status").ConfigureAwait(false);
            string contentString = await apiResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
            DialogsApiResponse<DialogsStatusModel> response;
            if (apiResponse.IsSuccessStatusCode)
            {
                var content = JsonSerializer.Deserialize<DialogsStatusModel>(contentString);
                response = new DialogsApiResponse<DialogsStatusModel>(content);
            }
            else
            {
                response = new DialogsApiResponse<DialogsStatusModel>(contentString);
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
                    // TODO: dispose managed state (managed objects)
                    _dialogsApiClient.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
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

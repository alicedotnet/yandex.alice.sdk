namespace Yandex.Alice.Sdk.Services
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Yandex.Alice.Sdk.Models.IoTApi;
    using Yandex.Alice.Sdk.Resources;

    public class IoTApiService : ApiServiceBase, IIoTApiService
    {
        public IoTApiService(string baseAddress = "https://api.iot.yandex.net")
        {
            if (baseAddress == null)
            {
                throw new ArgumentNullException(nameof(baseAddress));
            }

            ApiClient = new HttpClient()
            {
                BaseAddress = new Uri(baseAddress),
            };
        }

        public Task<IoTApiResponse<IoTUserInfoResponse>> GetUserInfoAsync(string authToken)
        {
            return GetAsync<IoTUserInfoResponse>(authToken, "/v1.0/user/info");
        }

        public Task<IoTApiResponse<IoTDeviceResponse>> GetDeviceAsync(string authToken, string deviceId)
        {
            if (string.IsNullOrEmpty(deviceId))
            {
                throw new ArgumentException("No Device Id provided", nameof(deviceId));
            }

            return GetAsync<IoTDeviceResponse>(authToken, $"/v1.0/devices/{deviceId}");
        }

        public Task<IoTApiResponse<IoTManageDevicesResponse>> ManageDevicesAsync(string authToken, IoTManageDevicesRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            return PostAsync<IoTManageDevicesResponse, IoTManageDevicesRequest>(authToken, $"/v1.0/devices/actions", request);
        }

        public Task<IoTApiResponse<IoTGroupResponse>> GetGroupAsync(string authToken, string groupId)
        {
            if (string.IsNullOrEmpty(groupId))
            {
                throw new ArgumentException("No Group Id provided", nameof(groupId));
            }

            return GetAsync<IoTGroupResponse>(authToken, $"/v1.0/groups/{groupId}");
        }

        public Task<IoTApiResponse<IoTManageGroupResponse>> ManageGroupAsync(string authToken, string groupId, IoTManageGroupRequest request)
        {
            if (string.IsNullOrEmpty(groupId))
            {
                throw new ArgumentException("No Group Id provided", nameof(groupId));
            }

            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            return PostAsync<IoTManageGroupResponse, IoTManageGroupRequest>(authToken, $"/v1.0/groups/{groupId}/actions", request);
        }

        public Task<IoTApiResponse<IoTManageScenarioResponse>> ManageScenarioAsync(string authToken, string scenarioId)
        {
            if (string.IsNullOrEmpty(scenarioId))
            {
                throw new ArgumentException("No Scenario Id provided", nameof(scenarioId));
            }

            return PostAsync<IoTManageScenarioResponse, object>(authToken, $"/v1.0/scenarios/{scenarioId}/actions", null);
        }

        private async Task<IoTApiResponse<TContent>> GetAsync<TContent>(string authToken, string url)
            where TContent : IoTResponseBase
        {
            using (var requestMessage = new HttpRequestMessage(HttpMethod.Get, url))
            {
                return await SendAsync<TContent>(authToken, requestMessage).ConfigureAwait(false);
            }
        }

        private async Task<IoTApiResponse<TContent>> PostAsync<TContent, TRequest>(string authToken, string url, TRequest payload)
            where TContent : IoTResponseBase
        {
            using (var requestMessage = new HttpRequestMessage(HttpMethod.Post, url))
            {
                var json = JsonSerializer.Serialize(payload);
                requestMessage.Content = new StringContent(json, Encoding.UTF8, "application/json");
                return await SendAsync<TContent>(authToken, requestMessage).ConfigureAwait(false);
            }
        }

        private Task<IoTApiResponse<TContent>> SendAsync<TContent>(string authToken, HttpRequestMessage message)
            where TContent : IoTResponseBase
        {
            if (string.IsNullOrEmpty(authToken))
            {
                throw new ArgumentException(Yandex_Alice_Sdk_Resources.Error_NoOAuthToken);
            }

            message.Headers.Authorization = new AuthenticationHeaderValue("Bearer", authToken);

            return SendAsync<TContent>(message);
        }

        private async Task<IoTApiResponse<TContent>> SendAsync<TContent>(HttpRequestMessage message)
            where TContent : IoTResponseBase
        {
            var apiResponse = await ApiClient.SendAsync(message).ConfigureAwait(false);
            string contentString = await apiResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
            TContent content = default;
            string errorMessage = null;
            bool isSuccess = false;
            if (apiResponse.Content.Headers.ContentType.MediaType == "application/json")
            {
                content = JsonSerializer.Deserialize<TContent>(contentString);
                isSuccess = apiResponse.IsSuccessStatusCode && content.Status == SmartHomeConstants.Status.Ok;
            }
            else
            {
                errorMessage = contentString;
            }

            var response = new IoTApiResponse<TContent>(content, errorMessage, isSuccess);
            return response;
        }
    }
}

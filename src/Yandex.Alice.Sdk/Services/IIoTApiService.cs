namespace Yandex.Alice.Sdk.Services
{
    using System.Threading.Tasks;
    using Yandex.Alice.Sdk.Models.IoTApi;

    public interface IIoTApiService
    {
        Task<IoTApiResponse<IoTUserInfoResponse>> GetUserInfoAsync(string authToken);

        Task<IoTApiResponse<IoTDeviceResponse>> GetDeviceAsync(string authToken, string deviceId);

        Task<IoTApiResponse<IoTManageDevicesResponse>> ManageDevicesAsync(string authToken, IoTManageDevicesRequest request);

        Task<IoTApiResponse<IoTGroupResponse>> GetGroupAsync(string authToken, string groupId);

        Task<IoTApiResponse<IoTManageGroupResponse>> ManageGroupAsync(string authToken, string groupId, IoTManageGroupRequest request);

        Task<IoTApiResponse<IoTManageScenarioResponse>> ManageScenarioAsync(string authToken, string scenarioId);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Yandex.Alice.Sdk.Models.DialogsApi;

namespace Yandex.Alice.Sdk.Services.Interfaces
{
    public interface IDialogsApiService
    {
        Task<DialogsApiResponse<DialogsStatus>> StatusAsync();
        Task<DialogsApiResponse<DialogsImageUploadResponse>> UploadImageAsync(Guid skillId, DialogsImageUploadRequest request);
        Task<DialogsApiResponse<DialogsImageUploadResponse>> UploadImageAsync(Guid skillId, DialogsImageFileUploadRequest request);
        Task<DialogsApiResponse<DialogsImagesInfoList>> GetImagesAsync(Guid skillId);
        Task<DialogsApiResponse<DialogsDeleteResponse>> DeleteImageAsync(Guid skillId, string imageId);
    }
}

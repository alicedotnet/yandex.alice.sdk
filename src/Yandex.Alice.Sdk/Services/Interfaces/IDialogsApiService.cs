using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Yandex.Alice.Sdk.Models.DialogsApi;

namespace Yandex.Alice.Sdk.Services.Interfaces
{
    public interface IDialogsApiService
    {
        Task<DialogsApiResponse<DialogsStatusModel>> StatusAsync();
    }
}

namespace Yandex.Alice.Sdk.Demo.Services.Interfaces;

using System.Threading.Tasks;
using Models;
using Sdk.Models;

public interface IAliceService
{
    Task<IAliceResponseBase> GetAliceResponseAsync(DemoAliceRequest aliceRequest);
}
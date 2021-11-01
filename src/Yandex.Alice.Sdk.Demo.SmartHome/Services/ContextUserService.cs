namespace Yandex.Alice.Sdk.Demo.SmartHome.Services
{
    using System.Linq;
    using Microsoft.AspNetCore.Http;

    public class ContextUserService : IContextUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ContextUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetContextUserId()
        {
            return _httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == "sub").Value;
        }
    }
}

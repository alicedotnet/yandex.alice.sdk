namespace Yandex.Alice.Sdk.Demo.SmartHome.Controllers.V1
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Yandex.Alice.Sdk.Demo.SmartHome.Models;
    using Yandex.Alice.Sdk.Demo.SmartHome.Services;
    using Yandex.Alice.Sdk.Models.SmartHome;
    using static IdentityServer4.IdentityServerConstants;

    [ApiController]
    [Route("v1.0/user/unlink")]
    [Authorize(LocalApi.PolicyName)]
    public class UnlinkController : ControllerBase
    {
        private readonly IContextUserService _contextUserService;
        private readonly ILogger<UnlinkController> _logger;

        public UnlinkController(IContextUserService contextUserService, ILogger<UnlinkController> logger)
        {
            _contextUserService = contextUserService;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Unlink([FromHeader] SmartHomeRequestHeaders requestHeader)
        {
            var response = new SmartHomeResponseAccountUnlink()
            {
                RequestId = requestHeader.RequestId,
            };

            _logger.LogWarning($"User '{_contextUserService.GetContextUserId()}' unlinked his account");

            return Ok(response);
        }
    }
}

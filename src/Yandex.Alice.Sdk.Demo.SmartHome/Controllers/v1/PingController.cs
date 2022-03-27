namespace Yandex.Alice.Sdk.Demo.SmartHome.Controllers.v1;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("v1.0")]
public class PingController : ControllerBase
{
    [HttpHead]
    public IActionResult Ping()
    {
        return Ok();
    }
}
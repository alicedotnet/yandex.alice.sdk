namespace Yandex.Alice.Sdk.Demo.SmartHome.Controllers.v1;

using Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using Sdk.Models.SmartHome;
using Services;
using static IdentityServer4.IdentityServerConstants;

[ApiController]
[Route("v1.0/user/devices")]
[Authorize(LocalApi.PolicyName)]
public class DevicesController : ControllerBase
{
    private readonly IDeviceService _deviceService;
    private readonly ILogger<DevicesController> _logger;

    public DevicesController(IDeviceService deviceService, ILogger<DevicesController> logger)
    {
        _deviceService = deviceService;
        _logger = logger;
    }

    [HttpGet]
    public IActionResult GetDevices([FromHeader] SmartHomeRequestHeaders requestHeaders)
    {
        var response = _deviceService.GetDevicesResponse(requestHeaders);
        return Ok(response);
    }

    [HttpPost]
    [Route("query")]
    public IActionResult QueryDevices([FromHeader] SmartHomeRequestHeaders requestHeaders, [FromBody] SmartHomeRequestDevicesQuery payload)
    {
        try
        {
            var response = _deviceService.GetDevicesQueryResponse(requestHeaders, payload);
            return Ok(response);
        }
        catch (DeviceNotFoundException e)
        {
            _logger.LogInformation(e, "Device not found");
            return NotFound();
        }
    }

    [HttpPost]
    [Route("action")]
    public IActionResult Action([FromHeader] SmartHomeRequestHeaders requestHeaders, [FromBody] SmartHomeRequestDevicesAction payload)
    {
        var response = _deviceService.ChangeDeviceState(requestHeaders, payload);
        return Ok(response);
    }
}
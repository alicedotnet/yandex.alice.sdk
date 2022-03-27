namespace Yandex.Alice.Sdk.Demo.Controllers;

using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Interfaces;
using Yandex.Alice.Sdk.Demo.Extensions;
using Yandex.Alice.Sdk.Demo.Models;

[ApiController]
[Route("[controller]")]
public class AliceController : ControllerBase
{
    private readonly IAliceService _aliceService;
    private readonly ILogger<AliceController> _logger;

    public AliceController(
        IAliceService aliceService,
        ILogger<AliceController> logger)
    {
        _aliceService = aliceService;
        _logger = logger;
    }

    [HttpPost]
    [Route("/alice")]
    public async Task<IActionResult> Get(DemoAliceRequest aliceRequest)
    {
        try
        {
            var response = await _aliceService.GetAliceResponseAsync(aliceRequest).ConfigureAwait(false);
            return Ok(response);
        }
        catch (Exception e)
        {
            Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var requestText = JsonSerializer.Serialize(aliceRequest);
            _logger.UnexpectedRequestError(e, requestText);
            return Content(e.ToString());
        }
    }
}
![Yandex.Alice.SDK](src/Yandex.Alice.Sdk/Resources/icon.png "Yandex.Alice.SDK")

.Net SDK for development of Yandex Alice skills using C# language.

![yandex.alice.sdk](https://github.com/alexvolchetsky/yandex.alice.sdk/workflows/yandex.alice.sdk/badge.svg)
![yandex.alice.sdk.demo](https://github.com/alexvolchetsky/yandex.alice.sdk/workflows/yandex.alice.sdk.demo/badge.svg)
[![NuGet](https://buildstats.info/nuget/Yandex.Alice.Sdk)](https://www.nuget.org/packages/Yandex.Alice.Sdk)

# Installation
Install NuGet package with SDK: 

`Install-Package Yandex.Alice.Sdk`
# Usage
This repository has [demo project](examples/yandex.alice.sdk.demo) written on ASP.NET Core Web Api, which demonstrates usage of SDK.

Demo project skill was publish in Alice catalogue:

[![alice](https://dialogs.s3.yandex.net/badges/v1-term1.svg)](https://dialogs.yandex.ru/store/skills/245ea3a4-net-sdk?utm_source=https://github.com&utm_medium=badge&utm_campaign=v1&utm_term=d1)

In general you would need to create controller with POST action method which receive object of AliceRequest class as parameter. 

Method can return one of three response types according to [Alice protocol](https://yandex.ru/dev/dialogs/alice/doc/protocol-docpage/?ncrnd=4989):
* AliceResponse - without images
* AliceImageResponse - with one image
* AliceGalleryResponse - with gallery of several images

Simple example of implementation of functionality described above:

```c#
using Microsoft.AspNetCore.Mvc;
using Yandex.Alice.Sdk.Models;

[ApiController]
[Route("[controller]")]
public class AliceController : ControllerBase
{
    [HttpPost]
    [Route("/alice")]
    public IActionResult Get(AliceRequest aliceRequest)
    {
        return Ok(new AliceResponse(aliceRequest, "Hello"));
    }
}
```

# Documentation
More info about library you can find in [wiki](https://github.com/alexvolchetsky/yandex.alice.sdk/wiki)
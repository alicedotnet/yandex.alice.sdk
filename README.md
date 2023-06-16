![Yandex.Alice.SDK](https://raw.githubusercontent.com/alexvolchetsky/yandex.alice.sdk/master/src/Yandex.Alice.Sdk/Resources/icon.png "Yandex.Alice.SDK")

.Net SDK for development of Yandex Alice skills using C# language.

![yandex.alice.sdk](https://github.com/alexvolchetsky/yandex.alice.sdk/workflows/yandex.alice.sdk/badge.svg)
![yandex.alice.sdk.demo](https://github.com/alexvolchetsky/yandex.alice.sdk/workflows/yandex.alice.sdk.demo/badge.svg)
[![NuGet](https://buildstats.info/nuget/Yandex.Alice.Sdk)](https://www.nuget.org/packages/Yandex.Alice.Sdk)


It supports the following skill types:
- ![General skills](https://raw.githubusercontent.com/alexvolchetsky/yandex.alice.sdk/master/media/images/general-skill.png) [General skills](#general-skills)
- ![Smart home skills](https://raw.githubusercontent.com/alexvolchetsky/yandex.alice.sdk/master/media/images/smart-home-skill.png) [Smart home skills](#smart-home-skills)

# Installation
Install NuGet package with SDK: 

`Install-Package Yandex.Alice.Sdk`
# General skills
This repository has a [demo project](https://github.com/alexvolchetsky/yandex.alice.sdk/tree/master/src/Yandex.Alice.Sdk.Demo) written on ASP.NET Core Web Api, which demonstrates the usage of SDK.

Demo project skill was published in the Alice catalog:

[![alice](https://raw.githubusercontent.com/alexvolchetsky/yandex.alice.sdk/master/media/images/skill-badge.svg)](https://dialogs.yandex.ru/store/skills/245ea3a4-net-sdk?utm_source=https://github.com&utm_medium=badge&utm_campaign=v1&utm_term=d1)

In general, you would need to create a controller with the POST action method which receives an object of AliceRequest class as a parameter. 

The method can return one of three response types according to [Alice's protocol](https://yandex.ru/dev/dialogs/alice/doc/protocol-docpage/?ncrnd=4989):
* AliceResponse - without images
* AliceImageResponse - with one image
* AliceGalleryResponse - with a gallery of several images

A simple example of the implementation of functionality is described above:

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

More info you can find in the [wiki](https://github.com/alexvolchetsky/yandex.alice.sdk/wiki)

# Smart home skills
For Smart home skills in addition to the server that receives requests from Alice, you would need an additional OAuth server.
In this [smart home demo project](https://github.com/alexvolchetsky/yandex.alice.sdk/tree/master/src/Yandex.Alice.Sdk.Demo.SmartHome), both servers were combined in one for simplicity.
This [wiki page](https://github.com/alexvolchetsky/yandex.alice.sdk/wiki/Smart-Home) has a guide that you can use to quickly create a skill and test library.

# Contributing
Please check out the [Contributing guide](https://github.com/alexvolchetsky/yandex.alice.sdk/tree/master/CONTRIBUTING.md) for guidelines about how to start.

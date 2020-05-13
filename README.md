![Yandex.Alice.SDK](src/Yandex.Alice.Sdk/Resources/icon.png "Yandex.Alice.SDK")

.Net SDK для разработки навыков Яндекс Алисы на языке C#

# Установка
Установите пакет c SDK: 

`Install-Package Yandex.Alice.Sdk`
# Использование
Репозиторий содержит [тестовый проект](examples/yandex.alice.sdk.demo) на ASP.NET Core Web Api, который демонстрирует работу с SDK.

В целом вам нужно будет создать контроллер с POST методом действия, принимающим объект класса AliceRequest в качестве параметра.

Метод может вернуть один из 3-х типов ответов в соответствии с [протоколом алисы](https://yandex.ru/dev/dialogs/alice/doc/protocol-docpage/#response):
* AliceResponse - без изображений
* AliceImageResponse - с одним изображением
* AliceGalleryResponse - с галереей из нескольких изображений

Простой пример реализации описанной выше функциональности:

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
        return Ok(new AliceResponse(aliceRequest, "Привет"));
    }
}
```
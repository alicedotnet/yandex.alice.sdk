using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Yandex.Alice.Sdk.Helpers;
using Yandex.Alice.Sdk.Models;

namespace Yandex.Alice.Sdk.Demo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AliceController : ControllerBase
    {
        private const string _codeButtonTitle = "посмотреть код";
        private const string _noImageButtonTitle = "ответ без изображений";
        private const string _oneImageButtonTitle = "ответ с одним изображением";
        private const string _galleryButtonTitle = "ответ с галереей из нескольких изображений";

        [HttpPost]
        [Route("/alice")]
        public IActionResult Get(AliceRequest aliceRequest)
        {
            try
            {
                return Ok(GetAliceResponse(aliceRequest));
            }
            catch(Exception e)
            {
                Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                return Content(e.ToString());
            }
        }

        private static AliceResponseBase GetAliceResponse(AliceRequest aliceRequest)
        {
            if (aliceRequest.Request.Command == _noImageButtonTitle)
            {
                string text = $"Это пример ответа без изображений. Здесь может быть текст или например эмодзи {char.ConvertFromUtf32(0x1F60E)}";
                var buttons = new List<AliceButtonModel>()
                    {
                        new AliceButtonModel(_codeButtonTitle, false, null, new Uri("https://github.com/alexvolchetsky/yandex.alice.sdk")),
                        new AliceButtonModel(_oneImageButtonTitle),
                        new AliceButtonModel(_galleryButtonTitle)
                    };
                return new AliceResponse(aliceRequest, text, buttons);
            }
            else if (aliceRequest.Request.Command == _oneImageButtonTitle)
            {
                string text = $"Здесь можно отобразить только одно большое фото. Например котика";
                var buttons = new List<AliceButtonModel>()
                    {
                        new AliceButtonModel(_codeButtonTitle, true, null, new Uri("https://github.com/alexvolchetsky/yandex.alice.sdk")),
                        new AliceButtonModel(_noImageButtonTitle, true),
                        new AliceButtonModel(_galleryButtonTitle, true)
                    };
                var aliceResponse = new AliceImageResponse(aliceRequest, text, buttons);
                aliceResponse.Response.Card = new AliceImageCardModel
                {
                    Title = "Манчкин",
                    Description = "Современная порода кошек. При средней длине тела их лапки короче, чем у обычных кошек в 2-3 раза.",
                    ImageId = "937455/748ce93e9e77af0a53d1",
                    Button = new AliceImageCardButtonModel()
                    {
                        Text = "подробнее",
                        Url = new Uri("https://ru.wikipedia.org/wiki/%D0%9C%D0%B0%D0%BD%D1%87%D0%BA%D0%B8%D0%BD_(%D0%BF%D0%BE%D1%80%D0%BE%D0%B4%D0%B0_%D0%BA%D0%BE%D1%88%D0%B5%D0%BA)")
                    }
                };
                return aliceResponse;    
            }
            else if(aliceRequest.Request.Command == _galleryButtonTitle)
            {
                string text = $"В ответе такого типа можно отобразить несколько фотографий";
                var buttons = new List<AliceButtonModel>()
                    {
                        new AliceButtonModel(_codeButtonTitle, true, null, new Uri("https://github.com/alexvolchetsky/yandex.alice.sdk")),
                        new AliceButtonModel(_noImageButtonTitle, true),
                        new AliceButtonModel(_oneImageButtonTitle, true)
                    };
                var aliceResponse = new AliceGalleryResponse(aliceRequest, text, buttons);
                aliceResponse.Response.Card = new AliceGalleryCardModel
                {
                    Header = new AliceGalleryCardHeaderModel("Щеночки"),
                    Items = new List<AliceGalleryCardItem>()
                    {
                        new AliceGalleryCardItem()
                        {
                            Title = "Ягдтерьер",
                            ImageId = "1656841/2ffd3010e6df3d0fd513",
                            Description = "Порода универсальных охотничьих собак.",
                            Button = new AliceImageCardButtonModel()
                            {
                                Text = "подробнее",
                                Url = new Uri("https://ru.wikipedia.org/wiki/%D0%9D%D0%B5%D0%BC%D0%B5%D1%86%D0%BA%D0%B8%D0%B9_%D1%8F%D0%B3%D0%B4%D1%82%D0%B5%D1%80%D1%8C%D0%B5%D1%80")
                            }
                        },
                        new AliceGalleryCardItem()
                        {
                            Title = "Хаски",
                            ImageId = "965417/8d82b0800c9cf1cdcf78",
                            Description = "Общее название для нескольких пород ездовых собак, выведенных в северных регионах, которые отличаются быстрой манерой тянуть упряжку.",
                            Button = new AliceImageCardButtonModel()
                            {
                                Text = "подробнее",
                                Url = new Uri("https://ru.wikipedia.org/wiki/%D0%A5%D0%B0%D1%81%D0%BA%D0%B8")
                            }
                        },
                        new AliceGalleryCardItem()
                        {
                            Title = "Лабрадор",
                            ImageId = "965417/6ac8614766ecc99a3967",
                            Description = "Порода собак. Первоначально была выведена в качестве охотничьей подружейной собаки.",
                            Button = new AliceImageCardButtonModel()
                            {
                                Text = "подробнее",
                                Url = new Uri("https://ru.wikipedia.org/wiki/%D0%9B%D0%B0%D0%B1%D1%80%D0%B0%D0%B4%D0%BE%D1%80-%D1%80%D0%B5%D1%82%D1%80%D0%B8%D0%B2%D0%B5%D1%80")
                            }
                        }
                    },
                    Footer = new AliceGalleryCardFooterModel("больше щеночков",
                    new AliceImageCardButtonModel()
                    {
                        Text = "больше щеночков",
                        Url = new Uri("https://www.google.com/search?q=%D1%89%D0%B5%D0%BD%D0%BE%D1%87%D0%BA%D0%B8&sxsrf=ALeKk03SlYE13sTDiS7dm3TPL9e5Y3FEMw:1589313761070&source=lnms&tbm=isch&sa=X&ved=2ahUKEwiW4qiRj6_pAhXsw8QBHVOqBHcQ_AUoAXoECAoQAw&biw=1216&bih=601")
                    })
                };
                return aliceResponse;
            }
            else
            {
                string text = aliceRequest.Session.New
                    ? "Привет! Это навык, демонстрирующий работу неофициального SDK для разработки навыков для Алисы на .Net"
                    : "Выберите действие";
                var buttons = new List<AliceButtonModel>()
                    {
                        new AliceButtonModel(_codeButtonTitle, false, null, new Uri("https://github.com/alexvolchetsky/yandex.alice.sdk")),
                        new AliceButtonModel(_noImageButtonTitle),
                        new AliceButtonModel(_oneImageButtonTitle),
                        new AliceButtonModel(_galleryButtonTitle)
                    };
                return new AliceResponse(aliceRequest, text, buttons);
            }
        }
    }
}

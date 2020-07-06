using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Yandex.Alice.Sdk.Demo.Models;
using Yandex.Alice.Sdk.Demo.Models.Intents;
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
        private const string _testIntentButtonTitle = "протестировать интент";
        private const string _homeButtonTitle = "назад";
        private const string _githubLink = "https://github.com/alexvolchetsky/yandex.alice.sdk";
        
        private readonly ILogger<AliceController> _logger;

        public AliceController(ILogger<AliceController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("/alice")]
        public IActionResult Get(AliceRequest<CustomIntents> aliceRequest)
        {
            try
            {
                return Ok(GetAliceResponse(aliceRequest));
            }
            catch(Exception e)
            {
                Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                _logger.LogError(e, string.Empty);
                return Content(e.ToString());
            }
        }        

        private static AliceResponseBase GetAliceResponse(AliceRequest<CustomIntents> aliceRequest)
        {
            if(aliceRequest.Request.Command == _codeButtonTitle)
            {
                string text = $"Вот ссылка на github";
                var buttons = new List<AliceButtonModel>()
                    {
                        new AliceButtonModel(_githubLink, false, null, new Uri(_githubLink))
                    };
                return new AliceResponse(aliceRequest, text, buttons);
            }
            if (aliceRequest.Request.Command == _noImageButtonTitle)
            {
                string text = $"Это пример ответа без изображений. Здесь может быть текст или например эмодзи {char.ConvertFromUtf32(0x1F60E)}";
                var buttons = new List<AliceButtonModel>()
                    {
                        new AliceButtonModel(_codeButtonTitle, false, null, new Uri(_githubLink)),
                        new AliceButtonModel(_oneImageButtonTitle),
                        new AliceButtonModel(_galleryButtonTitle),
                        new AliceButtonModel(_testIntentButtonTitle)
                    };
                return new AliceResponse(aliceRequest, text, buttons);
            }
            if (aliceRequest.Request.Command == _oneImageButtonTitle ||
                aliceRequest.Request.Command == "ответ с 1 изображением")
            {
                string text = $"Здесь можно отобразить только одно большое фото. Например котика";
                var buttons = new List<AliceButtonModel>()
                    {
                        new AliceButtonModel(_codeButtonTitle, true, null, new Uri(_githubLink)),
                        new AliceButtonModel(_noImageButtonTitle, true),
                        new AliceButtonModel(_galleryButtonTitle, true),
                        new AliceButtonModel(_testIntentButtonTitle, true)
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
            if(aliceRequest.Request.Command == _galleryButtonTitle)
            {
                string text = $"В ответе такого типа можно отобразить несколько фотографий";
                var buttons = new List<AliceButtonModel>()
                    {
                        new AliceButtonModel(_codeButtonTitle, true, null, new Uri(_githubLink)),
                        new AliceButtonModel(_noImageButtonTitle, true),
                        new AliceButtonModel(_oneImageButtonTitle, true),
                        new AliceButtonModel(_testIntentButtonTitle, true)
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
            if (aliceRequest.Request.Command == _testIntentButtonTitle)
            {
                string text = "Для того чтобы протестировать интент, нажмите на одну из кнопок";
                var buttons = new List<AliceButtonModel>()
                    {
                        new AliceButtonModel("включи свет в ванной"),
                        new AliceButtonModel("включи кондиционер на кухне"),
                        new AliceButtonModel(_homeButtonTitle)
                    };
                return new AliceResponse(aliceRequest, text, buttons)
                {
                    SessionState = new CustomSessionState(true)
                };
            }
            if(aliceRequest.Request.Command != _homeButtonTitle && aliceRequest.Request.Nlu?.Intents?.TurnOn == null)
            {
                var session = AliceHelper.JsonElementToObject<CustomSessionState>(aliceRequest.State?.Session);
                if(session?.IsInIntentsTestingMode == true)
                {
                    string text = "Не удалось распознать интент. Попробуйте еще раз";
                    var buttons = new List<AliceButtonModel>()
                    {
                        new AliceButtonModel("включи свет в ванной"),
                        new AliceButtonModel("включи кондиционер на кухне"),
                        new AliceButtonModel(_homeButtonTitle)
                    };
                    return new AliceResponse(aliceRequest, text, buttons)
                    {
                        SessionState = new CustomSessionState(true)
                    };
                }
            }
            if (aliceRequest.Request.Nlu?.Intents?.TurnOn != null)
            {
                var what = aliceRequest.Request.Nlu.Intents.TurnOn.Slots.What as AliceEntityStringModel;
                var where = aliceRequest.Request.Nlu.Intents.TurnOn.Slots.Where as AliceEntityStringModel;
                string text = $"Я распознал интент и понял что нужно включить {what.Value} {where.Value}. Но делать я этого конечно не буду " + char.ConvertFromUtf32(0x1F60E);
                var buttons = new List<AliceButtonModel>()
                    {
                        new AliceButtonModel(_codeButtonTitle, false, null, new Uri(_githubLink)),
                        new AliceButtonModel(_noImageButtonTitle),
                        new AliceButtonModel(_oneImageButtonTitle),
                        new AliceButtonModel(_galleryButtonTitle),
                        new AliceButtonModel(_testIntentButtonTitle)
                    };
                return new AliceResponse(aliceRequest, text, buttons);
            }
            else
            {
                string text = aliceRequest.Session.New
                    ? "Привет! Это навык, демонстрирующий работу неофициального SDK для разработки навыков для Алисы на .Net"
                    : "Выберите действие";
                var buttons = new List<AliceButtonModel>()
                    {
                        new AliceButtonModel(_codeButtonTitle, false, null, new Uri(_githubLink)),
                        new AliceButtonModel(_noImageButtonTitle),
                        new AliceButtonModel(_oneImageButtonTitle),
                        new AliceButtonModel(_galleryButtonTitle),
                        new AliceButtonModel(_testIntentButtonTitle)
                    };
                return new AliceResponse(aliceRequest, text, buttons);
            }
        }
    }
}

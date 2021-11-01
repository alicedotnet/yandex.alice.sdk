namespace Yandex.Alice.Sdk.Demo.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Yandex.Alice.Sdk.Demo.Models;
    using Yandex.Alice.Sdk.Demo.Models.Session;
    using Yandex.Alice.Sdk.Demo.Resources;
    using Yandex.Alice.Sdk.Models;
    using Yandex.Alice.Sdk.Models.DialogsApi;
    using Yandex.Alice.Sdk.Services;

    [ApiController]
    [Route("[controller]")]
    public class AliceController : ControllerBase
    {
        private const string _codeButtonTitle = "посмотреть код";
        private const string _noImageButtonTitle = "ответ без изображений";
        private const string _oneImageButtonTitle = "ответ с одним изображением";
        private const string _galleryButtonTitle = "ответ с галереей из нескольких изображений";
        private const string _testIntentButtonTitle = "протестировать интент";
        private const string _resourcesWorkButtonTitle = "работа с ресурсами";
        private const string _geolocationButtonTitle = "геолокация";
        private const string _homeButtonTitle = "назад";
        private const string _githubLink = "https://github.com/alexvolchetsky/yandex.alice.sdk";
        private const string _munchkinInfoLink = "https://ru.wikipedia.org/wiki/%D0%9C%D0%B0%D0%BD%D1%87%D0%BA%D0%B8%D0%BD_(%D0%BF%D0%BE%D1%80%D0%BE%D0%B4%D0%B0_%D0%BA%D0%BE%D1%88%D0%B5%D0%BA)";
        private const string _jagdterrierInfoLink = "https://ru.wikipedia.org/wiki/%D0%9D%D0%B5%D0%BC%D0%B5%D1%86%D0%BA%D0%B8%D0%B9_%D1%8F%D0%B3%D0%B4%D1%82%D0%B5%D1%80%D1%8C%D0%B5%D1%80";
        private const string _huskyInfoLink = "https://ru.wikipedia.org/wiki/%D0%A5%D0%B0%D1%81%D0%BA%D0%B8";
        private const string _labradorInfoLink = "https://ru.wikipedia.org/wiki/%D0%9B%D0%B0%D0%B1%D1%80%D0%B0%D0%B4%D0%BE%D1%80-%D1%80%D0%B5%D1%82%D1%80%D0%B8%D0%B2%D0%B5%D1%80";
        private const string _morePuppiesLink = "https://www.google.com/search?q=%D1%89%D0%B5%D0%BD%D0%BE%D1%87%D0%BA%D0%B8&sxsrf=ALeKk03SlYE13sTDiS7dm3TPL9e5Y3FEMw:1589313761070&source=lnms&tbm=isch&sa=X&ved=2ahUKEwiW4qiRj6_pAhXsw8QBHVOqBHcQ_AUoAXoECAoQAw&biw=1216&bih=601";

        private readonly ILogger<AliceController> _logger;
        private readonly IDialogsApiService _dialogsApiService;
        private readonly AliceSettings _aliceSettings;

        public AliceController(
            ILogger<AliceController> logger,
            IDialogsApiService dialogsApiService,
            AliceSettings aliceSettings)
        {
            _logger = logger;
            _dialogsApiService = dialogsApiService;
            _aliceSettings = aliceSettings;
        }

        [HttpPost]
        [Route("/alice")]
        public Task<IActionResult> Get(DemoAliceRequest aliceRequest)
        {
            if (aliceRequest == null)
            {
                throw new ArgumentNullException(nameof(aliceRequest));
            }

            return GetAsync(aliceRequest);
        }

        private async Task<IActionResult> GetAsync(DemoAliceRequest aliceRequest)
        {
            try
            {
                var response = await GetAliceResponseAsync(aliceRequest).ConfigureAwait(false);
                return Ok(response);
            }
            catch (Exception e)
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                string requestText = JsonSerializer.Serialize(aliceRequest);
                _logger.LogError(e, $"The following request produced exception: {requestText}");
                return Content(e.ToString());
            }
        }

        private async Task<IAliceResponseBase> GetAliceResponseAsync(DemoAliceRequest aliceRequest)
        {
            var buttons = new List<AliceButtonModel>()
            {
                new AliceButtonModel(_codeButtonTitle, true, null, new Uri(_githubLink)),
                new AliceButtonModel(_noImageButtonTitle, true),
                new AliceButtonModel(_oneImageButtonTitle, true),
                new AliceButtonModel(_galleryButtonTitle, true),
                new AliceButtonModel(_testIntentButtonTitle, true),
                new AliceButtonModel(_resourcesWorkButtonTitle, true),
            };
            if (aliceRequest.Meta.Interfaces.GeolocationSharing != null)
            {
                buttons.Add(new AliceButtonModel(_geolocationButtonTitle, true));
            }

            if (aliceRequest.Request.Command == _codeButtonTitle)
            {
                string text = $"Вот ссылка на github";
                var codeButtons = new List<AliceButtonModel>()
                    {
                        new AliceButtonModel(_githubLink, false, null, new Uri(_githubLink)),
                    };
                return new AliceResponse<CustomSessionState, object>(aliceRequest, text, codeButtons);
            }

            if (aliceRequest.Request.Command == _noImageButtonTitle)
            {
                string text = $"Это пример ответа без изображений. Здесь может быть текст или например эмодзи {char.ConvertFromUtf32(0x1F60E)}";
                return new AliceResponse<CustomSessionState, object>(aliceRequest, text, buttons);
            }

            if (aliceRequest.Request.Command == _oneImageButtonTitle ||
                aliceRequest.Request.Command == "ответ с 1 изображением")
            {
                string text = $"Здесь можно отобразить только одно большое фото. Например котика";
                var aliceResponse = new AliceImageResponse<CustomSessionState, object>(aliceRequest, text, buttons);
                aliceResponse.Response.Card = new AliceImageCardModel
                {
                    Title = "Манчкин",
                    Description = "Современная порода кошек. При средней длине тела их лапки короче, чем у обычных кошек в 2-3 раза.",
                    ImageId = DemoResources.Images.CatImageId1,
                    Button = new AliceImageCardButtonModel()
                    {
                        Text = "подробнее",
                        Url = new Uri(_munchkinInfoLink),
                    },
                };
                return aliceResponse;
            }

            if (aliceRequest.Request.Command == _galleryButtonTitle)
            {
                string text = $"В ответе такого типа можно отобразить несколько фотографий";
                var aliceResponse = new AliceGalleryResponse<CustomSessionState, object>(aliceRequest, text, buttons);
                aliceResponse.Response.Card = new AliceGalleryCardModel
                {
                    Header = new AliceGalleryCardHeaderModel("Щеночки"),
                    Items = new List<AliceGalleryCardItem>()
                    {
                        new AliceGalleryCardItem()
                        {
                            Title = "Ягдтерьер",
                            ImageId = DemoResources.Images.DogImageId1,
                            Description = "Порода универсальных охотничьих собак.",
                            Button = new AliceImageCardButtonModel()
                            {
                                Text = "подробнее",
                                Url = new Uri(_jagdterrierInfoLink),
                            },
                        },
                        new AliceGalleryCardItem()
                        {
                            Title = "Хаски",
                            ImageId = DemoResources.Images.DogImageId2,
                            Description = "Общее название для нескольких пород ездовых собак, выведенных в северных регионах, которые отличаются быстрой манерой тянуть упряжку.",
                            Button = new AliceImageCardButtonModel()
                            {
                                Text = "подробнее",
                                Url = new Uri(_huskyInfoLink),
                            },
                        },
                        new AliceGalleryCardItem()
                        {
                            Title = "Лабрадор",
                            ImageId = DemoResources.Images.DogImageId3,
                            Description = "Порода собак. Первоначально была выведена в качестве охотничьей подружейной собаки.",
                            Button = new AliceImageCardButtonModel()
                            {
                                Text = "подробнее",
                                Url = new Uri(_labradorInfoLink),
                            },
                        },
                    },
                    Footer = new AliceGalleryCardFooterModel(
                        "больше щеночков",
                        new AliceImageCardButtonModel()
                        {
                            Text = "больше щеночков",
                            Url = new Uri(_morePuppiesLink),
                        }),
                };
                return aliceResponse;
            }

            if (aliceRequest.Request.Command == _testIntentButtonTitle)
            {
                string text = "Для того чтобы протестировать интент, нажмите на одну из кнопок";
                var intentButtons = new List<AliceButtonModel>()
                    {
                        new AliceButtonModel("включи свет в ванной"),
                        new AliceButtonModel("включи кондиционер на кухне"),
                        new AliceButtonModel(_homeButtonTitle),
                    };
                return new AliceResponse<CustomSessionState, object>(aliceRequest, text, intentButtons)
                {
                    SessionState = new CustomSessionState(ModeType.IntentsTesting),
                };
            }

            if (aliceRequest.Request.Command == _resourcesWorkButtonTitle)
            {
                string text = "Так же я могу управлять файлами изображений и звуков в навыке, используя HTTP API. Попробуйте отправить мне ссылку на изображение и я отображу его в ответе";
                var resourcesButtons = new List<AliceButtonModel>()
                    {
                        new AliceButtonModel(_homeButtonTitle),
                    };
                return new AliceResponse<CustomSessionState, object>(aliceRequest, text, resourcesButtons)
                {
                    SessionState = new CustomSessionState(ModeType.ResourcesTesting),
                };
            }

            if (aliceRequest.Request.Command == _geolocationButtonTitle)
            {
                var response = new AliceResponse<CustomSessionState, object>(aliceRequest, "Разрешите доступ к геолокации, чтобы навык смог ее узнать")
                {
                    SessionState = new CustomSessionState(),
                };
                response.Response.Directives.SetRequestGeolocation();
                return response;
            }

            if (aliceRequest.Request.Type == AliceRequestType.GeolocationAllowed)
            {
                string text = $"Ваши координаты: {aliceRequest.Session.Location.Lat}, {aliceRequest.Session.Location.Lon}";
                return new AliceResponse<CustomSessionState, object>(aliceRequest, text, buttons)
                {
                    SessionState = new CustomSessionState(),
                };
            }

            if (aliceRequest.Request.Command != _homeButtonTitle
                && aliceRequest.State?.Session?.Mode == ModeType.ResourcesTesting)
            {
                if (Uri.TryCreate(aliceRequest.Request.OriginalUtterance, UriKind.Absolute, out Uri uri))
                {
                    var response = await _dialogsApiService.UploadImageAsync(_aliceSettings.SkillId, new DialogsWebUploadRequest(uri)).ConfigureAwait(false);
                    if (response.IsSuccess)
                    {
                        var uploadedButtons = new List<AliceButtonModel>()
                            {
                                new AliceButtonModel(_homeButtonTitle, true),
                            };
                        var aliceResponse = new AliceImageResponse<CustomSessionState, object>(aliceRequest, "Изображение загружено", uploadedButtons);
                        aliceResponse.Response.Card = new AliceImageCardModel
                        {
                            Title = Yandex_Alice_Sdk_Demo_Resources.Image_Upload_Success,
                            Description = "Вы можете попробовать загрузить другое изображение",
                            ImageId = response.Content.Image.Id,
                        };
                        aliceResponse.SessionState = new CustomSessionState(ModeType.ResourcesTesting);
                        return aliceResponse;
                    }
                }

                string text = "Не удалось загрузить изображение. Попробуйте еще раз";
                var resourcesButtons = new List<AliceButtonModel>()
                    {
                        new AliceButtonModel(_homeButtonTitle),
                    };
                return new AliceResponse<CustomSessionState, object>(aliceRequest, text, resourcesButtons)
                {
                    SessionState = new CustomSessionState(ModeType.ResourcesTesting),
                };
            }

            if (aliceRequest.Request.Command != _homeButtonTitle &&
                aliceRequest.Request.Nlu?.Intents?.TurnOn == null &&
                aliceRequest.State?.Session?.Mode == ModeType.IntentsTesting)
            {
                string text = "Не удалось распознать интент. Попробуйте еще раз";
                var intentButtons = new List<AliceButtonModel>()
                    {
                        new AliceButtonModel("включи свет в ванной"),
                        new AliceButtonModel("включи кондиционер на кухне"),
                        new AliceButtonModel(_homeButtonTitle),
                    };
                return new AliceResponse<CustomSessionState, object>(aliceRequest, text, intentButtons)
                {
                    SessionState = new CustomSessionState(ModeType.IntentsTesting),
                };
            }

            if (aliceRequest.Request.Nlu?.Intents?.TurnOn != null)
            {
                var what = aliceRequest.Request.Nlu.Intents.TurnOn.Slots.What as AliceEntityStringModel;
                var where = aliceRequest.Request.Nlu.Intents.TurnOn.Slots.Where as AliceEntityStringModel;
                string text = $"Я распознал интент и понял что нужно включить {what.Value} {where.Value}. Но делать я этого конечно не буду " + char.ConvertFromUtf32(0x1F60E);
                return new AliceResponse<CustomSessionState, object>(aliceRequest, text, buttons);
            }
            else
            {
                string text = aliceRequest.Session.New
                    ? "Привет! Это навык, демонстрирующий работу неофициального SDK для разработки навыков для Алисы на .Net"
                    : "Выберите действие";
                return new AliceResponse<CustomSessionState, object>(aliceRequest, text, buttons);
            }
        }
    }
}

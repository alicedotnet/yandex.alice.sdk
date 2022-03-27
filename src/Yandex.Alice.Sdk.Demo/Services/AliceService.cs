namespace Yandex.Alice.Sdk.Demo.Services;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Interfaces;
using Models;
using Models.Session;
using Sdk.Models;
using Sdk.Models.DialogsApi;
using Sdk.Services;

public class AliceService : IAliceService
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

    private readonly IDialogsApiService _dialogsApiService;
    private readonly AliceSettings _aliceSettings;

    public AliceService(
        IDialogsApiService dialogsApiService,
        AliceSettings aliceSettings)
    {
        _dialogsApiService = dialogsApiService;
        _aliceSettings = aliceSettings;
    }

    public Task<IAliceResponseBase> GetAliceResponseAsync(DemoAliceRequest aliceRequest)
    {
        if (aliceRequest == null)
        {
            throw new ArgumentNullException(nameof(aliceRequest));
        }

        return GetAliceResponseInternalAsync(aliceRequest);
    }

    private async Task<IAliceResponseBase> GetAliceResponseInternalAsync(DemoAliceRequest aliceRequest)
    {
        var buttons = new List<AliceButtonModel>
        {
            new (_codeButtonTitle, true, null, new Uri(_githubLink)),
            new (_noImageButtonTitle, true),
            new (_oneImageButtonTitle, true),
            new (_galleryButtonTitle, true),
            new (_testIntentButtonTitle, true),
            new (_resourcesWorkButtonTitle, true),
        };
        if (aliceRequest.Meta.Interfaces.GeolocationSharing != null)
        {
            buttons.Add(new AliceButtonModel(_geolocationButtonTitle, true));
        }

        switch (aliceRequest.Request.Command)
        {
            case _codeButtonTitle:
            {
                const string text = @"Вот ссылка на github";
                var codeButtons = new List<AliceButtonModel>
                {
                    new (_githubLink, false, null, new Uri(_githubLink)),
                };
                return new AliceResponse<CustomSessionState, object>(aliceRequest, text, codeButtons)
                    .WithAnalyticsEvent("github");
            }

            case _noImageButtonTitle:
            {
                var text = @$"Это пример ответа без изображений. Здесь может быть текст или например эмодзи {char.ConvertFromUtf32(0x1F60E)}";
                return new AliceResponse<CustomSessionState, object>(aliceRequest, text, buttons)
                    .WithAnalyticsEvent("no_image");
            }

            case _oneImageButtonTitle:
            case @"ответ с 1 изображением":
            {
                const string text = @"Здесь можно отобразить только одно большое фото. Например котика";
                var aliceResponse = new AliceImageResponse<CustomSessionState, object>(aliceRequest, text, buttons)
                {
                    Response =
                    {
                        Card = new AliceImageCardModel
                        {
                            Title = @"Манчкин",
                            Description = @"Современная порода кошек. При средней длине тела их лапки короче, чем у обычных кошек в 2-3 раза.",
                            ImageId = DemoResources.Images.CatImageId1,
                            Button = new AliceImageCardButtonModel
                            {
                                Text = @"подробнее",
                                Url = new Uri(_munchkinInfoLink),
                            },
                        },
                    },
                };
                return aliceResponse.WithAnalyticsEvent("one_image");
            }

            case _galleryButtonTitle:
            {
                const string text = @"В ответе такого типа можно отобразить несколько фотографий";
                var aliceResponse = new AliceGalleryResponse<CustomSessionState, object>(aliceRequest, text, buttons)
                {
                    Response =
                    {
                        Card = new AliceGalleryCardModel
                        {
                            Header = new AliceGalleryCardHeaderModel(@"Щеночки"),
                            Items = new List<AliceGalleryCardItem>
                            {
                                new ()
                                {
                                    Title = @"Ягдтерьер",
                                    ImageId = DemoResources.Images.DogImageId1,
                                    Description = @"Порода универсальных охотничьих собак.",
                                    Button = new AliceImageCardButtonModel
                                    {
                                        Text = @"подробнее",
                                        Url = new Uri(_jagdterrierInfoLink),
                                    },
                                },
                                new ()
                                {
                                    Title = @"Хаски",
                                    ImageId = DemoResources.Images.DogImageId2,
                                    Description = @"Общее название для нескольких пород ездовых собак, выведенных в северных регионах, которые отличаются быстрой манерой тянуть упряжку.",
                                    Button = new AliceImageCardButtonModel
                                    {
                                        Text = @"подробнее",
                                        Url = new Uri(_huskyInfoLink),
                                    },
                                },
                                new ()
                                {
                                    Title = @"Лабрадор",
                                    ImageId = DemoResources.Images.DogImageId3,
                                    Description = @"Порода собак. Первоначально была выведена в качестве охотничьей подружейной собаки.",
                                    Button = new AliceImageCardButtonModel
                                    {
                                        Text = @"подробнее",
                                        Url = new Uri(_labradorInfoLink),
                                    },
                                },
                            },
                            Footer = new AliceGalleryCardFooterModel(
                                @"больше щеночков",
                                new AliceImageCardButtonModel
                                {
                                    Text = @"больше щеночков",
                                    Url = new Uri(_morePuppiesLink),
                                }),
                        },
                    },
                };
                return aliceResponse.WithAnalyticsEvent(
                    "gallery",
                    new
                    {
                        field_one = "test",
                        field_two = new
                        {
                            field_three = "another test",
                        },
                    });
            }

            case _testIntentButtonTitle:
            {
                const string text = @"Для того чтобы протестировать интент, нажмите на одну из кнопок";
                var intentButtons = new List<AliceButtonModel>
                {
                    new (@"включи свет в ванной"),
                    new (@"включи кондиционер на кухне"),
                    new (_homeButtonTitle),
                };
                return new AliceResponse<CustomSessionState, object>(aliceRequest, text, intentButtons)
                {
                    SessionState = new CustomSessionState(ModeType.IntentsTesting),
                }.WithAnalyticsEvent("intent");
            }

            case _resourcesWorkButtonTitle:
            {
                const string text = @"Так же я могу управлять файлами изображений и звуков в навыке, используя HTTP API. Попробуйте отправить мне ссылку на изображение и я отображу его в ответе";
                var resourcesButtons = new List<AliceButtonModel>
                {
                    new (_homeButtonTitle),
                };
                return new AliceResponse<CustomSessionState, object>(aliceRequest, text, resourcesButtons)
                {
                    SessionState = new CustomSessionState(ModeType.ResourcesTesting),
                }.WithAnalyticsEvent("file_upload");
            }

            case _geolocationButtonTitle:
            {
                var response = new AliceResponse<CustomSessionState, object>(aliceRequest, @"Разрешите доступ к геолокации, чтобы навык смог ее узнать")
                {
                    SessionState = new CustomSessionState(),
                };
                response.Response.Directives.RequestGeolocation = new AliceRequestGeolocationDirective();
                return response.WithAnalyticsEvent("request_geo");
            }
        }

        if (aliceRequest.Request.Type == AliceRequestType.GeolocationAllowed)
        {
            var text = @$"Ваши координаты: {aliceRequest.Session.Location.Lat}, {aliceRequest.Session.Location.Lon}";
            return new AliceResponse<CustomSessionState, object>(aliceRequest, text, buttons)
            {
                SessionState = new CustomSessionState(),
            }.WithAnalyticsEvent("response_geo");
        }

        if (aliceRequest.Request.Command != _homeButtonTitle
            && aliceRequest.State?.Session?.Mode == ModeType.ResourcesTesting)
        {
            if (Uri.TryCreate(aliceRequest.Request.OriginalUtterance, UriKind.Absolute, out var uri))
            {
                var response = await _dialogsApiService.UploadImageAsync(_aliceSettings.SkillId, new DialogsWebUploadRequest(uri)).ConfigureAwait(false);
                if (response.IsSuccess)
                {
                    var uploadedButtons = new List<AliceButtonModel>
                    {
                        new (_homeButtonTitle, true),
                    };
                    var aliceResponse = new AliceImageResponse<CustomSessionState, object>(aliceRequest, @"Изображение загружено", uploadedButtons)
                        {
                            Response =
                            {
                                Card = new AliceImageCardModel
                                {
                                    Title = @"Изображение загружено",
                                    Description = @"Вы можете попробовать загрузить другое изображение",
                                    ImageId = response.Content.Image.Id,
                                },
                            },
                            SessionState = new CustomSessionState(ModeType.ResourcesTesting),
                        };
                    return aliceResponse.WithAnalyticsEvent("file_upload_success");
                }
            }

            const string text = @"Не удалось загрузить изображение. Попробуйте еще раз";
            var resourcesButtons = new List<AliceButtonModel>
            {
                new (_homeButtonTitle),
            };
            return new AliceResponse<CustomSessionState, object>(aliceRequest, text, resourcesButtons)
            {
                SessionState = new CustomSessionState(ModeType.ResourcesTesting),
            }.WithAnalyticsEvent("file_upload_fail");
        }

        if (aliceRequest.Request.Command != _homeButtonTitle &&
            aliceRequest.Request.Nlu?.Intents?.TurnOn == null &&
            aliceRequest.State?.Session?.Mode == ModeType.IntentsTesting)
        {
            const string text = @"Не удалось распознать интент. Попробуйте еще раз";
            var intentButtons = new List<AliceButtonModel>
            {
                new (@"включи свет в ванной"),
                new (@"включи кондиционер на кухне"),
                new (_homeButtonTitle),
            };
            return new AliceResponse<CustomSessionState, object>(aliceRequest, text, intentButtons)
            {
                SessionState = new CustomSessionState(ModeType.IntentsTesting),
            }.WithAnalyticsEvent("intent_fail");
        }

        if (aliceRequest.Request.Nlu?.Intents?.TurnOn != null)
        {
            var what = aliceRequest.Request.Nlu.Intents.TurnOn.Slots.What;
            var where = aliceRequest.Request.Nlu.Intents.TurnOn.Slots.Where;
            var text = @$"Я распознал интент и понял что нужно включить {what.Value} {where.Value}. Но делать я этого конечно не буду " + char.ConvertFromUtf32(0x1F60E);
            return new AliceResponse<CustomSessionState, object>(aliceRequest, text, buttons).WithAnalyticsEvent("intent_success");
        }
        else
        {
            var text = aliceRequest.Session.New
                ? @"Привет! Это навык, демонстрирующий работу неофициального SDK для разработки навыков для Алисы на .Net"
                : @"Выберите действие";
            return new AliceResponse<CustomSessionState, object>(aliceRequest, text, buttons).WithAnalyticsEvent("start");
        }
    }
}
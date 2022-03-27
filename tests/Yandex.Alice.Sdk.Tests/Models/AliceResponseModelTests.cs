namespace Yandex.Alice.Sdk.Tests.Models;

using System;
using FluentAssertions;
using Xunit;
using Yandex.Alice.Sdk.Helpers;
using Yandex.Alice.Sdk.Models;

public class AliceResponseModelTests
{
    private readonly string _tooLongString;

    public AliceResponseModelTests()
    {
        _tooLongString = "Extended kindness trifling remember he confined outlived if. Assistance sentiments yet unpleasing say. Open they an busy they my such high. An active dinner wishes at unable hardly no talked on. Immediate him her resolving his favourite. Wished denote abroad at branch at. Compliment interested discretion estimating on stimulated apartments oh. Dear so sing when in find read of call. As distrusts behaviour abilities defective is. Never at water me might. On formed merits hunted unable merely by mr whence or. Possession the unpleasing simplicity her uncommonly. John draw real poor on call my from. May she mrs furnished discourse extremely. Ask doubt noisy shade guest did built her him. Ignorant repeated hastened it do. Consider bachelor he yourself expenses no. Her itself active giving for expect vulgar months. Discovery commanded fat mrs remaining son she principle middleton neglected. Be miss he in post sons held. No tried is defer do money scale rooms. Much evil soon high in hope do view. Out may few northward believing attempted. Yet timed being songs marry one defer men our. Although finished blessing do of. Consider speaking me prospect whatever if. Ten nearer rather hunted six parish indeed number. Allowance repulsive sex may contained can set suspected abilities cordially. Do part am he high rest that. So fruit to ready it being views match.";
    }

    [Fact]
    public void TextMaxLength()
    {
        var model = new AliceResponseModel();
        Assert.Throws<ArgumentException>(() => model.Text = _tooLongString);
    }

    [Fact]
    public void TextRequired()
    {
        var model = new AliceResponseModel();
        Assert.Throws<ArgumentException>(() => model.Text = null);
    }

    [Fact]
    public void TtsMaxLength()
    {
        var model = new AliceResponseModel();
        Assert.Throws<ArgumentException>(() => model.Tts = _tooLongString);
    }

    [Fact]
    public void TtsValidationIgnoreTags()
    {
        // arrange
        var model = new AliceResponseModel();
        const string tts1024Symbols = "XH9vWSTYNdADOjPYVKoKcjZS0PaTYqXpkHqFUry3fY0q2bm1FzvyPhW6IC8ca11Cpdv0H57XhLI5qsGcHWyBOEi93P325MYNIGHYliYYa4zDc1qCX1eouDAvkDBpxgH6SHhSJzGfJuQ1K60lYTTqmQtchBeDYf0dcCxP6DbCXvPXKrXICGCUliXivtUfYlGUXxW6sdodFUElMhKGfdU9ypMbkyoZ3fXFj26LgMUAFXA7CMNffVSs6d45GOgnDFX5o2BiCvmA65p3tMjKiU0rV068kJOR9567ckQzBz5zNm6HWnz2pvgE9WW3VouEmVEiWY4VVlHLokRCcE2SV63KTttwg3vPJMS9AHfgyaoC7SLQuKFbkx0PQD6P9HKaPXVc8VKMKWLHgqYER24vfk858M3bDmaUNMb4V1aPMX0DQbhtsE2km508KeI0GX21Ha1Z0eCAOXMZrRySAccPNUmm4QGP3ObmuMSYXxHXGDlWUqywuaw67XIYEdZN81UkPlfCG09Oa0a08I6Uu77ajAqzONEk8gQYeqpVPLcxqdbwjXEpiK7xjksOUPYhSZgaHQUbZ05NCGUYJUTimA4TVJOTfz9H5xB6TYxCFn1pjr5R98oXhtwtiRM7KzrHppOAC1dPUotms24i5YlMTmuzMabls4V9FFR58hMTWfmdaqroirExgYwoDZ2r8rNpVR47ITLPdhkhhfjO2hjps0J2Xbj6IyFBBvkAAKSoSkSbfvCcgzkpJ9eHvzCsSCHjE86Vmeh3eXzm20TOwr0bMJ9Dwczxoap01MJevOkWQ4OmQXcCnHVjUAP6BsgHmN2yZLVCqg9FUn9fJIGfN9jVJBdz1qivBpqKsS2Yv2mN4p7GVkkwcgMDnGVxislnR3vCwhf0YNkQ24kAJOvhGVAHhcMKBCF8LmOlvWN04pDvSiZwWUrS4cnHxwJrm6qtkvFxyw4N1zd74wmXH1VuIf6YEPMoo5mo2WmaQdCOZwPqmfXIHLyLFl1LRjOGthwS0wqXO0aoFhHr";
        model.Tts = tts1024Symbols;

        // act
        Action act = () => model.Tts += AliceHelper.GetSpeakerTag("test");

        // assert
        act.Should().NotThrow();
    }

    [Fact]
    public void SetText_WithSilenceTag_CutSilenceTagInTextButKeepInTTS()
    {
        const string textWithoutSilence = "just text";
        const string textWithSilence = textWithoutSilence + "sil<[500]>";
        var model = new AliceResponseModel();
        model.SetText(textWithSilence);
        Assert.Equal(textWithoutSilence, model.Text);
        Assert.Equal(textWithSilence, model.Tts);
    }

    [Fact]
    public void AppendText_WithSilenceTag_CutSilenceTagInTextButKeepInTTS()
    {
        const string textWithoutSilence = "just text";
        const string textWithSilence = textWithoutSilence + "sil<[500]>";
        var model = new AliceResponseModel();
        model.AppendText(textWithSilence);
        Assert.Equal(textWithoutSilence, model.Text);
        Assert.Equal(textWithSilence, model.Tts);
    }

    [Fact]
    public void RequestGeolocation_Success()
    {
        var model = new AliceResponseModel
        {
            Directives =
            {
                RequestGeolocation = new AliceRequestGeolocationDirective(),
            },
        };
        Assert.NotNull(model.Directives.RequestGeolocation);
    }
}
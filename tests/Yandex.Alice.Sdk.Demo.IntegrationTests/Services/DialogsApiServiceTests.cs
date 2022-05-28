namespace Yandex.Alice.Sdk.Demo.IntegrationTests.Services;

using System;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using TestsInfrastructure.Fixtures;
using Xunit;
using Xunit.Abstractions;
using Yandex.Alice.Sdk.Models.DialogsApi;
using Yandex.Alice.Sdk.Resources;
using Yandex.Alice.Sdk.Services;
using Microsoft.Extensions.DependencyInjection;
using Models;

[Collection(TestsConstants.TestServerCollectionName)]
public class DialogsApiServiceTests
{
    private const string _imageUrl = "https://raw.githubusercontent.com/alexvolchetsky/yandex.alice.sdk/master/src/Yandex.Alice.Sdk/Resources/icon.png";

    private readonly ITestOutputHelper _testOutputHelper;
    private readonly IDialogsApiService _dialogsApiService;
    private readonly Guid _skillId;

    public DialogsApiServiceTests(TestServerFixture testServerFixture, ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
        _dialogsApiService = testServerFixture.Services.GetService<IDialogsApiService>();
        _skillId = testServerFixture.Services.GetService<AliceSettings>().SkillId;
    }

    [Fact]
    public async Task Status_InvalidAuthToken_Fail()
    {
        var settings = new DialogsApiSettings("i'm invalid for sure");
        using var dialogsApiService = new DialogsApiService(settings);
        var response = await dialogsApiService.StatusAsync().ConfigureAwait(false);
        Assert.False(response.IsSuccess);
        Assert.Contains(TestsConstants.InvalidCredentialsMessage, response.ErrorMessage, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public async Task Status_Ok()
    {
        var response = await _dialogsApiService.StatusAsync().ConfigureAwait(false);
        Assert.True(response.IsSuccess);
        Assert.NotNull(response.Content);
        Assert.NotNull(response.Content.Images);
        Assert.NotNull(response.Content.Images.Quota);
        Assert.NotNull(response.Content.Sounds);
        Assert.NotNull(response.Content.Sounds.Quota);
    }

    [Fact]
    public async Task UploadImage_InvalidAuthToken_Fail()
    {
        var request = new DialogsWebUploadRequest(new Uri(_imageUrl));
        var settings = new DialogsApiSettings("i'm invalid");
        using var dialogsApiService = new DialogsApiService(settings);
        var response = await dialogsApiService.UploadImageAsync(_skillId, request).ConfigureAwait(false);
        Assert.False(response.IsSuccess);
        Assert.Contains(TestsConstants.InvalidCredentialsMessage, response.ErrorMessage, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public async Task UploadImage_InvalidSkillId_Fail()
    {
        var request = new DialogsWebUploadRequest(new Uri(_imageUrl));
        var exception = await Assert.ThrowsAsync<ArgumentException>(() => _dialogsApiService.UploadImageAsync(Guid.Empty, request)).ConfigureAwait(false);
        Assert.Contains(AliceResources.Error_NoSkillId, exception.Message, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public async Task UploadImage_InvalidUrl_Fail()
    {
        var response = await _dialogsApiService.UploadImageAsync(_skillId, new DialogsWebUploadRequest(new Uri("https://www.google.com/"))).ConfigureAwait(false);
        Assert.False(response.IsSuccess);
        Assert.Contains("Invalid image", response.ErrorMessage, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public async Task UploadImage_Ok()
    {
        var uploadRequest = new DialogsWebUploadRequest(new Uri(_imageUrl));
        var uploadResponse = await _dialogsApiService.UploadImageAsync(_skillId, uploadRequest).ConfigureAwait(false);
        Assert.True(uploadResponse.IsSuccess, uploadResponse.ErrorMessage);
        Assert.NotNull(uploadResponse.Content);
        Assert.NotNull(uploadResponse.Content.Image);
        Assert.NotNull(uploadResponse.Content.Image.Id);
        Assert.NotNull(uploadResponse.Content.Image.OriginalUrl);
        Assert.True(uploadResponse.Content.Image.Size > 0);
        Assert.NotEqual(default, uploadResponse.Content.Image.CreatedAt);
        _testOutputHelper.WriteLine($"CreatedAt: {uploadResponse.Content.Image.CreatedAt.ToString(AliceConstants.DateTimeFormat, CultureInfo.InvariantCulture)}");
        await _dialogsApiService.DeleteImageAsync(_skillId, uploadResponse.Content.Image.Id).ConfigureAwait(false);
    }

    [Fact]
    public async Task UploadFileImage_NoAuthToken_Fail()
    {
        var settings = new DialogsApiSettings("i'm invalid for sure");
        using var dialogsApiService = new DialogsApiService(settings);
        var bytes = await File.ReadAllBytesAsync(TestsConstants.IconFilePath);
        var request = new DialogsFileUploadRequest(TestsConstants.IconFileName, bytes);
        var uploadResponse = await dialogsApiService.UploadImageAsync(_skillId, request).ConfigureAwait(false);
        Assert.False(uploadResponse.IsSuccess);
        Assert.Contains(TestsConstants.InvalidCredentialsMessage, uploadResponse.ErrorMessage, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public async Task UploadFileImage_NotImage_Fail()
    {
        var bytes = await File.ReadAllBytesAsync(TestsConstants.AliceRequestPingFilePath);
        var request = new DialogsFileUploadRequest("test.jpg", bytes);
        var response = await _dialogsApiService.UploadImageAsync(_skillId, request).ConfigureAwait(false);
        Assert.False(response.IsSuccess);
    }

    [Fact]
    public async Task UploadFileImage_Ok()
    {
        var bytes = await File.ReadAllBytesAsync(TestsConstants.IconFilePath);
        var request = new DialogsFileUploadRequest(TestsConstants.IconFileName, bytes);
        var uploadResponse = await _dialogsApiService.UploadImageAsync(_skillId, request).ConfigureAwait(false);
        Assert.True(uploadResponse.IsSuccess);

        await _dialogsApiService.DeleteImageAsync(_skillId, uploadResponse.Content.Image.Id).ConfigureAwait(false);
    }

    [Fact]
    public async Task GetImages_InvalidAuthToken_Fail()
    {
        var settings = new DialogsApiSettings("i'm invalid for sure");
        using var dialogsApiService = new DialogsApiService(settings);
        var imagesResponse = await dialogsApiService.GetImagesAsync(_skillId).ConfigureAwait(false);
        Assert.False(imagesResponse.IsSuccess);
        Assert.Contains(TestsConstants.InvalidCredentialsMessage, imagesResponse.ErrorMessage, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public async Task GetImages_Ok()
    {
        var uploadRequest = new DialogsWebUploadRequest(new Uri(_imageUrl));
        var uploadResponse = await _dialogsApiService.UploadImageAsync(_skillId, uploadRequest).ConfigureAwait(false);

        var imagesResponse = await _dialogsApiService.GetImagesAsync(_skillId).ConfigureAwait(false);
        Assert.True(imagesResponse.IsSuccess);
        Assert.NotEmpty(imagesResponse.Content.Images);
        Assert.True(imagesResponse.Content.Total > 0);

        await _dialogsApiService.DeleteImageAsync(_skillId, uploadResponse.Content.Image.Id).ConfigureAwait(false);
    }

    [Fact]
    public void NoAuthToken_Fail()
    {
        var settings = new DialogsApiSettings(null);
        var exception = Assert.Throws<ArgumentException>(() => new DialogsApiService(settings));
        Assert.Equal(AliceResources.Error_NoOAuthToken, exception.Message);
    }

    [Fact]
    public async Task DeleteImage_InvalidAuthToken_Fail()
    {
        var uploadResponse = await _dialogsApiService.UploadImageAsync(_skillId, new DialogsWebUploadRequest(new Uri(_imageUrl))).ConfigureAwait(false);
        var imageId = uploadResponse.Content.Image.Id;

        var settings = new DialogsApiSettings("i'm invalid for sure");
        using var dialogsApiService = new DialogsApiService(settings);
        var response = await dialogsApiService.DeleteImageAsync(_skillId, imageId).ConfigureAwait(false);
        Assert.False(response.IsSuccess);
        Assert.Contains(TestsConstants.InvalidCredentialsMessage, response.ErrorMessage, StringComparison.OrdinalIgnoreCase);

        await _dialogsApiService.DeleteImageAsync(_skillId, imageId).ConfigureAwait(false);
    }

    [Fact]
    public async Task DeleteImage_InvalidImageId_Fail()
    {
        var response = await _dialogsApiService.DeleteImageAsync(_skillId, "invalid").ConfigureAwait(false);
        Assert.False(response.IsSuccess);
    }

    [Fact]
    public async Task DeleteImage_Ok()
    {
        var uploadResponse = await _dialogsApiService.UploadImageAsync(_skillId, new DialogsWebUploadRequest(new Uri(_imageUrl))).ConfigureAwait(false);
        var imageId = uploadResponse.Content.Image.Id;
        var response = await _dialogsApiService.DeleteImageAsync(_skillId, imageId).ConfigureAwait(false);
        Assert.True(response.IsSuccess);
        Assert.Equal(DialogsResultType.Ok, response.Content.Result);
    }

    [Fact]
    public async Task UploadSound_Ok()
    {
        var bytes = await File.ReadAllBytesAsync(TestsConstants.SoundFilePath);
        var request = new DialogsFileUploadRequest(TestsConstants.SoundFileName, bytes);
        var uploadResponse = await _dialogsApiService.UploadSoundAsync(_skillId, request).ConfigureAwait(false);
        Assert.True(uploadResponse.IsSuccess);
        Assert.NotNull(uploadResponse.Content);
        Assert.NotNull(uploadResponse.Content.Sound);
        Assert.NotEqual(Guid.Empty, uploadResponse.Content.Sound.Id);
        Assert.NotEqual(Guid.Empty, uploadResponse.Content.Sound.SkillId);
        Assert.Null(uploadResponse.Content.Sound.Size);
        Assert.NotNull(uploadResponse.Content.Sound.OriginalName);
        Assert.NotEqual(default, uploadResponse.Content.Sound.CreatedAt);
        Assert.Null(uploadResponse.Content.Sound.Error);

        await _dialogsApiService.DeleteSoundAsync(_skillId, uploadResponse.Content.Sound.Id).ConfigureAwait(false);
    }

    [Fact]
    public async Task GetSound_InvalidSoundId_Fail()
    {
        var response = await _dialogsApiService.GetSoundAsync(_skillId, Guid.Empty).ConfigureAwait(false);
        Assert.False(response.IsSuccess);
    }

    [Fact]
    public async Task GetSound_Ok()
    {
        var bytes = await File.ReadAllBytesAsync(TestsConstants.SoundFilePath);
        var request = new DialogsFileUploadRequest(TestsConstants.SoundFileName, bytes);
        var uploadResponse = await _dialogsApiService.UploadSoundAsync(_skillId, request).ConfigureAwait(false);

        var soundId = uploadResponse.Content.Sound.Id;
        var response = await _dialogsApiService.GetSoundAsync(_skillId, soundId).ConfigureAwait(false);
        Assert.True(response.IsSuccess);
        Assert.NotNull(response.Content);
        Assert.NotNull(response.Content.Sound);
        Assert.NotEqual(Guid.Empty, response.Content.Sound.Id);

        await _dialogsApiService.DeleteSoundAsync(_skillId, uploadResponse.Content.Sound.Id).ConfigureAwait(false);
    }

    [Fact]
    public async Task GetSounds_Ok()
    {
        var bytes = await File.ReadAllBytesAsync(TestsConstants.SoundFilePath);
        var request = new DialogsFileUploadRequest(TestsConstants.SoundFileName, bytes);
        var uploadResponse = await _dialogsApiService.UploadSoundAsync(_skillId, request).ConfigureAwait(false);

        var response = await _dialogsApiService.GetSoundsAsync(_skillId).ConfigureAwait(false);
        Assert.NotEmpty(response.Content.Sounds);
        Assert.True(response.Content.Total > 0);

        await _dialogsApiService.DeleteSoundAsync(_skillId, uploadResponse.Content.Sound.Id).ConfigureAwait(false);
    }

    [Fact]
    public async Task DeleteSound_Ok()
    {
        var bytes = await File.ReadAllBytesAsync(TestsConstants.SoundFilePath);
        var request = new DialogsFileUploadRequest(TestsConstants.SoundFileName, bytes);
        var uploadResponse = await _dialogsApiService.UploadSoundAsync(_skillId, request).ConfigureAwait(false);
        var soundId = uploadResponse.Content.Sound.Id;
        var response = await _dialogsApiService.DeleteSoundAsync(_skillId, soundId).ConfigureAwait(false);
        Assert.True(response.IsSuccess);
        Assert.Equal(DialogsResultType.Ok, response.Content.Result);
    }
}
namespace Yandex.Alice.Sdk.Demo.IntegrationTests;

public static class TestsConstants
{
    public const string AliceRequestResourcesFilePath = $"{_assetsFolderPath}/AliceRequest_Resources.json";
    public const string AliceRequestFilePath = $"{_assetsFolderPath}/AliceRequest.json";
    public const string AliceRequestInvalidIntentFilePath = $"{_assetsFolderPath}/AliceRequest_InvalidIntent.json";
    public const string AliceRequestPingFilePath = $"{_assetsFolderPath}/AliceRequest_Ping.json";
    public const string IconFileName = "icon.png";
    public const string SoundFileName = "sound.mp3";
    public const string IconFilePath = $"{_assetsFolderPath}/{IconFileName}";
    public const string SoundFilePath = $"{_assetsFolderPath}/{SoundFileName}";

    public const string TestServerCollectionName = "TestServerCollection";

    public const string InvalidCredentialsMessage = "Forbidden (no credentials)";

    private const string _assetsFolderPath = "TestsInfrastructure/Assets";
}
namespace Yandex.Alice.Sdk.Tests.Models.SmartHome;

using System.IO;
using System.Text.Json;
using FluentAssertions;
using Xunit;
using Yandex.Alice.Sdk.Models.SmartHome;
using Yandex.Alice.Sdk.Tests.TestsInfrastructure;

public class SmartHomeDeviceColorSettingCapabilityStateValueTests
{
    [Fact]
    public void DeserializeJson()
    {
        // arrange
        var json = File.ReadAllText(TestsConstants.Assets.ColorSettingStatesFilePath);

        // act
        var colorSettings = JsonSerializer.Deserialize<SmartHomeDeviceColorSettingCapabilityStateValue[]>(json);

        // assert
        colorSettings.Should().NotBeNullOrEmpty();

        var rbgColorSetting = colorSettings.Should()
            .Contain(x => x.Instance == SmartHomeConstants.ColorSettingFunction.Rgb)
            .Subject;
        rbgColorSetting.Value.Should().BeOfType<int>()
            .And.Be(13910520);

        var temperatureKColorSetting = colorSettings.Should()
            .Contain(x => x.Instance == SmartHomeConstants.ColorSettingFunction.TemperatureK)
            .Subject;
        temperatureKColorSetting.Value.Should().BeOfType<int>()
            .And.Be(4500);

        var sceneColorSetting = colorSettings.Should()
            .Contain(x => x.Instance == SmartHomeConstants.ColorSettingFunction.Scene)
            .Subject;
        sceneColorSetting.Value.Should().BeOfType<string>()
            .And.Be("sunrise");

        var hsvColorSetting = colorSettings.Should()
            .Contain(x => x.Instance == SmartHomeConstants.ColorSettingFunction.Hsv)
            .Subject;
        var hsv = hsvColorSetting.Value.Should().BeOfType<SmartHomeHsv>()
            .Subject;
        hsv.H.Should().Be(255);
        hsv.S.Should().Be(100);
        hsv.V.Should().Be(50);
    }

    [Fact]
    public void SerializeJson()
    {
        // arrange
        var json = File.ReadAllText(TestsConstants.Assets.ColorSettingStatesFilePath);
        var colorSettings = JsonSerializer.Deserialize<SmartHomeDeviceColorSettingCapabilityStateValue[]>(json);

        // act
        json = JsonSerializer.Serialize(colorSettings);

        // assert
        colorSettings = JsonSerializer.Deserialize<SmartHomeDeviceColorSettingCapabilityStateValue[]>(json);

        colorSettings.Should().NotBeNullOrEmpty();

        var rbgColorSetting = colorSettings.Should()
            .Contain(x => x.Instance == SmartHomeConstants.ColorSettingFunction.Rgb)
            .Subject;
        rbgColorSetting.Value.Should().BeOfType<int>()
            .And.Be(13910520);

        var temperatureKColorSetting = colorSettings.Should()
            .Contain(x => x.Instance == SmartHomeConstants.ColorSettingFunction.TemperatureK)
            .Subject;
        temperatureKColorSetting.Value.Should().BeOfType<int>()
            .And.Be(4500);

        var sceneColorSetting = colorSettings.Should()
            .Contain(x => x.Instance == SmartHomeConstants.ColorSettingFunction.Scene)
            .Subject;
        sceneColorSetting.Value.Should().BeOfType<string>()
            .And.Be("sunrise");

        var hsvColorSetting = colorSettings.Should()
            .Contain(x => x.Instance == SmartHomeConstants.ColorSettingFunction.Hsv)
            .Subject;
        var hsv = hsvColorSetting.Value.Should().BeOfType<SmartHomeHsv>()
            .Subject;
        hsv.H.Should().Be(255);
        hsv.S.Should().Be(100);
        hsv.V.Should().Be(50);
    }

    [Fact]
    public void SerializeNull()
    {
        // arrange
        SmartHomeDeviceColorSettingCapabilityStateValue colorSetting = null;

        // act
        var json = JsonSerializer.Serialize(colorSetting);

        // assert
        json.Should().NotBeNullOrEmpty();
    }
}
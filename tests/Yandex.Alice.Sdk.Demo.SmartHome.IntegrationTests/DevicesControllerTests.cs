namespace Yandex.Alice.Sdk.Demo.SmartHome.IntegrationTests;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;
using Yandex.Alice.Sdk.Demo.SmartHome.IntegrationTests.TestsInfrastructure.Fixtures;
using Yandex.Alice.Sdk.Models.SmartHome;

public class DevicesControllerTests : BaseAuthorizedControllerTests
{
    public DevicesControllerTests(SmartHomeFixture smartHomeFixture)
        : base(smartHomeFixture)
    {
    }

    [Fact]
    public async Task GetDevices()
    {
        // arrange
        var requestId = Guid.NewGuid().ToString();
        Client.DefaultRequestHeaders.Add("X-Request-Id", requestId);

        // act
        var response = await Client.GetAsync("v1.0/user/devices");

        // assert
        var content = await response.Content.ReadAsStringAsync();
        response.StatusCode.Should().Be(HttpStatusCode.OK, content);
        var devicesResponse = JsonSerializer.Deserialize<SmartHomeResponseDevices>(content);
        devicesResponse.Should().NotBeNull();
        devicesResponse.RequestId.Should().NotBeNullOrEmpty()
            .And.Be(requestId);
        devicesResponse.Payload.Should().NotBeNull();
        devicesResponse.Payload.UserId.Should().NotBeNullOrEmpty();
        devicesResponse.Payload.Devices.Should().NotBeNullOrEmpty()
            .And.NotContainNulls(x => x.Id)
            .And.NotContainNulls(x => x.Name)
            .And.NotContainNulls(x => x.Description)
            .And.NotContainNulls(x => x.Room)
            .And.NotContainNulls(x => x.Type)
            .And.NotContainNulls(x => x.CustomData)
            .And.NotContainNulls(x => x.Capabilities)
            .And.OnlyContain(x => x.Capabilities.Any())
            .And.OnlyContain(x => x.Capabilities.All(c => !string.IsNullOrEmpty(c.Type)))
            .And.OnlyContain(x => x.Capabilities.All(c => c.Retrievable))
            .And.OnlyContain(x => x.Capabilities.All(c => c.Reportable))
            .And.Contain(x => x.Capabilities.Any(c => c is SmartHomeDeviceOnOffCapability))
            .And.OnlyContain(x => x.Capabilities
                .OfType<SmartHomeDeviceOnOffCapability>()
                .All(c => c.Type == SmartHomeConstants.Devices.Capabilities.OnOff
                          && c.Parameters != null
                          && c.Parameters.Split))
            .And.Contain(x => x.Capabilities.Any(c => c is SmartHomeDeviceColorSettingCapability))
            .And.OnlyContain(x => x.Capabilities
                .OfType<SmartHomeDeviceColorSettingCapability>()
                .All(c => c.Type == SmartHomeConstants.Devices.Capabilities.ColorSetting
                          && c.Parameters != null
                          && !string.IsNullOrEmpty(c.Parameters.ColorModel)
                          && c.Parameters.ColorModel == SmartHomeConstants.ColorSettingFunction.Rgb
                          && c.Parameters.TemperatureK != null
                          && c.Parameters.TemperatureK.Min == 2000
                          && c.Parameters.TemperatureK.Max == 9000
                          && c.Parameters.ColorScene != null
                          && c.Parameters.ColorScene.Scenes != null
                          && c.Parameters.ColorScene.Scenes.Any()
                          && c.Parameters.ColorScene.Scenes.Any(s => s.Id == SmartHomeConstants.ColorSettingScene.Alarm)))
            .And.Contain(x => x.Capabilities.Any(c => c is SmartHomeDeviceModeCapability))
            .And.OnlyContain(x => x.Capabilities
                .OfType<SmartHomeDeviceModeCapability>()
                .All(c => c.Type == SmartHomeConstants.Devices.Capabilities.Mode
                          && c.Parameters != null
                          && !string.IsNullOrEmpty(c.Parameters.Instance)
                          && c.Parameters.Instance != null
                          && c.Parameters.Modes != null
                          && c.Parameters.Modes.Any(m => !string.IsNullOrEmpty(m.Value))))
            .And.Contain(x => x.Capabilities.Any(c => c is SmartHomeDeviceRangeCapability))
            .And.OnlyContain(x => x.Capabilities
                .OfType<SmartHomeDeviceRangeCapability>()
                .All(c => c.Type == SmartHomeConstants.Devices.Capabilities.Range
                          && c.Parameters != null
                          && c.Parameters.Instance != null
                          && c.Parameters.RandomAccess
                          && c.Parameters.Range != null
                          && c.Parameters.Range.Min >= 0
                          && c.Parameters.Range.Max > 0
                          && c.Parameters.Range.Precision > 0))
            .And.Contain(x => x.Capabilities.Any(c => c is SmartHomeDeviceToggleCapability))
            .And.OnlyContain(x => x.Capabilities
                .OfType<SmartHomeDeviceToggleCapability>()
                .All(c => c.Type == SmartHomeConstants.Devices.Capabilities.Toggle
                          && c.Parameters != null
                          && !string.IsNullOrEmpty(c.Parameters.Instance)))
            .And.NotContainNulls(x => x.Properties)
            .And.OnlyContain(x => x.Properties.Any())
            .And.OnlyContain(x => x.Properties.All(p => !string.IsNullOrEmpty(p.Type)))
            .And.OnlyContain(x => x.Properties.All(p => p.Retrievable))
            .And.OnlyContain(x => x.Properties.All(p => p.Reportable))
            .And.Contain(x => x.Properties.Any(c => c is SmartHomeDeviceFloatProperty))
            .And.OnlyContain(x => x.Properties
                .OfType<SmartHomeDeviceFloatProperty>()
                .All(c => c.Type == SmartHomeConstants.Devices.Properties.Float
                          && c.Parameters != null
                          && !string.IsNullOrEmpty(c.Parameters.Instance)
                          && !string.IsNullOrEmpty(c.Parameters.Unit)))
            .And.Contain(x => x.Properties.Any(c => c is SmartHomeDeviceEventProperty))
            .And.OnlyContain(x => x.Properties
                .OfType<SmartHomeDeviceEventProperty>()
                .All(c => c.Type == SmartHomeConstants.Devices.Properties.Event
                          && c.Parameters != null
                          && !string.IsNullOrEmpty(c.Parameters.Instance)
                          && c.Parameters.Events != null
                          && c.Parameters.Events.Any()))
            .And.NotContainNulls(x => x.DeviceInfo)
            .And.NotContainNulls(x => x.DeviceInfo.Manufacturer)
            .And.NotContainNulls(x => x.DeviceInfo.Model)
            .And.NotContainNulls(x => x.DeviceInfo.HwVersion)
            .And.NotContainNulls(x => x.DeviceInfo.SwVersion);
    }

    [Fact]
    public async Task QueryDevices_DeviceExists_ShouldReturnSuccessResponse()
    {
        // arrange
        var requestId = Guid.NewGuid().ToString();
        Client.DefaultRequestHeaders.Add("X-Request-Id", requestId);

        var request = new SmartHomeRequestDevicesQuery
        {
            Devices = new List<SmartHomeRequestDevicesQueryDevice>
            {
                new ()
                {
                    Id = "1234",
                },
            },
        };
        var payload = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");

        // act
        var response = await Client.PostAsync("v1.0/user/devices/query", payload);

        // assert
        var content = await response.Content.ReadAsStringAsync();
        response.StatusCode.Should().Be(HttpStatusCode.OK, content);

        var devicesResponse = JsonSerializer.Deserialize<SmartHomeResponseDevicesQuery>(content);
        devicesResponse.Should().NotBeNull();
        devicesResponse.RequestId.Should().NotBeNullOrEmpty()
            .And.Be(requestId);
        devicesResponse.Payload.Should().NotBeNull();
        devicesResponse.Payload.Devices.Should().NotBeNullOrEmpty()
            .And.Contain(x => request.Devices.Any(d => d.Id == x.Id))
            .And.OnlyContain(x => x.Capabilities != null)
            .And.OnlyContain(x => x.Capabilities.Any())
            .And.OnlyContain(x => x.Capabilities.All(c => !string.IsNullOrEmpty(c.Type)))
            .And.Contain(x => x.Capabilities.Any(c => c is SmartHomeDeviceOnOffCapabilityState))
            .And.OnlyContain(x => x.Capabilities
                .OfType<SmartHomeDeviceOnOffCapabilityState>()
                .All(c => c.Type == SmartHomeConstants.Devices.Capabilities.OnOff
                          && c.State != null
                          && !string.IsNullOrEmpty(c.State.Instance)
                          && c.State.Value))
            .And.Contain(x => x.Capabilities.Any(c => c is SmartHomeDeviceColorSettingCapabilityState))
            .And.OnlyContain(x => x.Capabilities
                .OfType<SmartHomeDeviceColorSettingCapabilityState>()
                .All(c => c.Type == SmartHomeConstants.Devices.Capabilities.ColorSetting
                          && c.State != null
                          && !string.IsNullOrEmpty(c.State.Instance)
                          && c.State.Value != null))
            .And.Contain(x => x.Capabilities.Any(c => c is SmartHomeDeviceModeCapabilityState))
            .And.OnlyContain(x => x.Capabilities
                .OfType<SmartHomeDeviceModeCapabilityState>()
                .All(c => c.Type == SmartHomeConstants.Devices.Capabilities.Mode
                          && c.State != null
                          && !string.IsNullOrEmpty(c.State.Instance)
                          && !string.IsNullOrEmpty(c.State.Value)))
            .And.Contain(x => x.Capabilities.Any(c => c is SmartHomeDeviceRangeCapabilityState))
            .And.OnlyContain(x => x.Capabilities
                .OfType<SmartHomeDeviceRangeCapabilityState>()
                .All(c => c.Type == SmartHomeConstants.Devices.Capabilities.Range
                          && c.State != null
                          && !string.IsNullOrEmpty(c.State.Instance)
                          && c.State.Value > 0))
            .And.Contain(x => x.Capabilities.Any(c => c is SmartHomeDeviceToggleCapabilityState))
            .And.OnlyContain(x => x.Capabilities
                .OfType<SmartHomeDeviceToggleCapabilityState>()
                .All(c => c.Type == SmartHomeConstants.Devices.Capabilities.Toggle
                          && c.State != null
                          && !string.IsNullOrEmpty(c.State.Instance)))
            .And.OnlyContain(x => x.Properties != null)
            .And.OnlyContain(x => x.Properties.Any())
            .And.OnlyContain(x => x.Properties.All(p => !string.IsNullOrEmpty(p.Type)))
            .And.Contain(x => x.Properties.Any(c => c is SmartHomeDeviceFloatPropertyState))
            .And.OnlyContain(x => x.Properties
                .OfType<SmartHomeDeviceFloatPropertyState>()
                .All(c => c.Type == SmartHomeConstants.Devices.Properties.Float
                          && c.State != null
                          && !string.IsNullOrEmpty(c.State.Instance)
                          && c.State.Value > 0))
            .And.Contain(x => x.Properties.Any(c => c is SmartHomeDeviceEventPropertyState))
            .And.OnlyContain(x => x.Properties
                .OfType<SmartHomeDeviceEventPropertyState>()
                .All(c => c.Type == SmartHomeConstants.Devices.Properties.Event
                          && c.State != null
                          && !string.IsNullOrEmpty(c.State.Instance)
                          && !string.IsNullOrEmpty(c.State.Value)));
    }

    [Fact]
    public async Task QueryDevices_DeviceDoesNotExist_ShouldReturnNotFound()
    {
        // arrange
        var request = new SmartHomeRequestDevicesQuery
        {
            Devices = new List<SmartHomeRequestDevicesQueryDevice>
            {
                new ()
                {
                    Id = "unknown",
                },
            },
        };
        var payload = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");

        // act
        var response = await Client.PostAsync("v1.0/user/devices/query", payload);

        // assert
        var content = await response.Content.ReadAsStringAsync();
        response.StatusCode.Should().Be(HttpStatusCode.NotFound, content);
    }

    [Fact]
    public async Task Action_TurnOffDevice_ShouldTurnOffSuccessfully()
    {
        // arrange
        var request = new SmartHomeRequestDevicesAction
        {
            Payload = new SmartHomeRequestDevicesActionPayload
            {
                Devices = new List<SmartHomeRequestDevicesActionDevice>
                {
                    new ()
                    {
                        Id = "1234",
                        Capabilities = new List<SmartHomeDeviceCapabilityState>
                        {
                            new SmartHomeDeviceOnOffCapabilityState
                            {
                                State = new SmartHomeDeviceOnOffCapabilityStateValue
                                {
                                    Instance = SmartHomeConstants.OnOffFunction.On,
                                    Value = false,
                                },
                            },
                        },
                    },
                },
            },
        };
        var payload = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");

        // act
        var response = await Client.PostAsync("v1.0/user/devices/action", payload);

        // assert
        var content = await response.Content.ReadAsStringAsync();
        response.StatusCode.Should().Be(HttpStatusCode.OK, content);

        var queryRequest = new SmartHomeRequestDevicesQuery
        {
            Devices = new List<SmartHomeRequestDevicesQueryDevice>
            {
                new ()
                {
                    Id = "1234",
                },
            },
        };
        var queryPayload = new StringContent(JsonSerializer.Serialize(queryRequest), Encoding.UTF8, "application/json");
        var queryResponse = await Client.PostAsync("v1.0/user/devices/query", queryPayload);
        var queryContent = await queryResponse.Content.ReadAsStringAsync();
        var devicesQueryResponse = JsonSerializer.Deserialize<SmartHomeResponseDevicesQuery>(queryContent);
        var device = devicesQueryResponse.Payload.Devices.FirstOrDefault(x => x.Id == "1234");
        var capability = (SmartHomeDeviceOnOffCapabilityState)device.Capabilities.FirstOrDefault(x => x is SmartHomeDeviceOnOffCapabilityState);
        capability.State.Value.Should().BeFalse();
    }
}
namespace Yandex.Alice.Sdk.Demo.SmartHome.Services;

using System.Collections.Generic;
using System.Linq;
using Yandex.Alice.Sdk.Demo.SmartHome.Exceptions;
using Yandex.Alice.Sdk.Demo.SmartHome.Models;
using Yandex.Alice.Sdk.Models.SmartHome;

public class DeviceService : IDeviceService
{
    private readonly IContextUserService _contextUserService;

    private readonly List<SmartHomeDeviceState> _devicesStates;

    public DeviceService(IContextUserService contextUserService)
    {
        _contextUserService = contextUserService;
        _devicesStates = new List<SmartHomeDeviceState>
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
                            Value = true,
                        },
                    },
                    new SmartHomeDeviceColorSettingCapabilityState
                    {
                        State = new SmartHomeDeviceColorSettingCapabilityStateValue
                        {
                            Instance = SmartHomeConstants.ColorSettingFunction.Scene,
                            Value = SmartHomeConstants.ColorSettingScene.Jungle,
                        },
                    },
                    new SmartHomeDeviceModeCapabilityState
                    {
                        State = new SmartHomeDeviceModeCapabilityStateValue
                        {
                            Instance = SmartHomeConstants.ModeFunction.CleanupMode,
                            Value = SmartHomeConstants.DeviceMode.Quiet,
                        },
                    },
                    new SmartHomeDeviceModeCapabilityState
                    {
                        State = new SmartHomeDeviceModeCapabilityStateValue
                        {
                            Instance = SmartHomeConstants.ModeFunction.CoffeeMode,
                            Value = SmartHomeConstants.DeviceMode.Cappuccino,
                        },
                    },
                    new SmartHomeDeviceModeCapabilityState
                    {
                        State = new SmartHomeDeviceModeCapabilityStateValue
                        {
                            Instance = SmartHomeConstants.ModeFunction.Dishwashing,
                            Value = SmartHomeConstants.DeviceMode.Glass,
                        },
                    },
                    new SmartHomeDeviceModeCapabilityState
                    {
                        State = new SmartHomeDeviceModeCapabilityStateValue
                        {
                            Instance = SmartHomeConstants.ModeFunction.FanSpeed,
                            Value = SmartHomeConstants.DeviceMode.Medium,
                        },
                    },
                    new SmartHomeDeviceModeCapabilityState
                    {
                        State = new SmartHomeDeviceModeCapabilityStateValue
                        {
                            Instance = SmartHomeConstants.ModeFunction.Heat,
                            Value = SmartHomeConstants.DeviceMode.Min,
                        },
                    },
                    new SmartHomeDeviceModeCapabilityState
                    {
                        State = new SmartHomeDeviceModeCapabilityStateValue
                        {
                            Instance = SmartHomeConstants.ModeFunction.InputSource,
                            Value = SmartHomeConstants.DeviceMode.Two,
                        },
                    },
                    new SmartHomeDeviceModeCapabilityState
                    {
                        State = new SmartHomeDeviceModeCapabilityStateValue
                        {
                            Instance = SmartHomeConstants.ModeFunction.Program,
                            Value = SmartHomeConstants.DeviceMode.Cheesecake,
                        },
                    },
                    new SmartHomeDeviceModeCapabilityState
                    {
                        State = new SmartHomeDeviceModeCapabilityStateValue
                        {
                            Instance = SmartHomeConstants.ModeFunction.Swing,
                            Value = SmartHomeConstants.DeviceMode.Horizontal,
                        },
                    },
                    new SmartHomeDeviceModeCapabilityState
                    {
                        State = new SmartHomeDeviceModeCapabilityStateValue
                        {
                            Instance = SmartHomeConstants.ModeFunction.TeaMode,
                            Value = SmartHomeConstants.DeviceMode.OolongTea,
                        },
                    },
                    new SmartHomeDeviceModeCapabilityState
                    {
                        State = new SmartHomeDeviceModeCapabilityStateValue
                        {
                            Instance = SmartHomeConstants.ModeFunction.Thermostat,
                            Value = SmartHomeConstants.DeviceMode.FanOnly,
                        },
                    },
                    new SmartHomeDeviceModeCapabilityState
                    {
                        State = new SmartHomeDeviceModeCapabilityStateValue
                        {
                            Instance = SmartHomeConstants.ModeFunction.WorkSpeed,
                            Value = SmartHomeConstants.DeviceMode.Slow,
                        },
                    },
                    new SmartHomeDeviceRangeCapabilityState
                    {
                        State = new SmartHomeDeviceRangeCapabilityStateValue
                        {
                            Instance = SmartHomeConstants.RangeFunction.Brightness,
                            Value = 35,
                        },
                    },
                    new SmartHomeDeviceRangeCapabilityState
                    {
                        State = new SmartHomeDeviceRangeCapabilityStateValue
                        {
                            Instance = SmartHomeConstants.RangeFunction.Channel,
                            Value = 2,
                        },
                    },
                    new SmartHomeDeviceRangeCapabilityState
                    {
                        State = new SmartHomeDeviceRangeCapabilityStateValue
                        {
                            Instance = SmartHomeConstants.RangeFunction.Humidity,
                            Value = 45,
                        },
                    },
                    new SmartHomeDeviceRangeCapabilityState
                    {
                        State = new SmartHomeDeviceRangeCapabilityStateValue
                        {
                            Instance = SmartHomeConstants.RangeFunction.Open,
                            Value = 90,
                        },
                    },
                    new SmartHomeDeviceRangeCapabilityState
                    {
                        State = new SmartHomeDeviceRangeCapabilityStateValue
                        {
                            Instance = SmartHomeConstants.RangeFunction.Temperature,
                            Value = 24,
                        },
                    },
                    new SmartHomeDeviceRangeCapabilityState
                    {
                        State = new SmartHomeDeviceRangeCapabilityStateValue
                        {
                            Instance = SmartHomeConstants.RangeFunction.Volume,
                            Value = 67,
                        },
                    },
                    new SmartHomeDeviceToggleCapabilityState
                    {
                        State = new SmartHomeDeviceToggleCapabilityStateValue
                        {
                            Instance = SmartHomeConstants.ToggleFunction.Ionization,
                            Value = false,
                        },
                    },
                },
                Properties = new List<SmartHomeDevicePropertyState>
                {
                    new SmartHomeDeviceFloatPropertyState
                    {
                        State = new SmartHomeDeviceFloatPropertyStateValue
                        {
                            Instance = SmartHomeConstants.FloatFunction.Amperage,
                            Value = 15,
                        },
                    },
                    new SmartHomeDeviceFloatPropertyState
                    {
                        State = new SmartHomeDeviceFloatPropertyStateValue
                        {
                            Instance = SmartHomeConstants.FloatFunction.BatteryLevel,
                            Value = 97,
                        },
                    },
                    new SmartHomeDeviceFloatPropertyState
                    {
                        State = new SmartHomeDeviceFloatPropertyStateValue
                        {
                            Instance = SmartHomeConstants.FloatFunction.Co2Level,
                            Value = 13,
                        },
                    },
                    new SmartHomeDeviceFloatPropertyState
                    {
                        State = new SmartHomeDeviceFloatPropertyStateValue
                        {
                            Instance = SmartHomeConstants.FloatFunction.Humidity,
                            Value = 55,
                        },
                    },
                    new SmartHomeDeviceFloatPropertyState
                    {
                        State = new SmartHomeDeviceFloatPropertyStateValue
                        {
                            Instance = SmartHomeConstants.FloatFunction.Illumination,
                            Value = 8,
                        },
                    },
                    new SmartHomeDeviceFloatPropertyState
                    {
                        State = new SmartHomeDeviceFloatPropertyStateValue
                        {
                            Instance = SmartHomeConstants.FloatFunction.Pm1Density,
                            Value = 5,
                        },
                    },
                    new SmartHomeDeviceFloatPropertyState
                    {
                        State = new SmartHomeDeviceFloatPropertyStateValue
                        {
                            Instance = SmartHomeConstants.FloatFunction.Pm25Density,
                            Value = 6,
                        },
                    },
                    new SmartHomeDeviceFloatPropertyState
                    {
                        State = new SmartHomeDeviceFloatPropertyStateValue
                        {
                            Instance = SmartHomeConstants.FloatFunction.Pm10Density,
                            Value = 9,
                        },
                    },
                    new SmartHomeDeviceFloatPropertyState
                    {
                        State = new SmartHomeDeviceFloatPropertyStateValue
                        {
                            Instance = SmartHomeConstants.FloatFunction.Power,
                            Value = 25,
                        },
                    },
                    new SmartHomeDeviceFloatPropertyState
                    {
                        State = new SmartHomeDeviceFloatPropertyStateValue
                        {
                            Instance = SmartHomeConstants.FloatFunction.Pressure,
                            Value = 115,
                        },
                    },
                    new SmartHomeDeviceFloatPropertyState
                    {
                        State = new SmartHomeDeviceFloatPropertyStateValue
                        {
                            Instance = SmartHomeConstants.FloatFunction.Temperature,
                            Value = 21,
                        },
                    },
                    new SmartHomeDeviceFloatPropertyState
                    {
                        State = new SmartHomeDeviceFloatPropertyStateValue
                        {
                            Instance = SmartHomeConstants.FloatFunction.Tvoc,
                            Value = 1,
                        },
                    },
                    new SmartHomeDeviceFloatPropertyState
                    {
                        State = new SmartHomeDeviceFloatPropertyStateValue
                        {
                            Instance = SmartHomeConstants.FloatFunction.Voltage,
                            Value = 220,
                        },
                    },
                    new SmartHomeDeviceFloatPropertyState
                    {
                        State = new SmartHomeDeviceFloatPropertyStateValue
                        {
                            Instance = SmartHomeConstants.FloatFunction.WaterLevel,
                            Value = 90,
                        },
                    },
                    new SmartHomeDeviceEventPropertyState
                    {
                        State = new SmartHomeDeviceEventPropertyStateValue
                        {
                            Instance = SmartHomeConstants.EventFunction.BatteryLevel,
                            Value = SmartHomeConstants.Events.Low,
                        },
                    },
                },
            },
            new ()
            {
                Id = "1235",
                Capabilities = new List<SmartHomeDeviceCapabilityState>
                {
                    new SmartHomeDeviceOnOffCapabilityState
                    {
                        State = new SmartHomeDeviceOnOffCapabilityStateValue
                        {
                            Instance = SmartHomeConstants.OnOffFunction.On,
                            Value = true,
                        },
                    },
                },
                Properties = new List<SmartHomeDevicePropertyState>
                {
                    new SmartHomeDeviceFloatPropertyState
                    {
                        State = new SmartHomeDeviceFloatPropertyStateValue
                        {
                            Instance = SmartHomeConstants.FloatFunction.WaterLevel,
                            Value = 97,
                        },
                    },
                },
                ErrorCode = SmartHomeConstants.ErrorCodes.DeviceUnreachable,
                ErrorMessage = @"Устройство недоступно. Это кастомный текст",
            },
        };
    }

    public SmartHomeResponseDevices GetDevicesResponse(SmartHomeRequestHeaders requestHeaders)
    {
        var response = new SmartHomeResponseDevices
        {
            RequestId = requestHeaders.RequestId,
            Payload = new SmartHomeResponseDevicesPayload
            {
                UserId = _contextUserService.GetContextUserId(),
                Devices = new List<SmartHomeDevice>
                {
                    new ()
                    {
                        Id = SmartHomeDemoConstants.LampDeviceId,
                        Name = @"Фантомная лампочка",
                        Description = @"Несуществующая лампочка. Делает много чего не умеют обычные лампочки. По крайней мере она так считает",
                        Room = @"Спальня",
                        Type = SmartHomeConstants.Devices.Types.Light,
                        CustomData = new Dictionary<string, string> { { "custom", "data" } },
                        Capabilities = new List<SmartHomeDeviceCapability>
                        {
                            new SmartHomeDeviceOnOffCapability
                            {
                                Retrievable = true,
                                Reportable = true,
                                Parameters = new SmartHomeDeviceOnOffCapabilityParameters
                                {
                                    Split = true,
                                },
                            },
                            new SmartHomeDeviceColorSettingCapability
                            {
                                Retrievable = true,
                                Reportable = true,
                                Parameters = new SmartHomeDeviceColorSettingCapabilityParameters
                                {
                                    ColorModel = SmartHomeConstants.ColorSettingFunction.Rgb,
                                    TemperatureK = new SmartHomeTemperatureK
                                    {
                                        Min = 2000,
                                        Max = 9000,
                                    },
                                    ColorScene = new SmartHomeDeviceColorScene
                                    {
                                        Scenes = new List<SmartHomeColorScene>
                                        {
                                            new (SmartHomeConstants.ColorSettingScene.Alarm),
                                            new (SmartHomeConstants.ColorSettingScene.Alice),
                                            new (SmartHomeConstants.ColorSettingScene.Candle),
                                            new (SmartHomeConstants.ColorSettingScene.Dinner),
                                            new (SmartHomeConstants.ColorSettingScene.Fantasy),
                                            new (SmartHomeConstants.ColorSettingScene.Garland),
                                            new (SmartHomeConstants.ColorSettingScene.Jungle),
                                            new (SmartHomeConstants.ColorSettingScene.Movie),
                                            new (SmartHomeConstants.ColorSettingScene.Neon),
                                            new (SmartHomeConstants.ColorSettingScene.Night),
                                            new (SmartHomeConstants.ColorSettingScene.Ocean),
                                            new (SmartHomeConstants.ColorSettingScene.Party),
                                            new (SmartHomeConstants.ColorSettingScene.Reading),
                                            new (SmartHomeConstants.ColorSettingScene.Rest),
                                            new (SmartHomeConstants.ColorSettingScene.Romance),
                                            new (SmartHomeConstants.ColorSettingScene.Siren),
                                            new (SmartHomeConstants.ColorSettingScene.Sunrise),
                                            new (SmartHomeConstants.ColorSettingScene.Sunset),
                                        },
                                    },
                                },
                            },
                            new SmartHomeDeviceModeCapability
                            {
                                Retrievable = true,
                                Reportable = true,
                                Parameters = new SmartHomeDeviceModeCapabilityParameters
                                {
                                    Instance = SmartHomeConstants.ModeFunction.CleanupMode,
                                    Modes = new List<SmartHomeDeviceMode>
                                    {
                                        new (SmartHomeConstants.DeviceMode.Auto),
                                        new (SmartHomeConstants.DeviceMode.Eco),
                                        new (SmartHomeConstants.DeviceMode.Turbo),
                                        new (SmartHomeConstants.DeviceMode.Quiet),
                                    },
                                },
                            },
                            new SmartHomeDeviceModeCapability
                            {
                                Retrievable = true,
                                Reportable = true,
                                Parameters = new SmartHomeDeviceModeCapabilityParameters
                                {
                                    Instance = SmartHomeConstants.ModeFunction.CoffeeMode,
                                    Modes = new List<SmartHomeDeviceMode>
                                    {
                                        new (SmartHomeConstants.DeviceMode.Americano),
                                        new (SmartHomeConstants.DeviceMode.Cappuccino),
                                        new (SmartHomeConstants.DeviceMode.Espresso),
                                        new (SmartHomeConstants.DeviceMode.DoubleEspresso),
                                        new (SmartHomeConstants.DeviceMode.Latte),
                                    },
                                },
                            },
                            new SmartHomeDeviceModeCapability
                            {
                                Retrievable = true,
                                Reportable = true,
                                Parameters = new SmartHomeDeviceModeCapabilityParameters
                                {
                                    Instance = SmartHomeConstants.ModeFunction.Dishwashing,
                                    Modes = new List<SmartHomeDeviceMode>
                                    {
                                        new (SmartHomeConstants.DeviceMode.Auto),
                                        new (SmartHomeConstants.DeviceMode.Normal),
                                        new (SmartHomeConstants.DeviceMode.Intensive),
                                        new (SmartHomeConstants.DeviceMode.Glass),
                                        new (SmartHomeConstants.DeviceMode.Express),
                                        new (SmartHomeConstants.DeviceMode.PreRinse),
                                    },
                                },
                            },
                            new SmartHomeDeviceModeCapability
                            {
                                Retrievable = true,
                                Reportable = true,
                                Parameters = new SmartHomeDeviceModeCapabilityParameters
                                {
                                    Instance = SmartHomeConstants.ModeFunction.FanSpeed,
                                    Modes = new List<SmartHomeDeviceMode>
                                    {
                                        new (SmartHomeConstants.DeviceMode.High),
                                        new (SmartHomeConstants.DeviceMode.Medium),
                                        new (SmartHomeConstants.DeviceMode.Low),
                                    },
                                },
                            },
                            new SmartHomeDeviceModeCapability
                            {
                                Retrievable = true,
                                Reportable = true,
                                Parameters = new SmartHomeDeviceModeCapabilityParameters
                                {
                                    Instance = SmartHomeConstants.ModeFunction.Heat,
                                    Modes = new List<SmartHomeDeviceMode>
                                    {
                                        new (SmartHomeConstants.DeviceMode.Auto),
                                        new (SmartHomeConstants.DeviceMode.Min),
                                        new (SmartHomeConstants.DeviceMode.Max),
                                    },
                                },
                            },
                            new SmartHomeDeviceModeCapability
                            {
                                Retrievable = true,
                                Reportable = true,
                                Parameters = new SmartHomeDeviceModeCapabilityParameters
                                {
                                    Instance = SmartHomeConstants.ModeFunction.InputSource,
                                    Modes = new List<SmartHomeDeviceMode>
                                    {
                                        new (SmartHomeConstants.DeviceMode.One),
                                        new (SmartHomeConstants.DeviceMode.Two),
                                        new (SmartHomeConstants.DeviceMode.Three),
                                        new (SmartHomeConstants.DeviceMode.Four),
                                        new (SmartHomeConstants.DeviceMode.Five),
                                        new (SmartHomeConstants.DeviceMode.Six),
                                        new (SmartHomeConstants.DeviceMode.Seven),
                                        new (SmartHomeConstants.DeviceMode.Eight),
                                        new (SmartHomeConstants.DeviceMode.Nine),
                                        new (SmartHomeConstants.DeviceMode.Ten),
                                    },
                                },
                            },
                            new SmartHomeDeviceModeCapability
                            {
                                Retrievable = true,
                                Reportable = true,
                                Parameters = new SmartHomeDeviceModeCapabilityParameters
                                {
                                    Instance = SmartHomeConstants.ModeFunction.Program,
                                    Modes = new List<SmartHomeDeviceMode>
                                    {
                                        new (SmartHomeConstants.DeviceMode.Aspic),
                                        new (SmartHomeConstants.DeviceMode.BabyFood),
                                        new (SmartHomeConstants.DeviceMode.Bread),
                                        new (SmartHomeConstants.DeviceMode.Boiling),
                                        new (SmartHomeConstants.DeviceMode.Cereals),
                                        new (SmartHomeConstants.DeviceMode.Cheesecake),
                                        new (SmartHomeConstants.DeviceMode.DeepFryer),
                                        new (SmartHomeConstants.DeviceMode.Dessert),
                                        new (SmartHomeConstants.DeviceMode.Fowl),
                                        new (SmartHomeConstants.DeviceMode.Frying),
                                        new (SmartHomeConstants.DeviceMode.Macaroni),
                                        new (SmartHomeConstants.DeviceMode.MilkPorridge),
                                        new (SmartHomeConstants.DeviceMode.Multicooker),
                                        new (SmartHomeConstants.DeviceMode.Pasta),
                                        new (SmartHomeConstants.DeviceMode.Pilaf),
                                        new (SmartHomeConstants.DeviceMode.Pizza),
                                        new (SmartHomeConstants.DeviceMode.Sauce),
                                        new (SmartHomeConstants.DeviceMode.SlowCook),
                                        new (SmartHomeConstants.DeviceMode.Soup),
                                        new (SmartHomeConstants.DeviceMode.Steam),
                                        new (SmartHomeConstants.DeviceMode.Stewing),
                                        new (SmartHomeConstants.DeviceMode.Vacuum),
                                        new (SmartHomeConstants.DeviceMode.Yogurt),
                                    },
                                },
                            },
                            new SmartHomeDeviceModeCapability
                            {
                                Retrievable = true,
                                Reportable = true,
                                Parameters = new SmartHomeDeviceModeCapabilityParameters
                                {
                                    Instance = SmartHomeConstants.ModeFunction.Swing,
                                    Modes = new List<SmartHomeDeviceMode>
                                    {
                                        new (SmartHomeConstants.DeviceMode.Vertical),
                                        new (SmartHomeConstants.DeviceMode.Horizontal),
                                        new (SmartHomeConstants.DeviceMode.Stationary),
                                    },
                                },
                            },
                            new SmartHomeDeviceModeCapability
                            {
                                Retrievable = true,
                                Reportable = true,
                                Parameters = new SmartHomeDeviceModeCapabilityParameters
                                {
                                    Instance = SmartHomeConstants.ModeFunction.TeaMode,
                                    Modes = new List<SmartHomeDeviceMode>
                                    {
                                        new (SmartHomeConstants.DeviceMode.BlackTea),
                                        new (SmartHomeConstants.DeviceMode.GreenTea),
                                        new (SmartHomeConstants.DeviceMode.FlowerTea),
                                        new (SmartHomeConstants.DeviceMode.HerbalTea),
                                        new (SmartHomeConstants.DeviceMode.OolongTea),
                                        new (SmartHomeConstants.DeviceMode.PuerhTea),
                                        new (SmartHomeConstants.DeviceMode.RedTea),
                                        new (SmartHomeConstants.DeviceMode.WhiteTea),
                                    },
                                },
                            },
                            new SmartHomeDeviceModeCapability
                            {
                                Retrievable = true,
                                Reportable = true,
                                Parameters = new SmartHomeDeviceModeCapabilityParameters
                                {
                                    Instance = SmartHomeConstants.ModeFunction.Thermostat,
                                    Modes = new List<SmartHomeDeviceMode>
                                    {
                                        new (SmartHomeConstants.DeviceMode.Cool),
                                        new (SmartHomeConstants.DeviceMode.Dry),
                                        new (SmartHomeConstants.DeviceMode.FanOnly),
                                        new (SmartHomeConstants.DeviceMode.Heat),
                                        new (SmartHomeConstants.DeviceMode.Preheat),
                                    },
                                },
                            },
                            new SmartHomeDeviceModeCapability
                            {
                                Retrievable = true,
                                Reportable = true,
                                Parameters = new SmartHomeDeviceModeCapabilityParameters
                                {
                                    Instance = SmartHomeConstants.ModeFunction.WorkSpeed,
                                    Modes = new List<SmartHomeDeviceMode>
                                    {
                                        new (SmartHomeConstants.DeviceMode.Fast),
                                        new (SmartHomeConstants.DeviceMode.Slow),
                                    },
                                },
                            },
                            new SmartHomeDeviceRangeCapability
                            {
                                Retrievable = true,
                                Reportable = true,
                                Parameters = new SmartHomeDeviceRangeCapabilityParameters
                                {
                                    Instance = SmartHomeConstants.RangeFunction.Brightness,
                                    Unit = SmartHomeConstants.Unit.Percent,
                                    RandomAccess = true,
                                    Range = new SmartHomeRange
                                    {
                                        Min = 0,
                                        Max = 100,
                                        Precision = 1,
                                    },
                                },
                            },
                            new SmartHomeDeviceRangeCapability
                            {
                                Retrievable = true,
                                Reportable = true,
                                Parameters = new SmartHomeDeviceRangeCapabilityParameters
                                {
                                    Instance = SmartHomeConstants.RangeFunction.Channel,
                                    RandomAccess = true,
                                    Range = new SmartHomeRange
                                    {
                                        Min = 1,
                                        Max = 50,
                                        Precision = 1,
                                    },
                                },
                            },
                            new SmartHomeDeviceRangeCapability
                            {
                                Retrievable = true,
                                Reportable = true,
                                Parameters = new SmartHomeDeviceRangeCapabilityParameters
                                {
                                    Instance = SmartHomeConstants.RangeFunction.Humidity,
                                    Unit = SmartHomeConstants.Unit.Percent,
                                    RandomAccess = true,
                                    Range = new SmartHomeRange
                                    {
                                        Min = 0,
                                        Max = 100,
                                        Precision = 1,
                                    },
                                },
                            },
                            new SmartHomeDeviceRangeCapability
                            {
                                Retrievable = true,
                                Reportable = true,
                                Parameters = new SmartHomeDeviceRangeCapabilityParameters
                                {
                                    Instance = SmartHomeConstants.RangeFunction.Open,
                                    Unit = SmartHomeConstants.Unit.Percent,
                                    RandomAccess = true,
                                    Range = new SmartHomeRange
                                    {
                                        Min = 0,
                                        Max = 100,
                                        Precision = 1,
                                    },
                                },
                            },
                            new SmartHomeDeviceRangeCapability
                            {
                                Retrievable = true,
                                Reportable = true,
                                Parameters = new SmartHomeDeviceRangeCapabilityParameters
                                {
                                    Instance = SmartHomeConstants.RangeFunction.Temperature,
                                    Unit = SmartHomeConstants.Unit.Temperature.Celsius,
                                    RandomAccess = true,
                                    Range = new SmartHomeRange
                                    {
                                        Min = 18,
                                        Max = 40,
                                        Precision = 1,
                                    },
                                },
                            },
                            new SmartHomeDeviceRangeCapability
                            {
                                Retrievable = true,
                                Reportable = true,
                                Parameters = new SmartHomeDeviceRangeCapabilityParameters
                                {
                                    Instance = SmartHomeConstants.RangeFunction.Volume,
                                    Unit = SmartHomeConstants.Unit.Percent,
                                    RandomAccess = true,
                                    Range = new SmartHomeRange
                                    {
                                        Min = 0,
                                        Max = 100,
                                        Precision = 10,
                                    },
                                },
                            },
                            new SmartHomeDeviceToggleCapability
                            {
                                Retrievable = true,
                                Reportable = true,
                                Parameters = new SmartHomeDeviceToggleCapabilityParameters
                                {
                                    Instance = SmartHomeConstants.ToggleFunction.Backlight,
                                },
                            },
                            new SmartHomeDeviceToggleCapability
                            {
                                Retrievable = true,
                                Reportable = true,
                                Parameters = new SmartHomeDeviceToggleCapabilityParameters
                                {
                                    Instance = SmartHomeConstants.ToggleFunction.ControlsLocked,
                                },
                            },
                            new SmartHomeDeviceToggleCapability
                            {
                                Retrievable = true,
                                Reportable = true,
                                Parameters = new SmartHomeDeviceToggleCapabilityParameters
                                {
                                    Instance = SmartHomeConstants.ToggleFunction.Ionization,
                                },
                            },
                            new SmartHomeDeviceToggleCapability
                            {
                                Retrievable = true,
                                Reportable = true,
                                Parameters = new SmartHomeDeviceToggleCapabilityParameters
                                {
                                    Instance = SmartHomeConstants.ToggleFunction.KeepWarm,
                                },
                            },
                            new SmartHomeDeviceToggleCapability
                            {
                                Retrievable = true,
                                Reportable = true,
                                Parameters = new SmartHomeDeviceToggleCapabilityParameters
                                {
                                    Instance = SmartHomeConstants.ToggleFunction.Mute,
                                },
                            },
                            new SmartHomeDeviceToggleCapability
                            {
                                Retrievable = true,
                                Reportable = true,
                                Parameters = new SmartHomeDeviceToggleCapabilityParameters
                                {
                                    Instance = SmartHomeConstants.ToggleFunction.Oscillation,
                                },
                            },
                            new SmartHomeDeviceToggleCapability
                            {
                                Retrievable = true,
                                Reportable = true,
                                Parameters = new SmartHomeDeviceToggleCapabilityParameters
                                {
                                    Instance = SmartHomeConstants.ToggleFunction.Pause,
                                },
                            },
                        },
                        Properties = new List<SmartHomeDeviceProperty>
                        {
                            new SmartHomeDeviceFloatProperty
                            {
                                Retrievable = true,
                                Reportable = true,
                                Parameters = new SmartHomeDeviceFloatPropertyParameters
                                {
                                    Instance = SmartHomeConstants.FloatFunction.Amperage,
                                    Unit = SmartHomeConstants.Unit.Ampere,
                                },
                            },
                            new SmartHomeDeviceFloatProperty
                            {
                                Retrievable = true,
                                Reportable = true,
                                Parameters = new SmartHomeDeviceFloatPropertyParameters
                                {
                                    Instance = SmartHomeConstants.FloatFunction.BatteryLevel,
                                    Unit = SmartHomeConstants.Unit.Percent,
                                },
                            },
                            new SmartHomeDeviceFloatProperty
                            {
                                Retrievable = true,
                                Reportable = true,
                                Parameters = new SmartHomeDeviceFloatPropertyParameters
                                {
                                    Instance = SmartHomeConstants.FloatFunction.Co2Level,
                                    Unit = SmartHomeConstants.Unit.Ppm,
                                },
                            },
                            new SmartHomeDeviceFloatProperty
                            {
                                Retrievable = true,
                                Reportable = true,
                                Parameters = new SmartHomeDeviceFloatPropertyParameters
                                {
                                    Instance = SmartHomeConstants.FloatFunction.Humidity,
                                    Unit = SmartHomeConstants.Unit.Percent,
                                },
                            },
                            new SmartHomeDeviceFloatProperty
                            {
                                Retrievable = true,
                                Reportable = true,
                                Parameters = new SmartHomeDeviceFloatPropertyParameters
                                {
                                    Instance = SmartHomeConstants.FloatFunction.Illumination,
                                    Unit = SmartHomeConstants.Unit.Illumination.Lux,
                                },
                            },
                            new SmartHomeDeviceFloatProperty
                            {
                                Retrievable = true,
                                Reportable = true,
                                Parameters = new SmartHomeDeviceFloatPropertyParameters
                                {
                                    Instance = SmartHomeConstants.FloatFunction.Pm1Density,
                                    Unit = SmartHomeConstants.Unit.Density.McgM3,
                                },
                            },
                            new SmartHomeDeviceFloatProperty
                            {
                                Retrievable = true,
                                Reportable = true,
                                Parameters = new SmartHomeDeviceFloatPropertyParameters
                                {
                                    Instance = SmartHomeConstants.FloatFunction.Pm25Density,
                                    Unit = SmartHomeConstants.Unit.Density.McgM3,
                                },
                            },
                            new SmartHomeDeviceFloatProperty
                            {
                                Retrievable = true,
                                Reportable = true,
                                Parameters = new SmartHomeDeviceFloatPropertyParameters
                                {
                                    Instance = SmartHomeConstants.FloatFunction.Pm10Density,
                                    Unit = SmartHomeConstants.Unit.Density.McgM3,
                                },
                            },
                            new SmartHomeDeviceFloatProperty
                            {
                                Retrievable = true,
                                Reportable = true,
                                Parameters = new SmartHomeDeviceFloatPropertyParameters
                                {
                                    Instance = SmartHomeConstants.FloatFunction.Power,
                                    Unit = SmartHomeConstants.Unit.Watt,
                                },
                            },
                            new SmartHomeDeviceFloatProperty
                            {
                                Retrievable = true,
                                Reportable = true,
                                Parameters = new SmartHomeDeviceFloatPropertyParameters
                                {
                                    Instance = SmartHomeConstants.FloatFunction.Pressure,
                                    Unit = SmartHomeConstants.Unit.Pressure.Atm,
                                },
                            },
                            new SmartHomeDeviceFloatProperty
                            {
                                Retrievable = true,
                                Reportable = true,
                                Parameters = new SmartHomeDeviceFloatPropertyParameters
                                {
                                    Instance = SmartHomeConstants.FloatFunction.Temperature,
                                    Unit = SmartHomeConstants.Unit.Temperature.Celsius,
                                },
                            },
                            new SmartHomeDeviceFloatProperty
                            {
                                Retrievable = true,
                                Reportable = true,
                                Parameters = new SmartHomeDeviceFloatPropertyParameters
                                {
                                    Instance = SmartHomeConstants.FloatFunction.Tvoc,
                                    Unit = SmartHomeConstants.Unit.Density.McgM3,
                                },
                            },
                            new SmartHomeDeviceFloatProperty
                            {
                                Retrievable = true,
                                Reportable = true,
                                Parameters = new SmartHomeDeviceFloatPropertyParameters
                                {
                                    Instance = SmartHomeConstants.FloatFunction.Voltage,
                                    Unit = SmartHomeConstants.Unit.Volt,
                                },
                            },
                            new SmartHomeDeviceFloatProperty
                            {
                                Retrievable = true,
                                Reportable = true,
                                Parameters = new SmartHomeDeviceFloatPropertyParameters
                                {
                                    Instance = SmartHomeConstants.FloatFunction.WaterLevel,
                                    Unit = SmartHomeConstants.Unit.Percent,
                                },
                            },
                            new SmartHomeDeviceEventProperty
                            {
                                Retrievable = true,
                                Reportable = true,
                                Parameters = new SmartHomeDeviceEventPropertyParameters
                                {
                                    Instance = SmartHomeConstants.EventFunction.Vibration,
                                    Events = new List<SmartHomeEvent>
                                    {
                                        new (SmartHomeConstants.Events.Tilt),
                                        new (SmartHomeConstants.Events.Fall),
                                        new (SmartHomeConstants.Events.Vibration),
                                    },
                                },
                            },
                        },
                        DeviceInfo = new SmartHomeDeviceInfo
                        {
                            Manufacturer = "Test Manufacturer",
                            Model = "Test Model",
                            HwVersion = "1.0.0",
                            SwVersion = "2.0.0",
                        },
                    },
                    new ()
                    {
                        Id = "1235",
                        Name = @"Бракованная мультиварка",
                        Type = SmartHomeConstants.Devices.Types.CookingMulticooker,
                        Description = @"Мультиварка, которая умеет только показывать ошибки",
                        Room = @"Кухня",
                        CustomData = new Dictionary<string, string>(),
                        DeviceInfo = new SmartHomeDeviceInfo
                        {
                            HwVersion = "1.0.0",
                            Manufacturer = "Test",
                            Model = "Test",
                            SwVersion = "1.0.0",
                        },
                        Capabilities = new List<SmartHomeDeviceCapability>
                        {
                            new SmartHomeDeviceOnOffCapability
                            {
                                Retrievable = true,
                                Reportable = true,
                                Parameters = new SmartHomeDeviceOnOffCapabilityParameters
                                {
                                    Split = true,
                                },
                            },
                        },
                        Properties = new List<SmartHomeDeviceProperty>
                        {
                            new SmartHomeDeviceFloatProperty
                            {
                                Retrievable = true,
                                Reportable = true,
                                Parameters = new SmartHomeDeviceFloatPropertyParameters
                                {
                                    Instance = SmartHomeConstants.FloatFunction.WaterLevel,
                                    Unit = SmartHomeConstants.Unit.Percent,
                                },
                            },
                        },
                    },
                },
            },
        };
        return response;
    }

    public SmartHomeResponseDevicesQuery GetDevicesQueryResponse(SmartHomeRequestHeaders requestHeaders, SmartHomeRequestDevicesQuery payload)
    {
        var returnDevices = _devicesStates.Where(x => payload.Devices.Exists(d => d.Id == x.Id)).ToList();
        if (!returnDevices.Any())
        {
            throw new DeviceNotFoundException();
        }

        var response = new SmartHomeResponseDevicesQuery
        {
            RequestId = requestHeaders.RequestId,
            Payload = new SmartHomeResponseDevicesQueryPayload
            {
                Devices = returnDevices,
            },
        };
        return response;
    }

    public SmartHomeResponseDevicesAction ChangeDeviceState(SmartHomeRequestHeaders requestHeaders, SmartHomeRequestDevicesAction payload)
    {
        var devicesToChange = _devicesStates.Where(x => payload.Payload.Devices.Exists(d => d.Id == x.Id)).ToList();
        if (!devicesToChange.Any())
        {
            throw new DeviceNotFoundException();
        }

        var response = new SmartHomeResponseDevicesAction
        {
            RequestId = requestHeaders.RequestId,
            Payload = new SmartHomeResponseDevicesActionPayload
            {
                Devices = new List<SmartHomeResponseDevicesActionDevice>(),
            },
        };
        foreach (var deviceToChange in devicesToChange)
        {
            var requestedDevice = payload.Payload.Devices.First(x => x.Id == deviceToChange.Id);
            var responseDevice = new SmartHomeResponseDevicesActionDevice
            {
                Id = requestedDevice.Id,
                Capabilities = new List<SmartHomeResponseDevicesActionCapability>(),
            };
            foreach (var requestedCapability in requestedDevice.Capabilities)
            {
                var capabilityToChange = deviceToChange.Capabilities.Find(x => x.Type == requestedCapability.Type);
                if (capabilityToChange == null)
                {
                    continue;
                }

                var capabilityToChangeIndex = deviceToChange.Capabilities.IndexOf(capabilityToChange);
                deviceToChange.Capabilities[capabilityToChangeIndex] = requestedCapability;

                var instance = ((dynamic)requestedCapability).State.Instance.ToString(); // hacky way to get instance value

                responseDevice.Capabilities.Add(new SmartHomeResponseDevicesActionCapability
                {
                    Type = requestedCapability.Type,
                    State = new SmartHomeResponseDevicesActionCapabilityState
                    {
                        Instance = instance,
                        ActionResult = new SmartHomeActionResult
                        {
                            Status = SmartHomeConstants.ActionResult.Done,
                        },
                    },
                });
            }

            response.Payload.Devices.Add(responseDevice);
        }

        return response;
    }
}
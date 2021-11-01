namespace Yandex.Alice.Sdk.Demo.SmartHome.Services
{
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
            _devicesStates = new List<SmartHomeDeviceState>()
            {
                new SmartHomeDeviceState()
                {
                    Id = "1234",
                    Capabilities = new List<SmartHomeDeviceCapabilityState>()
                    {
                        new SmartHomeDeviceOnOffCapabilityState()
                        {
                            State = new SmartHomeDeviceOnOffCapabilityStateValue()
                            {
                                Instance = SmartHomeConstants.OnOffFunction.On,
                                Value = true,
                            },
                        },
                        new SmartHomeDeviceColorSettingCapabilityState()
                        {
                            State = new SmartHomeDeviceColorSettingCapabilityStateValue()
                            {
                                Instance = SmartHomeConstants.ColorSettingFunction.Scene,
                                Value = SmartHomeConstants.ColorSettingScene.Jungle,
                            },
                        },
                        new SmartHomeDeviceModeCapabilityState()
                        {
                            State = new SmartHomeDeviceModeCapabilityStateValue()
                            {
                                Instance = SmartHomeConstants.ModeFunction.CleanupMode,
                                Value = SmartHomeConstants.Mode.Quiet,
                            },
                        },
                        new SmartHomeDeviceModeCapabilityState()
                        {
                            State = new SmartHomeDeviceModeCapabilityStateValue()
                            {
                                Instance = SmartHomeConstants.ModeFunction.CoffeeMode,
                                Value = SmartHomeConstants.Mode.Cappuccino,
                            },
                        },
                        new SmartHomeDeviceModeCapabilityState()
                        {
                            State = new SmartHomeDeviceModeCapabilityStateValue()
                            {
                                Instance = SmartHomeConstants.ModeFunction.Dishwashing,
                                Value = SmartHomeConstants.Mode.Glass,
                            },
                        },
                        new SmartHomeDeviceModeCapabilityState()
                        {
                            State = new SmartHomeDeviceModeCapabilityStateValue()
                            {
                                Instance = SmartHomeConstants.ModeFunction.FanSpeed,
                                Value = SmartHomeConstants.Mode.Medium,
                            },
                        },
                        new SmartHomeDeviceModeCapabilityState()
                        {
                            State = new SmartHomeDeviceModeCapabilityStateValue()
                            {
                                Instance = SmartHomeConstants.ModeFunction.Heat,
                                Value = SmartHomeConstants.Mode.Min,
                            },
                        },
                        new SmartHomeDeviceModeCapabilityState()
                        {
                            State = new SmartHomeDeviceModeCapabilityStateValue()
                            {
                                Instance = SmartHomeConstants.ModeFunction.InputSource,
                                Value = SmartHomeConstants.Mode.Two,
                            },
                        },
                        new SmartHomeDeviceModeCapabilityState()
                        {
                            State = new SmartHomeDeviceModeCapabilityStateValue()
                            {
                                Instance = SmartHomeConstants.ModeFunction.Program,
                                Value = SmartHomeConstants.Mode.Cheesecake,
                            },
                        },
                        new SmartHomeDeviceModeCapabilityState()
                        {
                            State = new SmartHomeDeviceModeCapabilityStateValue()
                            {
                                Instance = SmartHomeConstants.ModeFunction.Swing,
                                Value = SmartHomeConstants.Mode.Horizontal,
                            },
                        },
                        new SmartHomeDeviceModeCapabilityState()
                        {
                            State = new SmartHomeDeviceModeCapabilityStateValue()
                            {
                                Instance = SmartHomeConstants.ModeFunction.TeaMode,
                                Value = SmartHomeConstants.Mode.OolongTea,
                            },
                        },
                        new SmartHomeDeviceModeCapabilityState()
                        {
                            State = new SmartHomeDeviceModeCapabilityStateValue()
                            {
                                Instance = SmartHomeConstants.ModeFunction.Thermostat,
                                Value = SmartHomeConstants.Mode.FanOnly,
                            },
                        },
                        new SmartHomeDeviceModeCapabilityState()
                        {
                            State = new SmartHomeDeviceModeCapabilityStateValue()
                            {
                                Instance = SmartHomeConstants.ModeFunction.WorkSpeed,
                                Value = SmartHomeConstants.Mode.Slow,
                            },
                        },
                        new SmartHomeDeviceRangeCapabilityState()
                        {
                            State = new SmartHomeDeviceRangeCapabilityStateValue()
                            {
                                Instance = SmartHomeConstants.RangeFunction.Brightness,
                                Value = 35,
                            },
                        },
                        new SmartHomeDeviceRangeCapabilityState()
                        {
                            State = new SmartHomeDeviceRangeCapabilityStateValue()
                            {
                                Instance = SmartHomeConstants.RangeFunction.Channel,
                                Value = 2,
                            },
                        },
                        new SmartHomeDeviceRangeCapabilityState()
                        {
                            State = new SmartHomeDeviceRangeCapabilityStateValue()
                            {
                                Instance = SmartHomeConstants.RangeFunction.Humidity,
                                Value = 45,
                            },
                        },
                        new SmartHomeDeviceRangeCapabilityState()
                        {
                            State = new SmartHomeDeviceRangeCapabilityStateValue()
                            {
                                Instance = SmartHomeConstants.RangeFunction.Open,
                                Value = 90,
                            },
                        },
                        new SmartHomeDeviceRangeCapabilityState()
                        {
                            State = new SmartHomeDeviceRangeCapabilityStateValue()
                            {
                                Instance = SmartHomeConstants.RangeFunction.Temperature,
                                Value = 24,
                            },
                        },
                        new SmartHomeDeviceRangeCapabilityState()
                        {
                            State = new SmartHomeDeviceRangeCapabilityStateValue()
                            {
                                Instance = SmartHomeConstants.RangeFunction.Volume,
                                Value = 67,
                            },
                        },
                        new SmartHomeDeviceToggleCapabilityState()
                        {
                            State = new SmartHomeDeviceToggleCapabilityStateValue()
                            {
                                Instance = SmartHomeConstants.ToggleFunction.Ionization,
                                Value = false,
                            },
                        },
                    },
                    Properties = new List<SmartHomeDevicePropertyState>()
                    {
                        new SmartHomeDeviceFloatPropertyState()
                        {
                            State = new SmartHomeDeviceFloatPropertyStateValue()
                            {
                                Instance = SmartHomeConstants.FloatFunction.Amperage,
                                Value = 15,
                            },
                        },
                        new SmartHomeDeviceFloatPropertyState()
                        {
                            State = new SmartHomeDeviceFloatPropertyStateValue()
                            {
                                Instance = SmartHomeConstants.FloatFunction.BatteryLevel,
                                Value = 97,
                            },
                        },
                        new SmartHomeDeviceFloatPropertyState()
                        {
                            State = new SmartHomeDeviceFloatPropertyStateValue()
                            {
                                Instance = SmartHomeConstants.FloatFunction.Co2Level,
                                Value = 13,
                            },
                        },
                        new SmartHomeDeviceFloatPropertyState()
                        {
                            State = new SmartHomeDeviceFloatPropertyStateValue()
                            {
                                Instance = SmartHomeConstants.FloatFunction.Humidity,
                                Value = 55,
                            },
                        },
                        new SmartHomeDeviceFloatPropertyState()
                        {
                            State = new SmartHomeDeviceFloatPropertyStateValue()
                            {
                                Instance = SmartHomeConstants.FloatFunction.Illumination,
                                Value = 8,
                            },
                        },
                        new SmartHomeDeviceFloatPropertyState()
                        {
                            State = new SmartHomeDeviceFloatPropertyStateValue()
                            {
                                Instance = SmartHomeConstants.FloatFunction.Pm1Density,
                                Value = 5,
                            },
                        },
                        new SmartHomeDeviceFloatPropertyState()
                        {
                            State = new SmartHomeDeviceFloatPropertyStateValue()
                            {
                                Instance = SmartHomeConstants.FloatFunction.Pm25Density,
                                Value = 6,
                            },
                        },
                        new SmartHomeDeviceFloatPropertyState()
                        {
                            State = new SmartHomeDeviceFloatPropertyStateValue()
                            {
                                Instance = SmartHomeConstants.FloatFunction.Pm10Density,
                                Value = 9,
                            },
                        },
                        new SmartHomeDeviceFloatPropertyState()
                        {
                            State = new SmartHomeDeviceFloatPropertyStateValue()
                            {
                                Instance = SmartHomeConstants.FloatFunction.Power,
                                Value = 25,
                            },
                        },
                        new SmartHomeDeviceFloatPropertyState()
                        {
                            State = new SmartHomeDeviceFloatPropertyStateValue()
                            {
                                Instance = SmartHomeConstants.FloatFunction.Pressure,
                                Value = 115,
                            },
                        },
                        new SmartHomeDeviceFloatPropertyState()
                        {
                            State = new SmartHomeDeviceFloatPropertyStateValue()
                            {
                                Instance = SmartHomeConstants.FloatFunction.Temperature,
                                Value = 21,
                            },
                        },
                        new SmartHomeDeviceFloatPropertyState()
                        {
                            State = new SmartHomeDeviceFloatPropertyStateValue()
                            {
                                Instance = SmartHomeConstants.FloatFunction.Tvoc,
                                Value = 1,
                            },
                        },
                        new SmartHomeDeviceFloatPropertyState()
                        {
                            State = new SmartHomeDeviceFloatPropertyStateValue()
                            {
                                Instance = SmartHomeConstants.FloatFunction.Voltage,
                                Value = 220,
                            },
                        },
                        new SmartHomeDeviceFloatPropertyState()
                        {
                            State = new SmartHomeDeviceFloatPropertyStateValue()
                            {
                                Instance = SmartHomeConstants.FloatFunction.WaterLevel,
                                Value = 90,
                            },
                        },
                        new SmartHomeDeviceEventPropertyState()
                        {
                            State = new SmartHomeDeviceEventPropertyStateValue()
                            {
                                Instance = SmartHomeConstants.EventFunction.BatteryLevel,
                                Value = SmartHomeConstants.Events.Low,
                            },
                        },
                    },
                },
                new SmartHomeDeviceState()
                {
                    Id = "1235",
                    Capabilities = new List<SmartHomeDeviceCapabilityState>()
                    {
                        new SmartHomeDeviceOnOffCapabilityState()
                        {
                            State = new SmartHomeDeviceOnOffCapabilityStateValue
                            {
                                Instance = SmartHomeConstants.OnOffFunction.On,
                                Value = true,
                            },
                        },
                    },
                    Properties = new List<SmartHomeDevicePropertyState>()
                    {
                        new SmartHomeDeviceFloatPropertyState()
                        {
                            State = new SmartHomeDeviceFloatPropertyStateValue()
                            {
                                Instance = SmartHomeConstants.FloatFunction.WaterLevel,
                                Value = 97,
                            },
                        },
                    },
                    ErrorCode = SmartHomeConstants.ErrorCodes.DeviceUnreachable,
                    ErrorMessage = "Устройство недоступно. Это кастомный текст",
                },
            };
        }

        public SmartHomeResponseDevices GetDevicesResponse(SmartHomeRequestHeaders requestHeaders)
        {
            var response = new SmartHomeResponseDevices
            {
                RequestId = requestHeaders.RequestId,
                Payload = new SmartHomeResponseDevicesPayload()
                {
                    UserId = _contextUserService.GetContextUserId(),
                    Devices = new List<SmartHomeDevice>()
                    {
                        new SmartHomeDevice()
                        {
                            Id = SmartHomeDemoConstants.LampDeviceId,
                            Name = "Фантомная лампочка",
                            Description = "Несуществующая лампочка. Делает много чего не умеют обычные лампочки. По крайней мере она так считает",
                            Room = "Спальня",
                            Type = SmartHomeConstants.Devices.Types.Light,
                            CustomData = new Dictionary<string, string>() { { "custom", "data" } },
                            Capabilities = new List<SmartHomeDeviceCapability>()
                            {
                                new SmartHomeDeviceOnOffCapability()
                                {
                                    Retrievable = true,
                                    Reportable = true,
                                    Parameters = new SmartHomeDeviceOnOffCapabilityParameters()
                                    {
                                        Split = true,
                                    },
                                },
                                new SmartHomeDeviceColorSettingCapability()
                                {
                                    Retrievable = true,
                                    Reportable = true,
                                    Parameters = new SmartHomeDeviceColorSettingCapabilityParameters()
                                    {
                                        ColorModel = SmartHomeConstants.ColorSettingFunction.Rgb,
                                        TemperatureK = new SmartHomeTemperatureK()
                                        {
                                            Min = 2000,
                                            Max = 9000,
                                        },
                                        ColorScene = new SmartHomeDeviceColorScene()
                                        {
                                            Scenes = new List<SmartHomeColorScene>()
                                            {
                                                new SmartHomeColorScene(SmartHomeConstants.ColorSettingScene.Alarm),
                                                new SmartHomeColorScene(SmartHomeConstants.ColorSettingScene.Alice),
                                                new SmartHomeColorScene(SmartHomeConstants.ColorSettingScene.Candle),
                                                new SmartHomeColorScene(SmartHomeConstants.ColorSettingScene.Dinner),
                                                new SmartHomeColorScene(SmartHomeConstants.ColorSettingScene.Fantasy),
                                                new SmartHomeColorScene(SmartHomeConstants.ColorSettingScene.Garland),
                                                new SmartHomeColorScene(SmartHomeConstants.ColorSettingScene.Jungle),
                                                new SmartHomeColorScene(SmartHomeConstants.ColorSettingScene.Movie),
                                                new SmartHomeColorScene(SmartHomeConstants.ColorSettingScene.Neon),
                                                new SmartHomeColorScene(SmartHomeConstants.ColorSettingScene.Night),
                                                new SmartHomeColorScene(SmartHomeConstants.ColorSettingScene.Ocean),
                                                new SmartHomeColorScene(SmartHomeConstants.ColorSettingScene.Party),
                                                new SmartHomeColorScene(SmartHomeConstants.ColorSettingScene.Reading),
                                                new SmartHomeColorScene(SmartHomeConstants.ColorSettingScene.Rest),
                                                new SmartHomeColorScene(SmartHomeConstants.ColorSettingScene.Romance),
                                                new SmartHomeColorScene(SmartHomeConstants.ColorSettingScene.Siren),
                                                new SmartHomeColorScene(SmartHomeConstants.ColorSettingScene.Sunrise),
                                                new SmartHomeColorScene(SmartHomeConstants.ColorSettingScene.Sunset),
                                            },
                                        },
                                    },
                                },
                                new SmartHomeDeviceModeCapability()
                                {
                                    Retrievable = true,
                                    Reportable = true,
                                    Parameters = new SmartHomeDeviceModeCapabilityParameters()
                                    {
                                        Instance = SmartHomeConstants.ModeFunction.CleanupMode,
                                        Modes = new List<SmartHomeDeviceMode>()
                                        {
                                            new SmartHomeDeviceMode(SmartHomeConstants.Mode.Auto),
                                            new SmartHomeDeviceMode(SmartHomeConstants.Mode.Eco),
                                            new SmartHomeDeviceMode(SmartHomeConstants.Mode.Turbo),
                                            new SmartHomeDeviceMode(SmartHomeConstants.Mode.Quiet),
                                        },
                                    },
                                },
                                new SmartHomeDeviceModeCapability()
                                {
                                    Retrievable = true,
                                    Reportable = true,
                                    Parameters = new SmartHomeDeviceModeCapabilityParameters()
                                    {
                                        Instance = SmartHomeConstants.ModeFunction.CoffeeMode,
                                        Modes = new List<SmartHomeDeviceMode>()
                                        {
                                            new SmartHomeDeviceMode(SmartHomeConstants.Mode.Americano),
                                            new SmartHomeDeviceMode(SmartHomeConstants.Mode.Cappuccino),
                                            new SmartHomeDeviceMode(SmartHomeConstants.Mode.Espresso),
                                            new SmartHomeDeviceMode(SmartHomeConstants.Mode.DoubleEspresso),
                                            new SmartHomeDeviceMode(SmartHomeConstants.Mode.Latte),
                                        },
                                    },
                                },
                                new SmartHomeDeviceModeCapability()
                                {
                                    Retrievable = true,
                                    Reportable = true,
                                    Parameters = new SmartHomeDeviceModeCapabilityParameters()
                                    {
                                        Instance = SmartHomeConstants.ModeFunction.Dishwashing,
                                        Modes = new List<SmartHomeDeviceMode>()
                                        {
                                            new SmartHomeDeviceMode(SmartHomeConstants.Mode.Auto),
                                            new SmartHomeDeviceMode(SmartHomeConstants.Mode.Normal),
                                            new SmartHomeDeviceMode(SmartHomeConstants.Mode.Intensive),
                                            new SmartHomeDeviceMode(SmartHomeConstants.Mode.Glass),
                                            new SmartHomeDeviceMode(SmartHomeConstants.Mode.Express),
                                            new SmartHomeDeviceMode(SmartHomeConstants.Mode.PreRinse),
                                        },
                                    },
                                },
                                new SmartHomeDeviceModeCapability()
                                {
                                    Retrievable = true,
                                    Reportable = true,
                                    Parameters = new SmartHomeDeviceModeCapabilityParameters()
                                    {
                                        Instance = SmartHomeConstants.ModeFunction.FanSpeed,
                                        Modes = new List<SmartHomeDeviceMode>()
                                        {
                                            new SmartHomeDeviceMode(SmartHomeConstants.Mode.High),
                                            new SmartHomeDeviceMode(SmartHomeConstants.Mode.Medium),
                                            new SmartHomeDeviceMode(SmartHomeConstants.Mode.Low),
                                        },
                                    },
                                },
                                new SmartHomeDeviceModeCapability()
                                {
                                    Retrievable = true,
                                    Reportable = true,
                                    Parameters = new SmartHomeDeviceModeCapabilityParameters()
                                    {
                                        Instance = SmartHomeConstants.ModeFunction.Heat,
                                        Modes = new List<SmartHomeDeviceMode>()
                                        {
                                            new SmartHomeDeviceMode(SmartHomeConstants.Mode.Auto),
                                            new SmartHomeDeviceMode(SmartHomeConstants.Mode.Min),
                                            new SmartHomeDeviceMode(SmartHomeConstants.Mode.Max),
                                        },
                                    },
                                },
                                new SmartHomeDeviceModeCapability()
                                {
                                    Retrievable = true,
                                    Reportable = true,
                                    Parameters = new SmartHomeDeviceModeCapabilityParameters()
                                    {
                                        Instance = SmartHomeConstants.ModeFunction.InputSource,
                                        Modes = new List<SmartHomeDeviceMode>()
                                        {
                                            new SmartHomeDeviceMode(SmartHomeConstants.Mode.One),
                                            new SmartHomeDeviceMode(SmartHomeConstants.Mode.Two),
                                            new SmartHomeDeviceMode(SmartHomeConstants.Mode.Three),
                                            new SmartHomeDeviceMode(SmartHomeConstants.Mode.Four),
                                            new SmartHomeDeviceMode(SmartHomeConstants.Mode.Five),
                                            new SmartHomeDeviceMode(SmartHomeConstants.Mode.Six),
                                            new SmartHomeDeviceMode(SmartHomeConstants.Mode.Seven),
                                            new SmartHomeDeviceMode(SmartHomeConstants.Mode.Eight),
                                            new SmartHomeDeviceMode(SmartHomeConstants.Mode.Nine),
                                            new SmartHomeDeviceMode(SmartHomeConstants.Mode.Ten),
                                        },
                                    },
                                },
                                new SmartHomeDeviceModeCapability()
                                {
                                    Retrievable = true,
                                    Reportable = true,
                                    Parameters = new SmartHomeDeviceModeCapabilityParameters()
                                    {
                                        Instance = SmartHomeConstants.ModeFunction.Program,
                                        Modes = new List<SmartHomeDeviceMode>()
                                        {
                                            new SmartHomeDeviceMode(SmartHomeConstants.Mode.Aspic),
                                            new SmartHomeDeviceMode(SmartHomeConstants.Mode.BabyFood),
                                            new SmartHomeDeviceMode(SmartHomeConstants.Mode.Bread),
                                            new SmartHomeDeviceMode(SmartHomeConstants.Mode.Boiling),
                                            new SmartHomeDeviceMode(SmartHomeConstants.Mode.Cereals),
                                            new SmartHomeDeviceMode(SmartHomeConstants.Mode.Cheesecake),
                                            new SmartHomeDeviceMode(SmartHomeConstants.Mode.DeepFryer),
                                            new SmartHomeDeviceMode(SmartHomeConstants.Mode.Dessert),
                                            new SmartHomeDeviceMode(SmartHomeConstants.Mode.Fowl),
                                            new SmartHomeDeviceMode(SmartHomeConstants.Mode.Frying),
                                            new SmartHomeDeviceMode(SmartHomeConstants.Mode.Macaroni),
                                            new SmartHomeDeviceMode(SmartHomeConstants.Mode.MilkPorridge),
                                            new SmartHomeDeviceMode(SmartHomeConstants.Mode.Multicooker),
                                            new SmartHomeDeviceMode(SmartHomeConstants.Mode.Pasta),
                                            new SmartHomeDeviceMode(SmartHomeConstants.Mode.Pilaf),
                                            new SmartHomeDeviceMode(SmartHomeConstants.Mode.Pizza),
                                            new SmartHomeDeviceMode(SmartHomeConstants.Mode.Sauce),
                                            new SmartHomeDeviceMode(SmartHomeConstants.Mode.SlowCook),
                                            new SmartHomeDeviceMode(SmartHomeConstants.Mode.Soup),
                                            new SmartHomeDeviceMode(SmartHomeConstants.Mode.Steam),
                                            new SmartHomeDeviceMode(SmartHomeConstants.Mode.Stewing),
                                            new SmartHomeDeviceMode(SmartHomeConstants.Mode.Vacuum),
                                            new SmartHomeDeviceMode(SmartHomeConstants.Mode.Yogurt),
                                        },
                                    },
                                },
                                new SmartHomeDeviceModeCapability()
                                {
                                    Retrievable = true,
                                    Reportable = true,
                                    Parameters = new SmartHomeDeviceModeCapabilityParameters()
                                    {
                                        Instance = SmartHomeConstants.ModeFunction.Swing,
                                        Modes = new List<SmartHomeDeviceMode>()
                                        {
                                            new SmartHomeDeviceMode(SmartHomeConstants.Mode.Vertical),
                                            new SmartHomeDeviceMode(SmartHomeConstants.Mode.Horizontal),
                                            new SmartHomeDeviceMode(SmartHomeConstants.Mode.Stationary),
                                        },
                                    },
                                },
                                new SmartHomeDeviceModeCapability()
                                {
                                    Retrievable = true,
                                    Reportable = true,
                                    Parameters = new SmartHomeDeviceModeCapabilityParameters()
                                    {
                                        Instance = SmartHomeConstants.ModeFunction.TeaMode,
                                        Modes = new List<SmartHomeDeviceMode>()
                                        {
                                            new SmartHomeDeviceMode(SmartHomeConstants.Mode.BlackTea),
                                            new SmartHomeDeviceMode(SmartHomeConstants.Mode.GreenTea),
                                            new SmartHomeDeviceMode(SmartHomeConstants.Mode.FlowerTea),
                                            new SmartHomeDeviceMode(SmartHomeConstants.Mode.HerbalTea),
                                            new SmartHomeDeviceMode(SmartHomeConstants.Mode.OolongTea),
                                            new SmartHomeDeviceMode(SmartHomeConstants.Mode.PuerhTea),
                                            new SmartHomeDeviceMode(SmartHomeConstants.Mode.RedTea),
                                            new SmartHomeDeviceMode(SmartHomeConstants.Mode.WhiteTea),
                                        },
                                    },
                                },
                                new SmartHomeDeviceModeCapability()
                                {
                                    Retrievable = true,
                                    Reportable = true,
                                    Parameters = new SmartHomeDeviceModeCapabilityParameters()
                                    {
                                        Instance = SmartHomeConstants.ModeFunction.Thermostat,
                                        Modes = new List<SmartHomeDeviceMode>()
                                        {
                                            new SmartHomeDeviceMode(SmartHomeConstants.Mode.Cool),
                                            new SmartHomeDeviceMode(SmartHomeConstants.Mode.Dry),
                                            new SmartHomeDeviceMode(SmartHomeConstants.Mode.FanOnly),
                                            new SmartHomeDeviceMode(SmartHomeConstants.Mode.Heat),
                                            new SmartHomeDeviceMode(SmartHomeConstants.Mode.Preheat),
                                        },
                                    },
                                },
                                new SmartHomeDeviceModeCapability()
                                {
                                    Retrievable = true,
                                    Reportable = true,
                                    Parameters = new SmartHomeDeviceModeCapabilityParameters()
                                    {
                                        Instance = SmartHomeConstants.ModeFunction.WorkSpeed,
                                        Modes = new List<SmartHomeDeviceMode>()
                                        {
                                            new SmartHomeDeviceMode(SmartHomeConstants.Mode.Fast),
                                            new SmartHomeDeviceMode(SmartHomeConstants.Mode.Slow),
                                        },
                                    },
                                },
                                new SmartHomeDeviceRangeCapability()
                                {
                                    Retrievable = true,
                                    Reportable = true,
                                    Parameters = new SmartHomeDeviceRangeCapabilityParameters()
                                    {
                                        Instance = SmartHomeConstants.RangeFunction.Brightness,
                                        Unit = SmartHomeConstants.Unit.Percent,
                                        RandomAccess = true,
                                        Range = new SmartHomeRange()
                                        {
                                            Min = 0,
                                            Max = 100,
                                            Precision = 1,
                                        },
                                    },
                                },
                                new SmartHomeDeviceRangeCapability()
                                {
                                    Retrievable = true,
                                    Reportable = true,
                                    Parameters = new SmartHomeDeviceRangeCapabilityParameters()
                                    {
                                        Instance = SmartHomeConstants.RangeFunction.Channel,
                                        RandomAccess = true,
                                        Range = new SmartHomeRange()
                                        {
                                            Min = 1,
                                            Max = 50,
                                            Precision = 1,
                                        },
                                    },
                                },
                                new SmartHomeDeviceRangeCapability()
                                {
                                    Retrievable = true,
                                    Reportable = true,
                                    Parameters = new SmartHomeDeviceRangeCapabilityParameters()
                                    {
                                        Instance = SmartHomeConstants.RangeFunction.Humidity,
                                        Unit = SmartHomeConstants.Unit.Percent,
                                        RandomAccess = true,
                                        Range = new SmartHomeRange()
                                        {
                                            Min = 0,
                                            Max = 100,
                                            Precision = 1,
                                        },
                                    },
                                },
                                new SmartHomeDeviceRangeCapability()
                                {
                                    Retrievable = true,
                                    Reportable = true,
                                    Parameters = new SmartHomeDeviceRangeCapabilityParameters()
                                    {
                                        Instance = SmartHomeConstants.RangeFunction.Open,
                                        Unit = SmartHomeConstants.Unit.Percent,
                                        RandomAccess = true,
                                        Range = new SmartHomeRange()
                                        {
                                            Min = 0,
                                            Max = 100,
                                            Precision = 1,
                                        },
                                    },
                                },
                                new SmartHomeDeviceRangeCapability()
                                {
                                    Retrievable = true,
                                    Reportable = true,
                                    Parameters = new SmartHomeDeviceRangeCapabilityParameters()
                                    {
                                        Instance = SmartHomeConstants.RangeFunction.Temperature,
                                        Unit = SmartHomeConstants.Unit.Temperature.Celsius,
                                        RandomAccess = true,
                                        Range = new SmartHomeRange()
                                        {
                                            Min = 18,
                                            Max = 40,
                                            Precision = 1,
                                        },
                                    },
                                },
                                new SmartHomeDeviceRangeCapability()
                                {
                                    Retrievable = true,
                                    Reportable = true,
                                    Parameters = new SmartHomeDeviceRangeCapabilityParameters()
                                    {
                                        Instance = SmartHomeConstants.RangeFunction.Volume,
                                        Unit = SmartHomeConstants.Unit.Percent,
                                        RandomAccess = true,
                                        Range = new SmartHomeRange()
                                        {
                                            Min = 0,
                                            Max = 100,
                                            Precision = 10,
                                        },
                                    },
                                },
                                new SmartHomeDeviceToggleCapability()
                                {
                                    Retrievable = true,
                                    Reportable = true,
                                    Parameters = new SmartHomeDeviceToggleCapabilityParameters()
                                    {
                                        Instance = SmartHomeConstants.ToggleFunction.Backlight,
                                    },
                                },
                                new SmartHomeDeviceToggleCapability()
                                {
                                    Retrievable = true,
                                    Reportable = true,
                                    Parameters = new SmartHomeDeviceToggleCapabilityParameters()
                                    {
                                        Instance = SmartHomeConstants.ToggleFunction.ControlsLocked,
                                    },
                                },
                                new SmartHomeDeviceToggleCapability()
                                {
                                    Retrievable = true,
                                    Reportable = true,
                                    Parameters = new SmartHomeDeviceToggleCapabilityParameters()
                                    {
                                        Instance = SmartHomeConstants.ToggleFunction.Ionization,
                                    },
                                },
                                new SmartHomeDeviceToggleCapability()
                                {
                                    Retrievable = true,
                                    Reportable = true,
                                    Parameters = new SmartHomeDeviceToggleCapabilityParameters()
                                    {
                                        Instance = SmartHomeConstants.ToggleFunction.KeepWarm,
                                    },
                                },
                                new SmartHomeDeviceToggleCapability()
                                {
                                    Retrievable = true,
                                    Reportable = true,
                                    Parameters = new SmartHomeDeviceToggleCapabilityParameters()
                                    {
                                        Instance = SmartHomeConstants.ToggleFunction.Mute,
                                    },
                                },
                                new SmartHomeDeviceToggleCapability()
                                {
                                    Retrievable = true,
                                    Reportable = true,
                                    Parameters = new SmartHomeDeviceToggleCapabilityParameters()
                                    {
                                        Instance = SmartHomeConstants.ToggleFunction.Oscillation,
                                    },
                                },
                                new SmartHomeDeviceToggleCapability()
                                {
                                    Retrievable = true,
                                    Reportable = true,
                                    Parameters = new SmartHomeDeviceToggleCapabilityParameters()
                                    {
                                        Instance = SmartHomeConstants.ToggleFunction.Pause,
                                    },
                                },
                            },
                            Properties = new List<SmartHomeDeviceProperty>()
                            {
                                new SmartHomeDeviceFloatProperty()
                                {
                                    Retrievable = true,
                                    Reportable = true,
                                    Parameters = new SmartHomeDeviceFloatPropertyParameters()
                                    {
                                        Instance = SmartHomeConstants.FloatFunction.Amperage,
                                        Unit = SmartHomeConstants.Unit.Ampere,
                                    },
                                },
                                new SmartHomeDeviceFloatProperty()
                                {
                                    Retrievable = true,
                                    Reportable = true,
                                    Parameters = new SmartHomeDeviceFloatPropertyParameters()
                                    {
                                        Instance = SmartHomeConstants.FloatFunction.BatteryLevel,
                                        Unit = SmartHomeConstants.Unit.Percent,
                                    },
                                },
                                new SmartHomeDeviceFloatProperty()
                                {
                                    Retrievable = true,
                                    Reportable = true,
                                    Parameters = new SmartHomeDeviceFloatPropertyParameters()
                                    {
                                        Instance = SmartHomeConstants.FloatFunction.Co2Level,
                                        Unit = SmartHomeConstants.Unit.Ppm,
                                    },
                                },
                                new SmartHomeDeviceFloatProperty()
                                {
                                    Retrievable = true,
                                    Reportable = true,
                                    Parameters = new SmartHomeDeviceFloatPropertyParameters()
                                    {
                                        Instance = SmartHomeConstants.FloatFunction.Humidity,
                                        Unit = SmartHomeConstants.Unit.Percent,
                                    },
                                },
                                new SmartHomeDeviceFloatProperty()
                                {
                                    Retrievable = true,
                                    Reportable = true,
                                    Parameters = new SmartHomeDeviceFloatPropertyParameters()
                                    {
                                        Instance = SmartHomeConstants.FloatFunction.Illumination,
                                        Unit = SmartHomeConstants.Unit.Illumination.Lux,
                                    },
                                },
                                new SmartHomeDeviceFloatProperty()
                                {
                                    Retrievable = true,
                                    Reportable = true,
                                    Parameters = new SmartHomeDeviceFloatPropertyParameters()
                                    {
                                        Instance = SmartHomeConstants.FloatFunction.Pm1Density,
                                        Unit = SmartHomeConstants.Unit.Density.McgM3,
                                    },
                                },
                                new SmartHomeDeviceFloatProperty()
                                {
                                    Retrievable = true,
                                    Reportable = true,
                                    Parameters = new SmartHomeDeviceFloatPropertyParameters()
                                    {
                                        Instance = SmartHomeConstants.FloatFunction.Pm25Density,
                                        Unit = SmartHomeConstants.Unit.Density.McgM3,
                                    },
                                },
                                new SmartHomeDeviceFloatProperty()
                                {
                                    Retrievable = true,
                                    Reportable = true,
                                    Parameters = new SmartHomeDeviceFloatPropertyParameters()
                                    {
                                        Instance = SmartHomeConstants.FloatFunction.Pm10Density,
                                        Unit = SmartHomeConstants.Unit.Density.McgM3,
                                    },
                                },
                                new SmartHomeDeviceFloatProperty()
                                {
                                    Retrievable = true,
                                    Reportable = true,
                                    Parameters = new SmartHomeDeviceFloatPropertyParameters()
                                    {
                                        Instance = SmartHomeConstants.FloatFunction.Power,
                                        Unit = SmartHomeConstants.Unit.Watt,
                                    },
                                },
                                new SmartHomeDeviceFloatProperty()
                                {
                                    Retrievable = true,
                                    Reportable = true,
                                    Parameters = new SmartHomeDeviceFloatPropertyParameters()
                                    {
                                        Instance = SmartHomeConstants.FloatFunction.Pressure,
                                        Unit = SmartHomeConstants.Unit.Pressure.Atm,
                                    },
                                },
                                new SmartHomeDeviceFloatProperty()
                                {
                                    Retrievable = true,
                                    Reportable = true,
                                    Parameters = new SmartHomeDeviceFloatPropertyParameters()
                                    {
                                        Instance = SmartHomeConstants.FloatFunction.Temperature,
                                        Unit = SmartHomeConstants.Unit.Temperature.Celsius,
                                    },
                                },
                                new SmartHomeDeviceFloatProperty()
                                {
                                    Retrievable = true,
                                    Reportable = true,
                                    Parameters = new SmartHomeDeviceFloatPropertyParameters()
                                    {
                                        Instance = SmartHomeConstants.FloatFunction.Tvoc,
                                        Unit = SmartHomeConstants.Unit.Density.McgM3,
                                    },
                                },
                                new SmartHomeDeviceFloatProperty()
                                {
                                    Retrievable = true,
                                    Reportable = true,
                                    Parameters = new SmartHomeDeviceFloatPropertyParameters()
                                    {
                                        Instance = SmartHomeConstants.FloatFunction.Voltage,
                                        Unit = SmartHomeConstants.Unit.Volt,
                                    },
                                },
                                new SmartHomeDeviceFloatProperty()
                                {
                                    Retrievable = true,
                                    Reportable = true,
                                    Parameters = new SmartHomeDeviceFloatPropertyParameters()
                                    {
                                        Instance = SmartHomeConstants.FloatFunction.WaterLevel,
                                        Unit = SmartHomeConstants.Unit.Percent,
                                    },
                                },
                                new SmartHomeDeviceEventProperty()
                                {
                                    Retrievable = true,
                                    Reportable = true,
                                    Parameters = new SmartHomeDeviceEventPropertyParameters()
                                    {
                                        Instance = SmartHomeConstants.EventFunction.Vibration,
                                        Events = new List<SmartHomeEvent>()
                                        {
                                            new SmartHomeEvent(SmartHomeConstants.Events.Tilt),
                                            new SmartHomeEvent(SmartHomeConstants.Events.Fall),
                                            new SmartHomeEvent(SmartHomeConstants.Events.Vibration),
                                        },
                                    },
                                },
                            },
                            DeviceInfo = new SmartHomeDeviceInfo()
                            {
                                Manufacturer = "Test Manufacturer",
                                Model = "Test Model",
                                HwVersion = "1.0.0",
                                SwVersion = "2.0.0",
                            },
                        },
                        new SmartHomeDevice()
                        {
                            Id = "1235",
                            Name = "Бракованная мультиварка",
                            Type = SmartHomeConstants.Devices.Types.CookingMulticooker,
                            Description = "Мультиварка, которая умеет только показывать ошибки",
                            Room = "Кухня",
                            CustomData = new Dictionary<string, string>(),
                            DeviceInfo = new SmartHomeDeviceInfo()
                            {
                                HwVersion = "1.0.0",
                                Manufacturer = "Test",
                                Model = "Test",
                                SwVersion = "1.0.0",
                            },
                            Capabilities = new List<SmartHomeDeviceCapability>()
                            {
                                new SmartHomeDeviceOnOffCapability()
                                {
                                    Retrievable = true,
                                    Reportable = true,
                                    Parameters = new SmartHomeDeviceOnOffCapabilityParameters()
                                    {
                                        Split = true,
                                    },
                                },
                            },
                            Properties = new List<SmartHomeDeviceProperty>()
                            {
                                new SmartHomeDeviceFloatProperty()
                                {
                                    Retrievable = true,
                                    Reportable = true,
                                    Parameters = new SmartHomeDeviceFloatPropertyParameters()
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
            var returnDevices = _devicesStates.Where(x => payload.Devices.Any(d => d.Id == x.Id)).ToList();
            if (!returnDevices.Any())
            {
                throw new DeviceNotFoundException();
            }

            var response = new SmartHomeResponseDevicesQuery()
            {
                RequestId = requestHeaders.RequestId,
                Payload = new SmartHomeResponseDevicesQueryPayload()
                {
                    Devices = returnDevices,
                },
            };
            return response;
        }

        public SmartHomeResponseDevicesAction ChangeDeviceState(SmartHomeRequestHeaders requestHeaders, SmartHomeRequestDevicesAction payload)
        {
            var devicesToChange = _devicesStates.Where(x => payload.Payload.Devices.Any(d => d.Id == x.Id)).ToList();
            if (!devicesToChange.Any())
            {
                throw new DeviceNotFoundException();
            }

            var response = new SmartHomeResponseDevicesAction
            {
                RequestId = requestHeaders.RequestId,
                Payload = new SmartHomeResponseDevicesActionPayload()
                {
                    Devices = new List<SmartHomeResponseDevicesActionDevice>(),
                },
            };
            foreach (var deviceToChange in devicesToChange)
            {
                var requestedDevice = payload.Payload.Devices.FirstOrDefault(x => x.Id == deviceToChange.Id);
                var responseDevice = new SmartHomeResponseDevicesActionDevice
                {
                    Id = requestedDevice.Id,
                    Capabilities = new List<SmartHomeResponseDevicesActionCapability>(),
                };
                foreach (var requestedCapability in requestedDevice.Capabilities)
                {
                    var capabilityToChange = deviceToChange.Capabilities.FirstOrDefault(x => x.Type == requestedCapability.Type);
                    if (capabilityToChange != null)
                    {
                        var capabilityToChangeIndex = deviceToChange.Capabilities.IndexOf(capabilityToChange);
                        deviceToChange.Capabilities[capabilityToChangeIndex] = requestedCapability;

                        var instance = ((dynamic)requestedCapability).State.Instance.ToString(); // hacky way to get instance value

                        responseDevice.Capabilities.Add(new SmartHomeResponseDevicesActionCapability()
                        {
                            Type = requestedCapability.Type,
                            State = new SmartHomeResponseDevicesActionCapabilityState()
                            {
                                Instance = instance,
                                ActionResult = new SmartHomeActionResult()
                                {
                                    Status = SmartHomeConstants.ActionResult.Done,
                                },
                            },
                        });
                    }
                }

                response.Payload.Devices.Add(responseDevice);
            }

            return response;
        }
    }
}

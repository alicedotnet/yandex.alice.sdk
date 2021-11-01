namespace Yandex.Alice.Sdk
{
    public static class SmartHomeConstants
    {
        public static class Devices
        {
            public static class Capabilities
            {
                public const string OnOff = "devices.capabilities.on_off";
                public const string ColorSetting = "devices.capabilities.color_setting";
                public const string Mode = "devices.capabilities.mode";
                public const string Range = "devices.capabilities.range";
                public const string Toggle = "devices.capabilities.toggle";
            }

            public static class Properties
            {
                public const string Float = "devices.properties.float";
                public const string Event = "devices.properties.event";
            }

            public static class Types
            {
                public const string Light = "devices.types.light";
                public const string Socket = "devices.types.socket";
                public const string Switch = "devices.types.switch";
                public const string Thermostat = "devices.types.thermostat";
                public const string ThermostatAc = "devices.types.thermostat.ac";
                public const string MediaDevice = "devices.types.media_device";
                public const string MediaDeviceTv = "devices.types.media_device.tv";
                public const string MediaDeviceTvBox = "devices.types.media_device.tv_box";
                public const string MediaDeviceReceiver = "devices.types.media_device.receiver";
                public const string Cooking = "devices.types.cooking";
                public const string CookingCoffeeMaker = "devices.types.cooking.coffee_maker";
                public const string CookingKettle = "devices.types.cooking.kettle";
                public const string CookingMulticooker = "devices.types.cooking.multicooker";
                public const string Openable = "devices.types.openable";
                public const string OpenableCurtain = "devices.types.openable.curtain";
                public const string Humidifier = "devices.types.humidifier";
                public const string Purifier = "devices.types.purifier";
                public const string VacuumCleaner = "devices.types.vacuum_cleaner";
                public const string WashingMachine = "devices.types.washing_machine";
                public const string Dishwasher = "devices.types.dishwasher";
                public const string Iron = "devices.types.iron";
                public const string Sensor = "devices.types.sensor";
                public const string Other = "devices.types.other";
            }
        }

        public static class ColorSettingFunction
        {
            public const string Hsv = "hsv";
            public const string Rgb = "rgb";
            public const string TemperatureK = "temperature_k";
            public const string Scene = "scene";
        }

        public static class ColorSettingScene
        {
            public const string Alarm = "alarm";
            public const string Alice = "alice";
            public const string Candle = "candle";
            public const string Dinner = "dinner";
            public const string Fantasy = "fantasy";
            public const string Garland = "garland";
            public const string Jungle = "jungle";
            public const string Movie = "movie";
            public const string Neon = "neon";
            public const string Night = "night";
            public const string Ocean = "ocean";
            public const string Party = "party";
            public const string Reading = "reading";
            public const string Rest = "rest";
            public const string Romance = "romance";
            public const string Siren = "siren";
            public const string Sunrise = "sunrise";
            public const string Sunset = "sunset";
        }

        public static class OnOffFunction
        {
            public const string On = "on";
        }

        public static class ModeFunction
        {
            public const string CleanupMode = "cleanup_mode";
            public const string CoffeeMode = "coffee_mode";
            public const string Dishwashing = "dishwashing";
            public const string FanSpeed = "fan_speed";
            public const string Heat = "heat";
            public const string InputSource = "input_source";
            public const string Program = "program";
            public const string Swing = "swing";
            public const string TeaMode = "tea_mode";
            public const string Thermostat = "thermostat";
            public const string WorkSpeed = "work_speed";
        }

        public static class Mode
        {
            public const string Auto = "auto";
            public const string Eco = "eco";
            public const string Turbo = "turbo";

            public const string Cool = "cool";
            public const string Dry = "dry";
            public const string FanOnly = "fan_only";
            public const string Heat = "heat";
            public const string Preheat = "preheat";

            public const string High = "high";
            public const string Low = "low";
            public const string Medium = "medium";

            public const string Max = "max";
            public const string Min = "min";

            public const string Fast = "fast";
            public const string Slow = "slow";

            public const string Express = "express";
            public const string Normal = "normal";
            public const string Quiet = "quiet";

            public const string Horizontal = "horizontal";
            public const string Stationary = "stationary";
            public const string Vertical = "vertical";

            public const string One = "one";
            public const string Two = "two";
            public const string Three = "three";
            public const string Four = "four";
            public const string Five = "five";
            public const string Six = "six";
            public const string Seven = "seven";
            public const string Eight = "eight";
            public const string Nine = "nine";
            public const string Ten = "ten";

            public const string Americano = "americano";
            public const string Cappuccino = "cappuccino";
            public const string DoubleEspresso = "double_espresso";
            public const string Espresso = "espresso";
            public const string Latte = "latte";

            public const string BlackTea = "black_tea";
            public const string FlowerTea = "flower_tea";
            public const string GreenTea = "green_tea";
            public const string HerbalTea = "herbal_tea";
            public const string OolongTea = "oolong_tea";
            public const string PuerhTea = "puerh_tea";
            public const string RedTea = "red_tea";
            public const string WhiteTea = "white_tea";

            public const string Glass = "glass";
            public const string Intensive = "intensive";
            public const string PreRinse = "pre_rinse";

            public const string Aspic = "aspic";
            public const string BabyFood = "baby_food";
            public const string Baking = "baking";
            public const string Bread = "bread";
            public const string Boiling = "boiling";
            public const string Cereals = "cereals";
            public const string Cheesecake = "cheesecake";
            public const string DeepFryer = "deep_fryer";
            public const string Dessert = "dessert";
            public const string Fowl = "fowl";
            public const string Frying = "frying";
            public const string Macaroni = "macaroni";
            public const string MilkPorridge = "milk_porridge";
            public const string Multicooker = "multicooker";
            public const string Pasta = "pasta";
            public const string Pilaf = "pilaf";
            public const string Pizza = "pizza";
            public const string Sauce = "sauce";
            public const string SlowCook = "slow_cook";
            public const string Soup = "soup";
            public const string Steam = "steam";
            public const string Stewing = "stewing";
            public const string Vacuum = "vacuum";
            public const string Yogurt = "yogurt";
        }

        public static class RangeFunction
        {
            public const string Brightness = "brightness";
            public const string Channel = "channel";
            public const string Humidity = "humidity";
            public const string Open = "open";
            public const string Temperature = "temperature";
            public const string Volume = "volume";
        }

        public static class Unit
        {
            public const string Percent = "unit.percent";
            public const string Ampere = "unit.ampere";
            public const string Ppm = "unit.ppm";
            public const string Watt = "unit.watt";
            public const string Volt = "unit.volt";

            public static class Illumination
            {
                public const string Lux = "unit.illumination.lux";
            }

            public static class Density
            {
                public const string McgM3 = "unit.density.mcg_m3";
            }

            public static class Temperature
            {
                public const string Celsius = "unit.temperature.celsius";
                public const string Kelvin = "unit.temperature.kelvin";
            }

            public static class Pressure
            {
                public const string Atm = "unit.pressure.atm";
                public const string Pascal = "unit.pressure.pascal";
                public const string Bar = "unit.pressure.bar";
                public const string Mmhg = "unit.pressure.mmhg";
            }
        }

        public static class ToggleFunction
        {
            public const string Backlight = "backlight";
            public const string ControlsLocked = "controls_locked";
            public const string Ionization = "ionization";
            public const string KeepWarm = "keep_warm";
            public const string Mute = "mute";
            public const string Oscillation = "oscillation";
            public const string Pause = "pause";
        }

        public static class FloatFunction
        {
            public const string Amperage = "amperage";
            public const string BatteryLevel = "battery_level";
            public const string Co2Level = "co2_level";
            public const string Humidity = "humidity";
            public const string Illumination = "illumination";
            public const string Pm1Density = "pm1_density";
            public const string Pm25Density = "pm2.5_density";
            public const string Pm10Density = "pm10_density";
            public const string Power = "power";
            public const string Pressure = "pressure";
            public const string Temperature = "temperature";
            public const string Tvoc = "tvoc";
            public const string Voltage = "voltage";
            public const string WaterLevel = "water_level";
        }

        public static class EventFunction
        {
            public const string Vibration = "vibration";
            public const string Open = "open";
            public const string Button = "button";
            public const string Motion = "motion";
            public const string Smoke = "smoke";
            public const string Gas = "gas";
            public const string BatteryLevel = "battery_level";
            public const string WaterLevel = "water_level";
            public const string WaterLeak = "water_leak";
        }

        public static class Events
        {
            public const string Tilt = "tilt";
            public const string Fall = "fall";
            public const string Vibration = "vibration";
            public const string Opened = "opened";
            public const string Closed = "closed";
            public const string Click = "click";
            public const string DoubleClick = "double_click";
            public const string LongPress = "long_press";
            public const string Detected = "detected";
            public const string NotDetected = "not_detected";
            public const string High = "high";
            public const string Low = "low";
            public const string Normal = "normal";
            public const string Dry = "dry";
            public const string Leak = "leak";
        }

        public static class ActionResult
        {
            public const string Done = "DONE";
            public const string Error = "ERROR";
        }

        public static class Status
        {
            public const string Ok = "ok";
            public const string Error = "error";
        }

        public static class ErrorCodes
        {
            public const string DoorOpen = "DOOR_OPEN";
            public const string LidOpen = "LID_OPEN";
            public const string RemoteControlDisabled = "REMOTE_CONTROL_DISABLED";
            public const string NotEnoughWater = "NOT_ENOUGH_WATER";
            public const string LowChargeLevel = "LOW_CHARGE_LEVEL";
            public const string ContainerFull = "CONTAINER_FULL";
            public const string ContainerEmpty = "CONTAINER_EMPTY";
            public const string DripTrayFull = "DRIP_TRAY_FULL";
            public const string DeviceStuck = "DEVICE_STUCK";
            public const string DeviceOff = "DEVICE_OFF";
            public const string FirmwareOutOfDate = "FIRMWARE_OUT_OF_DATE";
            public const string NotEnoughDetergent = "NOT_ENOUGH_DETERGENT";
            public const string HumanInvolvementNeeded = "HUMAN_INVOLVEMENT_NEEDED";
            public const string DeviceUnreachable = "DEVICE_UNREACHABLE";
            public const string DeviceBusy = "DEVICE_BUSY";
            public const string InternalError = "INTERNAL_ERROR";
            public const string InvalidAction = "INVALID_ACTION";
            public const string InvalidValue = "INVALID_VALUE";
            public const string NotSupportedInCurrentMode = "NOT_SUPPORTED_IN_CURRENT_MODE";
            public const string AccountLinkingError = "ACCOUNT_LINKING_ERROR";
        }

        public static class GroupState
        {
            public const string Online = "online";
            public const string Offline = "offline";
            public const string Split = "split";
        }
    }
}

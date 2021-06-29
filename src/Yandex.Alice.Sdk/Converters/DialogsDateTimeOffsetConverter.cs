namespace Yandex.Alice.Sdk.Converters
{
    public class DialogsDateTimeOffsetConverter : DateTimeOffsetConverter
    {
        public DialogsDateTimeOffsetConverter()
            : base(AliceConstants.DateTimeFormat)
        {
        }
    }
}

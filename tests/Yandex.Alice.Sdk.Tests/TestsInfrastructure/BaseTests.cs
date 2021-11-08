namespace Yandex.Alice.Sdk.Tests.TestsInfrastructure
{
    using System.Text.Encodings.Web;
    using System.Text.Json;
    using System.Text.Unicode;
    using Xunit.Abstractions;

    public abstract class BaseTests
    {
        public ITestOutputHelper TestOutputHelper { get; }

        protected BaseTests(ITestOutputHelper testOutputHelper)
        {
            TestOutputHelper = testOutputHelper;
        }

        protected void WritePrettyJson<T>(T value)
        {
            var options = new JsonSerializerOptions()
            {
                WriteIndented = true,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
            };
            string json = JsonSerializer.Serialize(value, options);
            TestOutputHelper.WriteLine(json);
        }
    }
}

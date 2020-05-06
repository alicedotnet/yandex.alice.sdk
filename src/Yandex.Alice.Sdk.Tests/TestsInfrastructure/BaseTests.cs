using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Xunit.Abstractions;

namespace Yandex.Alice.Sdk.Tests.TestsInfrastructure
{
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
                WriteIndented = true
            };
            string json = JsonSerializer.Serialize(value, options);
            TestOutputHelper.WriteLine(json);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Yandex.Alice.Sdk.Helpers;

namespace Yandex.Alice.Sdk.Tests.Helpers
{
    public class AliceHelperTests
    {
        [Fact]
        public void Get()
        {
            string tts1024Symbols = "XH9vWSTYNdADOjPYVKoKcjZS0PaTYqXpkHqFUry3fY0q2bm1FzvyPhW6IC8ca11Cpdv0H57XhLI5qsGcHWyBOEi93P325MYNIGHYliYYa4zDc1qCX1eouDAvkDBpxgH6SHhSJzGfJuQ1K60lYTTqmQtchBeDYf0dcCxP6DbCXvPXKrXICGCUliXivtUfYlGUXxW6sdodFUElMhKGfdU9ypMbkyoZ3fXFj26LgMUAFXA7CMNffVSs6d45GOgnDFX5o2BiCvmA65p3tMjKiU0rV068kJOR9567ckQzBz5zNm6HWnz2pvgE9WW3VouEmVEiWY4VVlHLokRCcE2SV63KTttwg3vPJMS9AHfgyaoC7SLQuKFbkx0PQD6P9HKaPXVc8VKMKWLHgqYER24vfk858M3bDmaUNMb4V1aPMX0DQbhtsE2km508KeI0GX21Ha1Z0eCAOXMZrRySAccPNUmm4QGP3ObmuMSYXxHXGDlWUqywuaw67XIYEdZN81UkPlfCG09Oa0a08I6Uu77ajAqzONEk8gQYeqpVPLcxqdbwjXEpiK7xjksOUPYhSZgaHQUbZ05NCGUYJUTimA4TVJOTfz9H5xB6TYxCFn1pjr5R98oXhtwtiRM7KzrHppOAC1dPUotms24i5YlMTmuzMabls4V9FFR58hMTWfmdaqroirExgYwoDZ2r8rNpVR47ITLPdhkhhfjO2hjps0J2Xbj6IyFBBvkAAKSoSkSbfvCcgzkpJ9eHvzCsSCHjE86Vmeh3eXzm20TOwr0bMJ9Dwczxoap01MJevOkWQ4OmQXcCnHVjUAP6BsgHmN2yZLVCqg9FUn9fJIGfN9jVJBdz1qivBpqKsS2Yv2mN4p7GVkkwcgMDnGVxislnR3vCwhf0YNkQ24kAJOvhGVAHhcMKBCF8LmOlvWN04pDvSiZwWUrS4cnHxwJrm6qtkvFxyw4N1zd74wmXH1VuIf6YEPMoo5mo2WmaQdCOZwPqmfXIHLyLFl1LRjOGthwS0wqXO0aoFhHr";
            string tts = tts1024Symbols;
            tts += AliceHelper.GetSpeakerTag("test");
            string shortTts = AliceHelper.GetTtsStringWithoutTags(tts);
            Assert.Equal(tts1024Symbols, shortTts);
        }
    }
}
